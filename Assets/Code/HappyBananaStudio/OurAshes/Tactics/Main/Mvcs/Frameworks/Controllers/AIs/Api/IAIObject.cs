using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Common.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Common.Orders.Reports.Api;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Controllers.AIs.Api
{
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