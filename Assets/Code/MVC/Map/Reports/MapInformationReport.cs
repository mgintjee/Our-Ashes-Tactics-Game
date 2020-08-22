using System;
using System.Collections.Generic;

/// <summary>
/// Report used to display the current information of the Map
/// </summary>
public class MapInformationReport
{
    #region Private Fields

    private readonly HashSet<HexTileInformationReport> hexTileInformationReportSet = null;

    #endregion Private Fields

    #region Private Constructors

    private MapInformationReport(HashSet<HexTileInformationReport> hexTileInformationReportSet)
    {
        this.hexTileInformationReportSet = new HashSet<HexTileInformationReport>(hexTileInformationReportSet);
    }

    #endregion Private Constructors

    #region Public Methods

    public HashSet<HexTileInformationReport> GetHexTileInformationReportSet()
    {
        return new HashSet<HexTileInformationReport>(this.hexTileInformationReportSet);
    }

    public override string ToString()
    {
        return this.GetType() + ": " +
            "\n\t>hexTileInformationReportSet:[" +
            "\n\t>" + string.Join("\n\t>", this.GetHexTileInformationReportSet()) +
            "\n]";
    }

    #endregion Public Methods

    #region Public Classes

    public class Builder
    {
        #region Private Fields

        private HashSet<HexTileInformationReport> hexTileInformationReportSet = null;

        #endregion Private Fields

        #region Public Methods

        public MapInformationReport Build()
        {
            HashSet<string> invalidReasons = this.IsValid();
            // Check that the set parameters are valid
            if (invalidReasons.Count == 0)
            {
                // Instantiate a new Report
                return new MapInformationReport(this.hexTileInformationReportSet);
            }
            else
            {
                throw new ArgumentException("Unable to construct " + this.GetType() + ". Invalid Parameters." +
                    string.Join("\n", invalidReasons));
            }
        }

        public Builder SetHexTileInformationReportSet(HashSet<HexTileInformationReport> hexTileInformationReportSet)
        {
            this.hexTileInformationReportSet = hexTileInformationReportSet;
            return this;
        }

        #endregion Public Methods

        #region Private Methods

        private HashSet<string> IsValid()
        {
            // Default an empty Set: String
            HashSet<string> argumentExceptionSet = new HashSet<string>();
            // Check that hexTileInformationReportSet has been set
            if (this.hexTileInformationReportSet == null)
            {
                argumentExceptionSet.Add("hexTileInformationReportSet has not been set");
            }
            // Check that cubeCoordinatesHexTileAttributesDictionary is valid
            if (this.hexTileInformationReportSet != null &&
                this.hexTileInformationReportSet.Count == 0)
            {
                argumentExceptionSet.Add("hexTileInformationReportSet is invalid");
            }

            return argumentExceptionSet;
        }

        #endregion Private Methods
    }

    #endregion Public Classes
}