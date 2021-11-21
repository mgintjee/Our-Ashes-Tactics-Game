using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Orders.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Rosters.Interfaces;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Orders.Interfaces
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