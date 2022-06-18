using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attrs.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attrs.Weapons.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Attrs.Abstrs;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Armors.Traits.Attrs.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public class ArmorTraitAlphaAlphaAttributesImpl
        : AbstractGearAttributes
    {
        /// <summary>
        /// Todo
        /// </summary>
        public ArmorTraitAlphaAlphaAttributesImpl()
        {
            this.combatantAttributes = CombatantAttributesImpl.Builder.Get()
                .Build();
            this.weaponAttributes = WeaponAttributesImpl.Builder.Get()
                .Build();
        }
    }
}