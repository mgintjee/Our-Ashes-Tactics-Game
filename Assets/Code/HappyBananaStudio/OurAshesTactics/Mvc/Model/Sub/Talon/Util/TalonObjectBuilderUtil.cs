/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Impl;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Reports;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Weapon.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Weapon.Enums;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Weapon.Impl;
using HappyBananaStudio.OurAshesTactics.Mvc.Util.Spawner;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Util
{
    /// <summary>
    /// Todo
    /// </summary>
    public static class TalonObjectBuilderUtil
    {
        #region Private Fields

        // Provide logging capability
        private static readonly Common.Logging.Logger logger = new Common.Logging.Logger(new StackFrame().GetMethod().DeclaringType);

        #endregion Private Fields

        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonConstructionReport"></param>
        /// <returns></returns>
        public static ITalonObject BuildTalonObject(TalonConstructionReport talonConstructionReport)
        {
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
                        List<IWeaponObject> weaponObjectList = BuildWeaponObjectList(talonConstructionReport.GetWeaponIdList());
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
                        logger.Error("Unable to build ?. ? is null.", typeof(ITalonObject), typeof(GameObject));
                    }
                }
                else
                {
                    logger.Error("Unable to build ?. ? is null.", typeof(ITalonObject), typeof(TalonIdentificationReport));
                }
            }
            else
            {
                logger.Error("Unable to build ?. ? is null.", typeof(ITalonObject), typeof(TalonConstructionReport));
            }
            return null;
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="weaponId"></param>
        /// <returns></returns>
        private static IWeaponObject BuildWeaponObject(WeaponIdEnum weaponId)
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
                logger.Error("Unable to build ?. Spawned ? is null.", typeof(IWeaponObject), typeof(GameObject));
            }
            return null;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="weaponIdList"></param>
        /// <returns></returns>
        private static List<IWeaponObject> BuildWeaponObjectList(List<WeaponIdEnum> weaponIdList)
        {
            List<IWeaponObject> weaponObjectList = new List<IWeaponObject>();

            foreach (WeaponIdEnum weaponId in weaponIdList)
            {
                IWeaponObject weaponObject = BuildWeaponObject(weaponId);
                if (weaponObject != null)
                {
                    weaponObjectList.Add(weaponObject);
                }
                else
                {
                    logger.Error("Unable to build ?. ? is null.", typeof(IWeaponObject), typeof(IWeaponObject));
                }
            }

            return weaponObjectList;
        }

        #endregion Private Methods
    }
}