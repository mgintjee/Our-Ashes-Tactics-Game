namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.ResourceLoaders.GameObjects
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Mounts.Utilities.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Mounts.Weapons.Enums;
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
        private static readonly ICodeLogger logger = new CodeLogger(new StackFrame().GetMethod().DeclaringType);

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
                GameObject spawnedGameObject = Object.Instantiate(prefab);
                if (spawnedGameObject != null)
                {
                    return spawnedGameObject;
                }
                else
                {
                    throw ExceptionUtil.Arguments.Build("Unable to ?. Invalid parameters. " +
                        "Instantiated GameObject is null for Path=?.", new StackFrame().GetMethod().Name, path);
                }
            }
            else
            {
                throw ExceptionUtil.Arguments.Build("Unable to ?. Invalid parameters. " +
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
            /// <returns></returns>
            public static GameObject LoadHexTileGameObjectResource()
            {
                return LoadGameObjectResource(HexTileGameObjectsFolderHome + HexTileGameObjectName);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Talons
        {
            // Todo
            private static readonly string TalonGameObjectsFolderHome = GameObjectsFolderHome + "Talons/";

            // Todo
            private static readonly string TalonBaseGameObjectName = "TalonBase";

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="talonId">
            /// </param>
            /// <returns>
            /// </returns>
            public static GameObject LoadTalonGameObjectResource(TalonId talonId)
            {
                if (!talonId.Equals(TalonId.None))
                {
                    GameObject talonGameObject = LoadGameObjectResource(TalonGameObjectsFolderHome + talonId.ToString());
                    GameObject talonBaseGameObject = LoadGameObjectResource(TalonGameObjectsFolderHome + TalonBaseGameObjectName);
                    talonBaseGameObject.transform.SetParent(talonGameObject.transform);
                    talonBaseGameObject.transform.localPosition = new Vector3(0, -.4f, 0);
                    return talonGameObject;
                }
                else
                {
                    throw ExceptionUtil.Arguments.Build("Unable to ?. Invalid Parameters.",
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
            /// <param name="utilityId">
            /// </param>
            /// <returns>
            /// </returns>
            public static GameObject LoadUtilityGameObjectResource(UtilityId utilityId)
            {
                if (!utilityId.Equals(UtilityId.None))
                {
                    GameObject gameObject = LoadGameObjectResource(UtiltiesGameObjectsFolderHome +
                        utilityId.ToString() + GameObjectsSuffix);
                    gameObject.name = utilityId.ToString();
                    return gameObject;
                }
                else
                {
                    throw ExceptionUtil.Arguments.Build("Unable to ?. Invalid Parameters.", new StackFrame().GetMethod().Name);
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
            public static GameObject LoadWeaponGameObjectResource(WeaponId weaponId)
            {
                if (!weaponId.Equals(WeaponId.None))
                {
                    GameObject gameObject = LoadGameObjectResource(WeaponGameObjectsFolderHome +
                        weaponId.ToString() + GameObjectsSuffix);
                    gameObject.name = weaponId.ToString();
                    return gameObject;
                }
                else
                {
                    throw ExceptionUtil.Arguments.Build("Unable to ?. Invalid Parameters.", new StackFrame().GetMethod().Name);
                }
            }
        }
    }
}