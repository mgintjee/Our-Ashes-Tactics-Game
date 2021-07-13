using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Scripts.Unity.Implementations.Abstract;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Scripts.Unity.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Maps.Paths.Collections.Scripts.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Maps.Paths.Scripts.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Maps.Paths.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Maps.Paths.Collections.Scripts.Implementations
{
    /// <summary>
    /// Path View Script Implementation
    /// </summary>
    public class PathViewCollectionScript : AbstractUnityScript, IPathViewCollectionScript
    {
        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private IUnityScript unityScript;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IPathViewScript Build()
            {
                GameObject gameObject = new GameObject(typeof(IPathViewScript).Name);
                IPathViewScript viewScript = gameObject.AddComponent<PathViewScript>();
                viewScript.SetParent(unityScript);
                return gameObject.GetComponent<IPathViewScript>();
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