using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Scripts.Unity.Abstract;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Scripts.Unity.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Rosters.Combatants.Collections.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Rosters.Combatants.Collections.Scripts.Implementations
{
    /// <summary>
    /// Sortie Combatant View Collection Script Implementation
    /// </summary>
    public class CombatantViewCollectionScript
        : AbstractUnityScript, ICombatantViewCollectionScript
    {
        void ICombatantViewCollectionScript.Clear()
        {
            throw new System.NotImplementedException();
        }

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
            public ICombatantViewCollectionScript Build()
            {
                GameObject gameObject = new GameObject(typeof(ICombatantViewCollectionScript).Name);
                ICombatantViewCollectionScript viewScript = gameObject.AddComponent<CombatantViewCollectionScript>();
                viewScript.SetParent(unityScript);
                return gameObject.GetComponent<ICombatantViewCollectionScript>();
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