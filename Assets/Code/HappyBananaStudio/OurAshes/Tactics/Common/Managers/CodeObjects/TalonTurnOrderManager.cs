

namespace HappyBananaStudio.OurAshes.Tactics.Common.Managers.CodeObjects
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Loggers;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Information;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Loggers;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Todo
    /// </summary>
    public class TalonTurnOrderManager
    {
        // Provide logging capability
        private static readonly ICodeLogger logger = new CodeLoggerImpl(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private static IList<ITalonIdentificationReport> orderedTalonIdentificationReportList = new List<ITalonIdentificationReport>();

        // Todo
        private static int phaseCounter = 0;

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public static IList<ITalonIdentificationReport> GetOrderedTalonIdentificationReportList()
        {
            if (orderedTalonIdentificationReportList.Count == 0)
            {
                UpdateOrdererdTalonIdentificationReportList();
                foreach (ITalonIdentificationReport talonIdentificationReport in orderedTalonIdentificationReportList)
                {
                    RosterObjectManager.GetTalonObject(talonIdentificationReport).ResetForNewTurn();
                }
                phaseCounter++;
            }
            return new List<ITalonIdentificationReport>(orderedTalonIdentificationReportList);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public static int GetPhaseCounter()
        {
            return phaseCounter;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonIdentificationReport">
        /// </param>
        public static void RemoveTalonTurn(ITalonIdentificationReport talonIdentificationReport)
        {
            orderedTalonIdentificationReportList.Remove(talonIdentificationReport);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public static void UpdateOrdererdTalonIdentificationReportList()
        {
            orderedTalonIdentificationReportList = new List<ITalonIdentificationReport>(RosterObjectManager.GetActiveTalonIdentificationReportSet());
            ((List<ITalonIdentificationReport>)orderedTalonIdentificationReportList).Sort(RosterObjectManager.GetOrderPointComparer());
        }
    }
}
