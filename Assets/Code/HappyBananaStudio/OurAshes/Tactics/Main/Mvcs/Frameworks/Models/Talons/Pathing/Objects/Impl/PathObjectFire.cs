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
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Todo
    /// </summary>
    public class PathObjectFire
        : AbstractPathObject
    {
        // Provide logging capability
        private static readonly ICodeLogger logger = new CodeLogger(new StackFrame().GetMethod().DeclaringType);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinatesStepList">
        /// </param>
        public PathObjectFire(IList<ICubeCoordinates> cubeCoordinatesStepList)
            : base(cubeCoordinatesStepList)
        {
        }

        /// <inheritdoc/>
        protected override float GetCubeCoordinatesPathCost(ICubeCoordinates cubeCoordinates)
        {
            if (cubeCoordinates != null)
            {
                IHexTileObject hexTileObject = GameBoardManager.GetHexTileObjectFrom(cubeCoordinates);
                if (hexTileObject != null)
                {
                    IHexTileReport hexTileReport = hexTileObject.GetHexTileReport();
                    if (hexTileReport != null)
                    {
                        // Todo: Add occupying talon penalty
                        return HexTileAttributesConstants.GetHexTileAttributes(hexTileReport.GetHexTileType())
                            .GetFireCost();
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