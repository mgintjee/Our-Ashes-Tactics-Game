using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Units.Attrs.Destructibles.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Units.Attrs.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Units.Attrs.Weapons.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Attrs.Abstrs;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Armors.Gears.Attrs.Impls
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