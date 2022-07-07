using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Gears.Attrs.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Attrs.Destructibles.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Attrs.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Attrs.Weapons.Impls;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Cabins.Gears.Attrs.Impls
{
    /// <summary>
    /// Trait Model Constants Impl
    /// </summary>
    public class CabinGearAlphaAlphaAttributesImpl
        : AbstractGearAttributes
    {
        public CabinGearAlphaAlphaAttributesImpl()
        {
            this.unitAttributes = UnitAttributesImpl.Builder.Get()
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