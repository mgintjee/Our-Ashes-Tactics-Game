using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Frames.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Unity.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Unity.Inters;
using System;
using UnityEngine;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Unity.Utils
{
    /// <summary>
    /// Todo
    /// </summary>
    public class UnityScriptUtils
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static IUnityScript BuildViewUnityScript(Type type, MvcType mvcType, IUnityScript parentUnityScript)
        {
            return BuildViewUnityScript(type.Name + ": " + mvcType, parentUnityScript);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static IUnityScript BuildViewUnityScript(string gameObjectName, IUnityScript parentUnityScript)
        {
            GameObject gameObject = new GameObject(gameObjectName);
            IUnityScript unityScript = gameObject.AddComponent<UnityScript>();
            unityScript.SetParent(parentUnityScript);
            return unityScript;
        }
    }
}