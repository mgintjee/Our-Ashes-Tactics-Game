using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Cube.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Loggers.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Loggers.Impl;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.GameBoards.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.HexTiles.Models.Attributes.Constants;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.HexTiles.Models.Objects.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.HexTiles.Models.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Common.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Pathing.Objects.Abs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Pathing.Objects.Api;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Pathing.Objects.Impl
{
    /// <summary>
    /// Todo
    /// </summary>
    public class PathObjectMove
        : AbstractPathObject
    {
        // Provide logging capability
        private static readonly ICodeLogger logger = new CodeLogger(new StackFrame().GetMethod().DeclaringType);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinatesStepList">
        /// </param>
        public PathObjectMove(IList<ICubeCoordinates> cubeCoordinatesStepList)
            : base(cubeCoordinatesStepList)
        {
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="pathObject">
        /// </param>
        public PathObjectMove(IPathObject pathObject)
            : base(pathObject)
        {
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinatesStart">
        /// </param>
        /// <param name="cubeCoordinatesEnd">
        /// </param>
        /// <param name="pathLength">
        /// </param>
        public PathObjectMove(ICubeCoordinates cubeCoordinatesStart, ICubeCoordinates cubeCoordinatesEnd, int pathLength)
            : base(cubeCoordinatesStart, cubeCoordinatesEnd, pathLength)
        {
        }

        /// <inheritdoc/>
        protected override float GetCubeCoordinatesPathCost(ICubeCoordinates cubeCoordinates)
        {
            if (cubeCoordinates != null)
            {
                // Todo: This can probably just be a simple query a constants file for this
                IHexTileObject hexTileObject = GameBoardManager.GetHexTileObjectFrom(cubeCoordinates);
                if (hexTileObject != null)
                {
                    IHexTileReport hexTileReport = hexTileObject.GetHexTileReport();
                    if (hexTileReport != null)
                    {
                        return HexTileAttributesConstants.GetHexTileAttributes(hexTileReport.GetHexTileType())
                            .GetMoveCost() + ((hexTileReport.GetTalonCallSign() != TalonCallSign.None) ? int.MaxValue : 0);
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