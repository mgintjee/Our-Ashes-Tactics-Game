﻿using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Scripts.Unity.Implementations.Abstract;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Scripts.Unity.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Frames.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Frames.Scripts.Implementations
{
    /// <summary>
    /// Mvc Sortie Frame Script Implementation
    /// </summary>
    public class MvcSortieFrameScript : AbstractUnityScript, IMvcSortieFrameScript
    {
        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private IUnityScript parentUnityScript;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IMvcSortieFrameScript Build()
            {
                GameObject gameObject = new GameObject(typeof(IMvcSortieFrameScript).Name);
                IMvcSortieFrameScript viewScript = gameObject.AddComponent<MvcSortieFrameScript>();
                viewScript.SetParent(parentUnityScript);
                return gameObject.GetComponent<IMvcSortieFrameScript>();
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="unityScript"></param>
            /// <returns></returns>
            public Builder SetUnityScript(IUnityScript unityScript)
            {
                this.parentUnityScript = unityScript;
                return this;
            }
        }
    }
}