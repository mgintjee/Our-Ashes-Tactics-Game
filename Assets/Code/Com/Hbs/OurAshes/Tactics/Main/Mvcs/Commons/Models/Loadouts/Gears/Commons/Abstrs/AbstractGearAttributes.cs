using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Combatants.Attrs.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Combatants.Attrs.Weapons.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Loadouts.Gears.Commons.Inters;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Loadouts.Gears.Commons.Abstrs
{
    /// <summary>
    /// Todo
    /// </summary>
    public abstract class AbstractGearAttributes
        : IGearAttributes
    {
        // Todo
        protected ICombatantAttributes combatantAttributes;

        // Todo
        protected IWeaponAttributes weaponAttributes;

        /// <inheritdoc/>
        ICombatantAttributes IGearAttributes.GetCombatantAttributes()
        {
            return combatantAttributes;
        }

        /// <inheritdoc/>
        IWeaponAttributes IGearAttributes.GetWeaponAttributes()
        {
            return weaponAttributes;
        }
    }
}