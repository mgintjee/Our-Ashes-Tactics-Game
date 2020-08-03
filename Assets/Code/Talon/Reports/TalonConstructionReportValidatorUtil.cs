using System.Diagnostics;

/// <summary>
/// Todo
/// </summary>
public class TalonConstructionReportValidatorUtil
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    #endregion Private Fields

    /*
    public static bool ValidMechConstructionReport(MechConstructionReport mechConstructionReport)
    {
        if (mechConstructionReport == null)
        {
            logger.Warn("? is null.", typeof(MechConstructionReport));
            return false;
        }
        if (!ValidMechId(mechConstructionReport.GetMechId()))
        {
            logger.Warn("? is contains an unsupported ?=?.",
                typeof(MechConstructionReport), typeof(MechIdEnum), mechConstructionReport.GetMechId());
            return false;
        }
        if (!ValidMechTeam(mechConstructionReport.GetTeamId()))
        {
            logger.Warn("? is contains an unsupported MechTeam=?.",
                typeof(MechConstructionReport), mechConstructionReport.GetTeamId());
            return false;
        }
        if (!ValidWeaponIdList(mechConstructionReport.GetWeaponIdList()))
        {
            logger.Warn("? is contains an unsupported List:?=?.",
                typeof(MechConstructionReport), typeof(WeaponIdEnum), mechConstructionReport.GetWeaponIdList());
            return false;
        }
        return true;
    }

    private static bool ValidMechId(MechIdEnum mechId)
    {
        return MechAttributeConstants.GetImplementedMechAttributes(mechId) != null;
    }

    private static bool ValidMechTeam(TeamIdEnum teamId)
    {
        return true;
    }

    private static bool ValidWeaponIdList(List<WeaponIdEnum> weaponIdList)
    {
        bool validWeaponIdList = weaponIdList != null && weaponIdList.Count != 0;
        if (validWeaponIdList)
        {
            foreach (WeaponIdEnum weaponId in weaponIdList)
            {
                validWeaponIdList = validWeaponIdList && WeaponAttributeConstants.GetImplementedWeaponAttributes(weaponId) != null;
                if (!validWeaponIdList)
                {
                    break;
                }
            }
        }
        return validWeaponIdList;
    }
    */
}