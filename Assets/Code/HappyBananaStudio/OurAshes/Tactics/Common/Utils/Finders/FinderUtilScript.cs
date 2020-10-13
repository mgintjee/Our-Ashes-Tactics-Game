/// <summary>
/// Company: HappyBananaStudio
/// Author: Matthew Gintjee
/// </summary>

namespace HappyBananaStudio.OurAshesTactics.Common.Utils.Finders
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Loggers;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Loggers;
    using HappyBananaStudio.OurAshesTactics.Common.Scripts.Unity;
    using System.Collections.Generic;
    using System.Diagnostics;
    using UnityEngine;

    public class FinderUtilScript
    : UnityScriptImpl
    {
        // Provide logging capability
        private static readonly ICodeLogger logger = new CodeLoggerImpl(new StackFrame().GetMethod().DeclaringType);

        public ISet<GameObject> FindAllGameObjects(System.Type gameObjectType)
        {
            // Todo Look at this logic again
            logger.Debug("Finding: All GameObjects of Type=?", gameObjectType.Name);
            ISet<GameObject> gameObjectSet = new HashSet<GameObject>();
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
                    else if (obj is UnityScriptImpl)
                    {
                        logger.Debug("Found AbstractUnityScript ? Implementation", gameObjectType.Name);
                        gameObjectSet.Add(((UnityScriptImpl)obj).GetGameObject());
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
