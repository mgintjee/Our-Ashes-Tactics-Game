namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Rosters.Phalanxes.Mangers
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.GameBoards.Objects.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Rosters.Phalanxes.Objects.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Rosters.Phalanxes.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;
    using System.Diagnostics;

    /// <summary>
    /// Todo
    /// </summary>
    public class PhalanxRosterManager
    {
        // Todo
        private static IPhalanxRosterObject phalanxRosterObject = null;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="phalanxRosterObject">
        /// </param>
        public static void SetPhalanxRosterObject(IPhalanxRosterObject phalanxRosterObject)
        {
            if (PhalanxRosterManager.phalanxRosterObject == null)
            {
                PhalanxRosterManager.phalanxRosterObject = phalanxRosterObject;
            }
            throw ExceptionUtil.Arguments.Build("Unable to ?. ? is already set.",
                new StackFrame().GetMethod().Name, typeof(IGameBoardObject));
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static IPhalanxRosterReport GetPhalanxRosterReport()
        {
            if (phalanxRosterObject != null)
            {
                return phalanxRosterObject.GetPhalanxRosterReport();
            }
            else
            {
                throw ExceptionUtil.Arguments.Build();
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static PhalanxCallSign GetPhalanxCallSign(TalonCallSign talonCallSign)
        {
            if (phalanxRosterObject != null)
            {
                return phalanxRosterObject.GetPhalanxCallSign(talonCallSign);
            }
            else
            {
                throw ExceptionUtil.Arguments.Build();
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static bool ArePhalanxCallSignsFriendly(
            PhalanxCallSign phalanxCallSignA, PhalanxCallSign phalanxCallSignB)
        {
            if (phalanxRosterObject != null)
            {
                return phalanxRosterObject.ArePhalanxCallSignsFriendly(phalanxCallSignA, phalanxCallSignB);
            }
            else
            {
                throw ExceptionUtil.Arguments.Build();
            }
        }
    }
}