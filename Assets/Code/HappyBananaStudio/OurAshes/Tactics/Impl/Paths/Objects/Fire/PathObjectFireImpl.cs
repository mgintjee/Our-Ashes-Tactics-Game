

namespace HappyBananaStudio.OurAshes.Tactics.Impl.Paths.Objects.Fire
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Coordinates.Objects.Cube;
    using HappyBananaStudio.OurAshes.Tactics.Api.HexTiles.Objects;
    using HappyBananaStudio.OurAshes.Tactics.Api.HexTiles.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Api.Loggers;
    using HappyBananaStudio.OurAshes.Tactics.Common.Constants.HexTiles.Attributes;
    using HappyBananaStudio.OurAshes.Tactics.Common.Managers.CodeObjects;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Loggers;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Paths.Objects.Abs;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Todo
    /// </summary>
    public class PathObjectFireImpl
    : PathObjectAbstract
    {
        // Provide logging capability
        private static readonly ICodeLogger logger = new CodeLoggerImpl(new StackFrame().GetMethod().DeclaringType);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="tileObjectStepList">
        /// </param>
        public PathObjectFireImpl(IList<ICubeCoordinates> tileObjectStepList)
            : base(tileObjectStepList)
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
                IHexTileObject hexTileObject = GameMapObjectManager.GetHexTileObjectFrom(cubeCoordinates);
                if (hexTileObject != null)
                {
                    IHexTileInformationReport hexTileInformationReport = hexTileObject.GetHexTileInformationReport();
                    if (hexTileInformationReport != null)
                    {
                        return HexTileAttributesConstants.GetAttributes(hexTileInformationReport.GetHexTileType()).GetFireCost();
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
