using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Common.Enums;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.TurnOrders.Reports.Api
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface ITurnOrderReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IList<TalonCallSign> GetOrderedTalonCallSignList();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        int GetPhaseCount();
    }
}