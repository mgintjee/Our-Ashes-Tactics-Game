/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Rosters;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Rosters;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Enums;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Exceptions;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Managers
{
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
        public static HashSet<ITalonIdentificationReport> GetActiveTalonIdentificationReportSet()
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
        public static HashSet<ITalonIdentificationReport> GetAllTalonIdentificationReportSet()
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
        public static HashSet<ITalonIdentificationReport> GetAllTalonIdentificationReportSet(PhalanxIdEnum talonPhalanxId)
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
        /// <param name="talonFactionId">
        /// </param>
        /// <returns>
        /// </returns>
        public static HashSet<ITalonIdentificationReport> GetAllTalonIdentificationReportSet(FactionIdEnum talonFactionId)
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
        /// <param name="newRosterObject">
        /// </param>
        public static void SetRosterObject(IRosterObject newRosterObject)
        {
            rosterObject = newRosterObject;
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