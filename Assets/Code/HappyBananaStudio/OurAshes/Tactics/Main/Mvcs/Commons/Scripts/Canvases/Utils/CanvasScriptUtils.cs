using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Canvases.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Canvases.Interfaces;
using System;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Canvases.Utils
{
    /// <summary>
    /// Todo
    /// </summary>
    public class CanvasScriptUtils
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static ICanvasScript BuildViewCanvasScript(Type type, MvcType mvcType, ICanvasScript parentCanvasScript)
        {
            return BuildViewCanvasScript(type.Name + ": " + mvcType, parentCanvasScript);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static ICanvasScript BuildViewCanvasScript(string gameObjectName, ICanvasScript parentCanvasScript)
        {
            GameObject gameObject = new GameObject(gameObjectName);
            ICanvasScript canvasScript = gameObject.AddComponent<CanvasScript>();
            canvasScript.SetParent(parentCanvasScript);
            return canvasScript;
        }
    }
}