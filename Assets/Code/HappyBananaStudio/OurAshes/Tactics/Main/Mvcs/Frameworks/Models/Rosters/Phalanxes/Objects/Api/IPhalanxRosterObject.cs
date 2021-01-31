using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Rosters.Phalanxes.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Rosters.Phalanxes.Objects.Api
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IPhalanxRosterObject
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IPhalanxRosterReport GetPhalanxRosterReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonCallSign"></param>
        /// <returns></returns>
        PhalanxCallSign GetPhalanxCallSign(TalonCallSign talonCallSign);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="phalanxCallSignA"></param>
        /// <param name="phalanxCallSignB"></param>
        /// <returns></returns>
        bool ArePhalanxCallSignsFriendly(PhalanxCallSign phalanxCallSignA, PhalanxCallSign phalanxCallSignB);
    }
}