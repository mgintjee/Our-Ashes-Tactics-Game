using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.CallSigns;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Maps.Coordinates.Cube.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Mvcs.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Sorties.Maps.Paths.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Paths.Implementaions.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Paths.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Paths.Implementaions.Moves
{
    /// <summary>
    /// Todo
    /// </summary>
    public class SortieMapMovePath : AbstractSortieMapPath
    {
        // Provides logging capability to the SORTIE logs
        private readonly ILogger _logger = LoggerManager.GetLogger(MvcType.Sortie, new StackFrame().GetMethod().DeclaringType);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinatesList"></param>
        /// <param name="mapReport">          </param>
        public SortieMapMovePath(IList<ICubeCoordinates> cubeCoordinatesList, ISortieMapReport mapReport)
            : base(cubeCoordinatesList, mapReport)
        {
            _pathType = PathType.Move;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="pathObject"></param>
        /// <param name="mapReport"> </param>
        public SortieMapMovePath(ISortieMapPath pathObject, ISortieMapReport mapReport)
            : base(pathObject, mapReport)
        {
            _pathType = PathType.Move;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinatesStart"></param>
        /// <param name="cubeCoordinatesEnd">  </param>
        /// <param name="pathLength">          </param>
        /// <param name="mapReport">           </param>
        public SortieMapMovePath(ICubeCoordinates cubeCoordinatesStart, ICubeCoordinates cubeCoordinatesEnd, int pathLength, ISortieMapReport mapReport)
            : base(cubeCoordinatesStart, cubeCoordinatesEnd, pathLength, mapReport)
        {
            _pathType = PathType.Move;
        }

        /// <inheritdoc/>
        protected override float GetCubeCoordinatesCost(ICubeCoordinates cubeCoordinates)
        {
            float moveCost = float.MaxValue;
            _mapReport.GetTileReport(cubeCoordinates).IfPresent(tileReport =>
            {
                if (tileReport.GetCombatantCallSign() == CombatantCallSign.None)
                {
                    moveCost = tileReport.GetTileStats().GetTileAttributes().GetMoveCost();
                }
            });
            return moveCost;
        }
    }
}