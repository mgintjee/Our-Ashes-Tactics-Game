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
    private readonly HashSet<MechConstructionReport> mechConstructionReportSet;
    private readonly HashSet<HashSet<TeamIdEnum>> teamIdFactionSet;

    #endregion Private Fields

    #region Private Constructors

    private MvcInitializationReport(MapConstructionReport mapConstructionReport,
        Dictionary<TeamIdEnum, ControllerTypeEnum> teamIdControllerTypeDictionary,
        HashSet<MechConstructionReport> mechConstructionReportSet,
        HashSet<HashSet<TeamIdEnum>> teamIdFactionSet)
    {
        this.mapConstructionReport = mapConstructionReport;
        this.teamIdControllerTypeDictionary = teamIdControllerTypeDictionary;
        this.mechConstructionReportSet = mechConstructionReportSet;
        this.teamIdFactionSet = teamIdFactionSet;
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

    public HashSet<MechConstructionReport> GetMechConstructionReportSet()
    {
        return new HashSet<MechConstructionReport>(this.mechConstructionReportSet);
    }
    public HashSet<HashSet<TeamIdEnum>> GetTeamIdFactionSet()
    {
        return new HashSet<HashSet<TeamIdEnum>>(this.teamIdFactionSet);
    }
    public override string ToString()
    {
        string teamIdControllerTypeDictionaryString = "";
        foreach (TeamIdEnum teamId in this.GetTeamIdControllerTypeDictionary().Keys)
        {
            teamIdControllerTypeDictionaryString += "\n" + (typeof(TeamIdEnum) + ": " + teamId + ", " +
                typeof(ControllerTypeEnum) + ": " + this.GetTeamIdControllerTypeDictionary()[teamId]);
        }
        string teamIdAlliedTeamIdSetDictionaryString = "";
        int counter = 0;
        foreach (HashSet<TeamIdEnum> teamIdFactionSet in this.GetTeamIdFactionSet())
        {
            teamIdAlliedTeamIdSetDictionaryString += "\nFaction" + counter + ": " + "[" + string.Join(",", teamIdFactionSet) + "]";
            counter++;
        }
        if(teamIdAlliedTeamIdSetDictionaryString.Length == 0)
        {
            teamIdAlliedTeamIdSetDictionaryString = "Free-for-all";
        }
        return this.GetType() + ": " +
            "\n>mapConstructionReport: " + this.GetMapConstructionReport() +
            ",\n>teamIdControllerTypeDictionary: " + teamIdControllerTypeDictionaryString +
            ",\n>teamIdAlliedTeamIdSetDictionary: " + teamIdAlliedTeamIdSetDictionaryString +
            ",\n>teamIdMechConstructionReportDictionary: [" + string.Join(",\n", this.GetMechConstructionReportSet()) + "]";
    }

    #endregion Public Methods

    #region Public Classes

    public class Builder
    {
        #region Private Fields

        private MapConstructionReport mapConstructionReport;
        private Dictionary<TeamIdEnum, ControllerTypeEnum> teamIdControllerTypeDictionary;
        private HashSet<HashSet<TeamIdEnum>> teamIdFactionSet;

        private HashSet<MechConstructionReport> mechConstructionReportSet;

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

        public Builder SetMechConstructionReportSet(HashSet<MechConstructionReport> mechConstructionReportSet)
        {
            this.mechConstructionReportSet = mechConstructionReportSet;
            return this;
        }

        public Builder SetTeamIdFactionSet(HashSet<HashSet<TeamIdEnum>> teamIdAlliedTeamIdSet)
        {
            this.teamIdFactionSet = teamIdAlliedTeamIdSet;
            return this;
        }

        public MvcInitializationReport Build()
        {
            this.IsValid();
            return new MvcInitializationReport(this.mapConstructionReport,
                this.teamIdControllerTypeDictionary, this.mechConstructionReportSet, 
                this.teamIdFactionSet);
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
            // Check if the mechConstructionReportSet has been set
            if (this.mechConstructionReportSet == null)
            {
                argumentExceptionSet.Add("mechConstructionReportSet has not been set");
            }
            // Check if the teamIdAlliedTeamIdSetDictionary has been set
            if (this.teamIdFactionSet == null)
            {
                argumentExceptionSet.Add("teamIdAlliedTeamIdSet has not been set");
            }
            // Check that all of the parameters have at least been set
            if (argumentExceptionSet.Count == 0)
            {
                HashSet<TeamIdEnum> teamIdControllerTypeSet = new HashSet<TeamIdEnum>(this.teamIdControllerTypeDictionary.Keys);
                Dictionary<TeamIdEnum, int> teamIdMechConstructionReportCountDictionary = new Dictionary<TeamIdEnum, int>();

                // Map the amount of MechConstructionReports to the TeamId
                foreach (MechConstructionReport mechConstructionReport in this.mechConstructionReportSet)
                {
                    TeamIdEnum teamId = mechConstructionReport.GetTeamId();
                    if (!teamIdMechConstructionReportCountDictionary.ContainsKey(teamId))
                    {
                        teamIdMechConstructionReportCountDictionary[teamId] = 0;
                    }
                    teamIdMechConstructionReportCountDictionary[teamId]++;
                }
                int maxTeamId = 6;
                int maxMechs = this.mapConstructionReport.GetMapRadius() * 2;
                int teamCount = teamIdMechConstructionReportCountDictionary.Keys.Count;
                int maxMechPerTeam = (teamCount > 0)
                    ? Mathf.FloorToInt(maxMechs / teamCount)
                    : 0;

                // Check that the Keys for teamIdControllerTypeDictionary are a valid amount
                if (teamIdControllerTypeSet.Count < 2 ||
                    teamIdControllerTypeSet.Count > maxTeamId + 1)
                {
                    argumentExceptionSet.Add("teamIdControllerTypeSet has an invalid amount of " + typeof(TeamIdEnum) + " keys: " + teamIdControllerTypeSet.Count);
                }

                // Check that the Keys for teamIdMechConstructionReportDictionary are a valid amount
                if (this.mechConstructionReportSet.Count < 2 ||
                   this.mechConstructionReportSet.Count > maxMechs)
                {
                    argumentExceptionSet.Add("mechConstructionReportSet has an invalid amount of " + typeof(MechConstructionReport) + ": " + this.mechConstructionReportSet.Count);
                }

                // Check that the Keys are the same for teamIdControllerTypeDictionary and teamIdMechConstructionReportDictionary
                if (!teamIdControllerTypeSet.SetEquals(teamIdMechConstructionReportCountDictionary.Keys))
                {
                    argumentExceptionSet.Add("Set: TeamId are not the same for teamIdControllerTypeDictionary and teamIdMechConstructionReport");
                }

                // Check that the MechConstructionReports are a valid amount for each teamId
                foreach (TeamIdEnum teamId in teamIdMechConstructionReportCountDictionary.Keys)
                {
                    if (teamIdMechConstructionReportCountDictionary[teamId] < 1 ||
                        teamIdMechConstructionReportCountDictionary[teamId] > maxMechPerTeam)
                    {
                        argumentExceptionSet.Add("TeamId: " + teamId + " has an invalid amount of MechConstructionReports: " +
                            teamIdMechConstructionReportCountDictionary[teamId]);
                    }
                }

                // Check that it is not a free-for-all
                if(this.teamIdFactionSet.Count > 0)
                {
                    // Check that the teamIdFactionSet keys is at least 2 factions
                    if (this.teamIdFactionSet.Count < 2)
                    {
                        argumentExceptionSet.Add("teamIdFactionSet must have as many as teamCount");
                    }

                    // Iterate teamIdAlliedTeamIdSetDictionary Keys and verify that all allied teamIds are bi-directional
                    foreach (HashSet<TeamIdEnum> teamIdFaction in this.teamIdFactionSet)
                    {
                        // Iterate over the allied TeamIds
                        foreach (TeamIdEnum teamIdToCheck in teamIdFaction)
                        {
                            int teamIdFactionCount = 0;
                            // Iterate teamIdAlliedTeamIdSetDictionary Keys and verify that all allied teamIds are bi-directional
                            foreach (HashSet<TeamIdEnum> teamIdFactionToCheck in this.teamIdFactionSet)
                            {
                                if(teamIdFactionToCheck.Contains(teamIdToCheck))
                                {
                                    teamIdFactionCount++;
                                }
                            }
                            if(teamIdFactionCount > 1)
                            {
                                argumentExceptionSet.Add(typeof(TeamIdEnum) + ": " + teamIdToCheck + " is in " + teamIdFactionCount + " Factions.");
                            }
                        }
                    }
                }
            }

            // Check that the Set: Argument Strings is greater than 0
            if (argumentExceptionSet.Count > 0)
            {
                throw new ArgumentException("Unable to construct " +
                    this.GetType() + ". Invalid Parameters.\n" +
                    string.Join("\n", argumentExceptionSet));
            }
        }

        #endregion Private Methods
    }

    #endregion Public Classes
}