using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Weapons.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Loadouts.Gears.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Reports.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Traits.Inters;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Gears.Inters
{
    /// <summary>
    /// Gear Report Interface
    /// </summary>
    public interface IGearReport : IReport
    {
        ICombatantAttributes GetCombatantAttributes();

        IWeaponAttributes GetWeaponAttributes();

        GearID GetGearID();

        ITraitReport GetTraitReport();
    }
}