using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Unity.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Unity.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Frames.Scripts.Inters;
using UnityEngine;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Frames.Scripts.Impls
{
    /// <summary>
    /// Mvc Sortie Frame Script Implementation
    /// </summary>
    public class MvcSortieFrameScript : UnityScript, IMvcSortieFrameScript
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