using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Frames.Sorties.Maps.Paths.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Frames.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Classes.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.CallSigns;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Maps.Coordinates.Cube.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Constants.Sorties.Tiles.Models.Managers;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Paths.Implementaions.Abstracts;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Paths.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Maps.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Paths.Implementaions.Moves
{
    /// <summary>
    /// Todo
    /// </summary>
    public class SortieMapMovePath : AbstractSortieMapPath
    {
        // Provides logging capability to the SORTIE logs
        private readonly IClassLogger _logger = LoggerManager.GetLogger(MvcType.Sortie)
            .GetClassLogger(new StackFrame().GetMethod().DeclaringType);

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
                    SortieTileModelConstantsManager.GetConstants(tileReport.GetSortieTileID()).IfPresent(tileConstants =>
                    {
                        moveCost = tileConstants.GetSortieTileAttributes().GetMoveCost();
                    });
                }
            });
            return moveCost;
        }
    }
}