using System;
using System.Collections.Generic;

/// <summary>
/// Todo
/// </summary>
public class MvcInitializationReport
{
    #region Private Fields

    // Determines the dimensions of the map
    private readonly MapInformationReport mapInformationReport;

    // Determines the information required for constructing Talons
    private readonly HashSet<TalonConstructionReport> talonConstructionReportSet;

    // Determines which ControllerType is for a ControllerId
    private readonly Dictionary<TalonControllerIdEnum, TalonControllerTypeEnum> talonControllerIdControllerTypeDictionary;

    // Determines which controller is responsible for a phalanx
    private readonly Dictionary<TalonControllerIdEnum, HashSet<TalonPhalanxIdEnum>> talonControllerIdPhalanxIdSetDictionary;

    // Determines which Faction a phalanx is fighting for
    private readonly Dictionary<TalonFactionIdEnum, HashSet<TalonPhalanxIdEnum>> talonFactionIdPhalanxIdSetDictionary;

    #endregion Private Fields

    #region Private Constructors

    private MvcInitializationReport(MapInformationReport mapInformationReport,
        Dictionary<TalonControllerIdEnum, HashSet<TalonPhalanxIdEnum>> talonControllerIdPhalanxIdSetDictionary,
        Dictionary<TalonControllerIdEnum, TalonControllerTypeEnum> talonControllerIdControllerTypeDictionary,
        HashSet<TalonConstructionReport> talonConstructionReportSet,
        Dictionary<TalonFactionIdEnum, HashSet<TalonPhalanxIdEnum>> talonFactionIdPhalanxIdSetDictionary)
    {
        this.mapInformationReport = mapInformationReport;
        this.talonControllerIdPhalanxIdSetDictionary = talonControllerIdPhalanxIdSetDictionary;
        this.talonControllerIdControllerTypeDictionary = talonControllerIdControllerTypeDictionary;
        this.talonConstructionReportSet = talonConstructionReportSet;
        this.talonFactionIdPhalanxIdSetDictionary = talonFactionIdPhalanxIdSetDictionary;
    }

    #endregion Private Constructors

    #region Public Methods

    public MapInformationReport GetMapConstructionReport()
    {
        return this.mapInformationReport;
    }

    public HashSet<TalonConstructionReport> GetTalonConstructionReportSet()
    {
        return new HashSet<TalonConstructionReport>(this.talonConstructionReportSet);
    }

    public Dictionary<TalonControllerIdEnum, TalonControllerTypeEnum> GetTalonControllerIdControllerTypeDictionary()
    {
        return new Dictionary<TalonControllerIdEnum, TalonControllerTypeEnum>(this.talonControllerIdControllerTypeDictionary);
    }

    public Dictionary<TalonControllerIdEnum, HashSet<TalonPhalanxIdEnum>> GetTalonControllerIdPhalanxIdSetDictionary()
    {
        return new Dictionary<TalonControllerIdEnum, HashSet<TalonPhalanxIdEnum>>(this.talonControllerIdPhalanxIdSetDictionary);
    }

    public Dictionary<TalonFactionIdEnum, HashSet<TalonPhalanxIdEnum>> GetTalonFactionIdPhalanxIdSetDictionary()
    {
        return new Dictionary<TalonFactionIdEnum, HashSet<TalonPhalanxIdEnum>>(this.talonFactionIdPhalanxIdSetDictionary);
    }

    public override string ToString()
    {
        return this.GetType().ToString();
    }

    #endregion Public Methods

    #region Public Classes

    public class Builder
    {
        #region Private Fields

        // Determines the dimensions of the map
        private MapInformationReport mapInformationReport = null;

        // Determines the information required for constructing Talons
        private HashSet<TalonConstructionReport> talonConstructionReportSet = null;

        // Determines which ControllerType is for a ControllerId
        private Dictionary<TalonControllerIdEnum, TalonControllerTypeEnum> talonControllerIdControllerTypeDictionary = null;

        // Determines which controller is responsible for a phalanx
        private Dictionary<TalonControllerIdEnum, HashSet<TalonPhalanxIdEnum>> talonControllerIdPhalanxIdSetDictionary = null;

        // Determines which Faction a phalanx is fighting for
        private Dictionary<TalonFactionIdEnum, HashSet<TalonPhalanxIdEnum>> talonFactionIdPhalanxIdSetDictionary = null;

        #endregion Private Fields

        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public MvcInitializationReport Build()
        {
            HashSet<string> invalidReasons = this.IsValid();
            // Check that the set parameters are valid
            if (invalidReasons.Count == 0)
            {
                // Instantiate a new Report
                return new MvcInitializationReport(this.mapInformationReport, this.talonControllerIdPhalanxIdSetDictionary,
                    this.talonControllerIdControllerTypeDictionary, this.talonConstructionReportSet,
                    this.talonFactionIdPhalanxIdSetDictionary);
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

        public Builder SetTalonConstructionReportSet(HashSet<TalonConstructionReport> talonConstructionReportSet)
        {
            this.talonConstructionReportSet = talonConstructionReportSet;
            return this;
        }

        public Builder SetTalonControllerIdControllerTypeDictionary(
            Dictionary<TalonControllerIdEnum, TalonControllerTypeEnum> talonControllerIdControllerTypeDictionary)
        {
            this.talonControllerIdControllerTypeDictionary = talonControllerIdControllerTypeDictionary;
            return this;
        }

        public Builder SetTalonControllerIdPhalanxIdSetDictionary(
                            Dictionary<TalonControllerIdEnum, HashSet<TalonPhalanxIdEnum>> talonControllerIdPhalanxIdSetDictionary)
        {
            this.talonControllerIdPhalanxIdSetDictionary = talonControllerIdPhalanxIdSetDictionary;
            return this;
        }

        public Builder SetTalonFactionIdPhalanxIdSetDictionary(Dictionary<TalonFactionIdEnum, HashSet<TalonPhalanxIdEnum>> talonFactionIdPhalanxIdSetDictionary)
        {
            this.talonFactionIdPhalanxIdSetDictionary = talonFactionIdPhalanxIdSetDictionary;
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
            // Check if the mapInformationReport has been set
            if (this.mapInformationReport == null)
            {
                argumentExceptionSet.Add("mapInformationReport has not been set");
            }
            // Check if the talonControllerIdPhalanxIdSetDictionary has been set
            if (this.talonControllerIdPhalanxIdSetDictionary == null)
            {
                argumentExceptionSet.Add("talonControllerIdPhalanxIdSetDictionary has not been set");
            }
            // Check if the talonControllerIdControllerTypeDictionary has been set
            if (this.talonControllerIdControllerTypeDictionary == null)
            {
                argumentExceptionSet.Add("talonControllerIdControllerTypeDictionary has not been set");
            }
            // Check if the teamIdAlliedTeamIdSetDictionary has been set
            if (this.talonConstructionReportSet == null)
            {
                argumentExceptionSet.Add("teamIdAlliedTeamIdSet has not been set");
            }
            // Check if the teamIdAlliedTeamIdSetDictionary has been set
            if (this.talonFactionIdPhalanxIdSetDictionary == null)
            {
                argumentExceptionSet.Add("teamIdAlliedTeamIdSet has not been set");
            }

            return argumentExceptionSet;
        }

        #endregion Private Methods
    }

    #endregion Public Classes
}