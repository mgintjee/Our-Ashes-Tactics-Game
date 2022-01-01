using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.CallSigns;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Commons.Maps.Paths.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Requests.Inters;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Frames.Requests.Inters
{
    /// <summary>
    /// Sortie Request Interface
    /// </summary>
    public interface IMvcControlSortieRequest : IMvcRequest
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        CombatantCallSign GetCallSign();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ISortieMapPath GetPath();
    }
}