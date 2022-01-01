using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Frames.Scripts.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Unity.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Unity.Inters;
using UnityEngine;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Frames.Scripts.Impls
{
    /// <summary>
    /// Mvc Sortie Frame Script Impl
    /// </summary>
    public class MvcSortieFrameScript
        : AbstractUnityScript, IMvcSortieFrameScript
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