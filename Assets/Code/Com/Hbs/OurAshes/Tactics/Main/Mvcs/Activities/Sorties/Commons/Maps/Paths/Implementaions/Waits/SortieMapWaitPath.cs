using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Frames.Sorties.Maps.Paths.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Maps.Coordinates.Cube.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Commons.Maps.Paths.Implementaions.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Reports.Models.Maps.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Commons.Maps.Paths.Implementaions.Waits
{
    /// <summary>
    /// Todo
    /// </summary>
    public class SortieMapWaitPath : AbstractSortieMapPath
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates"></param>
        public SortieMapWaitPath(IList<ICubeCoordinates> cubeCoordinates, ISortieMapReport mapReport) : base(cubeCoordinates, mapReport)
        {
            if (cubeCoordinates.Count != 1)
            {
                throw ExceptionUtil.Arguments.Build("Unable to construct {}. Invalid Parameters. " +
                    "List: {} should be of length 1. " +
                    "Parameterized List: {} is length={}.",
                   this.GetType(), typeof(ICubeCoordinates), typeof(ICubeCoordinates), cubeCoordinates.Count);
            }
            _pathType = PathType.Wait;
        }

        /// <inheritdoc/>
        protected override float GetCubeCoordinatesCost(ICubeCoordinates cubeCoordinates)
        {
            return float.MaxValue;
        }
    }
}