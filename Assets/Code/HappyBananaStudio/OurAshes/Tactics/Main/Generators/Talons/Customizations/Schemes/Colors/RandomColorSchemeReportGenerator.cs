namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Generators.Talons.Customizations.Schemes.Colors
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Customizations.Colors.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Customizations.Colors.Reports.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Colors.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Utils.Enums;

    /// <summary>
    /// Todo
    /// </summary>
    public static class RandomColorSchemeReportGenerator
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public static IColorSchemeReport GenerateRandomColorSchemeReport()
        {
            return new ColorSchemeReport.Builder()
                .SetPrimaryColorId(EnumUtils.GetRandomEnum<ColorId>())
                .SetSecondaryColorId(EnumUtils.GetRandomEnum<ColorId>())
                .SetTertiaryColorId(EnumUtils.GetRandomEnum<ColorId>())
                .Build();
        }
    }
}