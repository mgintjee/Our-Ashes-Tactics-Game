using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.CallSigns;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Mvcs.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Maps.Coordinates.Cube.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Paths.Implementaions.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Paths.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Paths.Types.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Reports.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Paths.Implementaions.Moves
{
    /// <summary>
    /// Todo
    /// </summary>
    public class MovePath
        : AbstractPath
    {
        // Provides logging capability to the SORTIE logs
        private readonly ILogger _logger = LoggerManager.GetLogger(MvcType.Sortie, new StackFrame().GetMethod().DeclaringType);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinatesList"></param>
        /// <param name="mapReport">          </param>
        public MovePath(IList<ICubeCoordinates> cubeCoordinatesList, IMapReport mapReport)
            : base(cubeCoordinatesList, mapReport)
        {
            _pathType = PathType.Move;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="pathObject"></param>
        /// <param name="mapReport"> </param>
        public MovePath(IPath pathObject, IMapReport mapReport)
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
        public MovePath(ICubeCoordinates cubeCoordinatesStart, ICubeCoordinates cubeCoordinatesEnd, int pathLength, IMapReport mapReport)
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