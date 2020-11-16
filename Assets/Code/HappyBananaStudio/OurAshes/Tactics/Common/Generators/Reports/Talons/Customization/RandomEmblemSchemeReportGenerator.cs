namespace HappyBananaStudio.OurAshes.Tactics.Common.Generators.Reports.Talons.Customization
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Customization;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Schemes.Emblem;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.RandomNumberGenerators;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Talons.Reports.Customization;
    using System;

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
            return new EmblemSchemeReportImpl.Builder()
                .SetBackgroundId(GetRandomEmblemSpriteIdEnum())
                .SetForeground(GetRandomEmblemSpriteIdEnum())
                .SetIconId(GetRandomEmblemSpriteIdEnum())
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        private static EmblemSpriteIdEnum GetRandomEmblemSpriteIdEnum()
        {
            Array enumValues = Enum.GetValues(typeof(EmblemSpriteIdEnum));
            return (EmblemSpriteIdEnum)enumValues.GetValue(RandomNumberGeneratorUtil.GetNextInt(1, enumValues.Length));
        }
    }
}
