/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Common.Logging;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.HexTile.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.HexTile.Constants;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.HexTile.Enums;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.HexTile.Reports;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Reports;
using System;
using System.Diagnostics;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.HexTile.Impl
{
    /// <summary>
    /// HexTile Object Impl
    /// </summary>
    public class HexTileObjectImpl
    : IHexTileObject
    {
        #region Private Fields

        // Provide logging capability
        private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly HexTileAttributes hexTileAttributes = null;

        // Todo
        private readonly HexTileConstructionReport hexTileConstructionReport = null;

        // Todo
        private readonly HexTileScript hexTileScript = null;

        // Todo
        private readonly IHexTileVisual hexTileVisual = null;

        // Todo
        private TalonIdentificationReport occupyingTalonIdentificationReport = null;

        #endregion Private Fields

        #region Public Constructors

        public HexTileObjectImpl(HexTileScript hexTileScript, HexTileConstructionReport hexTileConstructionReport)
        {
            if (hexTileScript != null &&
                hexTileConstructionReport != null)
            {
                logger.Info("Constructing: ? with ?=?", this.GetType(), typeof(HexTileConstructionReport), hexTileConstructionReport);
                this.hexTileScript = hexTileScript;
                this.hexTileConstructionReport = hexTileConstructionReport;
                this.hexTileAttributes = HexTileAttributesConstants.GetAttributes(this.hexTileConstructionReport.GetHexTileType());
                this.hexTileVisual = new HexTileVisualImpl(this);
            }
            else
            {
                throw new ArgumentException("Unable to construct " + this.GetType() + ". Invalid Parameters." +
                    "\n\t>" + typeof(HexTileScript) + " is null: " + (hexTileScript == null) +
                    "\n\t>" + typeof(HexTileConstructionReport) + " is null: " + (hexTileConstructionReport == null));
            }
        }

        #endregion Public Constructors

        #region Public Methods

        public HexTileInformationReport GetHexTileInformationReport()
        {
            return new HexTileInformationReport.Builder()
                .SetHexTileAttributes(this.hexTileAttributes)
                .SetHexTileConstructionReport(this.hexTileConstructionReport)
                .SetTalonIdentificationReport(this.occupyingTalonIdentificationReport)
                .Build();
        }

        public HexTileScript GetHexTileScript()
        {
            return this.hexTileScript;
        }

        public HexTileTypeEnum GetHexTileType()
        {
            return this.hexTileConstructionReport.GetHexTileType();
        }

        public void SetOccupyingTalonIdentificationReport(TalonIdentificationReport talonIdentificationReport)
        {
            this.occupyingTalonIdentificationReport = talonIdentificationReport;
        }

        #endregion Public Methods
    }
}