using System.Diagnostics;
using UnityEngine;

/// <summary>
/// Todo
/// </summary>
public class MechScriptGenerationUtil
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    #endregion Private Fields

    #region Public Methods

    public static MechScript GenerateMechScript(MechConstructionReport mechConstructionReport)
    {
        if (MechConstructionReportValidatorUtil.ValidMechConstructionReport(mechConstructionReport))
        {
            GameObject mechGameObject = new GameObject(mechConstructionReport.GetMechName());
            MechScript mechScript = mechGameObject.AddComponent<MechScriptImpl>();
            if (mechScript != null)
            {
                mechScript.Initialize(mechConstructionReport);
                foreach (WeaponIdEnum weaponId in mechConstructionReport.GetWeaponIdList())
                {
                    GameObject weaponGameObject = new GameObject(weaponId.ToString());
                    WeaponScript weaponScript = weaponGameObject.AddComponent<WeaponScriptImpl>();
                    WeaponConstructionReport weaponConstructionReport = new WeaponConstructionReport.Builder()
                        .SetWeaponId(weaponId)
                        .SetPaintSchemeReport(mechConstructionReport.GetPaintSchemeReport())
                        .Build();
                    if (weaponScript != null)
                    {
                        weaponScript.Initialize(weaponConstructionReport);
                        mechScript.AddWeapon(weaponScript);
                    }
                    else
                    {
                        logger.Warn("Unable to Generate HashSet: WeaponScript. MechScript is null");
                        GameObject.Destroy(weaponGameObject);
                    }
                }
            }
            else
            {
                logger.Warn("Unable to Generate HashSet: WeaponScript. MechScript is null");
                GameObject.Destroy(mechGameObject);
            }
            return mechScript;
        }
        logger.Warn("Unable to Generate GameObject. ? is invalid.", typeof(MechConstructionReport));
        return null;
    }

    #endregion Public Methods
}