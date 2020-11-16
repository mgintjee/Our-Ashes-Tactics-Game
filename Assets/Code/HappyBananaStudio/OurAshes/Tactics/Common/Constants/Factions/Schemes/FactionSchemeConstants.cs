namespace HappyBananaStudio.OurAshes.Tactics.Common.Constants.Factions.Schemes
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Customization;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Factions;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Schemes.Color;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Schemes.Emblem;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Exceptions;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Talons.Reports.Customization;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Todo
    /// </summary>
    public static class FactionSchemeConstants
    {
        // Todo
        private static readonly IDictionary<FactionId, IColorSchemeReport> factionIdColorSchemeReportDictionary =
                new Dictionary<FactionId, IColorSchemeReport>();

        // Todo
        private static readonly IDictionary<FactionId, ICustomizationReport> factionIdCustomizationReportDictionary =
                new Dictionary<FactionId, ICustomizationReport>();

        // Todo
        private static readonly IDictionary<FactionId, IEmblemSchemeReport> factionIdEmblemSchemeReportDictionary =
                new Dictionary<FactionId, IEmblemSchemeReport>();

        // Todo
        private static readonly ISet<FactionId> supportedFactionIdSet = new HashSet<FactionId>()
        {
            FactionId.CreativeFaction1, FactionId.CreativeFaction2, FactionId.CreativeFaction3, FactionId.CreativeFaction4
        };

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="factionId">
        /// </param>
        /// <returns>
        /// </returns>
        public static IColorSchemeReport GetFactionColorSchemeReport(FactionId factionId)
        {
            if (supportedFactionIdSet.Contains(factionId))
            {
                if (!factionIdColorSchemeReportDictionary.ContainsKey(factionId))
                {
                    factionIdColorSchemeReportDictionary.Add(factionId, BuildColorSchemeReport(factionId));
                }
                return factionIdColorSchemeReportDictionary[factionId];
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                    new StackFrame().GetMethod().Name, factionId);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="factionId">
        /// </param>
        /// <returns>
        /// </returns>
        public static ICustomizationReport GetFactionCustomizationReport(FactionId factionId)
        {
            if (supportedFactionIdSet.Contains(factionId))
            {
                if (!factionIdCustomizationReportDictionary.ContainsKey(factionId))
                {
                    factionIdCustomizationReportDictionary.Add(factionId,
                        new CustomizationReportImpl.Builder()
                        .SetColorSchemeReport(GetFactionColorSchemeReport(factionId))
                        .SetEmblemSchemeReport(GetFactionEmblemSchemeReport(factionId))
                        .Build()
                        );
                }
                return factionIdCustomizationReportDictionary[factionId];
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                    new StackFrame().GetMethod().Name, factionId);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="factionId">
        /// </param>
        /// <returns>
        /// </returns>
        public static IEmblemSchemeReport GetFactionEmblemSchemeReport(FactionId factionId)
        {
            if (supportedFactionIdSet.Contains(factionId))
            {
                if (!factionIdEmblemSchemeReportDictionary.ContainsKey(factionId))
                {
                    factionIdEmblemSchemeReportDictionary.Add(factionId, BuildEmblemSchemeReport(factionId));
                }
                return factionIdEmblemSchemeReportDictionary[factionId];
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                    new StackFrame().GetMethod().Name, factionId);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="factionId">
        /// </param>
        /// <returns>
        /// </returns>
        private static IColorSchemeReport BuildColorSchemeReport(FactionId factionId)
        {
            switch (factionId)
            {
                case FactionId.CreativeFaction1:
                    return new ColorSchemeReportImpl.Builder()
                            .SetPrimaryColorId(ColorIdEnum.Yellow)
                            .SetSecondaryColorId(ColorIdEnum.Purple)
                            .SetTertiaryColorId(ColorIdEnum.Red)
                            .Build();

                case FactionId.CreativeFaction2:
                    return new ColorSchemeReportImpl.Builder()
                            .SetPrimaryColorId(ColorIdEnum.Teal)
                            .SetSecondaryColorId(ColorIdEnum.Lime)
                            .SetTertiaryColorId(ColorIdEnum.Purple)
                            .Build();

                case FactionId.CreativeFaction3:
                    return new ColorSchemeReportImpl.Builder()
                            .SetPrimaryColorId(ColorIdEnum.Red)
                            .SetSecondaryColorId(ColorIdEnum.DimGray)
                            .SetTertiaryColorId(ColorIdEnum.Green)
                            .Build();

                case FactionId.CreativeFaction4:
                    return new ColorSchemeReportImpl.Builder()
                            .SetPrimaryColorId(ColorIdEnum.LightSkyBlue)
                            .SetSecondaryColorId(ColorIdEnum.Silver)
                            .SetTertiaryColorId(ColorIdEnum.Coral)
                            .Build();

                default:
                    throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                        new StackFrame().GetMethod().Name, factionId);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="factionId">
        /// </param>
        /// <returns>
        /// </returns>
        private static IEmblemSchemeReport BuildEmblemSchemeReport(FactionId factionId)
        {
            switch (factionId)
            {
                case FactionId.CreativeFaction1:
                    return new EmblemSchemeReportImpl.Builder()
                        .SetBackgroundId(EmblemSpriteIdEnum.Circle)
                        .SetForeground(EmblemSpriteIdEnum.Circle)
                        .SetIconId(EmblemSpriteIdEnum.Circle)
                        .Build();

                case FactionId.CreativeFaction2:
                    return new EmblemSchemeReportImpl.Builder()
                        .SetBackgroundId(EmblemSpriteIdEnum.Circle)
                        .SetForeground(EmblemSpriteIdEnum.Circle)
                        .SetIconId(EmblemSpriteIdEnum.Circle)
                        .Build();

                case FactionId.CreativeFaction3:
                    return new EmblemSchemeReportImpl.Builder()
                        .SetBackgroundId(EmblemSpriteIdEnum.Circle)
                        .SetForeground(EmblemSpriteIdEnum.Circle)
                        .SetIconId(EmblemSpriteIdEnum.Circle)
                        .Build();

                case FactionId.CreativeFaction4:
                    return new EmblemSchemeReportImpl.Builder()
                        .SetBackgroundId(EmblemSpriteIdEnum.Circle)
                        .SetForeground(EmblemSpriteIdEnum.Circle)
                        .SetIconId(EmblemSpriteIdEnum.Circle)
                        .Build();

                default:
                    throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                        new StackFrame().GetMethod().Name, factionId);
            }
        }
    }
}
