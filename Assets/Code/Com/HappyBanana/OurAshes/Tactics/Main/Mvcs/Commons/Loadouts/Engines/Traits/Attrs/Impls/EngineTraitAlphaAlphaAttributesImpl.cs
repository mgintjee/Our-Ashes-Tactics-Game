using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Units.Attrs.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Units.Attrs.Weapons.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Attrs.Abstrs;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Engines.Traits.Attrs.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public class EngineTraitAlphaAlphaAttributesImpl
        : AbstractGearAttributes
    {
        public EngineTraitAlphaAlphaAttributesImpl()
        {
            this.unitAttributes = UnitAttributesImpl.Builder.Get()
                .Build();
            this.weaponAttributes = WeaponAttributesImpl.Builder.Get()
                .Build();
        }
    }
}