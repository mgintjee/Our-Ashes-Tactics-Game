using System.Collections.Generic;
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
                    // Build the List: WeaponObject
                    List<WeaponObject> weaponObjectList = BuildWeaponObjectList(talonConstructionReport.GetWeaponIdList());
                    // Check that all of the WeaponObjects were populated
                    if (weaponObjectList.Count == talonConstructionReport.GetWeaponIdList().Count)
                    {
                        // Add the TalonScript to the GameObject
                        TalonScript talonScript = talonGameObject.AddComponent<TalonScriptImpl>();
                        // Initialize the TalonScript with the TalonConstructionReport and List: WeaponObject
                        talonScript.Initialize(talonConstructionReport, weaponObjectList);
                        // Return the TalonObject
                        return talonScript.GetTalonObject();
                    }
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
    }

    #endregion Public Methods

    #region Private Methods

    private static WeaponObject BuildWeaponObject(WeaponIdEnum weaponId)
    {
        // Spawn the GameObject
        GameObject weaponGameObject = SpawnerUtil.SpawnWeapon(weaponId.ToString());
        if (weaponGameObject != null)
        {
            // Add the WeaponScript to the GameObject
            WeaponScript weaponScript = weaponGameObject.AddComponent<WeaponScriptImpl>();
            // Initialize the WeaponScript with the WeaponIdEnum
            weaponScript.Initialize(weaponId);
            // Return the WeaponObject
            return weaponScript.GetWeaponObject();
        }
        else
        {
            logger.Error("Unable to build ?. Spawned ? is null.", typeof(WeaponObject), typeof(GameObject));
        }
        return null;
    }

    private static List<WeaponObject> BuildWeaponObjectList(List<WeaponIdEnum> weaponIdList)
    {
        List<WeaponObject> weaponObjectList = new List<WeaponObject>();

        foreach (WeaponIdEnum weaponId in weaponIdList)
        {
            WeaponObject weaponObject = BuildWeaponObject(weaponId);
            if (weaponObject != null)
            {
                weaponObjectList.Add(weaponObject);
            }
            else
            {
                logger.Error("Unable to build ?. ? is null.", typeof(WeaponObject), typeof(WeaponObject));
            }
        }

        return weaponObjectList;
    }

    #endregion Private Methods
}