using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Gears.Attrs.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Attrs.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Attrs.Weapons.Impls;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Armors.Traits.Attrs.Impls
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
            this.unitAttributes = UnitAttributesImpl.Builder.Get()
                .Build();
            this.weaponAttributes = WeaponAttributesImpl.Builder.Get()
                .Build();
        }
    }
}