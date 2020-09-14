/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Common.Logging;
using HappyBananaStudio.OurAshesTactics.Mvc.Coordinates.Cube;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.HexTile.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.HexTile.Reports;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.HexTile.Util;
using System.Collections.Generic;
using System.Diagnostics;

namespace HappyBananaStudio.OurAshesTactics.Pathing.Object.Impl
{
    /// <summary>
    /// Todo
    /// </summary>
    public class PathObjectWait
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
        public PathObjectWait(List<CubeCoordinates> tileObjectStepList)
            : base(tileObjectStepList)
        {
            if (tileObjectStepList.Count != 1)
            {
                logger.Error("Error creating a PathObjectWait. List: CubeCoordinates should be of length 1. Parameterized List: CubeCoordinates is length=?", tileObjectStepList.Count);
            }
        }

        #endregion Public Constructors

        #region Protected Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="tileCoordinates"></param>
        /// <returns></returns>
        protected override int GetTileObjectPathCost(CubeCoordinates tileCoordinates)
        {
            if (tileCoordinates != null)
            {
                IHexTileObject hexTileObject = HexTileObjectFinderUtil.FindHexTileObjectFrom(tileCoordinates);
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
                    }
                }
                else
                {
                    logger.Warn("Unable to determine FireCost for TileObject. Parameterized TileCoordiantes is not tracked in the MapModelObject.");
                }
            }
            else
            {
                logger.Warn("Unable to determine FireCost for TileObject. Parameterized TileCoordiantes is null.");
            }
            return int.MaxValue;
        }

        #endregion Protected Methods
    }
}