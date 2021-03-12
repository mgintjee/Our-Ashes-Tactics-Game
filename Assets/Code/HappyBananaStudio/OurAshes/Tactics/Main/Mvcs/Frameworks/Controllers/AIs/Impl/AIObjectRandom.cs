namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Controllers.AIs.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Randoms.Generators.Numbers;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Controllers.AIs.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Orders.Reports.Api;
    using System.Collections.Generic;

    /// <summary>
    /// Workaround until I implement an actual AI
    /// </summary>
    public class AIObjectRandom
        : IAIObject
    {
        /// <inheritdoc/>
        ITalonOrderReport IAIObject.DetermineBestOrderReport(TalonCallSign talonCallSign,
            ISet<ITalonOrderReport> talonOrderReportSet)
        {
            if (talonOrderReportSet.Count > 0)
            {
                return new List<ITalonOrderReport>(talonOrderReportSet)
                    [RandomNumberGeneratorUtil.GetNextInt(talonOrderReportSet.Count)];
            }
            else
            {
                throw ExceptionUtil.Arguments.Build();
            }
        }
    }
}