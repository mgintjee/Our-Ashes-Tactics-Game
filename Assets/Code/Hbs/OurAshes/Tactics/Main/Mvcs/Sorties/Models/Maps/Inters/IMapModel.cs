using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Paths.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Frames.Requests.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Combatants.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Maps.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Rosters.Inters;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Maps.Inters
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IMapModel
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ISortieMapReport GetReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="combatantReport"></param>
        /// <returns></returns>
        ISet<ISortieMapPath> GetPaths(ICombatantReport combatantReport);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="ModelRequest"></param>
        /// <param name="rosterReport">  </param>
        void Process(IMvcControlSortieRequest ModelRequest, IRosterModelReport rosterReport);
    }
}