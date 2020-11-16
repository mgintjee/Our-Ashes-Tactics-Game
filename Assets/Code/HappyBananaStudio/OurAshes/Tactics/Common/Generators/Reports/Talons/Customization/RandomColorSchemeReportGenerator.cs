namespace HappyBananaStudio.OurAshes.Tactics.Common.Generators.Reports.Talons.Customization
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Customization;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Schemes.Color;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.RandomNumberGenerators;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Talons.Reports.Customization;
    using System;

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
        public static IColorSchemeReport GenerateRandomEmblemSchemeReport()
        {
            return new ColorSchemeReportImpl.Builder()
                .SetPrimaryColorId(GetRandomColorIdEnum())
                .SetSecondaryColorId(GetRandomColorIdEnum())
                .SetTertiaryColorId(GetRandomColorIdEnum())
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        private static ColorIdEnum GetRandomColorIdEnum()
        {
            Array enumValues = Enum.GetValues(typeof(ColorIdEnum));
            return (ColorIdEnum)enumValues.GetValue(RandomNumberGeneratorUtil.GetNextInt(1, enumValues.Length));
        }
    }
}
