namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Roes.Managers
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Roes.Objects.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;
    using System.Diagnostics;

    /// <summary>
    /// Roster Manager
    /// </summary>
    public class RoeManager
    {
        // Todo
        private static IRoeObject roeObject;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="roeObject"></param>
        public static void SetRoeObject(IRoeObject roeObject)
        {
            if (RoeManager.roeObject == null)
            {
                RoeManager.roeObject = roeObject;
            }
            else
            {
                throw ExceptionUtil.Argument.Build("Unable to ?. ? is already set.",
                    new StackFrame().GetMethod().Name, typeof(IRoeObject));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonCallSignA"></param>
        /// <param name="talonCallSignB"></param>
        /// <returns></returns>
        public static bool AreCallSignsFriendly(TalonCallSign talonCallSignA, TalonCallSign talonCallSignB)
        {
            if (roeObject != null)
            {
                return roeObject.AreCallSignsFriendly(talonCallSignA, talonCallSignB);
            }
            else
            {
                throw ExceptionUtil.Argument.Build();
            }
        }
    }
}