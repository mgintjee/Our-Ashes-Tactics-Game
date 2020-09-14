/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using System.Diagnostics;
using UnityEngine;

namespace HappyBananaStudio.OurAshesTactics.Common.ResourceLoader
{
    /// <summary>
    /// Todo
    /// </summary>
    public class GameObjectResourceLoader
    {
        #region Private Fields

        // Todo: Store somewhere else. Maybe in a Resources File Structure class
        private static readonly string GAMEOBJECTS_FOLDER_HOME = "GameObjects/";

        // Provide logging capability
        private static readonly Common.Logging.Logger logger = new Common.Logging.Logger(new StackFrame().GetMethod().DeclaringType);

        #endregion Private Fields

        #region Private Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="modelPath"></param>
        /// <returns></returns>
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

        #endregion Private Methods

        #region Public Classes

        public class Canvas
        {
            #region Private Fields

            // Todo
            private static readonly string CANVAS_GAMEOBJECTS_FOLDER_HOME = GAMEOBJECTS_FOLDER_HOME + "Canvases/";

            // Todo
            private static readonly string MVC_CANVAS_GAMEOBJECT_NAME = "mvcCanvasGameObject";

            // Todo
            private static readonly string TALON_CANVAS_GAMEOBJECT_NAME = "talonCanvasGameObject";

            #endregion Private Fields

            #region Public Methods

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public static GameObject LoadMvcCanvasGameObject()
            {
                GameObject gameObject = LoadGameObjectResource(CANVAS_GAMEOBJECTS_FOLDER_HOME + MVC_CANVAS_GAMEOBJECT_NAME);
                gameObject.name = MVC_CANVAS_GAMEOBJECT_NAME;
                return gameObject;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public static GameObject LoadTalonCanvasGameObject()
            {
                GameObject gameObject = LoadGameObjectResource(CANVAS_GAMEOBJECTS_FOLDER_HOME + TALON_CANVAS_GAMEOBJECT_NAME);
                gameObject.name = TALON_CANVAS_GAMEOBJECT_NAME;
                return gameObject;
            }

            #endregion Public Methods
        }

        #endregion Public Classes
    }
}