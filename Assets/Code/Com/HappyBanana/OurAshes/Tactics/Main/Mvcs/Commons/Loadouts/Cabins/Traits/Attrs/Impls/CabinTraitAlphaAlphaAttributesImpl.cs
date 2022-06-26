using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Units.Attrs.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Units.Attrs.Weapons.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Attrs.Abstrs;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Cabins.Traits.Attrs.Impls
{
    /// <summary>
    /// Trait Model Constants Impl
    /// </summary>
    public class CabinTraitAlphaAlphaAttributesImpl
        : AbstractGearAttributes
    {
        public CabinTraitAlphaAlphaAttributesImpl()
        {
            this.unitAttributes = UnitAttributesImpl.Builder.Get()
                .Build();
            this.weaponAttributes = WeaponAttributesImpl.Builder.Get()
                .Build();
        }
    }
}