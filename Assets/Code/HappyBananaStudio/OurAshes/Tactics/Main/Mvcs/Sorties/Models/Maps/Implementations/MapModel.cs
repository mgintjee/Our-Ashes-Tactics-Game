using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.CallSigns.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Maps.Spawns.Areas.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Maps.Spawns.Sides.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Mvcs.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Fireables.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Maps.Coordinates.Cube.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Maps.Coordinates.Cube.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Combatants.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Constructions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Paths.Implementaions.Fires;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Paths.Implementaions.Moves;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Paths.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Reports.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Spawns.Positions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Types.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Rosters.Reports.Interfaces;
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
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Maps.Implementations
{
    /// <summary>
    /// Todo
    /// </summary>
    public class MapModel
        : IMapModel
    {
        // Provides logging capability to the SORTIE logs
        private readonly ILogger _logger = LoggerManager.GetLogger(MvcType.Sortie, new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly bool _mirroredMap;

        // Todo
        private readonly int _radius;

        // Todo
        private readonly ISet<ITileModel> _models;

        // Todo
        private readonly ISet<ITileReport> _tileReports = new HashSet<ITileReport>();

        // Todo
        private IMapReport _report;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mapConstruction"></param>
        public MapModel(IMapConstruction mapConstruction)
        {
            _radius = mapConstruction.GetRadius();
            _mirroredMap = mapConstruction.GetMirroredMap();
            _models = new HashSet<ITileModel>();
            foreach (KeyValuePair<ICubeCoordinates, TileType> cubeCoordinatesTileType in
                TileTypeUtil.GetCubeCoordinatesTileTypes(this.GetCubeCoordinates(_radius), _mirroredMap))
            {
                _models.Add(new TileModel.Builder()
                    .SetCubeCoordinates(cubeCoordinatesTileType.Key)
                    .SetTileType(cubeCoordinatesTileType.Value)
                    .Build());
            }

            foreach (KeyValuePair<CombatantCallSign, ISpawnPosition> callSignSpawnPosition in
                mapConstruction.GetCombatantCallSignSpawnPosition())
            {
                _logger.Info("Setting {} @ {}", callSignSpawnPosition.Key, callSignSpawnPosition.Value);
                this.GetTileModel(callSignSpawnPosition.Value)
                    .IfPresent(tileModel => tileModel.SetCombatantCallSign(callSignSpawnPosition.Key));
            }
            this.BuildReport();
        }

        /// <inheritdoc/>
        IMapReport IMapModel.GetReport()
        {
            return _report;
        }

        /// <inheritdoc/>
        ISet<IPath> IMapModel.GetPaths(ICombatantReport combatantReport)
        {
            _logger.Info("GetPaths for {}. {}", combatantReport, _report);
            ISet<IPath> paths = new HashSet<IPath>();
            ISet<IPathFinder> pathFinders = new HashSet<IPathFinder>();
            this.GetTileModel(combatantReport.GetCombatantCallSign()).IfPresent((tileModel) =>
            {
                float maxAccuracy = float.MinValue;
                float maxRange = float.MinValue;
                IFireableAttributes combatantFireableAttributes = combatantReport
                    .GetCurrentAttributes().GetFireableAttributes();
                foreach (IGearReport weaponGearReport in combatantReport.GetLoadoutReport().GetGearReports())
                {
                    IFireableAttributes weaponFireableAttributes = weaponGearReport
                        .GetCombatantAttributes().GetFireableAttributes();
                    float currentAccuracy = combatantFireableAttributes.GetAccuracy() +
                        weaponFireableAttributes.GetAccuracy();
                    if (currentAccuracy > maxAccuracy)
                    {
                        maxAccuracy = currentAccuracy;
                    }
                    float currentRange = combatantFireableAttributes.GetRange() +
                        weaponFireableAttributes.GetRange();
                    if (currentRange > maxRange)
                    {
                        maxRange = currentRange;
                    }
                }
                float maxMovement = combatantReport.GetMaximumAttributes().GetMovableAttributes().GetMovement();
                ICubeCoordinates cubeCoordinates = tileModel.GetReport().GetCubeCoordinates();
                pathFinders.Add(new MovePathFinder.Builder()
                    .SetMapReport(_report)
                    .SetCubeCoordinates(cubeCoordinates)
                    .SetMovements(maxMovement)
                    .Build());
                pathFinders.Add(new FirePathFinder.Builder()
                    .SetMapReport(_report)
                    .SetCubeCoordinates(cubeCoordinates)
                    .SetAPs(maxAccuracy)
                    .SetRPs(maxRange)
                    .Build());
                pathFinders.Add(new WaitPathFinder.Builder()
                    .SetMapReport(_report)
                    .SetCubeCoordinates(cubeCoordinates)
                    .Build());
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
            if (controllerRequest != null)
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
                            if (!rosterReport.GetActiveCombatantCallSigns().Contains(
                                tileModel.GetReport().GetCombatantCallSign()))
                            {
                                tileModel.SetCombatantCallSign(CombatantCallSign.None);
                            }
                        });
                    }
                }
            }
            this.BuildReport();
        }

        /// <summary>
        /// Todo
        /// </summary>
        private void BuildReport()
        {
            _tileReports.Clear();
            foreach (ITileModel model in _models)
            {
                _tileReports.Add(model.GetReport());
            }
            _report = new MapReport.Builder()
                .SetIsMirrored(_mirroredMap)
                .SetRadius(_radius)
                .SetTileReports(_tileReports)
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="radius"></param>
        /// <returns></returns>
        private ISet<ICubeCoordinates> GetCubeCoordinates(int radius)
        {
            ISet<ICubeCoordinates> cubeCoordinates = new HashSet<ICubeCoordinates>();

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
                if (tileReport.GetCubeCoordinates().Equals(cubeCoordinates))
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

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="spawnPosition"></param>
        /// <returns></returns>
        private Optional<ITileModel> GetTileModel(ISpawnPosition spawnPosition)
        {
            return GetTileModel(DetermineCubeCoordinates(spawnPosition));
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="spawnPosition"></param>
        /// <returns></returns>
        private ICubeCoordinates DetermineCubeCoordinates(ISpawnPosition spawnPosition)
        {
            int initialX = 0;
            int initialY = 0;
            int initialZ = 0;
            switch (spawnPosition.GetSpawnArea())
            {
                case SpawnArea.CenterNorth:
                    initialX = +1;
                    initialY = -1;
                    initialZ = 0;
                    break;

                case SpawnArea.CenterNorthEast:
                    initialX = 0;
                    initialY = -1;
                    initialZ = +1;
                    break;

                case SpawnArea.CenterSouthEast:
                    initialX = -1;
                    initialY = 0;
                    initialZ = +1;
                    break;

                case SpawnArea.CenterSouth:
                    initialX = -1;
                    initialY = +1;
                    initialZ = 0;
                    break;

                case SpawnArea.CenterSouthWest:
                    initialX = 0;
                    initialY = +1;
                    initialZ = -1;
                    break;

                case SpawnArea.CenterNorthWest:
                    initialX = +1;
                    initialY = 0;
                    initialZ = -1;
                    break;

                case SpawnArea.CornerNorth:
                    initialX = (_radius - 1) + 1;
                    initialY = (_radius - 1) - 1;
                    initialZ = 0;
                    break;

                case SpawnArea.CornerNorthEast:
                    initialX = 0;
                    initialY = (_radius - 1) - 1;
                    initialZ = (_radius - 1) + 1;
                    break;

                case SpawnArea.CornerSouthEast:
                    initialX = (_radius - 1) - 1;
                    initialY = 0;
                    initialZ = (_radius - 1) + 1;
                    break;

                case SpawnArea.CornerSouth:
                    initialX = (_radius - 1) - 1;
                    initialY = (_radius - 1) + 1;
                    initialZ = 0;
                    break;

                case SpawnArea.CornerSouthWest:
                    initialX = 0;
                    initialY = (_radius - 1) + 1;
                    initialZ = (_radius - 1) - 1;
                    break;

                case SpawnArea.CornerNorthWest:
                    initialX = (_radius - 1) + 1;
                    initialY = 0;
                    initialZ = (_radius - 1) - 1;
                    break;

                default:
                    // Throw an error that the SpawnArea is not supported
                    break;
            }
            return DetermineCubeCoordinates(initialX, initialY, initialZ, spawnPosition);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="initialX">     </param>
        /// <param name="initialY">     </param>
        /// <param name="initialZ">     </param>
        /// <param name="spawnPosition"></param>
        /// <returns></returns>
        private ICubeCoordinates DetermineCubeCoordinates(int initialX, int initialY,
            int initialZ, ISpawnPosition spawnPosition)
        {
            int x = initialX;
            int y = initialY;
            int z = initialZ;
            switch (spawnPosition.GetSpawnSide())
            {
                case SpawnSide.Lead:
                    // Do nothing since the initial spot is perfect as is
                    break;

                case SpawnSide.Right:
                    switch (spawnPosition.GetSpawnArea())
                    {
                        case SpawnArea.CenterNorth:
                        case SpawnArea.CornerNorth:
                            x++; z--;
                            break;

                        case SpawnArea.CenterNorthEast:
                        case SpawnArea.CornerNorthEast:
                            x++; y--;
                            break;

                        case SpawnArea.CenterSouthEast:
                        case SpawnArea.CornerSouthEast:
                            z++; y--;
                            break;

                        case SpawnArea.CenterSouth:
                        case SpawnArea.CornerSouth:
                            z++; y--;
                            break;

                        case SpawnArea.CenterSouthWest:
                        case SpawnArea.CornerSouthWest:
                            z++; x--;
                            break;

                        case SpawnArea.CenterNorthWest:
                        case SpawnArea.CornerNorthWest:
                            y++; x--;
                            break;
                    }
                    break;

                case SpawnSide.Rear:
                    switch (spawnPosition.GetSpawnArea())
                    {
                        case SpawnArea.CenterNorth:
                        case SpawnArea.CornerNorth:
                            x++; y--;
                            break;

                        case SpawnArea.CenterNorthEast:
                        case SpawnArea.CornerNorthEast:
                            z++; y--;
                            break;

                        case SpawnArea.CenterSouthEast:
                        case SpawnArea.CornerSouthEast:
                            z++; x--;
                            break;

                        case SpawnArea.CenterSouth:
                        case SpawnArea.CornerSouth:
                            y++; x--;
                            break;

                        case SpawnArea.CenterSouthWest:
                        case SpawnArea.CornerSouthWest:
                            y++; z--;
                            break;

                        case SpawnArea.CenterNorthWest:
                        case SpawnArea.CornerNorthWest:
                            x++; z--;
                            break;
                    }
                    break;

                case SpawnSide.Left:
                    switch (spawnPosition.GetSpawnArea())
                    {
                        case SpawnArea.CenterNorth:
                        case SpawnArea.CornerNorth:
                            z++; y--;
                            break;

                        case SpawnArea.CenterNorthEast:
                        case SpawnArea.CornerNorthEast:
                            z++; x--;
                            break;

                        case SpawnArea.CenterSouthEast:
                        case SpawnArea.CornerSouthEast:
                            y++; x--;
                            break;

                        case SpawnArea.CenterSouth:
                        case SpawnArea.CornerSouth:
                            y++; z--;
                            break;

                        case SpawnArea.CenterSouthWest:
                        case SpawnArea.CornerSouthWest:
                            x++; z--;
                            break;

                        case SpawnArea.CenterNorthWest:
                        case SpawnArea.CornerNorthWest:
                            x++; y--;
                            break;
                    }
                    break;

                default:
                    // Throw an error that the SpawnSide is not supported
                    break;
            }
            return new CubeCoordinates(x, y, z);
        }
    }
}