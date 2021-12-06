using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Frames.Sorties.Maps.Spawns.Areas;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Frames.Sorties.Maps.Spawns.Sides;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Frames.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Classes.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Fireables.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.CallSigns;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Maps.Coordinates.Cube.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Maps.Coordinates.Cube.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Paths.Implementaions.Fires;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Paths.Implementaions.Moves;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Paths.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Spawns.Positions.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constrs.Models.Maps.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constrs.Models.Maps.Tiles.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Frames.Requests.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Maps.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Maps.PathFinders.Implementaions.Fires;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Maps.PathFinders.Implementaions.Moves;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Maps.PathFinders.Implementaions.Waits;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Maps.PathFinders.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Maps.Tiles.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Maps.Tiles.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Combatants.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Gears.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Maps.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Maps.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Rosters.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Tiles.Inters;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Maps.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public class MapModel : IMapModel
    {
        // Provides logging capability
        private readonly IClassLogger _logger = LoggerManager.GetLogger(MvcType.Sortie)
            .GetClassLogger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly bool _mirroredMap;

        // Todo
        private readonly int _radius;

        // Todo
        private readonly ISet<ISortieTileModel> _models;

        // Todo
        private readonly ISet<ISortieTileReport> _sortieTileReports = new HashSet<ISortieTileReport>();

        // Todo
        private ISortieMapReport _mapReport;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="sortieMapModelConstruction"></param>
        public MapModel(ISortieMapModelConstruction sortieMapModelConstruction)
        {
            _models = new HashSet<ISortieTileModel>();

            foreach (ISortieTileModelConstruction sortieTileModelConstruction in
                sortieMapModelConstruction.GetSortieTileModelConstrs())
            {
                _models.Add(new SortieTileModel(sortieTileModelConstruction));
            }

            this.BuildReport();
        }

        /// <inheritdoc/>
        ISortieMapReport IMapModel.GetReport()
        {
            return _mapReport;
        }

        /// <inheritdoc/>
        ISet<ISortieMapPath> IMapModel.GetPaths(ICombatantReport combatantReport)
        {
            _logger.Info("GetPaths for {}. {}", combatantReport, _mapReport);
            ISet<ISortieMapPath> paths = new HashSet<ISortieMapPath>();
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
                    .SetMapReport(_mapReport)
                    .SetCubeCoordinates(cubeCoordinates)
                    .SetMovements(maxMovement)
                    .Build());
                pathFinders.Add(new FirePathFinder.Builder()
                    .SetMapReport(_mapReport)
                    .SetCubeCoordinates(cubeCoordinates)
                    .SetAPs(maxAccuracy)
                    .SetRPs(maxRange)
                    .Build());
                pathFinders.Add(new WaitPathFinder.Builder()
                    .SetMapReport(_mapReport)
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
        void IMapModel.Process(ISortieRequest controllerRequest, IRosterModelReport rosterReport)
        {
            if (controllerRequest != null)
            {
                ISortieMapPath path = controllerRequest.GetPath();
                if (path is SortieMapMovePath)
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
                else if (path is SortieMapFirePath firePath)
                {
                    foreach (CombatantCallSign callSign in rosterReport.GetAllCombatantCallSigns())
                    {
                        Optional<ISortieTileModel> tileModel = this.GetTileModel(callSign);
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
            _sortieTileReports.Clear();
            foreach (ISortieTileModel model in _models)
            {
                _sortieTileReports.Add(model.GetReport());
            }
            _mapReport = new SortieMapReport.Builder()
                .SetIsMirrored(_mirroredMap)
                .SetRadius(_radius)
                .SetTileReports(_sortieTileReports)
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
                        { CubeCoordinates.Builder.Get().Build() };
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
                        coordinates.GetDistanceFrom(CubeCoordinates.Builder.Get().Build()) <= radius)
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
        private Optional<ISortieTileModel> GetTileModel(ICubeCoordinates cubeCoordinates)
        {
            foreach (ISortieTileModel tileModel in _models)
            {
                ISortieTileReport tileReport = tileModel.GetReport();
                if (tileReport.GetCubeCoordinates().Equals(cubeCoordinates))
                {
                    return Optional<ISortieTileModel>.Of(tileModel);
                }
            }
            return Optional<ISortieTileModel>.Empty();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="callSign"></param>
        /// <returns></returns>
        private Optional<ISortieTileModel> GetTileModel(CombatantCallSign callSign)
        {
            foreach (ISortieTileModel tileModel in _models)
            {
                ISortieTileReport tileReport = tileModel.GetReport();
                if (tileReport.GetCombatantCallSign() == callSign)
                {
                    return Optional<ISortieTileModel>.Of(tileModel);
                }
            }
            return Optional<ISortieTileModel>.Empty();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="spawnPosition"></param>
        /// <returns></returns>
        private Optional<ISortieTileModel> GetTileModel(ISpawnPosition spawnPosition)
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
            return CubeCoordinates.Builder.Get().SetX(x).SetY(y).SetZ(z).Build();
        }
    }
}