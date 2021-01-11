using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Reports.Api;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface ITalonObjectReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        TalonCallSign GetCallSign();

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        double GetCurrentHealthPoints();

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        double GetCurrentArmorPoints();

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        int GetCurrentMovementPoints();

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        int GetCurrentActionPoints();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ITalonLoadoutReport GetTalonLoadoutReport();
    }
}