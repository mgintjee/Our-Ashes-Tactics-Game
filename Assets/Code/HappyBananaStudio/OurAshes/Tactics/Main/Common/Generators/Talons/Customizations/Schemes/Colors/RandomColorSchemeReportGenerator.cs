using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Colors.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Utils.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Views.Customizations.Colors.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Views.Customizations.Colors.Reports.Impl;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Generators.Talons.Customizations.Schemes.Colors
{
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