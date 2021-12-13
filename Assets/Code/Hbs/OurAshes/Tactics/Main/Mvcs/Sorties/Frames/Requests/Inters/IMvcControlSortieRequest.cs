using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.CallSigns;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Requests.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Paths.Inters;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Frames.Requests.Inters
{
    /// <summary>
    /// Sortie Request Interface
    /// </summary>
    public interface IMvcControlSortieRequest : IMvcControlRequest
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