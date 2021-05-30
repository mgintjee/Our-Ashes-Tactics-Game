using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Gears.IDs.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Gears.Sizes.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Gears.Types.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Loadouts.Reports.Gears.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Loadouts.Reports.Traits.Interfaces;
using System;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Loadouts.Reports.Gears.Implementations
{
    /// <summary>
    /// Gear Report Implementation
    /// </summary>
    public class GearReport
        : IGearReport
    {
        ICombatantAttributes IGearReport.GetCombatantAttributes()
        {
            throw new NotImplementedException();
        }

        GearID IGearReport.GetGearID()
        {
            throw new NotImplementedException();
        }

        GearSize IGearReport.GetGearSize()
        {
            throw new NotImplementedException();
        }

        GearType IGearReport.GetGearType()
        {
            throw new NotImplementedException();
        }

        ITraitReport IGearReport.GetTraitReport()
        {
            throw new NotImplementedException();
        }
    }
}