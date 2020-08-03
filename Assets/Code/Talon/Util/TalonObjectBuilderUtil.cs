using System.Diagnostics;
using UnityEngine;

/// <summary>
/// Todo
/// </summary>
public static class TalonObjectBuilderUtil
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    #endregion Private Fields

    #region Public Methods

    /// <summary>
    /// Todo
    /// </summary>
    /// <param name="talonConstructionReport"></param>
    /// <returns></returns>
    public static TalonObject BuildTalonObject(TalonConstructionReport talonConstructionReport)
    {
        logger.Debug("Building: ?", talonConstructionReport);
        // Check that the TalonConstructionReport is non-null
        if (talonConstructionReport != null)
        {
            TalonIdentificationReport talonIdentificationReport = talonConstructionReport.GetTalonIdentificationReport();
            if (talonIdentificationReport != null)
            {
                // Spawn the GameObject
                GameObject talonGameObject = SpawnerUtil.SpawnMech(talonIdentificationReport.GetTalonId().ToString());
                if (talonGameObject != null)
                {
                    // Add the TalonScript to the GameObject
                    TalonScript talonScript = talonGameObject.AddComponent<TalonScriptImpl>();
                    // Initialize the TalonScript with the TalonConstructionReport
                    talonScript.Initialize(talonConstructionReport);
                    // Return the TalonObject
                    return talonScript.GetTalonObject();
                }
                else
                {
                    logger.Error("Unable to build ?. ? is null.", typeof(TalonObject), typeof(GameObject));
                }
            }
            else
            {
                logger.Error("Unable to build ?. ? is null.", typeof(TalonObject), typeof(TalonIdentificationReport));
            }
        }
        else
        {
            logger.Error("Unable to build ?. ? is null.", typeof(TalonObject), typeof(TalonConstructionReport));
        }
        return null;
        /*
        // Check that the mechConstructionReport is non-null
        if (talonConstructionReport != null)
        {
            logger.Debug("Building ? from ?", typeof(MechObject), talonConstructionReport);
            // Spawn the mechGameObject
            GameObject mechGameObject = new GameObject(talonConstructionReport.GetMechName());
            // Add the mechScript to the GameObject
            MechScript mechScript = mechGameObject.AddComponent<MechScriptImpl>();
            if (mechScript != null)
            {
                // Initialize the mechScript with the mechConstructionReport
                mechScript.Initialize(talonConstructionReport);
                foreach (WeaponIdEnum weaponId in talonConstructionReport.GetWeaponIdList())
                {
                    GameObject weaponGameObject = new GameObject(weaponId.ToString());
                    WeaponScript weaponScript = weaponGameObject.AddComponent<WeaponScriptImpl>();
                    WeaponConstructionReport weaponConstructionReport = new WeaponConstructionReport.Builder()
                        .SetWeaponId(weaponId)
                        .SetPaintSchemeReport(talonConstructionReport.GetPaintSchemeReport())
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
        */
    }

    #endregion Public Methods
}