using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.IDs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.Skins;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Constants.Combatants.Views.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Constants.Combatants.Views.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Constants.Combatants.Views.Managers
{
    /// <summary>
    /// Todo
    /// </summary>
    public static class CombatantViewConstantsManager
    {
        private static readonly IDictionary<CombatantID, ICombatantViewConstants> IDViewConstants =
            new Dictionary<CombatantID, ICombatantViewConstants>()
        {
            {
                CombatantID.LightAlpha,
                CombatantViewConstants.Builder.Get()
                .SetCombatantSkins(new HashSet<CombatantSkin>(){CombatantSkin.LightAlphaDefault })
                .Build()
            },
            {
                CombatantID.MediumAlpha,
                CombatantViewConstants.Builder.Get()
                .SetCombatantSkins(new HashSet<CombatantSkin>(){CombatantSkin.MediumAlphaDefault })
                .Build()
            },
            {
                CombatantID.HeavyAlpha,
                CombatantViewConstants.Builder.Get()
                .SetCombatantSkins(new HashSet<CombatantSkin>(){CombatantSkin.HeavyAlphaDefault })
                .Build()
            },
        };

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="combatantID"></param>
        /// <returns></returns>
        public static Optional<ICombatantViewConstants> GetConstants(CombatantID combatantID)
        {
            return (IDViewConstants.ContainsKey(combatantID))
                ? Optional<ICombatantViewConstants>.Of(IDViewConstants[combatantID])
                : Optional<ICombatantViewConstants>.Empty();
        }
    }
}