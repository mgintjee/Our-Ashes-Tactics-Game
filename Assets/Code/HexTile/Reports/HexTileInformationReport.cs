using System;
using System.Collections.Generic;

/// <summary>
/// Report to display the all of the information for a specific HexTile
/// </summary>
public class HexTileInformationReport
{
    #region Private Fields

    private readonly HexTileAttributes hexTileAttributes = null;
    private readonly HexTileConstructionReport hexTileConstructionReport = null;
    private readonly TalonIdentificationReport talonIdentificationReport = null;

    #endregion Private Fields

    #region Private Constructors

    private HexTileInformationReport(HexTileAttributes hexTileAttributes, HexTileConstructionReport tileConstructionReport,
        TalonIdentificationReport talonIdentificationReport)
    {
        this.hexTileAttributes = hexTileAttributes;
        this.hexTileConstructionReport = tileConstructionReport;
        this.talonIdentificationReport = talonIdentificationReport;
    }

    #endregion Private Constructors

    #region Public Methods

    public HexTileAttributes GetHexTileAttributes()
    {
        return this.hexTileAttributes;
    }

    public HexTileConstructionReport GetHexTileConstructionReport()
    {
        return this.hexTileConstructionReport;
    }

    public TalonIdentificationReport GetTalonIdentificationReport()
    {
        return this.talonIdentificationReport;
    }

    #endregion Public Methods

    #region Public Classes

    public class Builder
    {
        #region Private Fields

        private HexTileAttributes hexTileAttributes = null;

        private HexTileConstructionReport hexTileConstructionReport = null;
        private TalonIdentificationReport talonIdentificationReport = null;

        #endregion Private Fields

        #region Public Methods

        public HexTileInformationReport Build()
        {
            HashSet<string> invalidReasons = this.IsValid();
            // Check that the set parameters are valid
            if (invalidReasons.Count == 0)
            {
                // Instantiate a new Report
                return new HexTileInformationReport(this.hexTileAttributes, this.hexTileConstructionReport, talonIdentificationReport);
            }
            else
            {
                throw new ArgumentException("Unable to construct " + this.GetType() + ". Invalid Parameters." +
                    string.Join("\n>", invalidReasons));
            }
        }

        public Builder SetHexTileAttributes(HexTileAttributes hexTileAttributes)
        {
            this.hexTileAttributes = hexTileAttributes;
            return this;
        }

        public Builder SetHexTileConstructionReport(HexTileConstructionReport tileConstructionReport)
        {
            this.hexTileConstructionReport = tileConstructionReport;
            return this;
        }

        public Builder SetTalonIdentificationReport(TalonIdentificationReport talonIdentificationReport)
        {
            this.talonIdentificationReport = talonIdentificationReport;
            return this;
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        private HashSet<string> IsValid()
        {
            // Default an empty Set: String
            HashSet<string> argumentExceptionSet = new HashSet<string>();
            // Check that hexTileAttributes has been set
            if (this.hexTileAttributes == null)
            {
                argumentExceptionSet.Add(typeof(HexTileAttributes) + " has not been set");
            }
            // Check that hexTileConstructionReport has been set
            if (this.hexTileConstructionReport == null)
            {
                argumentExceptionSet.Add(typeof(HexTileConstructionReport) + " has not been set");
            }
            return argumentExceptionSet;
        }

        #endregion Private Methods
    }

    #endregion Public Classes
}