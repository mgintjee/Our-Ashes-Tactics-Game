using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Gears.Attrs.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Gears.Sizes;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Attrs.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Attrs.Weapons.Inters;
using System;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Gears.Attrs.Abstrs
{
    /// <summary>
    /// Todo
    /// </summary>
    public abstract class AbstractGearAttributes<TEnum>
        : IGearAttributes<TEnum>
        where TEnum : Enum
    {
        // Todo
        protected IUnitAttributes unitAttributes;

        // Todo
        protected IWeaponAttributes weaponAttributes;

        // Todo
        protected TEnum id;

        // Todo
        protected GearSize gearSize;

        /// <inheritdoc/>
        TEnum IGearAttributes<TEnum>.GetID()
        {
            return id;
        }

        /// <inheritdoc/>
        IUnitAttributes IGearAttributes<TEnum>.GetUnitAttributes()
        {
            return unitAttributes;
        }

        /// <inheritdoc/>
        IWeaponAttributes IGearAttributes<TEnum>.GetWeaponAttributes()
        {
            return weaponAttributes;
        }

        /// <inheritdoc/>
        GearSize IGearAttributes<TEnum>.GetGearSize()
        {
            return gearSize;
        }
    }
}