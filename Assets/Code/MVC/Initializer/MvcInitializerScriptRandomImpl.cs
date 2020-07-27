using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

/// <summary>
/// MvcInitializer Script Random Impl
/// </summary>
public class MvcInitializerScriptRandomImpl
    : MvcInitializerScript
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    private readonly System.Random random = new System.Random();
    private bool mapIsMirrored;
    private int mapRadius;
    private int mapSeed;

    private HashSet<TeamIdEnum> teamIdSet = new HashSet<TeamIdEnum>()
    {
        TeamIdEnum.East, TeamIdEnum.NorthWest, TeamIdEnum.SouthWest
    };

    private Dictionary<TeamIdEnum, PaintSchemeReport> teamIdPaintSchemeReportDictionary;

    #endregion Private Fields

    #region Protected Methods

    protected override MvcInitializationReport BuildMvcInitializationReport()
    {
        this.mapIsMirrored = true;//this.random.Next() % 2 == 0;
        this.mapRadius = this.random.Next(2, 5);
        this.mapSeed = this.random.Next();
        this.teamIdSet = this.BuildTeamIdSet();
        MvcInitializationReport mvcInitializationReport = new MvcInitializationReport.Builder()
            .SetMapConstructionReport(this.BuildMapConstructionReport())
            .SetTeamIdControllerTypeDictionary(this.BuildTeamIdControllerTypeDictionary())
            .SetMechConstructionReportSet(this.BuildMechConstructionReportSet())
            .SetTeamIdFactionSet(new HashSet<HashSet<TeamIdEnum>>())
            .Build();
        logger.Info("Building: ?", mvcInitializationReport);
        return mvcInitializationReport;
    }

    #endregion Protected Methods

    #region Private Methods

    private HashSet<TeamIdEnum> BuildTeamIdSet()
    {
        return TeamIdConstants.GetTeamIdSet(random.Next(2,6), true);
    }

    private MapConstructionReport BuildMapConstructionReport()
    {
        return new MapConstructionReport.Builder()
            .SetMapMirrored(this.mapIsMirrored)
            .SetMapRadius(this.mapRadius)
            .SetMapSeed(this.mapSeed)
            .Build();
    }

    private Dictionary<TeamIdEnum, ControllerTypeEnum> BuildTeamIdControllerTypeDictionary()
    {
        Dictionary<TeamIdEnum, ControllerTypeEnum> teamIdControllerTypeDictionary = new Dictionary<TeamIdEnum, ControllerTypeEnum>();

        foreach (TeamIdEnum teamId in this.teamIdSet)
        {
            teamIdControllerTypeDictionary.Add(teamId, ControllerTypeEnum.Robot);
        }
        return teamIdControllerTypeDictionary;
    }

    private HashSet<MechConstructionReport> BuildMechConstructionReportSet()
    {
        int maxMechs = this.mapRadius * 2;
        int teamCount = this.teamIdSet.Count;
        int mechPerTeam = Mathf.CeilToInt(maxMechs / teamCount);
        HashSet<MechConstructionReport> mechConstructionReportSet = new HashSet<MechConstructionReport>();

        foreach (TeamIdEnum teamId in this.teamIdSet)
        {
            for (int i = 0; i < mechPerTeam; ++i)
            {
                mechConstructionReportSet.Add(BuildRandomMechConstructionReport(teamId, i));
            }
        }

        return mechConstructionReportSet;
    }

    private MechConstructionReport BuildRandomMechConstructionReport(TeamIdEnum teamId, int mechTeamIndex)
    {
        if (this.teamIdPaintSchemeReportDictionary == null)
        {
            this.teamIdPaintSchemeReportDictionary = new Dictionary<TeamIdEnum, PaintSchemeReport>();
            foreach (TeamIdEnum team in this.teamIdSet)
            {
                this.teamIdPaintSchemeReportDictionary.Add(team, PaintConstants.LoadRandomPaintSchemeReport());
            }
        }

        MechIdEnum mechId = MechAttributeConstants.GetRandomMechId();
        List<WeaponIdEnum> weaponIdList = new List<WeaponIdEnum>();
        MechAttributes mechAttributes = MechAttributeConstants.GetImplementedMechAttributes(mechId);
        for (int i = 0; i < mechAttributes.GetWeaponPoints(); ++i)
        {
            weaponIdList.Add(WeaponAttributeConstants.GetRandomWeaponId());
        }
        return new MechConstructionReport.Builder()
            .SetMechId(MechAttributeConstants.GetRandomMechId())
            .SetMechTeamIndex(mechTeamIndex)
            .SetPaintSchemeReport(this.teamIdPaintSchemeReportDictionary[teamId])
            .SetTeamId(teamId)
            .SetWeaponIdList(weaponIdList)
            .Build();
    }

    #endregion Private Methods
}