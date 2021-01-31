namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Controllers.AIs.Api
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;
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
        /// <param name="talonCallSign"></param>
        /// <param name="talonOrderReportSet"></param>
        /// <returns></returns>
        ITalonOrderReport DetermineBestOrderReport(TalonCallSign talonCallSign, ISet<ITalonOrderReport> talonOrderReportSet);
    }
}