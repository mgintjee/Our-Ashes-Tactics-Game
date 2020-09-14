/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Common.UnityScript;
using System.Diagnostics;
using UnityEngine;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Util.Spawner
{
    /// <summary>
    /// Todo
    /// </summary>
    public class SpawnerUtilScript
    : AbstractUnityScript
    {
        #region Private Fields

        // Provide logging capability
        private static readonly Common.Logging.Logger logger = new Common.Logging.Logger(new StackFrame().GetMethod().DeclaringType);

        #endregion Private Fields

        #region Public Methods

        /// <summary>
        /// Spawner Method, To provide the ability to spawn GameObjects without being a Script
        /// </summary>
        /// <param name="path">The string path to the GameObject Prefab that is desired to be spawned</param>
        /// <returns>The Spawned GameObject is available, Null otherwise</returns>
        public GameObject Spawn(string path)
        {
            logger.Debug("Spawning: GameObject with Path=" + path);
            GameObject prefab = Resources.Load<GameObject>(path);
            if (prefab != null)
            {
                GameObject spawnedGameObject = Instantiate(prefab);
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

        #endregion Public Methods
    }
}