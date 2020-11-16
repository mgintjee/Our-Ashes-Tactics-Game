namespace HappyBananaStudio.OurAshes.Tactics.Common.Generators.Reports.Talons.Customization
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Customization;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Talons.Reports.Customization;

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
            return new CustomizationReportImpl.Builder()
                .SetColorSchemeReport(RandomColorSchemeReportGenerator.GenerateRandomEmblemSchemeReport())
                .SetEmblemSchemeReport(RandomEmblemSchemeReportGenerator.GenerateRandomEmblemSchemeReport())
                .Build();
        }
    }
}
