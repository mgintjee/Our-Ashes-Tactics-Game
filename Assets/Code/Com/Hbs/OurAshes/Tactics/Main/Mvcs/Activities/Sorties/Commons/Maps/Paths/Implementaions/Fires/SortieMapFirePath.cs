using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Frames.Sorties.Maps.Paths.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.CallSigns;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Maps.Coordinates.Cube.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Constants.Sorties.Tiles.Models.Managers;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Commons.Maps.Paths.Implementaions.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Reports.Models.Maps.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Commons.Maps.Paths.Implementaions.Fires
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
        public SortieMapFirePath(IList<ICubeCoordinates> cubeCoordinatesStepList, ISortieMapReport mapReport)
            : base(cubeCoordinatesStepList, mapReport)
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