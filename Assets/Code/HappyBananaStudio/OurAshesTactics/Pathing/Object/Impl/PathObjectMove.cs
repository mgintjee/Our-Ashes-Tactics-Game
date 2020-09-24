/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Common.Logging;
using HappyBananaStudio.OurAshesTactics.Mvc.Coordinates.Cube;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.HexTile.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.HexTile.Reports;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Map.Manager;
using HappyBananaStudio.OurAshesTactics.Pathing.Object.Api;
using System.Collections.Generic;
using System.Diagnostics;

namespace HappyBananaStudio.OurAshesTactics.Pathing.Object.Impl
{
    /// <summary>
    /// Todo
    /// </summary>
    public class PathObjectMove
    : PathObjectAbstract
    {
        #region Private Fields

        // Provide logging capability
        private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="tileObjectStepList"></param>
        public PathObjectMove(List<CubeCoordinates> tileObjectStepList)
            : base(tileObjectStepList)
        {
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="pathObject"></param>
        public PathObjectMove(IPathObject pathObject)
            : base(pathObject)
        {
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="tileCoordinatesStart"></param>
        /// <param name="tileCoordinatesEnd">  </param>
        /// <param name="pathLength">          </param>
        public PathObjectMove(CubeCoordinates tileCoordinatesStart, CubeCoordinates tileCoordinatesEnd, int pathLength)
            : base(tileCoordinatesStart, tileCoordinatesEnd, pathLength)
        {
        }

        #endregion Public Constructors

        #region Protected Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates"></param>
        /// <returns></returns>
        protected override int GetTileObjectPathCost(CubeCoordinates cubeCoordinates)
        {
            if (cubeCoordinates != null)
            {
                IHexTileObject hexTileObject = MapObjectManager.FindHexTileObjectFrom(cubeCoordinates);
                if (hexTileObject != null)
                {
                    HexTileInformationReport hexTileInformationReport = hexTileObject.GetHexTileInformationReport();
                    if (hexTileInformationReport != null)
                    {
                        HexTileAttributes hexTileAttributes = hexTileInformationReport.GetHexTileAttributes();
                        if (hexTileAttributes != null)
                        {
                            return hexTileAttributes.GetMoveCost();
                        }
                        else
                        {
                            logger.Warn("Unable GetTileObjectPathCost. {} is null.", typeof(HexTileAttributes));
                        }
                    }
                    else
                    {
                        logger.Warn("Unable GetTileObjectPathCost. {} is null.", typeof(HexTileInformationReport));
                    }
                }
                else
                {
                    logger.Warn("Unable GetTileObjectPathCost. {} is null.", typeof(IHexTileObject));
                }
            }
            else
            {
                logger.Warn("Unable GetTileObjectPathCost. {} is null.", typeof(CubeCoordinates));
            }
            return int.MaxValue;
        }

        #endregion Protected Methods
    }
}