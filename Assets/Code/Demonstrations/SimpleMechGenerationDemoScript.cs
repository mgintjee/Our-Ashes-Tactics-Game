using System.Collections.Generic;
using System.Diagnostics;

/// <summary>
/// Todo
/// </summary>
public class SimpleMechGenerationDemoScript
    : AbstractUnityScript
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    #endregion Private Fields

    #region Public Methods

    public void Start()
    {
        MechScriptGenerationUtil.GenerateMechScript(GenerateRandomMechInfoReport(0, TeamIdEnum.East));
    }

    #endregion Public Methods

    #region Private Methods

    private MechConstructionReport GenerateRandomMechInfoReport(int id, TeamIdEnum teamId)
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
            .SetTeamId(teamId)
            .SetMechTeamIndex(id)
            .SetPaintSchemeReport(PaintConstants.LoadRandomPaintSchemeReport())
            .SetWeaponIdList(weaponIdList)
            .Build();
    }

    #endregion Private Methods
}