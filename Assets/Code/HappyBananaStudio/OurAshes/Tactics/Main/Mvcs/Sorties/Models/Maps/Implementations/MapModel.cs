using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.CallSigns.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Fireables.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Maps.Coordinates.Cube.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Maps.Coordinates.Cube.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Combatants.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Constructions.Maps.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Loadouts.Reports.Gears.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Paths.Implementaions.Fires;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Paths.Implementaions.Moves;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Paths.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Reports.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Types.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Types.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Models.Rosters.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Controllers.Requests.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Maps.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Maps.PathFinders.Implementaions.Fires;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Maps.PathFinders.Implementaions.Moves;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Maps.PathFinders.Implementaions.Waits;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Maps.PathFinders.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Maps.Tiles.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Maps.Tiles.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Maps.Tiles.Tiles.Types.Utils;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Maps.Implementations
{
    /// <summary>
    /// Todo
    /// </summary>
    public class MapModel
        : IMapModel
    {
        // Todo
        private readonly MapType _mapType;

        // Todo
        private readonly bool _mirroredMap;

        // Todo
        private readonly int _radius;

        // Todo
        private readonly ISet<ITileModel> _models;

        // Todo
        private IMapReport _report;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mapConstruction"></param>
        public MapModel(IMapConstruction mapConstruction)
        {
            _mapType = mapConstruction.GetMapType();
            _radius = mapConstruction.GetRadius();
            _mirroredMap = mapConstruction.GetMirroredMap();
            _models = new HashSet<ITileModel>();
            foreach (KeyValuePair<ICubeCoordinates, TileType> cubeCoordinatesTileType in
                TileTypeUtil.GetCubeCoordinatesTileTypes(this.GetCubeCoordinates(_mapType, _radius), _mirroredMap))
            {
                _models.Add(new TileModel.Builder()
                    .SetCubeCoordinates(cubeCoordinatesTileType.Key)
                    .SetTileType(cubeCoordinatesTileType.Value)
                    .Build());
            }

            foreach (KeyValuePair<CombatantCallSign, ICubeCoordinates> combatantCallSignCubeCoordinates in
                mapConstruction.GetCombatantCallSignCubeCoordinates())
            {
                this.GetTileModel(combatantCallSignCubeCoordinates.Value)
                    .IfPresent(tileModel => tileModel.SetCombatantCallSign(combatantCallSignCubeCoordinates.Key));
            }
        }

        /// <inheritdoc/>
        IMapReport IMapModel.GetReport()
        {
            return _report;
        }

        /// <inheritdoc/>
        ISet<IPath> IMapModel.GetPaths(ICombatantReport combatantReport)
        {
            ISet<IPath> paths = new HashSet<IPath>();
            ISet<IPathFinder> pathFinders = new HashSet<IPathFinder>();
            this.GetTileModel(combatantReport.GetCombatantCallSign()).IfPresent((tileModel) =>
            {
                float maxAPs = float.MinValue;
                float maxRPs = float.MinValue;
                IFireableAttributes combatantFireableAttributes = combatantReport
                    .GetCurrentAttributes().GetFireableAttributes();
                foreach (IGearReport weaponGearReport in combatantReport.GetLoadoutReport().GetGearReports())
                {
                    IFireableAttributes weaponFireableAttributes = weaponGearReport
                        .GetCombatantAttributes().GetFireableAttributes();
                    float currentAPs = combatantFireableAttributes.GetAccuracy() +
                        weaponFireableAttributes.GetAccuracy();
                    if (currentAPs > maxAPs)
                    {
                        maxAPs = currentAPs;
                    }
                    float currentRPs = combatantFireableAttributes.GetRange() +
                        weaponFireableAttributes.GetRange();
                    if (currentRPs > maxRPs)
                    {
                        maxRPs = currentRPs;
                    }
                    ICubeCoordinates cubeCoordinates = tileModel.GetReport().GetCubeCoordinates();
                    pathFinders.Add(new MovePathFinder.Builder()
                        .SetMapReport(_report)
                        .SetCubeCoordinates(cubeCoordinates)
                        .SetMPs(combatantReport.GetCurrentAttributes().GetMovableAttributes().GetMovement())
                        .Build());
                    pathFinders.Add(new FirePathFinder.Builder()
                        .SetMapReport(_report)
                        .SetCubeCoordinates(cubeCoordinates)
                        .SetAPs(maxAPs)
                        .SetRPs(maxRPs)
                        .Build());
                    pathFinders.Add(new WaitPathFinder.Builder()
                        .SetMapReport(_report)
                        .SetCubeCoordinates(cubeCoordinates)
                        .Build());
                }
            });

            foreach (IPathFinder pathFinder in pathFinders)
            {
                paths.UnionWith(pathFinder.GetPaths());
            }

            return paths;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="controllerRequest"></param>
        /// <param name="rosterReport">     </param>
        void IMapModel.Process(ISortieControllerRequest controllerRequest, IRosterReport rosterReport)
        {
            IPath path = controllerRequest.GetPath();
            if (path is MovePath)
            {
                ICubeCoordinates start = path.GetStart();
                ICubeCoordinates end = path.GetEnd();
                this.GetTileModel(start).IfPresent((tileModel) =>
                {
                    tileModel.SetCombatantCallSign(CombatantCallSign.None);
                });
                this.GetTileModel(end).IfPresent((tileModel) =>
                {
                    tileModel.SetCombatantCallSign(controllerRequest.GetCallSign());
                });
            }
            else if (path is FirePath firePath)
            {
                foreach (CombatantCallSign callSign in rosterReport.GetAllCombatantCallSigns())
                {
                    Optional<ITileModel> tileModel = this.GetTileModel(callSign);
                    tileModel.IfPresent((tileModel) =>
                    {
                        if (rosterReport.GetActiveCombatantCallSigns().Contains(
                            tileModel.GetReport().GetCombatantCallSign()))
                        {
                            tileModel.SetCombatantCallSign(CombatantCallSign.None);
                        }
                    });
                }
            }
            ISet<ITileReport> tileReports = new HashSet<ITileReport>();
            foreach (ITileModel model in _models)
            {
                tileReports.Add(model.GetReport());
            }
            _report = new MapReport.Builder()
                .SetIsMirrored(_mirroredMap)
                .SetMapType(_mapType)
                .SetRadius(_radius)
                .SetTileReports(tileReports)
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mapType"></param>
        /// <param name="radius"> </param>
        /// <returns></returns>
        private ISet<ICubeCoordinates> GetCubeCoordinates(MapType mapType, int radius)
        {
            ISet<ICubeCoordinates> cubeCoordinates = new HashSet<ICubeCoordinates>();

            switch (mapType)
            {
                case MapType.Hex:
                    ISet<ICubeCoordinates> visitedCubeCoordinatesSet = new HashSet<ICubeCoordinates>();
                    ISet<ICubeCoordinates> unvisitedCubeCoordinatesSet = new HashSet<ICubeCoordinates>
                        { new CubeCoordinates(0, 0, 0) };
                    // Iterate over all of the unvisisted CubeCoordinates
                    while (unvisitedCubeCoordinatesSet.Count > 0)
                    {
                        ICubeCoordinates currentCubeCoordinates = new List<ICubeCoordinates>(unvisitedCubeCoordinatesSet)[0];
                        unvisitedCubeCoordinatesSet.Remove(currentCubeCoordinates);
                        cubeCoordinates.Add(currentCubeCoordinates);
                        if (!visitedCubeCoordinatesSet.Contains(currentCubeCoordinates))
                        {
                            visitedCubeCoordinatesSet.Add(currentCubeCoordinates);
                        }
                        foreach (ICubeCoordinates coordinates in currentCubeCoordinates.GetNeighbors())
                        {
                            if (!visitedCubeCoordinatesSet.Contains(coordinates) &&
                                coordinates.GetDistanceFrom(new CubeCoordinates(0, 0, 0)) <= radius)
                            {
                                unvisitedCubeCoordinatesSet.Add(coordinates);
                            }
                        }
                    }
                    break;
            }

            return cubeCoordinates;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates"></param>
        /// <returns></returns>
        private Optional<ITileModel> GetTileModel(ICubeCoordinates cubeCoordinates)
        {
            foreach (ITileModel tileModel in _models)
            {
                ITileReport tileReport = tileModel.GetReport();
                if (tileReport.GetCubeCoordinates() == cubeCoordinates)
                {
                    return Optional<ITileModel>.Of(tileModel);
                }
            }
            return Optional<ITileModel>.Empty();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="callSign"></param>
        /// <returns></returns>
        private Optional<ITileModel> GetTileModel(CombatantCallSign callSign)
        {
            foreach (ITileModel tileModel in _models)
            {
                ITileReport tileReport = tileModel.GetReport();
                if (tileReport.GetCombatantCallSign() == callSign)
                {
                    return Optional<ITileModel>.Of(tileModel);
                }
            }
            return Optional<ITileModel>.Empty();
        }
    }
}