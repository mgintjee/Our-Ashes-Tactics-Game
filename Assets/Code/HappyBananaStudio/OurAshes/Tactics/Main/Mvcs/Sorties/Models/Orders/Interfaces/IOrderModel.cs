using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Orders.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Rosters.Reports.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Orders.Interfaces
{
    /// <summary>
    /// Todo
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
        void Process(IRosterReport rosterReport);
    }
}