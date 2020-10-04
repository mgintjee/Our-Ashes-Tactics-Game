/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Attributes.HexTiles;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.HexTile;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.HexTiles;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Scripts.HexTiles;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Builders;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Constants.Attributes.HexTiles;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Enums;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Loggers;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Utils.Exceptions;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Objects.HexTiles
{
    /// <summary>
    /// HexTile Object Impl
    /// </summary>
    public class HexTileObjectImpl
    : IHexTileObject
    {
        // Provide logging capability
        private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly IHexTileAttributes hexTileAttributes = null;

        // Todo
        private readonly IHexTileConstructionReport hexTileConstructionReport = null;

        // Todo
        private readonly IHexTileScript hexTileScript = null;

        // Todo
        private readonly IHexTileVisual hexTileVisual = null;

        // Todo
        private ITalonIdentificationReport occupyingTalonIdentificationReport = null;

        public HexTileObjectImpl(IHexTileScript hexTileScript, IHexTileConstructionReport hexTileConstructionReport)
        {
            if (hexTileScript != null &&
                hexTileConstructionReport != null)
            {
                logger.Info("Constructing: ? with ?", this.GetType(), hexTileConstructionReport);
                this.hexTileScript = hexTileScript;
                this.hexTileConstructionReport = hexTileConstructionReport;
                this.hexTileAttributes = HexTileAttributesConstants.GetAttributes(this.hexTileConstructionReport.GetHexTileType());
                this.hexTileVisual = new HexTileVisualImpl(this);
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. " +
                    "\n\t> ? is null: ?" +
                    "\n\t> ? is null: ?", this.GetType(),
                    typeof(IHexTileScript), (hexTileScript == null),
                    typeof(IHexTileConstructionReport), (hexTileConstructionReport == null));
            }
        }

        public IHexTileInformationReport GetHexTileInformationReport()
        {
            return ReportBuilder.HexTile.Information.GetBuilder()
                .SetHexTileAttributes(this.hexTileAttributes)
                .SetHexTileConstructionReport(this.hexTileConstructionReport)
                .SetTalonIdentificationReport(this.occupyingTalonIdentificationReport)
                .Build();
        }

        public IHexTileScript GetHexTileScript()
        {
            return this.hexTileScript;
        }

        public HexTileTypeEnum GetHexTileType()
        {
            return this.hexTileConstructionReport.GetHexTileType();
        }

        public void SetOccupyingTalonIdentificationReport(ITalonIdentificationReport talonIdentificationReport)
        {
            this.occupyingTalonIdentificationReport = talonIdentificationReport;
        }
    }
}