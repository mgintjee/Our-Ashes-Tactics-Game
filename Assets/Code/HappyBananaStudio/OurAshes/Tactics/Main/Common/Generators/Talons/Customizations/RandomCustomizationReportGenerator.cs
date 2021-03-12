namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Generators.Talons.Customizations
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Generators.Talons.Customizations.Schemes.Colors;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Generators.Talons.Customizations.Schemes.Emblems;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Customizations.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Customizations.Reports.Impl;

    /// <summary>
    /// Todo
    /// </summary>
    public static class RandomCustomizationReportGenerator
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public static ICustomizationReport GenerateRandomCustomizationReport()
        {
            return new CustomizationReport.Builder()
                .SetColorSchemeReport(RandomColorSchemeReportGenerator
                    .GenerateRandomColorSchemeReport())
                .SetEmblemSchemeReport(RandomEmblemSchemeReportGenerator
                    .GenerateRandomEmblemSchemeReport())
                .Build();
        }
    }
}