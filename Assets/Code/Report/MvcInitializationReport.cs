using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Todo
/// </summary>
public class MvcInitializationReport
{
    #region Private Fields

    private readonly MapConstructionReport mapConstructionReport;
    private readonly Dictionary<TeamIdEnum, ControllerTypeEnum> teamIdControllerTypeDictionary;
    private readonly Dictionary<TeamIdEnum, HashSet<MechConstructionReport>> teamIdMechConstructionReport;

    #endregion Private Fields

    #region Private Constructors

    private MvcInitializationReport(MapConstructionReport mapConstructionReport,
        Dictionary<TeamIdEnum, ControllerTypeEnum> teamIdControllerTypeDictionary,
        Dictionary<TeamIdEnum, HashSet<MechConstructionReport>> teamIdMechConstructionReport)
    {
        this.mapConstructionReport = mapConstructionReport;
        this.teamIdControllerTypeDictionary = teamIdControllerTypeDictionary;
        this.teamIdMechConstructionReport = teamIdMechConstructionReport;
    }

    #endregion Private Constructors

    #region Public Methods

    public MapConstructionReport GetMapConstructionReport()
    {
        return this.mapConstructionReport;
    }

    public Dictionary<TeamIdEnum, ControllerTypeEnum> GetTeamIdControllerTypeDictionary()
    {
        return new Dictionary<TeamIdEnum, ControllerTypeEnum>(this.teamIdControllerTypeDictionary);
    }

    public Dictionary<TeamIdEnum, HashSet<MechConstructionReport>> GetTeamIdMechConstructionReportSetDictionary()
    {
        return new Dictionary<TeamIdEnum, HashSet<MechConstructionReport>>(this.teamIdMechConstructionReport);
    }

    #endregion Public Methods

    #region Public Classes

    public class Builder
    {
        #region Private Fields

        private MapConstructionReport mapConstructionReport;
        private Dictionary<TeamIdEnum, ControllerTypeEnum> teamIdControllerTypeDictionary;
        private Dictionary<TeamIdEnum, HashSet<MechConstructionReport>> teamIdMechConstructionReportDictionary;

        #endregion Private Fields

        #region Public Methods

        public Builder SetMapConstructionReport(MapConstructionReport mapConstructionReport)
        {
            this.mapConstructionReport = mapConstructionReport;
            return this;
        }

        public Builder SetTeamIdControllerTypeDictionary(Dictionary<TeamIdEnum, ControllerTypeEnum> teamIdControllerTypeDictionary)
        {
            this.teamIdControllerTypeDictionary = teamIdControllerTypeDictionary;
            return this;
        }

        public Builder SetTeamIdMechConstructionReportSetDictionary(Dictionary<TeamIdEnum, HashSet<MechConstructionReport>> teamIdMechConstructionReportDictionary)
        {
            this.teamIdMechConstructionReportDictionary = teamIdMechConstructionReportDictionary;
            return this;
        }

        public MvcInitializationReport Build()
        {
            this.IsValid();
            return new MvcInitializationReport(this.mapConstructionReport, this.teamIdControllerTypeDictionary, this.teamIdMechConstructionReportDictionary);
        }

        #endregion Public Methods

        #region Private Methods

        private void IsValid()
        {
            // Default an empty Set: String
            HashSet<string> argumentExceptionSet = new HashSet<string>();
            // Check if the mapConstructionReport has been set
            if (this.mapConstructionReport == null)
            {
                argumentExceptionSet.Add("mapConstructionReport has not been set");
            }
            // Check if the teamIdControllerTypeDictionary has been set
            if (this.teamIdControllerTypeDictionary == null)
            {
                argumentExceptionSet.Add("teamIdControllerTypeDictionary has not been set");
            }
            // Check if the teamIdMechConstructionReportDictionary has been set
            if (this.teamIdMechConstructionReportDictionary == null)
            {
                argumentExceptionSet.Add("teamIdMechConstructionReport has not been set");
            }
            // Check that all of the parameters have at least been set
            if (argumentExceptionSet.Count == 0)
            {
                HashSet<TeamIdEnum> teamIdControllerTypeSet = new HashSet<TeamIdEnum>(this.teamIdControllerTypeDictionary.Keys);
                HashSet<TeamIdEnum> teamIdMechConstructionReportSet = new HashSet<TeamIdEnum>(this.teamIdMechConstructionReportDictionary.Keys);
                // Check that the Keys for teamIdControllerTypeDictionary are a valid amount
                if (teamIdControllerTypeSet.Count < 2 ||
                    teamIdControllerTypeSet.Count > this.mapConstructionReport.GetMapRadius() + 1)
                {
                    argumentExceptionSet.Add("teamIdControllerTypeDictionary has an invalid amount of teamIds: " + teamIdControllerTypeSet.Count);
                }
                // Check that the Keys for teamIdMechConstructionReportDictionary are a valid amount
                if (teamIdMechConstructionReportSet.Count < 2 ||
                    teamIdMechConstructionReportSet.Count > this.mapConstructionReport.GetMapRadius() + 1)
                {
                    argumentExceptionSet.Add("teamIdMechConstructionReport has an invalid amount of teamIds: " + teamIdMechConstructionReportSet.Count);
                }
                // Check that the Keys are the same for teamIdControllerTypeDictionary and teamIdMechConstructionReportDictionary
                if (!teamIdControllerTypeSet.Equals(teamIdMechConstructionReportSet))
                {
                    argumentExceptionSet.Add("Set: TeamId are not the same for teamIdControllerTypeDictionary and teamIdMechConstructionReport");
                }
                int maxMechConstructionReportPerTeam = (int)Mathf.Floor(this.mapConstructionReport.GetMapRadius() * 2 / teamIdMechConstructionReportSet.Count);
                // Check that the MechConstructionReports are a valid amount for each teamId
                foreach (TeamIdEnum teamId in this.teamIdMechConstructionReportDictionary.Keys)
                {
                    HashSet<MechConstructionReport> mechConstructionReportSet = this.teamIdMechConstructionReportDictionary[teamId];
                    if (mechConstructionReportSet.Count < 1 ||
                        mechConstructionReportSet.Count > maxMechConstructionReportPerTeam)
                    {
                        argumentExceptionSet.Add("TeamId: " + teamId + "has an invalid amount of MechConstructionReports: " + mechConstructionReportSet.Count);
                    }
                }
            }

            if (argumentExceptionSet.Count > 0)
            {
                throw new ArgumentException("Unable to construct ?" +
                    this.GetType() + ". Invalid Parameters." +
                    string.Join("\n", argumentExceptionSet));
            }
        }

        #endregion Private Methods
    }

    #endregion Public Classes
}