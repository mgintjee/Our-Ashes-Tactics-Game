using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Scripts.Unity.Implementations.Abstract;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Scripts.Unity.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Rosters.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Rosters.Scripts.Implementations
{
    /// <summary>
    /// Roster View Script Implementation
    /// </summary>
    public class RosterViewScript : AbstractUnityScript, IRosterViewScript
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
            public IRosterViewScript Build()
            {
                GameObject gameObject = new GameObject(typeof(IRosterViewScript).Name);
                IRosterViewScript viewScript = gameObject.AddComponent<RosterViewScript>();
                viewScript.SetParent(unityScript);
                return gameObject.GetComponent<IRosterViewScript>();
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