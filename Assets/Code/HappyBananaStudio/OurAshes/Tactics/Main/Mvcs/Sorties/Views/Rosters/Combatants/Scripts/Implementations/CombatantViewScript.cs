using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.CallSigns;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.Skins;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Unity.Scripts.Implementations.Abstract;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Unity.Scripts.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Rosters.Combatants.Scripts.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Rosters.Combatants.Scripts.Mounts.Interfaces;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Rosters.Combatants.Scripts.Implementations
{
    /// <summary>
    /// Sortie Combatant View Script Implementation
    /// </summary>
    public class CombatantViewScript : AbstractUnityScript, ICombatantViewScript
    {
        /// <inheritdoc/>
        ICombatantMountScript ICombatantViewScript.GetCombatantMountScript()
        {
            return this.GetComponent<ICombatantMountScript>();
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private IUnityScript unityScript;

            // Todo
            private CombatantCallSign combatantCallSign;

            // Todo
            private CombatantSkin combatantSkin;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public ICombatantViewScript Build()
            {
                // Todo: Load the CombatantSkin with the ResourceLoader
                GameObject gameObject = new GameObject(typeof(ICombatantViewScript).Name +
                    ":" + combatantSkin + ":" + combatantCallSign);
                ICombatantViewScript viewScript = gameObject.AddComponent<CombatantViewScript>();
                viewScript.SetParent(unityScript);
                return gameObject.GetComponent<ICombatantViewScript>();
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

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="combatantCallSign"></param>
            /// <returns></returns>
            public Builder SetCombatantCallSign(CombatantCallSign combatantCallSign)
            {
                this.combatantCallSign = combatantCallSign;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="combatantSkin"></param>
            /// <returns></returns>
            public Builder SetCombatantSkin(CombatantSkin combatantSkin)
            {
                this.combatantSkin = combatantSkin;
                return this;
            }
        }
    }
}