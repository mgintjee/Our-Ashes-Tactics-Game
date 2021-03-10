namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Generators.Talons.Customizations.Schemes.Emblems
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Customizations.Emblems.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Customizations.Emblems.Reports.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Sprites.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Utils.Enums;

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