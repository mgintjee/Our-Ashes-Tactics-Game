using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attrs.Constants;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attrs.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Models;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attrs.Managers
{
    /// <summary>
    /// Todo
    /// </summary>
    public static class CombatantAttributesManager
    {
        // Todo
        private static readonly IDictionary<ModelID, ICombatantAttributes> ID_ATTRIBUTES =
            new Dictionary<ModelID, ICombatantAttributes>()
            {
                {ModelID.LightAlpha, new LightAlphaAttributesImpl() },
                {ModelID.MediumAlpha, new MediumAlphaAttributesImpl() },
                {ModelID.HeavyAlpha, new HeavyAlphaAttributesImpl() },
            };

        public static Optional<ICombatantAttributes> GetCombatantAttributes(ModelID combatantID)
        {
            return ID_ATTRIBUTES.ContainsKey(combatantID)
                ? Optional<ICombatantAttributes>.Of(ID_ATTRIBUTES[combatantID])
                : Optional<ICombatantAttributes>.Empty();
        }
    }
}