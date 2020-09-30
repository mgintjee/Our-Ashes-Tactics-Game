/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Attributes.Api.HexTiles;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Coordinates;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.HexTile;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Paths.Object;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.HexTiles;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Loggers;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Managers;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Path.Objects.Abs;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Path.Objects.Move
{
    /// <summary>
    /// Todo
    /// </summary>
    public class PathObjectMove
    : PathObjectAbstract
    {
        // Provide logging capability
        private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="tileObjectStepList">
        /// </param>
        public PathObjectMove(List<ICubeCoordinates> tileObjectStepList)
            : base(tileObjectStepList)
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
        /// <param name="tileCoordinatesStart">
        /// </param>
        /// <param name="tileCoordinatesEnd">
        /// </param>
        /// <param name="pathLength">
        /// </param>
        public PathObjectMove(ICubeCoordinates tileCoordinatesStart, ICubeCoordinates tileCoordinatesEnd, int pathLength)
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
        protected override int GetTileObjectPathCost(ICubeCoordinates cubeCoordinates)
        {
            if (cubeCoordinates != null)
            {
                IHexTileObject hexTileObject = GameMapObjectManager.FindHexTileObjectFrom(cubeCoordinates);
                if (hexTileObject != null)
                {
                    IHexTileInformationReport hexTileInformationReport = hexTileObject.GetHexTileInformationReport();
                    if (hexTileInformationReport != null)
                    {
                        IHexTileAttributes hexTileAttributes = hexTileInformationReport.GetHexTileAttributes();
                        if (hexTileAttributes != null)
                        {
                            return hexTileAttributes.GetMoveCost();
                        }
                        else
                        {
                            logger.Warn("Unable GetTileObjectPathCost. {} is null.", typeof(IHexTileAttributes));
                        }
                    }
                    else
                    {
                        logger.Warn("Unable GetTileObjectPathCost. {} is null.", typeof(IHexTileInformationReport));
                    }
                }
                else
                {
                    logger.Warn("Unable GetTileObjectPathCost. {} is null.", typeof(IHexTileObject));
                }
            }
            else
            {
                logger.Warn("Unable GetTileObjectPathCost. {} is null.", typeof(ICubeCoordinates));
            }
            return int.MaxValue;
        }
    }
}