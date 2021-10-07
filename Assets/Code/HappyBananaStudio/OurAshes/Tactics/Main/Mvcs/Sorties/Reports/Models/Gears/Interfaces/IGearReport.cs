using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Traits.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Gears.Interfaces
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