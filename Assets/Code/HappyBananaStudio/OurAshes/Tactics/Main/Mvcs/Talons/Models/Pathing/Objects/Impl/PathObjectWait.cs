using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Cube.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Pathing.Objects.Abs;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Pathing.Objects.Impl
{
    /// <summary>
    /// Todo
    /// </summary>
    public class PathObjectWait
        : AbstractPathObject
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinatesStepList">
        /// </param>
        public PathObjectWait(IList<ICubeCoordinates> cubeCoordinatesStepList)
            : base(cubeCoordinatesStepList)
        {
            if (cubeCoordinatesStepList.Count != 1)
            {
                throw ExceptionUtil.Arguments.Build("Unable to construct ?. Invalid Parameters. " +
                    "List: ? should be of length 1. " +
                    "Parameterized List: ? is length=?.",
                   this.GetType(), typeof(ICubeCoordinates), typeof(ICubeCoordinates), cubeCoordinatesStepList.Count);
            }
        }

        /// <inheritdoc/>
        protected override float GetCubeCoordinatesPathCost(ICubeCoordinates cubeCoordinates)
        {
            return float.MaxValue;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: List: {1}=[{2}]",
                this.GetType().Name, typeof(ICubeCoordinates).Name,
                string.Join(", ", this.cubeCoordinatesStepList));
        }
    }
}