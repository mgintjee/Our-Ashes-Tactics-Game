using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Gears.Attrs.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Attrs.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Attrs.Weapons.Inters;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Gears.Attrs.Abstrs
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