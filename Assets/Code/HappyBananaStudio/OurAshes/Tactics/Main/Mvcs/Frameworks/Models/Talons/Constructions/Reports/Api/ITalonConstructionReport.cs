namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Constructions.Reports.Api
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Customizations.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Reports.Api;

    /// <summary>
    /// Todo
    /// </summary>
    public interface ITalonConstructionReport
    {
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