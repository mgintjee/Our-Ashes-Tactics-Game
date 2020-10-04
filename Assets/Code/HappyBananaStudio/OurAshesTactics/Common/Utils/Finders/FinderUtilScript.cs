/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Scripts.Unity;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Utils.Finders
{
    public class FinderUtilScript
    : UnityScript
    {
        // Provide logging capability
        private static readonly Common.Loggers.Logger logger = new Common.Loggers.Logger(new StackFrame().GetMethod().DeclaringType);

        public HashSet<GameObject> FindAllGameObjects(System.Type gameObjectType)
        {
            // Todo Look at this logic again
            logger.Debug("Finding: All GameObjects of Type=?", gameObjectType.Name);
            HashSet<GameObject> gameObjectSet = new HashSet<GameObject>();
            Object[] objectArray = GameObject.FindObjectsOfType(gameObjectType);
            if (objectArray != null &&
                objectArray.Length != 0)
            {
                foreach (Object obj in objectArray)
                {
                    logger.Debug("Found ? Implementation: Name=?", gameObjectType.Name, obj.name);
                    if (obj is GameObject)
                    {
                        logger.Debug("Found GameObject ? Implementation", gameObjectType.Name);
                        gameObjectSet.Add((GameObject)obj);
                    }
                    else if (obj is UnityScript)
                    {
                        logger.Debug("Found AbstractUnityScript ? Implementation", gameObjectType.Name);
                        gameObjectSet.Add(((UnityScript)obj).GetGameObject());
                    }
                }
            }
            else
            {
                logger.Warn("Unable to Find All GameObjects of Type=?. No Objects available.", gameObjectType.Name);
            }
            return gameObjectSet;
        }
    }
}