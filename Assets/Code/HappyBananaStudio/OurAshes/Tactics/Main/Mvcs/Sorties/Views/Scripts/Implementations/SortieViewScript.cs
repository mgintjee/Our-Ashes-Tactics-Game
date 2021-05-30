using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Scripts.Unity.Abstract;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Scripts.Unity.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Scripts.Implementations
{
    /// <summary>
    /// Sortie View Script Implementation
    /// </summary>
    public class SortieViewScript
        : AbstractUnityScript, ISortieViewScript
    {
        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            internal IUnityScript parentUnityScript;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public ISortieViewScript Build()
            {
                GameObject gameObject = new GameObject(typeof(ISortieViewScript).Name);
                ISortieViewScript viewScript = gameObject.AddComponent<SortieViewScript>();
                viewScript.SetParent(parentUnityScript);
                return gameObject.GetComponent<ISortieViewScript>();
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