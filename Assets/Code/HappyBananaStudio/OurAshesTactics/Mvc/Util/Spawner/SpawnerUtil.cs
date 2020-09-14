/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using System.Diagnostics;
using UnityEngine;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Util.Spawner
{
    /// <summary>
    /// Todo
    /// </summary>
    public class SpawnerUtil
    {
        #region Private Fields

        // Provide logging capability
        private static readonly Common.Logging.Logger logger = new Common.Logging.Logger(new StackFrame().GetMethod().DeclaringType);

        private static SpawnerUtilScript spawnerUtilScript;

        #endregion Private Fields

        #region Public Methods

        /// <summary>
        /// </summary>
        /// <param name="mechName"></param>
        /// <returns></returns>
        public static GameObject SpawnCanvas()
        {
            string canvasResourcePath = SpawnerUtilConstants.GetCanvasModelFolderPath();
            return Spawn(canvasResourcePath);
        }

        /// <summary>
        /// </summary>
        /// <param name="weaponName"></param>
        /// <returns></returns>
        public static GameObject SpawnHexTile()
        {
            string tileResourcePath = SpawnerUtilConstants.GetTileModelFolderPath();
            return Spawn(tileResourcePath);
        }

        /// <summary>
        /// </summary>
        /// <param name="mechName"></param>
        /// <returns></returns>
        public static GameObject SpawnMech(string mechName)
        {
            return Spawn(SpawnerUtilConstants.GetMechModelsFolderPath() + mechName);
        }

        /// <summary>
        /// </summary>
        /// <param name="weaponName"></param>
        /// <returns></returns>
        public static GameObject SpawnWeapon(string weaponName)
        {
            return Spawn(SpawnerUtilConstants.GetWeaponModelsFolderPath() + weaponName);
        }

        #endregion Public Methods

        #region Private Methods

        private static void CollectSpawnerUtilGameObject()
        {
            // Find the SpawnerUtil GameObject
            GameObject spawnerUtilGameObject = GameObject.Find(SpawnerScriptConstants.GetSpawnerUtilGameObjectName());
            // Check if the SpawnerUtil GameObject is non-null
            if (spawnerUtilGameObject != null)
            {
                // Collect the SpawnerUtilScript from the GameObject
                SpawnerUtilScript spawnerUtilScript = spawnerUtilGameObject.GetComponent<SpawnerUtilScript>();
                // Check if the SpawnerUtilScript is non-null
                if (spawnerUtilScript != null)
                {
                    SpawnerUtil.spawnerUtilScript = spawnerUtilScript;
                    logger.Debug("Collected SpawnerUtilScript");
                }
                else
                {
                    logger.Error("Error Spawning Model: Loaded Null SpawnerUtilScript");
                }
            }
            else
            {
                logger.Error("Error Spawning Model: Loaded Null SpawnerUtil GameObject");
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="modelPath"></param>
        /// <returns></returns>
        private static GameObject Spawn(string modelPath)
        {
            // Default a null spawned GameObject
            GameObject spawnedGameObject = null;

            // Checking if the GameObjectSpawnerUtil is non-null
            if (spawnerUtilScript == null)
            {
                CollectSpawnerUtilGameObject();
            }

            if (spawnerUtilScript != null)
            {
                spawnedGameObject = spawnerUtilScript.Spawn(modelPath);
                // Check if the spawnedGameObject is null
                if (spawnedGameObject == null)
                {
                    logger.Error("Error Spawning Model: SpawnerUtil Script loaded a null GameObject for Path=?", modelPath);
                }
            }
            else
            {
                logger.Error("Error Spawning Model: SpawnerUtil Script is null");
            }

            // Return the Spawned GameObject
            return spawnedGameObject;
        }

        #endregion Private Methods
    }
}