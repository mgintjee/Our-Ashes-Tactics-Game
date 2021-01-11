namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.AIs.Api
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Orders.Reports.Api;
    using System.Collections.Generic;

    /// <summary>
    /// Workaround until I implement an actual AI
    /// </summary>
    public interface IAIObject
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonOrderReportSet">
        /// </param>
        /// <returns>
        /// </returns>
        ITalonOrderReport DetermineBestOrderReport(ISet<ITalonOrderReport> talonOrderReportSet);
    }
}