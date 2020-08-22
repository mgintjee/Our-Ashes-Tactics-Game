using System;
using System.Collections.Generic;

/// <summary>
/// Report used to convey the state of the MvcModel
/// </summary>
public class MvcModelInformationReport
{
    #region Private Fields

    private readonly MapInformationReport mapInformationReport = null;
    private readonly Dictionary<TalonIdentificationReport, TalonInformationReport> talonIdentificationInformationReportDictionary = null;

    #endregion Private Fields

    #region Private Constructors

    private MvcModelInformationReport(MapInformationReport mapInformationReport,
        Dictionary<TalonIdentificationReport, TalonInformationReport> talonIdentificationInformationReportDictionary)
    {
        this.mapInformationReport = mapInformationReport;
        this.talonIdentificationInformationReportDictionary = new Dictionary<TalonIdentificationReport, TalonInformationReport>(talonIdentificationInformationReportDictionary);
    }

    #endregion Private Constructors

    #region Public Methods

    public MapInformationReport GetMapInformationReport()
    {
        return this.mapInformationReport;
    }

    public Dictionary<TalonIdentificationReport, TalonInformationReport> GetTalonInformationReportSet()
    {
        return new Dictionary<TalonIdentificationReport, TalonInformationReport>(this.talonIdentificationInformationReportDictionary);
    }

    public override string ToString()
    {
        string talonInformationReportDictionaryString = "";
        foreach (TalonIdentificationReport talonIdentificationReport in this.GetTalonInformationReportSet().Keys)
        {
            talonInformationReportDictionaryString += "\n\t>" + talonIdentificationReport +
                "\n\t>" + this.GetTalonInformationReportSet()[talonIdentificationReport];
        }
        return this.GetType() + ":" +
            "\n\t>" + this.GetMapInformationReport() +
            "\n\t>talonIdentificationInformationReportDictionary:" + talonInformationReportDictionaryString;
    }

    #endregion Public Methods

    #region Public Classes

    public class Builder
    {
        #region Private Fields

        private MapInformationReport mapInformationReport = null;
        private Dictionary<TalonIdentificationReport, TalonInformationReport> talonIdentificationInformationReportDictionary = null;

        #endregion Private Fields

        #region Public Methods

        public MvcModelInformationReport Build()
        {
            HashSet<string> invalidReasons = this.IsValid();
            // Check that the set parameters are valid
            if (invalidReasons.Count == 0)
            {
                // Instantiate a new Report
                return new MvcModelInformationReport(this.mapInformationReport, this.talonIdentificationInformationReportDictionary);
            }
            else
            {
                throw new ArgumentException("Unable to construct " + this.GetType() + ". Invalid Parameters." +
                    string.Join("\n", invalidReasons));
            }
        }

        public Builder SetMapInformationReport(MapInformationReport mapInformationReport)
        {
            this.mapInformationReport = mapInformationReport;
            return this;
        }

        public Builder SetTalonIdentificationInformationReportDictionary(
            Dictionary<TalonIdentificationReport, TalonInformationReport> talonIdentificationInformationReportDictionary)
        {
            this.talonIdentificationInformationReportDictionary = talonIdentificationInformationReportDictionary;
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
            // Check that mapInformationReport has been set
            if (this.mapInformationReport == null)
            {
                argumentExceptionSet.Add(typeof(MapInformationReport) + " has not been set");
            }
            // Check that talonIdentificationInformationReportDictionary has been set
            if (this.talonIdentificationInformationReportDictionary == null)
            {
                argumentExceptionSet.Add("talonIdentificationInformationReportDictionary has not been set");
            }
            // Check that talonIdentificationInformationReportDictionary is valid
            if (this.talonIdentificationInformationReportDictionary != null &&
                this.talonIdentificationInformationReportDictionary.Count == 0)
            {
                argumentExceptionSet.Add("talonIdentificationInformationReportDictionary is invalid");
            }
            return argumentExceptionSet;
        }

        #endregion Private Methods
    }

    #endregion Public Classes
}