using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Constants.Sorties.Tiles.Models.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Paths.Implementaions.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Maps.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Paths.Implementaions.Fires
{
    /// <summary>
    /// Todo
    /// </summary>
    public class SortieMapFirePath : AbstractSortieMapPath
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinatesStepList"></param>
        public SortieMapFirePath(IList<ICubeCoordinates> cubeCoordinatesStepList, ISortieMapReport mapReport) : base(cubeCoordinatesStepList, mapReport)
        {
            _pathType = PathType.Fire;
        }

        /// <inheritdoc/>
        protected override float GetCubeCoordinatesCost(ICubeCoordinates cubeCoordinates)
        {
            float fireCost = float.MaxValue;
            _mapReport.GetTileReport(cubeCoordinates).IfPresent(tileReport =>
            {
                SortieTileModelConstantsManager.GetConstants(tileReport.GetSortieTileID()).IfPresent(tileConstants =>
                {
                    fireCost = tileConstants.GetSortieTileAttributes().GetFireCost();
                });
                if (tileReport.GetCombatantCallSign() != CombatantCallSign.None)
                {
                    fireCost += 10f;
                }
            });
            return fireCost;
        }
    }
}