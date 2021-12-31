using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Orders.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Rosters.Inters;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Orders.Inters
{
    /// <summary>
    /// Order Model Interface
    /// </summary>
    public interface IOrderModel
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IOrderReport GetReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="rosterReport"></param>
        void Process(IRosterModelReport rosterReport);
    }
}