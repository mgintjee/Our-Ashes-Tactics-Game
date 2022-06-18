using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attrs.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attrs.Weapons.Inters;
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