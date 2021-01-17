namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Reports.Api
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Coordinates.Cube.Api;
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
        /// Todo
        /// </summary>
        /// <returns></returns>
        ITalonAttributesReport GetCurrentTalonAttributesReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ITalonAttributesReport GetMaximumTalonAttributesReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ICubeCoordinates GetCubeCoordinates();

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