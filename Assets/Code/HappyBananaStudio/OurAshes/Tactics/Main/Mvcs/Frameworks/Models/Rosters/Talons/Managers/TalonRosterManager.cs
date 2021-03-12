namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Rosters.Talons.Managers
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Rosters.Talons.Objects.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Rosters.Talons.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Orders.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Reports.Api;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Roster Manager
    /// </summary>
    public class TalonRosterManager
    {
        // Todo
        private static ITalonRosterObject talonRosterObject;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonRosterObject"></param>
        public static void SetTalonRosterObject(ITalonRosterObject talonRosterObject)
        {
            if (TalonRosterManager.talonRosterObject == null)
            {
                TalonRosterManager.talonRosterObject = talonRosterObject;
            }
            throw ExceptionUtil.Arguments.Build("Unable to ?. ? is already set.",
                new StackFrame().GetMethod().Name, typeof(ITalonRosterObject));
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static ISet<TalonCallSign> GetActiveTalonCallSignSet()
        {
            if (talonRosterObject != null)
            {
                return talonRosterObject.GetActiveTalonCallSignSet();
            }
            throw ExceptionUtil.Arguments.Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static ITalonRosterReport GetTalonRosterReport()
        {
            if (talonRosterObject != null)
            {
                return talonRosterObject.GetTalonRosterReport();
            }
            throw ExceptionUtil.Arguments.Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonCallSign"></param>
        /// <returns></returns>
        public static ITalonReport GetTalonReport(TalonCallSign talonCallSign)
        {
            if (talonRosterObject != null)
            {
                return talonRosterObject.GetTalonObject(talonCallSign).GetTalonReport();
            }
            throw ExceptionUtil.Arguments.Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonCallSign"></param>
        /// <returns></returns>
        public static ISet<ITalonOrderReport> GetTalonOrderReportSet(TalonCallSign talonCallSign)
        {
            if (talonRosterObject != null)
            {
                return talonRosterObject.GetTalonObject(talonCallSign).GetTalonOrderReportSet();
            }
            throw ExceptionUtil.Arguments.Build();
        }
    }
}