using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attrs.Destructibles.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attrs.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attrs.Weapons.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Attrs.Abstrs;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Weapons.Gears.Attrs.Impls
{
    /// <summary>
    /// Trait Model Constants Impl
    /// </summary>
    public class WeaponGearAlphaAlphaAttributesImpl
        : AbstractGearAttributes
    {
        public WeaponGearAlphaAlphaAttributesImpl()
        {
            this.combatantAttributes = CombatantAttributesImpl.Builder.Get()
                    .SetDestructibleAttributes(DestructibleAttributesImpl.Builder.Get()
                    .SetArmor(5)
                    .SetHealth(10)
                    .Build())
                .Build();
            this.weaponAttributes = WeaponAttributesImpl.Builder.Get()
                .Build();
        }
    }
}