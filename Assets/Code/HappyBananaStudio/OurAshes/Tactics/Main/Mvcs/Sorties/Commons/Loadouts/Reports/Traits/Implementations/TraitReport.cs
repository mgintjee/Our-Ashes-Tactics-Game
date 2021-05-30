using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Gears.Types.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Traits.IDs.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Loadouts.Reports.Traits.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Loadouts.Reports.Traits.Implementations
{
    /// <summary>
    /// Trait Report Implementation
    /// </summary>
    public class TraitReport
        : ITraitReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ICombatantAttributes ITraitReport.GetCombatantAttributes()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        GearType ITraitReport.GetGearType()
        {
            throw new System.NotImplementedException();
        }

        ISet<TraitID> ITraitReport.GetTraitIDs()
        {
            throw new System.NotImplementedException();
        }
    }
}