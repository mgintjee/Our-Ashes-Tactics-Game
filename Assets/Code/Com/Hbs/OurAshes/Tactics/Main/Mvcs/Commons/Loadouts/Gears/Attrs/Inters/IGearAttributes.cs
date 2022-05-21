using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attrs.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attrs.Weapons.Inters;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Attrs.Inters
{
    /// <summary>
    /// Trait Model Constants Interface
    /// </summary>
    public interface IGearAttributes
    {
        ICombatantAttributes GetCombatantAttributes();

        IWeaponAttributes GetWeaponAttributes();
    }
}