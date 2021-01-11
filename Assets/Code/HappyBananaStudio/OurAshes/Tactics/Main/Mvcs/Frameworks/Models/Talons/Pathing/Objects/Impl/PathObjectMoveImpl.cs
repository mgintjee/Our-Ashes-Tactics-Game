namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Pathing.Objects.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Loggers.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Loggers.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Coordinates.Cube.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.GameBoards.Managers;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.HexTiles.Constants;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.HexTiles.Objects.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.HexTiles.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Pathing.Objects.Abs;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Pathing.Objects.Api;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Todo
    /// </summary>
    public class PathObjectMoveImpl
        : AbstractPathObject
    {
        // Provide logging capability
        private static readonly ICodeLogger logger = new CodeLoggerImpl(new StackFrame().GetMethod().DeclaringType);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="tileObjectStepList">
        /// </param>
        public PathObjectMoveImpl(IList<ICubeCoordinates> tileObjectStepList)
            : base(tileObjectStepList)
        {
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="pathObject">
        /// </param>
        public PathObjectMoveImpl(IPathObject pathObject)
            : base(pathObject)
        {
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="tileCoordinatesStart">
        /// </param>
        /// <param name="tileCoordinatesEnd">
        /// </param>
        /// <param name="pathLength">
        /// </param>
        public PathObjectMoveImpl(ICubeCoordinates tileCoordinatesStart, ICubeCoordinates tileCoordinatesEnd, int pathLength)
            : base(tileCoordinatesStart, tileCoordinatesEnd, pathLength)
        {
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates">
        /// </param>
        /// <returns>
        /// </returns>
        protected override float GetTileObjectPathCost(ICubeCoordinates cubeCoordinates)
        {
            if (cubeCoordinates != null)
            {
                IHexTileObject hexTileObject = GameBoardObjectManager.GetHexTileObjectFrom(cubeCoordinates);
                if (hexTileObject != null)
                {
                    IHexTileReport hexTileReport = hexTileObject.GetHexTileReport();
                    if (hexTileReport != null)
                    {
                        // Todo: Add occupying talon penalty
                        return HexTileAttributesConstants.GetHexTileAttributes(hexTileReport.GetHexTileType())
                            .GetMoveCost();
                    }
                    else
                    {
                        logger.Warn("Unable to ?. Invalid Parameters. ? is null.",
                            new StackFrame().GetMethod().Name, typeof(IHexTileReport));
                    }
                }
                else
                {
                    logger.Warn("Unable to ?. Invalid Parameters. ? is null.",
                        new StackFrame().GetMethod().Name, typeof(IHexTileObject));
                }
            }
            else
            {
                logger.Warn("Unable to ?. Invalid Parameters. ? is null.",
                    new StackFrame().GetMethod().Name, typeof(ICubeCoordinates));
            }
            return int.MaxValue;
        }
    }
}