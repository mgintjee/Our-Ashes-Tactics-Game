namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Pathing.Objects.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Loggers.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Loggers.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Coordinates.Cube.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Pathing.Objects.Abs;
    using HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Todo
    /// </summary>
    public class PathObjectWaitImpl
        : AbstractPathObject
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
                throw ExceptionUtil.Argument.Build("Unable to construct ?. Invalid Parameters. " +
                    "List: ? should be of length 1. " +
                    "Parameterized List: ? is length=?.",
                   this.GetType(), typeof(ICubeCoordinates), typeof(ICubeCoordinates), tileObjectStepList.Count);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="tileCoordinates">
        /// </param>
        /// <returns>
        /// </returns>
        protected override float GetTileObjectPathCost(ICubeCoordinates tileCoordinates)
        {
            return float.MaxValue;
        }
    }
}