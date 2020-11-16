namespace HappyBananaStudio.OurAshes.Tactics.Common.Managers.GameObjects
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Coordinates.Objects.Cube;
    using HappyBananaStudio.OurAshes.Tactics.Api.Loggers;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Construction;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Information;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Scripts;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Factions;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Phalanxes;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Utilities;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Weapons;
    using HappyBananaStudio.OurAshes.Tactics.Common.ResourceLoaders;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Exceptions;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Loggers;
    using System.Collections.Generic;
    using System.Diagnostics;
    using UnityEngine;

    /// <summary>
    /// Todo
    /// </summary>
    public class TalonGameObjectManager
    {
        // Todo
        private static readonly IDictionary<FactionId, GameObject> factionIdGameObjectDictionary = new Dictionary<FactionId, GameObject>();

        // Todo
        private static readonly string factionIdGameObjectPrefix = "FactionId: ";

        // Provide logging capability
        private static readonly ICodeLogger logger = new CodeLoggerImpl(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private static readonly IDictionary<PhalanxId, GameObject> phalanxIdGameObjectDictionary = new Dictionary<PhalanxId, GameObject>();

        // Todo
        private static readonly string phalanxIdGameObjectPrefix = "PhalanxId: ";

        // Todo
        private static readonly string talonGameObjectCollectionName = "talonGameObjectCollection";

        // Todo
        private static readonly IDictionary<ITalonIdentificationReport, GameObject> talonIdentificationReportGameObjectDictionary =
            new Dictionary<ITalonIdentificationReport, GameObject>();

        // Todo
        private static GameObject talonGameObjectCollection = null;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonConstructionReport">
        /// </param>
        public static void BuildTalonGameObject(ITalonConstructionReport talonConstructionReport)
        {
            if (talonConstructionReport != null)
            {
                ITalonIdentificationReport talonIdentificationReport = talonConstructionReport.GetTalonIdentificationReport();
                BuildPhalanxIdGameObject(talonIdentificationReport.GetFactionId(), talonIdentificationReport.GetPhalanxId());
                GameObject talonGameObject = GameObjectResourceLoader.Talons.LoadTalonGameObjectResource(talonIdentificationReport.GetTalonModelId());
                ITalonMountsScript talonMountsScript = talonGameObject.GetComponent<ITalonMountsScript>();
                AttachMounts(talonMountsScript, talonConstructionReport);
                UpdateTalonGameObjectVisuals(talonGameObject, talonConstructionReport);
                talonIdentificationReportGameObjectDictionary.Add(talonIdentificationReport, talonGameObject);
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
        /// <param name="talonIdentificationReport">
        /// </param>
        public static void DeactivateTalonIdentificationReport(ITalonIdentificationReport talonIdentificationReport)
        {
            GameObject.Destroy(talonIdentificationReportGameObjectDictionary[talonIdentificationReport]);
            talonIdentificationReportGameObjectDictionary.Remove(talonIdentificationReport);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonIdentificationReport">
        /// </param>
        /// <returns>
        /// </returns>
        public static GameObject GetTalonGameObject(ITalonIdentificationReport talonIdentificationReport)
        {
            if (talonIdentificationReportGameObjectDictionary.ContainsKey(talonIdentificationReport))
            {
                return talonIdentificationReportGameObjectDictionary[talonIdentificationReport];
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. ?=? is not tracked",
                    new StackFrame().GetMethod().Name, typeof(ITalonIdentificationReport), talonIdentificationReport);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonIdentificationReport">
        /// </param>
        /// <returns>
        /// </returns>
        public static Vector3 GetTalonWorldPosition(ITalonIdentificationReport talonIdentificationReport)
        {
            if (talonIdentificationReportGameObjectDictionary.ContainsKey(talonIdentificationReport))
            {
                return talonIdentificationReportGameObjectDictionary[talonIdentificationReport].transform.position;
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. ?=? is not tracked",
                    new StackFrame().GetMethod().Name, typeof(ITalonIdentificationReport), talonIdentificationReport);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonIdentificationReport">
        /// </param>
        /// <param name="newWorldPosition">
        /// </param>
        public static void UpdateTalonWorldPosition(ITalonIdentificationReport talonIdentificationReport, ICubeCoordinates cubeCoordinates)
        {
            if (talonIdentificationReportGameObjectDictionary.ContainsKey(talonIdentificationReport))
            {
                Vector3 cubeCoordinatesWorldPosition = HexTileGameObjectManager.GetHexTileWorldPosition(cubeCoordinates);
                cubeCoordinatesWorldPosition.y = 0;
                talonIdentificationReportGameObjectDictionary[talonIdentificationReport].transform.position = cubeCoordinatesWorldPosition;
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. ?=? is not tracked",
                    new StackFrame().GetMethod().Name, typeof(ITalonIdentificationReport), talonIdentificationReport);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonIdentificationReport">
        /// </param>
        /// <param name="newWorldPosition">
        /// </param>
        public static void UpdateTalonWorldPosition(ITalonIdentificationReport talonIdentificationReport, Vector3 worldPosition)
        {
            if (talonIdentificationReportGameObjectDictionary.ContainsKey(talonIdentificationReport))
            {
                worldPosition.y = 0;
                talonIdentificationReportGameObjectDictionary[talonIdentificationReport].transform.position = worldPosition;
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. ?=? is not tracked",
                    new StackFrame().GetMethod().Name, typeof(ITalonIdentificationReport), talonIdentificationReport);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonMountsScript">
        /// </param>
        /// <param name="talonConstructionReport">
        /// </param>
        private static void AttachMounts(ITalonMountsScript talonMountsScript, ITalonConstructionReport talonConstructionReport)
        {
            int index = 0;
            foreach (WeaponModelId weaponModelId in talonConstructionReport.GetWeaponModelIdList())
            {
                if (index < talonMountsScript.GetWeaponMountCount())
                {
                    GameObject weaponMountGameObject = talonMountsScript.GetWeaponMountGameObject(index);
                    GameObject weaponGameObject = GameObjectResourceLoader.Weapons.LoadWeaponGameObjectResource(weaponModelId);
                    weaponGameObject.name = weaponModelId.ToString();
                    weaponGameObject.transform.SetParent(weaponMountGameObject.transform);
                    weaponGameObject.transform.localPosition = Vector3.zero;
                    index++;
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to ?. WeaponMountIndex=? is out of bounds. Must be less than ?.",
                        new StackFrame().GetMethod().Name, index, talonMountsScript.GetWeaponMountCount());
                }
            }
            index = 0;
            foreach (UtilityModelId utilityModelId in talonConstructionReport.GetUtilityModelIdList())
            {
                if (index < talonMountsScript.GetUtilityMountCount())
                {
                    GameObject utilityMountGameObject = talonMountsScript.GetUtilityMountGameObject(index);
                    GameObject utilityGameObject = GameObjectResourceLoader.Utilities.LoadUtilityGameObjectResource(utilityModelId);
                    utilityGameObject.name = utilityModelId.ToString();
                    utilityGameObject.transform.SetParent(utilityMountGameObject.transform);
                    utilityGameObject.transform.localPosition = Vector3.zero;
                    index++;
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to ?. UtilityMountIndex=? is out of bounds. Must be less than ?.",
                        new StackFrame().GetMethod().Name, index, talonMountsScript.GetUtilityMountCount());
                }
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="factionId">
        /// </param>
        private static void BuildFactionIdGameObject(FactionId factionIdEnum)
        {
            if (!factionIdEnum.Equals(FactionId.None))
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
        /// <param name="factionId">
        /// </param>
        /// <param name="phalanxId">
        /// </param>
        private static void BuildPhalanxIdGameObject(FactionId factionId, PhalanxId phalanxId)
        {
            BuildTalonGameObjectCollection();
            if (!factionId.Equals(FactionId.None))
            {
                BuildFactionIdGameObject(factionId);
                if (!phalanxId.Equals(PhalanxId.None))
                {
                    if (!phalanxIdGameObjectDictionary.ContainsKey(phalanxId))
                    {
                        GameObject phalanxIdGameObject = new GameObject(phalanxIdGameObjectPrefix + factionId);
                        phalanxIdGameObject.transform.SetParent(factionIdGameObjectDictionary[factionId].transform);
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
                    new StackFrame().GetMethod().Name, factionId);
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

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="factionId">
        /// </param>
        /// <returns>
        /// </returns>
        private static Vector3 GetLocalEulerAnglesFor(FactionId factionId)
        {
            switch (factionId)
            {
                case FactionId.CreativeFaction1:
                    return new Vector3(0, 60, 0);

                case FactionId.CreativeFaction2:
                    return new Vector3(0, 120, 0);

                case FactionId.CreativeFaction3:
                    return new Vector3(0, 240, 0);

                case FactionId.CreativeFaction4:
                    return new Vector3(0, 300, 0);

                default:
                    throw ArgumentExceptionUtil.Build("Unable to ?. ? is not supported.",
                        new StackFrame().GetMethod().Name, factionId);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="talonGameObject">
        /// </param>
        /// <param name="talonCustomizationReport">
        /// </param>
        private static void UpdateTalonGameObjectVisuals(GameObject talonGameObject, ITalonConstructionReport talonConstructionReport)
        {
            /*
            ITalonEmblemWidget talonEmblemWidget = WidgetResourceLoader.Emblems.LoadTalonEmblemWidgetResource(
                talonConstructionReport.GetTalonIdentificationReport().GetCallSign(),
                talonConstructionReport.GetTalonCustomizationReport());
            talonEmblemWidget.GetTransform().SetParent(talonGameObject.transform);
            // Todo: Store these somewhere
            talonEmblemWidget.UpdateEmblemScale(new Vector3(0.06f, 0.06f, 0.06f));
            talonEmblemWidget.GetTransform().localPosition = new Vector3(0, 17.5f, 0);
            talonEmblemWidget.GetTransform().localEulerAngles = new Vector3(-45, 0, 0);
            */
            // Todo: Load the Phalanx Emblem here Then attach it to the talonGameObject Paint the
            // talonGameObject with the materials loaded from the customizationReportHave some
            // constants file that will generate the Material[] based off the
            // talonCustomizationReport and TalonModelId? Or just work to have it all be constantly
            // the same indices in the material
            // Todo: color the GameObject with Materials
            /*
            MeshRenderer meshRenderer = talonGameObject.GetComponent<MeshRenderer>();
            Material[] materials = meshRenderer.materials;
            materials[1] = MaterialResourceLoader.HexTile.Top.LoadHexTileTopMaterialResource(hexTileType);
            meshRenderer.materials = materials;
            */
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
