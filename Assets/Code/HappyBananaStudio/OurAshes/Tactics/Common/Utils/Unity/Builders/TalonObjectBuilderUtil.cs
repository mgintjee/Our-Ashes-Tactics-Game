/// <summary>
/// Company: HappyBananaStudio
/// Author: Matthew Gintjee
/// </summary>

namespace HappyBananaStudio.OurAshesTactics.Common.Utils.Talons
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Loggers;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Construction;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Information;
    using HappyBananaStudio.OurAshes.Tactics.Common.Constants.Factions.Enums;
    using HappyBananaStudio.OurAshes.Tactics.Common.Constants.Phalanxes.Enums;
    using HappyBananaStudio.OurAshes.Tactics.Common.ResourceLoaders;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Loggers;
    using HappyBananaStudio.OurAshesTactics.Common.Utils.Exceptions;
    using System.Collections.Generic;
    using System.Diagnostics;
    using UnityEngine;

    /// <summary>
    /// Todo
    /// </summary>
    public static class TalonGameObjectBuilderUtil
    {
        // Provide logging capability
        private static readonly ICodeLogger logger = new CodeLoggerImpl(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private static readonly IDictionary<FactionIdEnum, GameObject> factionIdGameObjectDictionary = new Dictionary<FactionIdEnum, GameObject>();

        // Todo
        private static readonly IDictionary<PhalanxIdEnum, GameObject> phalanxIdGameObjectDictionary = new Dictionary<PhalanxIdEnum, GameObject>();

        // Todo
        private static readonly IDictionary<ITalonIdentificationReport, GameObject> talonIdentificationReportGameObjectDictionary =
            new Dictionary<ITalonIdentificationReport, GameObject>();

        // Todo
        private static readonly string talonGameObjectCollectionName = "talonGameObjectCollection";

        // Todo
        private static readonly string factionIdGameObjectPrefix = "FactionId: ";

        // Todo
        private static readonly string phalanxIdGameObjectPrefix = "PhalanxId: ";

        // Todo
        private static GameObject talonGameObjectCollection = null;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonConstructionReport">
        /// </param>
        private static void BuildTalonGameObject(ITalonConstructionReport talonConstructionReport)
        {
            if (talonConstructionReport != null)
            {
                ITalonIdentificationReport talonIdentificationReport = talonConstructionReport.GetTalonIdentificationReport();
                BuildPhalanxIdGameObject(talonIdentificationReport.GetFactionId(), talonIdentificationReport.GetPhalanxId());
                GameObject talonGameObject = GameObjectResourceLoader.Talons
                    .LoadTalonGameObjectResource(talonIdentificationReport.GetTalonModelId());
                talonGameObject.transform.SetParent(phalanxIdGameObjectDictionary[talonIdentificationReport.GetPhalanxId()].transform);
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid parameters.", new StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="factionIdEnum">
        /// </param>
        /// <param name="phalanxId">
        /// </param>
        private static void BuildPhalanxIdGameObject(FactionIdEnum factionIdEnum, PhalanxIdEnum phalanxId)
        {
            BuildTalonGameObjectCollection();
            if (!factionIdEnum.Equals(FactionIdEnum.None))
            {
                BuildFactionIdGameObject(factionIdEnum);
                if (!phalanxId.Equals(PhalanxIdEnum.None))
                {
                    if (!phalanxIdGameObjectDictionary.ContainsKey(phalanxId))
                    {
                        GameObject phalanxIdGameObject = new GameObject(phalanxIdGameObjectPrefix + factionIdEnum);
                        phalanxIdGameObject.transform.SetParent(factionIdGameObjectDictionary[factionIdEnum].transform);
                        phalanxIdGameObjectDictionary.Add(phalanxId, phalanxIdGameObject);
                    }
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to ?. Invalid parameters. ? is not supported.",
                        new StackFrame().GetMethod().Name, phalanxId);
                }
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid parameters. ? is not supported.",
                    new StackFrame().GetMethod().Name, factionIdEnum);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="factionIdEnum">
        /// </param>
        private static void BuildFactionIdGameObject(FactionIdEnum factionIdEnum)
        {
            if (!factionIdEnum.Equals(FactionIdEnum.None))
            {
                if (!factionIdGameObjectDictionary.ContainsKey(factionIdEnum))
                {
                    GameObject factionIdGameObject = new GameObject(factionIdGameObjectPrefix + factionIdEnum);
                    factionIdGameObject.transform.SetParent(talonGameObjectCollection.transform);
                    factionIdGameObjectDictionary.Add(factionIdEnum, factionIdGameObject);
                }
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid parameters.", new StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        private static void BuildTalonGameObjectCollection()
        {
            if (talonGameObjectCollection == null)
            {
                talonGameObjectCollection = new GameObject(talonGameObjectCollectionName);
            }
        }

        /*
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
                        .LoadTalonGameObjectResource(talonIdentificationReport.GetTalonModelId());
                    if (talonGameObject != null)
                    {
                        // Build the List: WeaponObject
                        IList<IWeaponObject> weaponObjectList = BuildWeaponObjectList(talonConstructionReport.GetWeaponIdList());
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
                                new StackFrame().GetMethod().Name, typeof(IList<IWeaponObject>),
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
        private static IList<IWeaponObject> BuildWeaponObjectList(IList<WeaponModelIdEnum> weaponIdList)
        {
            IList<IWeaponObject> weaponObjectList = new List<IWeaponObject>();

            foreach (WeaponModelIdEnum weaponId in weaponIdList)
            {
                weaponObjectList.Add(BuildWeaponObject(weaponId));
            }

            return weaponObjectList;
        }
        */
    }
}
