

namespace HappyBananaStudio.OurAshes.Tactics.Common.Managers.CodeObjects
{
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
        private static IFactionRosterObject rosterObject;

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
                throw ArgumentExceptionUtil.Build("Unable to ?. ? is null.", new StackFrame().GetMethod().Name, typeof(IFactionRosterObject));
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
                throw ArgumentExceptionUtil.Build("Unable to ?. ? is null.", new StackFrame().GetMethod().Name, typeof(IFactionRosterObject));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonPhalanxId">
        /// </param>
        /// <returns>
        /// </returns>
        public static ISet<ITalonIdentificationReport> GetAllTalonIdentificationReportSet(PhalanxId talonPhalanxId)
        {
            if (rosterObject != null)
            {
                return rosterObject.GetAllTalonIdentificationReportSet(talonPhalanxId);
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. ? is null.", new StackFrame().GetMethod().Name, typeof(IFactionRosterObject));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonFactionId">
        /// </param>
        /// <returns>
        /// </returns>
        public static ISet<ITalonIdentificationReport> GetAllTalonIdentificationReportSet(FactionId talonFactionId)
        {
            if (rosterObject != null)
            {
                return rosterObject.GetAllTalonIdentificationReportSet(talonFactionId);
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. ? is null.", new StackFrame().GetMethod().Name, typeof(IFactionRosterObject));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public static ISet<FactionId> GetFactionIdSet()
        {
            if (rosterObject != null)
            {
                return rosterObject.GetFactionIdSet();
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. ? is null.", new StackFrame().GetMethod().Name, typeof(IFactionRosterObject));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public static IComparer<ITalonIdentificationReport> GetOrderPointComparer()
        {
            if (rosterObject != null)
            {
                return rosterObject.GetOrderPointComparer();
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. ? is null.", new StackFrame().GetMethod().Name, typeof(IFactionRosterObject));
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
                throw ArgumentExceptionUtil.Build("Unable to ?. ? is null.", new StackFrame().GetMethod().Name, typeof(IFactionRosterObject));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonIdentificationReport">
        /// </param>
        /// <returns>
        /// </returns>
        public static ITalonObject GetTalonObject(ITalonIdentificationReport talonIdentificationReport)
        {
            if (rosterObject != null)
            {
                return rosterObject.GetTalonObject(talonIdentificationReport);
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. ? is null.", new StackFrame().GetMethod().Name, typeof(IFactionRosterObject));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="newRosterObject">
        /// </param>
        public static void SetRosterObject(IFactionRosterObject newRosterObject)
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
                throw ArgumentExceptionUtil.Build("Unable to ?. ? is null.", new StackFrame().GetMethod().Name, typeof(IFactionRosterObject));
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
                throw ArgumentExceptionUtil.Build("Unable to ?. ? is null.", new StackFrame().GetMethod().Name, typeof(IFactionRosterObject));
            }
        }
    }
}
