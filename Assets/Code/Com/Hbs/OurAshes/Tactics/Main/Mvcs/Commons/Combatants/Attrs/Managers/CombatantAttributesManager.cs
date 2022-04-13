using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Combatants.Attrs.Constants;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Combatants.Attrs.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Combatants.Attrs.Managers
{
    /// <summary>
    /// Todo
    /// </summary>
    public static class CombatantAttributesManager
    {
        // Todo
        private static readonly IDictionary<CombatantID, ICombatantAttributes> ID_ATTRIBUTES =
            new Dictionary<CombatantID, ICombatantAttributes>()
            {
                {CombatantID.LightAlpha, new LightAlphaAttributesImpl() },
                {CombatantID.MediumAlpha, new MediumAlphaAttributesImpl() },
                {CombatantID.HeavyAlpha, new HeavyAlphaAttributesImpl() },
            };

        public static Optional<ICombatantAttributes> GetCombatantAttributes(CombatantID combatantID)
        {
            return ID_ATTRIBUTES.ContainsKey(combatantID)
                ? Optional<ICombatantAttributes>.Of(ID_ATTRIBUTES[combatantID])
                : Optional<ICombatantAttributes>.Empty();
        }
    }
}