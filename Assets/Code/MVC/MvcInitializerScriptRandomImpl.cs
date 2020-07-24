using System.Collections.Generic;

/// <summary>
/// MvcInitializer Script Random Impl
/// </summary>
public class MvcInitializerScriptRandomImpl
    : MvcInitializerScript
{
    #region Private Fields

    private Dictionary<TeamIdEnum, PaintSchemeReport> teamIdPaintSchemeReportDictionary = new Dictionary<TeamIdEnum, PaintSchemeReport>()
    {
        {TeamIdEnum.East, PaintConstants.LoadRandomPaintSchemeReport() },
        {TeamIdEnum.West, PaintConstants.LoadRandomPaintSchemeReport() },
    };

    #endregion Private Fields

    #region Protected Methods

    protected override MvcInitializationReport BuildMvcInitializationReport()
    {
        return new MvcInitializationReport.Builder()
            .SetMapConstructionReport(this.BuildMapConstructionReport())
            .SetTeamIdControllerTypeDictionary(this.BuildTeamIdControllerTypeDictionary())
            .SetTeamIdMechConstructionReportSetDictionary(this.BuildTeamIdMechConstructionReportSet())
            .Build();
    }

    #endregion Protected Methods

    #region Private Methods

    private MapConstructionReport BuildMapConstructionReport()
    {
        return new MapConstructionReport.Builder()
            .SetMapMirrored(MvcInitializationConstants.GetMapMirrored())
            .SetMapRadius(MvcInitializationConstants.GetMapRadius())
            .SetMapSeed(MvcInitializationConstants.GetMapSeed())
            .Build();
    }

    private Dictionary<TeamIdEnum, ControllerTypeEnum> BuildTeamIdControllerTypeDictionary()
    {
        return new Dictionary<TeamIdEnum, ControllerTypeEnum>()
        {
            {TeamIdEnum.East, ControllerTypeEnum.Robot },
            {TeamIdEnum.West, ControllerTypeEnum.Robot }
        };
    }

    private Dictionary<TeamIdEnum, HashSet<MechConstructionReport>> BuildTeamIdMechConstructionReportSet()
    {
        return new Dictionary<TeamIdEnum, HashSet<MechConstructionReport>>()
        {
            {TeamIdEnum.East, new HashSet<MechConstructionReport>()
            {
                BuildRandomMechConstructionReport(TeamIdEnum.East, 0),
            }
            },
            {TeamIdEnum.West, new HashSet<MechConstructionReport>()
            {
                BuildRandomMechConstructionReport(TeamIdEnum.West, 0),
            }
            },
        };
    }

    private MechConstructionReport BuildRandomMechConstructionReport(TeamIdEnum teamId, int mechTeamIndex)
    {
        MechIdEnum mechId = MechAttributeConstants.GetRandomMechId();
        MechAttributes mechAttributes = MechAttributeConstants.GetImplementedMechAttributes(mechId);
        List<WeaponIdEnum> weaponIdList = new List<WeaponIdEnum>();
        for (int i = 0; i < mechAttributes.GetWeaponPoints(); ++i)
        {
            weaponIdList.Add(WeaponAttributeConstants.GetRandomWeaponId());
        }
        return new MechConstructionReport.Builder()
            .SetMechId(MechAttributeConstants.GetRandomMechId())
            .SetMechTeamIndex(mechTeamIndex)
            .SetPaintSchemeReport(teamIdPaintSchemeReportDictionary[teamId])
            .SetTeamId(teamId)
            .SetWeaponIdList(weaponIdList)
            .Build();
    }

    #endregion Private Methods
}