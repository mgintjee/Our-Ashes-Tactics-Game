/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Attributes.HexTiles;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Coordinates;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.HexTile;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.HexTiles;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Loggers;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Managers;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Objects.Paths.Objects.Abs;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Objects.Paths.Objects.Wait
{
    /// <summary>
    /// Todo
    /// </summary>
    public class PathObjectWaitImpl
    : PathObjectAbstract
    {
        // Provide logging capability
        private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="tileObjectStepList">
        /// </param>
        public PathObjectWaitImpl(List<ICubeCoordinates> tileObjectStepList)
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
            if (tileCoordinates != null)
            {
                IHexTileObject hexTileObject = GameMapObjectManager.FindHexTileObjectFrom(tileCoordinates);
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
    }
}