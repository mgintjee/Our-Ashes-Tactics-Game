namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Reports.Api
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Customizations.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Reports.Api;

    /// <summary>
    /// Todo
    /// </summary>
    public interface ITalonReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        TalonCallSign GetTalonCallSign();

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        float GetCurrentHealthPoints();

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        float GetCurrentArmorPoints();

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        float GetCurrentMovementPoints();

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        float GetCurrentActionPoints();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ITalonLoadoutReport GetTalonLoadoutReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ICustomizationReport GetCustomizationReport();
    }
}