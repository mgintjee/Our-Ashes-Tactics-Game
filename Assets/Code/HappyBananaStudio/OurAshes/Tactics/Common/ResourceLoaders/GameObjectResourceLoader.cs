namespace HappyBananaStudio.OurAshes.Tactics.Common.ResourceLoaders
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Loggers;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Talons;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Utilities;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Weapons;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Exceptions;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Loggers;
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
        /// <param name="path">
        /// </param>
        /// <returns>
        /// </returns>
        public static GameObject LoadGameObjectResource(string path)
        {
            GameObject prefab = Resources.Load<GameObject>(path);
            if (prefab != null)
            {
                GameObject spawnedGameObject = GameObject.Instantiate(prefab);
                if (spawnedGameObject != null)
                {
                    return spawnedGameObject;
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to ?. Invalid parameters. " +
                        "Instantiated GameObject is null for Path=?.", new StackFrame().GetMethod().Name, path);
                }
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid parameters. " +
                    "Prefab is null for Path=?.", new StackFrame().GetMethod().Name, path);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Canvas
        {
            // Todo
            private static readonly string CanvasGameObjectsFolderHome = GameObjectsFolderHome + "Canvases/";

            // Todo
            private static readonly string MVCCanvasGameObjectName = "mvcCanvasGameObject";

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns>
            /// </returns>
            public static GameObject LoadMvcCanvasGameObject()
            {
                GameObject gameObject = LoadGameObjectResource(CanvasGameObjectsFolderHome + MVCCanvasGameObjectName);
                gameObject.name = MVCCanvasGameObjectName;
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
            public static GameObject LoadTalonGameObjectResource(TalonModelId talonId)
            {
                if (!talonId.Equals(TalonModelId.None))
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
            public static GameObject LoadUtilityGameObjectResource(UtilityModelId utilityModelId)
            {
                if (!utilityModelId.Equals(UtilityModelId.None))
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
            public static GameObject LoadWeaponGameObjectResource(WeaponModelId weaponId)
            {
                if (!weaponId.Equals(WeaponModelId.None))
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
    }
}