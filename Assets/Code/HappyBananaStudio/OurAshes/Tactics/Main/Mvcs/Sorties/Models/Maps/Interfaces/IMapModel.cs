using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Combatants.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Requests.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Paths.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Rosters.Reports.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Maps.Interfaces
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
        IMapReport GetReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="combatantReport"></param>
        /// <returns></returns>
        ISet<IPath> GetPaths(ICombatantReport combatantReport);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="controllerRequest"></param>
        /// <param name="rosterReport">     </param>
        void Process(ISortieRequest controllerRequest, IRosterReport rosterReport);
    }
}