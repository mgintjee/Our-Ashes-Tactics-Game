

namespace HappyBananaStudio.OurAshes.Tactics.Common.Managers.CodeObjects
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Rosters.Objects;
    using HappyBananaStudio.OurAshes.Tactics.Api.Rosters.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Objects;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Information;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Factions;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Phalanxes;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Exceptions;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Todo
    /// </summary>
    public class RosterObjectManager
    {
        // Todo
        private static IRosterObject rosterObject;

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public static ISet<ITalonIdentificationReport> GetActiveTalonIdentificationReportSet()
        {
            if (rosterObject != null)
            {
                return rosterObject.GetActiveTalonIdentificationReportSet();
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. ? is null.", new StackFrame().GetMethod().Name, typeof(IRosterObject));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public static ISet<FactionIdEnum> GetFactionIdSet()
        {
            if (rosterObject != null)
            {
                return rosterObject.GetFactionIdSet();
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. ? is null.", new StackFrame().GetMethod().Name, typeof(IRosterObject));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public static ISet<ITalonIdentificationReport> GetAllTalonIdentificationReportSet()
        {
            if (rosterObject != null)
            {
                return rosterObject.GetActiveTalonIdentificationReportSet();
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. ? is null.", new StackFrame().GetMethod().Name, typeof(IRosterObject));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonPhalanxId">
        /// </param>
        /// <returns>
        /// </returns>
        public static ISet<ITalonIdentificationReport> GetAllTalonIdentificationReportSet(PhalanxIdEnum talonPhalanxId)
        {
            if (rosterObject != null)
            {
                return rosterObject.GetAllTalonIdentificationReportSet(talonPhalanxId);
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. ? is null.", new StackFrame().GetMethod().Name, typeof(IRosterObject));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonFactionId">
        /// </param>
        /// <returns>
        /// </returns>
        public static ISet<ITalonIdentificationReport> GetAllTalonIdentificationReportSet(FactionIdEnum talonFactionId)
        {
            if (rosterObject != null)
            {
                return rosterObject.GetAllTalonIdentificationReportSet(talonFactionId);
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. ? is null.", new StackFrame().GetMethod().Name, typeof(IRosterObject));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public static IRosterInformationReport GetRosterInformationReport()
        {
            if (rosterObject != null)
            {
                return rosterObject.GetRosterInformationReport();
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. ? is null.", new StackFrame().GetMethod().Name, typeof(IRosterObject));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonIdentificationReport">
        /// </param>
        /// <returns>
        /// </returns>
        public static ITalonObject GetTalonObjectFrom(ITalonIdentificationReport talonIdentificationReport)
        {
            if (rosterObject != null)
            {
                return rosterObject.GetTalonObject(talonIdentificationReport);
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. ? is null.", new StackFrame().GetMethod().Name, typeof(IRosterObject));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="newRosterObject">
        /// </param>
        public static void SetRosterObject(IRosterObject newRosterObject)
        {
            if (rosterObject == null)
            {
                rosterObject = newRosterObject;
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonIdentificationReport">
        /// </param>
        /// <returns>
        /// </returns>
        public ITalonInformationReport GetTalonInformationReport(ITalonIdentificationReport talonIdentificationReport)
        {
            if (rosterObject != null)
            {
                return rosterObject.GetTalonInformationReport(talonIdentificationReport);
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. ? is null.", new StackFrame().GetMethod().Name, typeof(IRosterObject));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonIdentificationReport">
        /// </param>
        /// <returns>
        /// </returns>
        public bool IsTalonIdentificationReportActive(ITalonIdentificationReport talonIdentificationReport)
        {
            if (rosterObject != null)
            {
                return rosterObject.IsTalonIdentificationReportActive(talonIdentificationReport);
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. ? is null.", new StackFrame().GetMethod().Name, typeof(IRosterObject));
            }
        }
    }
}
