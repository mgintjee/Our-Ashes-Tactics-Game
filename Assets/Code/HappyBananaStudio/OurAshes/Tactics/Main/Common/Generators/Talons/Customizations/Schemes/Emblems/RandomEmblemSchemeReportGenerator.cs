namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Generators.Talons.Customizations.Schemes.Emblems
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Customizations.Emblems.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Customizations.Emblems.Reports.Impl;

    /// <summary>
    /// Todo
    /// </summary>
    public static class RandomEmblemSchemeReportGenerator
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public static IEmblemSchemeReport GenerateRandomEmblemSchemeReport()
        {
            return new EmblemSchemeReport.Builder()
                .SetBackgroundEmblemId(EnumUtils.GetRandomEnum<SpriteId>())
                .SetForegroundEmblemId(EnumUtils.GetRandomEnum<SpriteId>())
                .SetIconEmblemId(EnumUtils.GetRandomEnum<SpriteId>())
                .Build();
        }
    }
}