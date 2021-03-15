using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Sprites.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Utils.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Views.Customizations.Emblems.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Views.Customizations.Emblems.Reports.Impl;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Generators.Talons.Customizations.Schemes.Emblems
{
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