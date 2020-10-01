/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Enums;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Exceptions;
using System.Diagnostics;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Common.ResourceLoaders
{
    /// <summary>
    /// Todo
    /// </summary>
    public class GameObjectResourceLoader
    {
        // Todo: Store somewhere else. Maybe in a Resources File Structure class
        private static readonly string GAMEOBJECTS_FOLDER_HOME = "GameObjects/";

        // Todo
        private static readonly string GAMEOBJECTS_SUFFIX = "Model";

        // Provide logging capability
        private static readonly Common.Loggers.Logger logger = new Common.Loggers.Logger(new StackFrame().GetMethod().DeclaringType);

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
            private static readonly string CANVAS_GAMEOBJECTS_FOLDER_HOME = GAMEOBJECTS_FOLDER_HOME + "Canvases/";

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
            private static readonly string GAME_HEXTILE_GAMEOBJECT_NAME = "HexTile";

            // Todo
            private static readonly string HEXTILE_GAMEOBJECTS_FOLDER_HOME = GAMEOBJECTS_FOLDER_HOME + "HexTiles/";

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="talonId">
            /// </param>
            /// <returns>
            /// </returns>
            public static GameObject LoadHexTileGameObjectResource()
            {
                GameObject gameObject = LoadGameObjectResource(HEXTILE_GAMEOBJECTS_FOLDER_HOME + GAME_HEXTILE_GAMEOBJECT_NAME + GAMEOBJECTS_SUFFIX);
                return gameObject;
            }
        }

        public class Talons
        {
            // Todo
            private static readonly string TALON_GAMEOBJECTS_FOLDER_HOME = GAMEOBJECTS_FOLDER_HOME + "Talons/";

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
                    GameObject gameObject = LoadGameObjectResource(TALON_GAMEOBJECTS_FOLDER_HOME + talonId.ToString() + GAMEOBJECTS_SUFFIX);
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
            private static readonly string WEAPON_GAMEOBJECTS_FOLDER_HOME = GAMEOBJECTS_FOLDER_HOME + "Weapons/";

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
                    GameObject gameObject = LoadGameObjectResource(WEAPON_GAMEOBJECTS_FOLDER_HOME + weaponId.ToString() + GAMEOBJECTS_SUFFIX);
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