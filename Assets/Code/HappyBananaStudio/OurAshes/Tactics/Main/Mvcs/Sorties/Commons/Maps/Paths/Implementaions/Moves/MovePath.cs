using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.CallSigns.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Maps.Coordinates.Cube.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Paths.Implementaions.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Paths.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Paths.Types.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Reports.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Paths.Implementaions.Moves
{
    /// <summary>
    /// Todo
    /// </summary>
    public class MovePath
        : AbstractPath
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinatesList"></param>
        /// <param name="mapReport">          </param>
        public MovePath(IList<ICubeCoordinates> cubeCoordinatesList, IMapReport mapReport)
            : base(cubeCoordinatesList, mapReport)
        {
            this.PathType = PathType.Move;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="pathObject"></param>
        /// <param name="mapReport"> </param>
        public MovePath(IPath pathObject, IMapReport mapReport)
            : base(pathObject, mapReport)
        {
            this.PathType = PathType.Move;
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
            this.PathType = PathType.Move;
        }

        /// <inheritdoc/>
        protected override float GetCubeCoordinatesCost(ICubeCoordinates cubeCoordinates)
        {
            float moveCost = float.MaxValue;
            this.MapReport.GetTileReport(cubeCoordinates).IfPresent((tileReport) =>
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