using System.Diagnostics;
using UnityEngine;

/// <summary>
/// Todo
/// </summary>
public static class MechObjectBuilderUtil
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    #endregion Private Fields

    #region Public Methods

    /// <summary>
    /// Todo
    /// </summary>
    /// <param name="mechConstructionReport"></param>
    /// <returns></returns>
    public static MechObject BuildMechObject(MechConstructionReport mechConstructionReport)
    {
        // Check that the mechConstructionReport is non-null
        if (mechConstructionReport != null)
        {
            logger.Debug("Building ? from ?", typeof(MechObject), mechConstructionReport);
            // Spawn the mechGameObject
            GameObject mechGameObject = new GameObject(mechConstructionReport.GetMechName());
            // Add the mechScript to the GameObject
            MechScript mechScript = mechGameObject.AddComponent<MechScriptImpl>();
            if (mechScript != null)
            {
                // Initialize the mechScript with the mechConstructionReport
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
                        logger.Warn("Unable to Generate ?. ? is null", typeof(WeaponObject), typeof(WeaponScript));
                        GameObject.Destroy(weaponGameObject);
                    }
                }
            }
            else
            {
                logger.Warn("Unable to Generate ?. ? is null", typeof(MechObject), typeof(MechScript));
                GameObject.Destroy(mechGameObject);
            }
            // Return the MechObject if MechScript is present
            return (mechScript != null)
                ? mechScript.GetMechObject()
                : null;
        }
        else
        {
            logger.Error("Unable to build ?. Invalid Parameters.", typeof(MechObject));
            return null;
        }
    }

    #endregion Public Methods
}