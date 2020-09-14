/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Util.Finder
{
    public class FinderUtil
    {
        #region Private Fields

        // Provide logging capability
        private static readonly Common.Logging.Logger logger = new Common.Logging.Logger(new StackFrame().GetMethod().DeclaringType);

        private static FinderUtilScript finderUtilScript;

        #endregion Private Fields

        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static HashSet<GameObject> FindAllGameObjectType(System.Type type)
        {
            logger.Debug("Finding Type: Name=?", type.Name);
            return Find(type);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static GameObject FindGameObjectType(System.Type type)
        {
            logger.Debug("Finding Type: Name=?", type.Name);
            HashSet<GameObject> foundGameObjectSet = Find(type);
            if (foundGameObjectSet.Count > 0)
            {
                logger.Debug("Found ? GameObjects of Type: Name=?. Returning only one.", foundGameObjectSet.Count, type.Name);
                List<GameObject> foundGameObjectList = new List<GameObject>(foundGameObjectSet);
                return foundGameObjectList[0];
            }
            else
            {
                logger.Warn("Found 0 GameObjects of Type: Name=?. Returning null.", type.Name);
                return null;
            }
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Todo
        /// </summary>
        private static void CollectFinderUtilGameObject()
        {
            // Find the FinderUtil GameObject
            GameObject finderUtilGameObject = GameObject.Find(FinderScriptConstants.GetFinderUtilGameObjectName());
            // Check if the FinderUtil GameObject is non-null
            if (finderUtilGameObject != null)
            {
                // Collect the FinderUtilScript from the GameObject
                FinderUtilScript finderUtilScript = finderUtilGameObject.GetComponent<FinderUtilScript>();
                // Check if the FinderUtilScript is non-null
                if (finderUtilScript != null)
                {
                    FinderUtil.finderUtilScript = finderUtilScript;
                    logger.Debug("Collected FinderUtilScript");
                }
                else
                {
                    logger.Error("Error Loading Model: Loaded Null FinderUtilScript");
                }
            }
            else
            {
                logger.Error("Error Loading Model: Loaded Null FinderUtil GameObject");
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static HashSet<GameObject> Find(System.Type type)
        {
            // Default a null found GameObject
            HashSet<GameObject> foundGameObjectSet = new HashSet<GameObject>();

            // Checking if the GameObjectSpawnerUtil is non-null
            if (finderUtilScript == null)
            {
                CollectFinderUtilGameObject();
            }

            if (finderUtilScript != null)
            {
                foreach (GameObject foundObject in finderUtilScript.FindAllGameObjects(type))
                {
                    if (foundObject != null)
                    {
                        logger.Debug("Found GameObject: Name=?", foundObject.name);
                        foundGameObjectSet.Add(foundObject);
                    }
                }
            }
            else
            {
                logger.Error("Error Finding GameObject: FinderUtil Script is null");
            }

            return foundGameObjectSet;
        }

        #endregion Private Methods
    }
}