using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Attrs.Constants;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Attrs.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Models;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Attrs.Managers
{
    /// <summary>
    /// Todo
    /// </summary>
    public static class UnitAttributesManager
    {
        // Todo
        private static readonly IDictionary<ModelID, IUnitAttributes> ID_ATTRIBUTES =
            new Dictionary<ModelID, IUnitAttributes>()
            {
                {ModelID.LightAlpha, new LightAlphaAttributesImpl() },
                {ModelID.MediumAlpha, new MediumAlphaAttributesImpl() },
                {ModelID.HeavyAlpha, new HeavyAlphaAttributesImpl() },
            };

        public static Optional<IUnitAttributes> GetUnitAttributes(ModelID unitID)
        {
            return ID_ATTRIBUTES.ContainsKey(unitID)
                ? Optional<IUnitAttributes>.Of(ID_ATTRIBUTES[unitID])
                : Optional<IUnitAttributes>.Empty();
        }
    }
}