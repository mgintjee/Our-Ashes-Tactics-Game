using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Loadouts.Traits.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Reports.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Reports.Models.Traits.Inters
{
    /// <summary>
    /// Trait Report Interface
    /// </summary>
    public interface ITraitReport : IReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ISet<TraitID> GetTraitIDs();
    }
}