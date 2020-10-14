

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
                // Todo: Rotate the talonGameObject based off of the faction here? or the phalanx?
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
        /// <param name="talonMountsScript">
        /// </param>
        /// <param name="talonConstructionReport">
        /// </param>
        private static void AttachMounts(ITalonMountsScript talonMountsScript, ITalonConstructionReport talonConstructionReport)
        {
            int index = 0;
            foreach (WeaponModelIdEnum weaponModelId in talonConstructionReport.GetWeaponModelIdList())
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
            foreach (UtilityModelIdEnum utilityModelId in talonConstructionReport.GetUtilityModelIdList())
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
        /// </summary>
        /// <param name="talonGameObject">
        /// </param>
        /// <param name="talonCustomizationReport">
        /// </param>
        private static void UpdateTalonGameObjectVisuals(GameObject talonGameObject, ITalonConstructionReport talonConstructionReport)
        {
            GameObject talonEmblemGameObject = GameObjectResourceLoader.Emblems.LoadEmblemGameObjectResource(
                talonConstructionReport.GetTalonIdentificationReport().GetCallSign(),
                talonConstructionReport.GetTalonCustomizationReport());
            talonEmblemGameObject.transform.SetParent(talonGameObject.transform);
            // Todo: Determine best place to have the emblem stay? If there is no x/z adjustment
            //       then it will be consistent positioning regardless of the rotations
            talonEmblemGameObject.transform.localPosition = new Vector3(0, 17.5f, 0);
            talonEmblemGameObject.transform.localEulerAngles = new Vector3(45, -talonGameObject.transform.localEulerAngles.y, 0);
            // Todo: Load the Phalanx Emblem here Then attach it to the talonGameObject Paint the
            // talonGameObject with the materials loaded from the customizationReportHave some
            // constants file that will generate the Material[] based off the
            // talonCustomizationReport and TalonModelId? Or just work to have it all be constantly
            // the same indices in the material
            /*
            MeshRenderer meshRenderer = talonGameObject.GetComponent<MeshRenderer>();
            Material[] materials = meshRenderer.materials;
            materials[1] = MaterialResourceLoader.HexTile.Top.LoadHexTileTopMaterialResource(hexTileType);
            meshRenderer.materials = materials;
            */
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
