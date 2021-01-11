namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.TurnOrders.Reports.Api
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;
    using System.Collections.Generic;

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