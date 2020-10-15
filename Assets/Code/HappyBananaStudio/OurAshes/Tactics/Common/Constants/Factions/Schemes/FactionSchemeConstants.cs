

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
        private static readonly IDictionary<FactionIdEnum, IColorSchemeReport> factionIdColorSchemeReportDictionary =
                new Dictionary<FactionIdEnum, IColorSchemeReport>();

        // Todo
        private static readonly IDictionary<FactionIdEnum, IEmblemSchemeReport> factionIdEmblemSchemeReportDictionary =
                new Dictionary<FactionIdEnum, IEmblemSchemeReport>();

        // Todo
        private static readonly ISet<FactionIdEnum> supportedFactionIdSet = new HashSet<FactionIdEnum>()
        {
            FactionIdEnum.CreativeFaction1, FactionIdEnum.CreativeFaction2,
            FactionIdEnum.CreativeFaction3, FactionIdEnum.CreativeFaction4
        };

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="factionId">
        /// </param>
        /// <returns>
        /// </returns>
        public static IColorSchemeReport GetFactionColorSchemeReport(FactionIdEnum factionId)
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
        public static IEmblemSchemeReport GetFactionEmblemSchemeReport(FactionIdEnum factionId)
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
        private static IColorSchemeReport BuildColorSchemeReport(FactionIdEnum factionId)
        {
            switch (factionId)
            {
                case FactionIdEnum.CreativeFaction1:
                    return new ColorSchemeReportImpl.Builder()
                            .SetPrimaryColorId(ColorIdEnum.Yellow)
                            .SetSecondaryColorId(ColorIdEnum.Purple)
                            .SetTertiaryColorId(ColorIdEnum.Red)
                            .Build();

                case FactionIdEnum.CreativeFaction2:
                    return new ColorSchemeReportImpl.Builder()
                            .SetPrimaryColorId(ColorIdEnum.Teal)
                            .SetSecondaryColorId(ColorIdEnum.Lime)
                            .SetTertiaryColorId(ColorIdEnum.Purple)
                            .Build();

                case FactionIdEnum.CreativeFaction3:
                    return new ColorSchemeReportImpl.Builder()
                            .SetPrimaryColorId(ColorIdEnum.Red)
                            .SetSecondaryColorId(ColorIdEnum.DimGray)
                            .SetTertiaryColorId(ColorIdEnum.Green)
                            .Build();

                case FactionIdEnum.CreativeFaction4:
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
        private static IEmblemSchemeReport BuildEmblemSchemeReport(FactionIdEnum factionId)
        {
            switch (factionId)
            {
                case FactionIdEnum.CreativeFaction1:
                    return new EmblemSchemeReportImpl.Builder()
                                .SetEmblemBackgroundId(EmblemBackgroundIdEnum.Circle)
                                .SetEmblemIconId(EmblemIconIdEnum.Heart)
                            .Build();

                case FactionIdEnum.CreativeFaction2:
                    return new EmblemSchemeReportImpl.Builder()
                                .SetEmblemBackgroundId(EmblemBackgroundIdEnum.Circle)
                                .SetEmblemIconId(EmblemIconIdEnum.Heart)
                            .Build();

                case FactionIdEnum.CreativeFaction3:
                    return new EmblemSchemeReportImpl.Builder()
                                .SetEmblemBackgroundId(EmblemBackgroundIdEnum.Circle)
                                .SetEmblemIconId(EmblemIconIdEnum.Heart)
                            .Build();

                case FactionIdEnum.CreativeFaction4:
                    return new EmblemSchemeReportImpl.Builder()
                                .SetEmblemBackgroundId(EmblemBackgroundIdEnum.Circle)
                                .SetEmblemIconId(EmblemIconIdEnum.Heart)
                            .Build();

                default:
                    throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                        new StackFrame().GetMethod().Name, factionId);
            }
        }
    }
}
