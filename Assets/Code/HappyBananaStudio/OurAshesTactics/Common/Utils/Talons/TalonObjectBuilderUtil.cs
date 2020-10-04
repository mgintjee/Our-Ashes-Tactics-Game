/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Talons.Objects;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Weapons.Objects;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Scripts.Talons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Scripts.Weapons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Enums;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.ResourceLoaders;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Utils.Exceptions;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Scripts.Talons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Scripts.Weapons;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Utils.Talons
{
    /// <summary>
    /// Todo
    /// </summary>
    public static class TalonObjectBuilderUtil
    {
        // Provide logging capability
        private static readonly Common.Loggers.Logger logger = new Common.Loggers.Logger(new StackFrame().GetMethod().DeclaringType);

        public static ITalonObject BuildTalonObject(FactionIdEnum factionId, PhalanxIdEnum phalanxId, ITalonConstructionReport talonConstructionReport)
        {
            // Check that the TalonConstructionReport is non-null
            if (talonConstructionReport != null)
            {
                ITalonIdentificationReport talonIdentificationReport = talonConstructionReport.GetTalonIdentificationReport();
                if (talonIdentificationReport != null)
                {
                    // Spawn the GameObject
                    GameObject talonGameObject = GameObjectResourceLoader.Talons
                        .LoadTalonGameObjectResource(talonIdentificationReport.GetTalonId());
                    if (talonGameObject != null)
                    {
                        // Build the List: WeaponObject
                        List<IWeaponObject> weaponObjectList = BuildWeaponObjectList(talonConstructionReport.GetWeaponIdList());
                        // Check that all of the WeaponObjects were populated
                        if (weaponObjectList.Count == talonConstructionReport.GetWeaponIdList().Count)
                        {
                            // Add the TalonScript to the GameObject
                            ITalonScript talonScript = talonGameObject.AddComponent<TalonScriptImpl>();
                            // Initialize the TalonScript with the TalonConstructionReport and List: WeaponObject
                            talonScript.Initialize(factionId, phalanxId, talonConstructionReport, weaponObjectList);
                            // Return the TalonObject
                            return talonScript.GetTalonObject();
                        }
                        else
                        {
                            throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. ? does not have the correct amount of values." +
                                "\n\t> Required=?, Actual=?.",
                                new StackFrame().GetMethod().Name, typeof(List<IWeaponObject>),
                                talonConstructionReport.GetWeaponIdList().Count, weaponObjectList.Count);
                        }
                    }
                    else
                    {
                        throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. Talon ? is null.",
                            new StackFrame().GetMethod().Name, typeof(GameObject));
                    }
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. ? is null.",
                        new StackFrame().GetMethod().Name, typeof(ITalonIdentificationReport));
                }
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. ? is null.",
                    new StackFrame().GetMethod().Name, typeof(ITalonConstructionReport));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="weaponId">
        /// </param>
        /// <returns>
        /// </returns>
        private static IWeaponObject BuildWeaponObject(WeaponModelIdEnum weaponId)
        {
            // Spawn the GameObject
            GameObject weaponGameObject = GameObjectResourceLoader.Weapons
                .LoadWeaponGameObjectResource(weaponId);
            if (weaponGameObject != null)
            {
                // Add the WeaponScript to the GameObject
                IWeaponScript weaponScript = weaponGameObject.AddComponent<WeaponScriptImpl>();
                // Initialize the WeaponScript with the WeaponIdEnum
                weaponScript.Initialize(weaponId);
                // Return the WeaponObject
                return weaponScript.GetWeaponObject();
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. Spawned Weapon ? is null.",
                    new StackFrame().GetMethod().Name, typeof(GameObject));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="weaponIdList">
        /// </param>
        /// <returns>
        /// </returns>
        private static List<IWeaponObject> BuildWeaponObjectList(List<WeaponModelIdEnum> weaponIdList)
        {
            List<IWeaponObject> weaponObjectList = new List<IWeaponObject>();

            foreach (WeaponModelIdEnum weaponId in weaponIdList)
            {
                weaponObjectList.Add(BuildWeaponObject(weaponId));
            }

            return weaponObjectList;
        }
    }
}