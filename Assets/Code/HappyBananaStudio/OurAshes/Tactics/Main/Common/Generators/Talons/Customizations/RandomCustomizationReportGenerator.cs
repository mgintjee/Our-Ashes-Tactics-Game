using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Generators.Talons.Customizations.Schemes.Colors;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Generators.Talons.Customizations.Schemes.Emblems;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Views.Customizations.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Views.Customizations.Reports.Impl;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Generators.Talons.Customizations
{
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
        public static ITalonCustomizationReport GenerateRandomTalonCustomizationReport()
        {
            return new TalonCustomizationReport.Builder()
                .SetColorSchemeReport(RandomColorSchemeReportGenerator
                    .GenerateRandomColorSchemeReport())
                .SetEmblemSchemeReport(RandomEmblemSchemeReportGenerator
                    .GenerateRandomEmblemSchemeReport())
                .Build();
        }
    }
}