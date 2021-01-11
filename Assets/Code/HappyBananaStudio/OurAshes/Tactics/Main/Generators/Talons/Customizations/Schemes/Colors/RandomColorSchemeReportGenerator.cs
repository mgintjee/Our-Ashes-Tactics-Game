namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Generators.Talons.Customizations.Schemes.Colors
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Generators.Talons.Loadouts.Armors.Reports;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Generators.Talons.Loadouts.Engines.Reports;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Generators.Talons.Loadouts.Mounts.Utilities.Reports;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Generators.Talons.Loadouts.Mounts.Weapons.Reports;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Customizations.Color.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Customizations.Color.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Customizations.Color.Reports.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Customizations.Emblem.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Customizations.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Customizations.Reports.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Attributes.Constants;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Common.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Mounts.Common.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Mounts.Common.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Reports.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Randoms.Generators.Numbers;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Utils.Enums;
    using System;
    using System.Collections.Generic;

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
            return new ColorSchemeReportImpl.Builder()
                .SetPrimaryColorId(EnumUtils.GetRandomEnum<ColorId>())
                .SetSecondaryColorId(EnumUtils.GetRandomEnum<ColorId>())
                .SetTertiaryColorId(EnumUtils.GetRandomEnum<ColorId>())
                .Build();
        }
    }
}