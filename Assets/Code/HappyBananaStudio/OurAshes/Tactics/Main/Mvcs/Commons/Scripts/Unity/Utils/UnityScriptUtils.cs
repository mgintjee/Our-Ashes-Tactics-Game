﻿using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Mvcs.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Unity.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Unity.Interfaces;
using System;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Unity.Utils
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