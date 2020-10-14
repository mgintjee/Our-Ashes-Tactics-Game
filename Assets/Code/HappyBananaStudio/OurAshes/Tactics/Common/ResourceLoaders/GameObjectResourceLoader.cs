
namespace HappyBananaStudio.OurAshes.Tactics.Common.ResourceLoaders
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Loggers;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Customization;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Talons;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Utilities;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Weapons;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Emblems;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Exceptions;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Loggers;
    using System.Diagnostics;
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// Todo
    /// </summary>
    public class GameObjectResourceLoader
    {
        // Todo: Store somewhere else. Maybe in a Resources File Structure class
        private static readonly string GameObjectsFolderHome = "GameObjects/";

        // Todo
        private static readonly string GameObjectsSuffix = "Model";

        // Provide logging capability
        private static readonly ICodeLogger logger = new CodeLoggerImpl(new StackFrame().GetMethod().DeclaringType);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="modelPath">
        /// </param>
        /// <returns>
        /// </returns>
        private static GameObject LoadGameObjectResource(string modelPath)
        {
            GameObject prefab = Resources.Load<GameObject>(modelPath);
            if (prefab != null)
            {
                GameObject spawnedGameObject = GameObject.Instantiate(prefab);
                if (spawnedGameObject != null)
                {
                    return spawnedGameObject;
                }
                else
                {
                    logger.Error("Error: spawned GameObject is null");
                }
            }
            else
            {
                logger.Error("Error: prefab is null");
            }
            return null;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Canvas
        {
            // Todo
            private static readonly string CANVAS_GAMEOBJECTS_FOLDER_HOME = GameObjectsFolderHome + "Canvases/";

            // Todo
            private static readonly string MVC_CANVAS_GAMEOBJECT_NAME = "mvcCanvasGameObject";

            // Todo
            private static readonly string TALON_CANVAS_GAMEOBJECT_NAME = "talonCanvasGameObject";

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns>
            /// </returns>
            public static GameObject LoadMvcCanvasGameObject()
            {
                GameObject gameObject = LoadGameObjectResource(CANVAS_GAMEOBJECTS_FOLDER_HOME + MVC_CANVAS_GAMEOBJECT_NAME);
                gameObject.name = MVC_CANVAS_GAMEOBJECT_NAME;
                return gameObject;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns>
            /// </returns>
            public static GameObject LoadTalonCanvasGameObject()
            {
                GameObject gameObject = LoadGameObjectResource(CANVAS_GAMEOBJECTS_FOLDER_HOME + TALON_CANVAS_GAMEOBJECT_NAME);
                gameObject.name = TALON_CANVAS_GAMEOBJECT_NAME;
                return gameObject;
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class HexTiles
        {
            // Todo
            private static readonly string HexTileGameObjectName = "HexTile";

            // Todo
            private static readonly string HexTileGameObjectsFolderHome = GameObjectsFolderHome + "HexTiles/";

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="talonId">
            /// </param>
            /// <returns>
            /// </returns>
            public static GameObject LoadHexTileGameObjectResource()
            {
                GameObject gameObject = LoadGameObjectResource(HexTileGameObjectsFolderHome + HexTileGameObjectName + GameObjectsSuffix);
                return gameObject;
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Talons
        {
            // Todo
            private static readonly string TalonGameObjectsFolderHome = GameObjectsFolderHome + "Talons/";

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="talonId">
            /// </param>
            /// <returns>
            /// </returns>
            public static GameObject LoadTalonGameObjectResource(TalonModelIdEnum talonId)
            {
                if (!talonId.Equals(TalonModelIdEnum.None))
                {
                    GameObject gameObject = LoadGameObjectResource(TalonGameObjectsFolderHome + talonId.ToString() + GameObjectsSuffix);
                    gameObject.name = talonId.ToString();
                    return gameObject;
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters.",
                        new StackFrame().GetMethod().Name);
                }
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Emblems
        {
            // Todo
            private static readonly string EmblemGameObjectsFolderHome = GameObjectsFolderHome + "Emblems/";

            // Todo
            private static readonly string EmblemGameObjectName = "talonEmblemGameObject";

            // Todo
            private static readonly string BackgroundGameObjectName = "backgroundImage";

            // Todo
            private static readonly string IconGameObjectName = "iconImage";

            // Todo
            private static readonly string FactionEmblemGameObjectName = "factionEmblem";

            // Todo
            private static readonly string PhalanxEmblemGameObjectName = "phalanxEmblem";

            // Todo
            private static readonly string CallSignGameObjectName = "callSignText";

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="callSign">
            /// </param>
            /// <param name="talonCustomizationReport">
            /// </param>
            /// <returns>
            /// </returns>
            public static GameObject LoadEmblemGameObjectResource(CallSignEnum callSign,
                ITalonCustomizationReport talonCustomizationReport)
            {
                if (talonCustomizationReport != null)
                {
                    GameObject talonEmblemGameObject = LoadGameObjectResource(EmblemGameObjectsFolderHome + EmblemGameObjectName);
                    GameObject factionEmblemGameObject = talonEmblemGameObject.transform.Find(FactionEmblemGameObjectName).gameObject;
                    GameObject phalanxEmblemGameObject = talonEmblemGameObject.transform.Find(PhalanxEmblemGameObjectName).gameObject;
                    GameObject callSignTextGameObject = talonEmblemGameObject.transform.Find(CallSignGameObjectName).gameObject;
                    callSignTextGameObject.GetComponent<Text>().text = CallSignsUtil.GetCharacter(callSign);

                    UpdateEmblemGameObject(factionEmblemGameObject, talonCustomizationReport.GetFactionColorSchemeReport(),
                        talonCustomizationReport.GetFactionEmblemSchemeReport());
                    UpdateEmblemGameObject(phalanxEmblemGameObject, talonCustomizationReport.GetPhalanxColorSchemeReport(),
                        talonCustomizationReport.GetPhalanxEmblemSchemeReport());
                    talonEmblemGameObject.name = EmblemGameObjectName;

                    return talonEmblemGameObject;
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters.",
                        new StackFrame().GetMethod().Name);
                }
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="emblemGameObject">
            /// </param>
            /// <param name="colorSchemeReport">
            /// </param>
            /// <param name="emblemSchemeReport">
            /// </param>
            private static void UpdateEmblemGameObject(GameObject emblemGameObject,
                IColorSchemeReport colorSchemeReport, IEmblemSchemeReport emblemSchemeReport)
            {
                emblemGameObject.transform.Find(BackgroundGameObjectName).GetComponent<Image>().sprite =
                    SpriteResourceLoader.Background.LoadSpriteBackgroundResource(emblemSchemeReport.GetEmblemBackgroundId());
                emblemGameObject.transform.Find(IconGameObjectName).GetComponent<Image>().sprite =
                    SpriteResourceLoader.Icon.LoadSpriteIconResource(emblemSchemeReport.GetEmblemIconId());

                emblemGameObject.GetComponent<Image>().color = EmblemColorUtil.GetColor(colorSchemeReport.GetPrimaryPaintColorId());
                emblemGameObject.transform.Find(BackgroundGameObjectName).GetComponent<Image>().color =
                    EmblemColorUtil.GetColor(colorSchemeReport.GetSecondaryPaintColorId());
                emblemGameObject.transform.Find(IconGameObjectName).GetComponent<Image>().color =
                    EmblemColorUtil.GetColor(colorSchemeReport.GetTertiaryPaintColorId());
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Weapons
        {
            // Todo
            private static readonly string WeaponGameObjectsFolderHome = GameObjectsFolderHome + "Weapons/";

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="weaponId">
            /// </param>
            /// <returns>
            /// </returns>
            public static GameObject LoadWeaponGameObjectResource(WeaponModelIdEnum weaponId)
            {
                if (!weaponId.Equals(WeaponModelIdEnum.None))
                {
                    GameObject gameObject = LoadGameObjectResource(WeaponGameObjectsFolderHome + weaponId.ToString() + GameObjectsSuffix);
                    gameObject.name = weaponId.ToString();
                    return gameObject;
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters.", new StackFrame().GetMethod().Name);
                }
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Utilities
        {
            // Todo
            private static readonly string UtiltiesGameObjectsFolderHome = GameObjectsFolderHome + "Utilities/";

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="utilityModelId">
            /// </param>
            /// <returns>
            /// </returns>
            public static GameObject LoadUtilityGameObjectResource(UtilityModelIdEnum utilityModelId)
            {
                if (!utilityModelId.Equals(UtilityModelIdEnum.None))
                {
                    GameObject gameObject = LoadGameObjectResource(UtiltiesGameObjectsFolderHome + utilityModelId.ToString() + GameObjectsSuffix);
                    gameObject.name = utilityModelId.ToString();
                    return gameObject;
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters.", new StackFrame().GetMethod().Name);
                }
            }
        }
    }
}
