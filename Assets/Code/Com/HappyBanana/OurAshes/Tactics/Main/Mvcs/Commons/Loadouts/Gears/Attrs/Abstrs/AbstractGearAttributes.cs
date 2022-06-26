using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Units.Attrs.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Units.Attrs.Weapons.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Attrs.Inters;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Attrs.Abstrs
{
    /// <summary>
    /// Todo
    /// </summary>
    public abstract class AbstractGearAttributes
        : IGearAttributes
    {
        // Todo
        protected IUnitAttributes unitAttributes;

        // Todo
        protected IWeaponAttributes weaponAttributes;

        /// <inheritdoc/>
        IUnitAttributes IGearAttributes.GetUnitAttributes()
        {
            return unitAttributes;
        }

        /// <inheritdoc/>
        IWeaponAttributes IGearAttributes.GetWeaponAttributes()
        {
            return weaponAttributes;
        }
    }
}