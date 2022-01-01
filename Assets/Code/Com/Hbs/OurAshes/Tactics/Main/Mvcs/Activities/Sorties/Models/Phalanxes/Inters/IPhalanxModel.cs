using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Reports.Models.Phalanxes.Inters;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Models.Phalanxes.Inters
{
    /// <summary>
    /// Phalanx Model Interface
    /// </summary>
    public interface IPhalanxModel
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IPhalanxReport GetReport();
    }
}