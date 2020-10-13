/// <summary>
/// Company: HappyBananaStudio
/// Author: Matthew Gintjee
/// </summary>
/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshes.Tactics.Api.Coordinates.Objects.Cube;
using HappyBananaStudio.OurAshes.Tactics.Api.Loggers;
using HappyBananaStudio.OurAshes.Tactics.Impl.Loggers;
using HappyBananaStudio.OurAshesTactics.Impl.Objects.Paths.Objects.Abs;
using System.Collections.Generic;
using System.Diagnostics;

namespace HappyBananaStudio.OurAshesTactics.Impl.Objects.Paths.Objects.Wait
{
    /// <summary>
    /// Todo
    /// </summary>
    public class PathObjectWaitImpl
    : PathObjectAbstract
    {
        // Provide logging capability
        private static readonly ICodeLogger logger = new CodeLoggerImpl(new StackFrame().GetMethod().DeclaringType);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="tileObjectStepList">
        /// </param>
        public PathObjectWaitImpl(IList<ICubeCoordinates> tileObjectStepList)
            : base(tileObjectStepList)
        {
            if (tileObjectStepList.Count != 1)
            {
                logger.Error("Error creating a PathObjectWait. List: CubeCoordinates should be of length 1. Parameterized List: CubeCoordinates is length=?", tileObjectStepList.Count);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="tileCoordinates">
        /// </param>
        /// <returns>
        /// </returns>
        protected override int GetTileObjectPathCost(ICubeCoordinates tileCoordinates)
        {
            return int.MaxValue;
        }
    }
}
