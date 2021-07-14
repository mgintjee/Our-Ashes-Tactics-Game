using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Maps.Coordinates.Cube.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Sorties.Maps.Paths.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Paths.Implementaions.Abstracts;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Paths.Implementaions.Waits
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