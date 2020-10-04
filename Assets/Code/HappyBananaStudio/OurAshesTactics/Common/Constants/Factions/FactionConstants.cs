/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Customization;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Builders;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Enums;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Utils.Exceptions;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Constants.Factions
{
    /// <summary>
    /// Todo
    /// </summary>
    public static class FactionConstants
    {
        // Todo
        private static readonly Dictionary<FactionIdEnum, IColorSchemeReport> FACTION_ID_COLOR_SCHEME_REPORT_DICTIONARY =
                new Dictionary<FactionIdEnum, IColorSchemeReport>()
                {
                    {
                        FactionIdEnum.CreativeFaction1,
                            ReportBuilder.Customization.Color.GetBuilder()
                            .SetPrimaryPaintColorId(ColorIdEnum.Navy)
                            .SetSecondaryPaintColorId(ColorIdEnum.Green)
                            .SetTertiaryPaintColorId(ColorIdEnum.White)
                            .Build()
                    },
                    {
                        FactionIdEnum.CreativeFaction2,
                            ReportBuilder.Customization.Color.GetBuilder()
                            .SetPrimaryPaintColorId(ColorIdEnum.Gray)
                            .SetSecondaryPaintColorId(ColorIdEnum.Black)
                            .SetTertiaryPaintColorId(ColorIdEnum.Navy)
                            .Build()
                    },
                    {
                        FactionIdEnum.CreativeFaction3,
                            ReportBuilder.Customization.Color.GetBuilder()
                            .SetPrimaryPaintColorId(ColorIdEnum.Olive)
                            .SetSecondaryPaintColorId(ColorIdEnum.Orange)
                            .SetTertiaryPaintColorId(ColorIdEnum.Maroon)
                            .Build()
                    },
                    {
                        FactionIdEnum.CreativeFaction4,
                            ReportBuilder.Customization.Color.GetBuilder()
                            .SetPrimaryPaintColorId(ColorIdEnum.Purple)
                            .SetSecondaryPaintColorId(ColorIdEnum.Orange)
                            .SetTertiaryPaintColorId(ColorIdEnum.Navy)
                            .Build()
                    },
                };

        // Todo
        private static readonly Dictionary<FactionIdEnum, IEmblemSchemeReport> FACTION_ID_EMBLEM_SCHEME_REPORT_DICTIONARY =
                new Dictionary<FactionIdEnum, IEmblemSchemeReport>()
                {
                    {
                        FactionIdEnum.CreativeFaction1,
                            ReportBuilder.Customization.Emblem.GetBuilder()
                                .SetEmblemBackgroundId(EmblemBackgroundIdEnum.Circle)
                                .SetEmblemIconId(EmblemIconIdEnum.Heart)
                            .Build()
                    },
                    {
                        FactionIdEnum.CreativeFaction2,
                            ReportBuilder.Customization.Emblem.GetBuilder()
                                .SetEmblemBackgroundId(EmblemBackgroundIdEnum.Circle)
                                .SetEmblemIconId(EmblemIconIdEnum.Heart)
                            .Build()
                    },
                    {
                        FactionIdEnum.CreativeFaction3,
                            ReportBuilder.Customization.Emblem.GetBuilder()
                                .SetEmblemBackgroundId(EmblemBackgroundIdEnum.Circle)
                                .SetEmblemIconId(EmblemIconIdEnum.Heart)
                            .Build()
                    },
                    {
                        FactionIdEnum.CreativeFaction4,
                            ReportBuilder.Customization.Emblem.GetBuilder()
                                .SetEmblemBackgroundId(EmblemBackgroundIdEnum.Circle)
                                .SetEmblemIconId(EmblemIconIdEnum.Heart)
                            .Build()
                    },
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
            if (FACTION_ID_COLOR_SCHEME_REPORT_DICTIONARY.ContainsKey(factionId))
            {
                return FACTION_ID_COLOR_SCHEME_REPORT_DICTIONARY[factionId];
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
            if (FACTION_ID_EMBLEM_SCHEME_REPORT_DICTIONARY.ContainsKey(factionId))
            {
                return FACTION_ID_EMBLEM_SCHEME_REPORT_DICTIONARY[factionId];
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                    new StackFrame().GetMethod().Name, factionId);
            }
        }
    }
}