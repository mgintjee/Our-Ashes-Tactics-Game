using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attrs.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attrs.Weapons.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Attrs.Abstrs;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Engines.Traits.Attrs.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public class EngineTraitAlphaAlphaAttributesImpl
        : AbstractGearAttributes
    {
        public EngineTraitAlphaAlphaAttributesImpl()
        {
            this.combatantAttributes = CombatantAttributesImpl.Builder.Get()
                .Build();
            this.weaponAttributes = WeaponAttributesImpl.Builder.Get()
                .Build();
        }
    }
}