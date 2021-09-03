using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Unity.Scripts.Implementations.Abstract;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Unity.Scripts.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Canvases.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Canvases.Scripts.Implementations
{
    /// <summary>
    /// Canvas View Script Implementation
    /// </summary>
    public class CanvasViewScript : AbstractUnityScript, ICanvasViewScript
    {
        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            internal IUnityScript unityScript;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public ICanvasViewScript Build()
            {
                GameObject gameObject = new GameObject(typeof(ICanvasViewScript).Name);
                ICanvasViewScript canvasViewScript = gameObject.AddComponent<CanvasViewScript>();
                canvasViewScript.SetParent(unityScript);
                return gameObject.GetComponent<ICanvasViewScript>();
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="unityScript"></param>
            /// <returns></returns>
            public Builder SetUnityScript(IUnityScript unityScript)
            {
                this.unityScript = unityScript;
                return this;
            }
        }
    }
}