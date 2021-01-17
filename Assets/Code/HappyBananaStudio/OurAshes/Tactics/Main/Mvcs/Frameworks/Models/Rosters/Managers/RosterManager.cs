namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Rosters.Managers
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Rosters.Objects.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Objects.Api;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Roster Manager
    /// </summary>
    public class RosterManager
    {
        // Todo
        private static IRosterObject rosterObject;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="rosterObject"></param>
        public static void SetRosterObject(IRosterObject rosterObject)
        {
            if (RosterManager.rosterObject == null)
            {
                RosterManager.rosterObject = rosterObject;
            }
            else
            {
                throw ExceptionUtil.Argument.Build("Unable to ?. ? is already set.",
                    new StackFrame().GetMethod().Name, typeof(IRosterObject));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static ISet<TalonCallSign> GetActiveTalonCallSignSet()
        {
            if (rosterObject != null)
            {
                return rosterObject.GetActiveTalonCallSignSet();
            }
            else
            {
                throw ExceptionUtil.Argument.Build();
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonCallSign"></param>
        /// <returns></returns>
        public static ITalonObject GetTalonObject(TalonCallSign talonCallSign)
        {
            if (rosterObject != null)
            {
                return rosterObject.GetTalonObject(talonCallSign);
            }
            else
            {
                throw ExceptionUtil.Argument.Build();
            }
        }
    }
}