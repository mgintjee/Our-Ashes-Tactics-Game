using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using System.Diagnostics;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.ResourceLoaders.GameObjects
{
    /// <summary>
    /// Todo
    /// </summary>
    public class GameObjectResourceLoader
    {
        // Todo: Store somewhere else. Maybe in a Resources File Structure class
        protected static readonly string GameObjectsFolderHome = "GameObjects/";

        // Todo
        protected static readonly string GameObjectsSuffix = "Model";

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        protected static GameObject LoadGameObjectResource(string path)
        {
            GameObject prefab = Resources.Load<GameObject>(path);
            if (prefab != null)
            {
                GameObject spawnedGameObject = Object.Instantiate(prefab);
                if (spawnedGameObject != null)
                {
                    return spawnedGameObject;
                }
                throw ExceptionUtil.Arguments.Build("Unable to {}. Invalid parameters. " +
                    "Instantiated GameObject is null for Path={}.", new StackFrame().GetMethod().Name, path);
            }
            throw ExceptionUtil.Arguments.Build("Unable to {}. Invalid parameters. " +
                "Prefab is null for Path={}.", new StackFrame().GetMethod().Name, path);
        }
    }
}