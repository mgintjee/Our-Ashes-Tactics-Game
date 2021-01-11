namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.AIs.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.AIs.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Orders.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Randoms.Generators.Numbers;
    using System.Collections.Generic;

    /// <summary>
    /// Workaround until I implement an actual AI
    /// </summary>
    public class AIObjectRandomImpl
        : IAIObject
    {
        /// <inheritdoc/>
        ITalonOrderReport IAIObject.DetermineBestOrderReport(ISet<ITalonOrderReport> talonOrderReportSet)
        {
            if (talonOrderReportSet.Count > 0)
            {
                return new List<ITalonOrderReport>(talonOrderReportSet)
                    [RandomNumberGeneratorUtil.GetNextInt(talonOrderReportSet.Count)];
            }
            else
            {
                throw ExceptionUtil.Argument.Build();
            }
        }
    }
}