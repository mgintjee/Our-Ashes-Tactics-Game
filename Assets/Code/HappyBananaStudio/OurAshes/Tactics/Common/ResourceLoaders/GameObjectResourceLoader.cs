
namespace HappyBananaStudio.OurAshes.Tactics.Common.ResourceLoaders
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Loggers;
    using HappyBananaStudio.OurAshes.Tactics.Common.Constants.Talons.Enums;
    using HappyBananaStudio.OurAshes.Tactics.Common.Constants.Utilities.Enums;
    using HappyBananaStudio.OurAshes.Tactics.Common.Constants.Weapons.Enums;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Loggers;
    using HappyBananaStudio.OurAshesTactics.Common.Utils.Exceptions;
    using System.Diagnostics;
    using UnityEngine;

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
