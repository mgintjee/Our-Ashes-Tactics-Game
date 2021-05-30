using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.Skins.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Stats.Views.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Materials.Indices.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Stats.Views.Implementations
{
    /// <summary>
    /// Combatant View Stats Implementation
    /// </summary>
    public struct CombatantViewStats
        : ICombatantViewStats
    {
        // Todo
        private readonly ISet<CombatantSkin> combatantSkins;

        // Todo
        private readonly IMaterialIndices combatantMaterialIndices;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="combatantSkins">          </param>
        /// <param name="combatantMaterialIndices"></param>
        private CombatantViewStats(ISet<CombatantSkin> combatantSkins,
            IMaterialIndices combatantMaterialIndices)
        {
            this.combatantSkins = combatantSkins;
            this.combatantMaterialIndices = combatantMaterialIndices;
        }

        ISet<CombatantSkin> ICombatantViewStats.GetCombatantSkins()
        {
            return new HashSet<CombatantSkin>(combatantSkins);
        }

        IMaterialIndices ICombatantViewStats.GetMaterialIndices()
        {
            return combatantMaterialIndices;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private ISet<CombatantSkin> combatantSkins = null;

            // Todo
            private IMaterialIndices combatantMaterialIndices = null;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public ICombatantViewStats Build()
            {
                return new CombatantViewStats(combatantSkins, combatantMaterialIndices);
            }

            public Builder SetCombatantMaterialIndices(IMaterialIndices combatantMaterialIndices)
            {
                this.combatantMaterialIndices = combatantMaterialIndices;
                return this;
            }

            public Builder SetCombatantSkins(ISet<CombatantSkin> combatantSkins)
            {
                if (combatantSkins != null)
                {
                    this.combatantSkins = combatantSkins;
                }
                return this;
            }
        }
    }
}