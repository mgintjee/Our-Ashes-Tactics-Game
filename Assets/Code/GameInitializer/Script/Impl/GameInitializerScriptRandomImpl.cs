using System.Collections.Generic;
using System.Diagnostics;

/// <summary>
/// </summary>
public class GameInitializerScriptRandomImpl
    : GameInitializerScript
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    private PaintSchemeReport TEAM_1_PAINT_SCHEME_REPORT;

    private PaintSchemeReport TEAM_2_PAINT_SCHEME_REPORT;

    #endregion Private Fields

    #region Protected Methods

    protected override List<MechConstructionReport> GetMechConstructionReportList()
    {
        // Todo: Have these be constants or something like all of the frameworks, have default
        // values and have the some be set and retuurn the default if they have not been set yet
        TEAM_1_PAINT_SCHEME_REPORT = PaintConstants.LoadRandomPaintSchemeReport();
        TEAM_2_PAINT_SCHEME_REPORT = PaintConstants.LoadRandomPaintSchemeReport();

        logger.Debug("Generating Random Mech Lists");
        List<MechConstructionReport> mechCreationReportList = new List<MechConstructionReport>();
        int maxMechPerTeam = GameFrameworkObjectConstants.GetMaxMechPerTeam();

        for (int i = 0; i < maxMechPerTeam; ++i)
        {
            mechCreationReportList.Add(this.GenerateRandomMechInfoReport(i, 1));
        }

        for (int i = 0; i < maxMechPerTeam; ++i)
        {
            mechCreationReportList.Add(this.GenerateRandomMechInfoReport(i, 2));
        }
        return mechCreationReportList;
    }

    #endregion Protected Methods

    #region Private Methods

    private MechConstructionReport GenerateRandomMechInfoReport(int id, int team)
    {
        MechIdEnum mechName = MechAttributeConstants.GetRandomMechId();
        List<WeaponIdEnum> weaponIdList = new List<WeaponIdEnum>();
        int weaponMax = MechAttributeConstants.GetImplementedMechAttributes(mechName).GetWeaponPoints();
        for (int i = 0; i < weaponMax; ++i)
        {
            weaponIdList.Add(WeaponAttributeConstants.GetRandomWeaponId());
        }

        return new MechConstructionReport.Builder()
            .SetMechId(mechName)
            .SetMechTeam(team)
            .SetMechTeamIndex(id)
            .SetPaintSchemeReport(
                (team == 1)
                    ? TEAM_1_PAINT_SCHEME_REPORT
                    : TEAM_2_PAINT_SCHEME_REPORT)
            .SetWeaponIdList(weaponIdList)
            .Build();
    }

    #endregion Private Methods
}