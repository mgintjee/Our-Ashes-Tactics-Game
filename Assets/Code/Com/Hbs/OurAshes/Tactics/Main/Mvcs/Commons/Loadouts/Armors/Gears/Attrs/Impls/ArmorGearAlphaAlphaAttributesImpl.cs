using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attrs.Destructibles.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attrs.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attrs.Weapons.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Attrs.Abstrs;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Armors.Gears.Attrs.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public class ArmorGearAlphaAlphaAttributesImpl
        : AbstractGearAttributes
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ArmorGearAlphaAlphaAttributesImpl()
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