using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.CallSigns;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Maps.Coordinates.Cube.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Sorties.Maps.Paths.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Paths.Implementaions.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Reports.Interfaces;
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
            _mapReport.GetTileReport(cubeCoordinates).IfPresent((tileReport) =>
            {
                fireCost = tileReport.GetTileStats().GetTileAttributes().GetFireCost();
                if (tileReport.GetCombatantCallSign() != CombatantCallSign.None)
                {
                    fireCost += 10f;
                }
            });
            return fireCost;
        }
    }
}