using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Maps.Coordinates.Cube.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Paths.Implementaions.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Paths.Types.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Reports.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Paths.Implementaions.Waits
{
    /// <summary>
    /// Todo
    /// </summary>
    public class WaitPath
        : AbstractPath
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates"></param>
        public WaitPath(IList<ICubeCoordinates> cubeCoordinates, IMapReport mapReport)
            : base(cubeCoordinates, mapReport)
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