namespace HappyBananaStudio.OurAshes.Tactics.Common.ResourceLoaders
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Emblems.Widgets.Emblems;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Customization;
    using HappyBananaStudio.OurAshes.Tactics.Api.Widgets;
    using HappyBananaStudio.OurAshes.Tactics.Api.Widgets.ScoreBoards;
    using HappyBananaStudio.OurAshes.Tactics.Api.Widgets.ScoreBoards.Entries;
    using HappyBananaStudio.OurAshes.Tactics.Api.Widgets.Texts;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.GameTypes;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Talons;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Exceptions;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Widgets.WinConditions.Entries;
    using System.Diagnostics;
    using UnityEngine;

    /// <summary>
    /// Todo
    /// </summary>
    public class WidgetResourceLoader
    {
        // Todo: Store somewhere else. Maybe in a Resources File Structure class
        private static readonly string WidgetsFolderHome = "Widgets/";

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="path">
        /// </param>
        /// <returns>
        /// </returns>
        private static IWidget LoadWidgetResource(string path)
        {
            GameObject gameObject = GameObjectResourceLoader.LoadGameObjectResource(path);
            if (gameObject != null)
            {
                IWidget widget = gameObject.GetComponent<IWidget>();
                if (widget != null)
                {
                    return widget;
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to ?. Invalid parameters. " +
                        "Loaded GameObject is not a Widget for Path=?.", new StackFrame().GetMethod().Name, path);
                }
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid parameters. " +
                    "GameObject is null for Path=?.", new StackFrame().GetMethod().Name, path);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Texts
        {
            // Todo
            private static readonly string TextsWidgetsFolderHome = WidgetsFolderHome + "Texts/";

            // Todo
            private static readonly string SimpleTextWidgetName = "simpleTextWidget";

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="callSign">
            /// </param>
            /// <returns>
            /// </returns>
            public static ISimpleTextWidget LoadSimpleTextWidget()
            {
                ISimpleTextWidget simpleTextWidget = (ISimpleTextWidget)LoadWidgetResource(
                    TextsWidgetsFolderHome + SimpleTextWidgetName);
                simpleTextWidget.GetTransform().name = SimpleTextWidgetName;
                return simpleTextWidget;
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Emblems
        {
            // Todo
            private static readonly string EmblemWidgetsFolderHome = WidgetsFolderHome + "Emblems/";

            // Todo
            private static readonly string TalonEmblemWidgetName = "talonEmblemWidget";

            // Todo
            private static readonly string EmblemWidgetName = "emblemWidget";

            // Todo
            private static readonly string CallSignWidgetName = "callSignWidget";

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="callSign">
            /// </param>
            /// <param name="talonCustomizationReport">
            /// </param>
            /// <returns>
            /// </returns>
            public static ITalonEmblemWidget LoadTalonEmblemWidgetResource(CallSignEnum callSign,
                    ITalonCustomizationReport talonCustomizationReport)
            {
                if (!callSign.Equals(CallSignEnum.None) &&
                    talonCustomizationReport != null)
                {
                    ITalonEmblemWidget talonEmblemGameObject = (ITalonEmblemWidget)LoadWidgetResource(
                        EmblemWidgetsFolderHome + TalonEmblemWidgetName);
                    talonEmblemGameObject.GetTransform().name = "";
                    talonEmblemGameObject.Initialize(talonCustomizationReport, callSign);
                    return talonEmblemGameObject;
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters.",
                        new StackFrame().GetMethod().Name);
                }
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="emblemSchemeReport">
            /// </param>
            /// <param name="colorSchemeReport">
            /// </param>
            /// <returns>
            /// </returns>
            public static IEmblemWidget LoadEmblemWidget(IEmblemSchemeReport emblemSchemeReport, IColorSchemeReport colorSchemeReport)
            {
                if (emblemSchemeReport != null &&
                    colorSchemeReport != null)
                {
                    IEmblemWidget emblemWidget = (IEmblemWidget)LoadWidgetResource(
                        EmblemWidgetsFolderHome + EmblemWidgetName);
                    emblemWidget.UpdateForegroundSprite(emblemSchemeReport.GetEmblemBackgroundId());
                    emblemWidget.UpdateIconSprite(emblemSchemeReport.GetEmblemIconId());
                    emblemWidget.UpdateBackgroundColor(colorSchemeReport.GetPrimaryPaintColorId());
                    emblemWidget.UpdateForegroundColor(colorSchemeReport.GetSecondaryPaintColorId());
                    emblemWidget.UpdateIconColor(colorSchemeReport.GetTertiaryPaintColorId());
                    emblemWidget.GetTransform().name = EmblemWidgetName;
                    return emblemWidget;
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters.",
                        new StackFrame().GetMethod().Name);
                }
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class ScoreBoards
        {
            // Todo
            private static readonly string ScoreBoardWidgetsFolderHome = WidgetsFolderHome + "ScoreBoards/";

            // Todo
            private static readonly string ScoreBoardWidgetName = "scoreBoardWidget";

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns>
            /// </returns>
            public static IScoreBoardWidget LoadScoreBoardWidget()
            {
                IScoreBoardWidget winConditionWidget = (IScoreBoardWidget)LoadWidgetResource(
                    ScoreBoardWidgetsFolderHome + ScoreBoardWidgetName);
                winConditionWidget.GetTransform().name = ScoreBoardWidgetName;
                return winConditionWidget;
            }

            /// <summary>
            /// Todo
            /// </summary>
            public class Factions
            {
                // Todo
                private static readonly string ScoreBoardFactionsWidgetsFolderHome = ScoreBoardWidgetsFolderHome + "Factions/";

                // Todo
                private static readonly string ScoreBoardFactionWidgetName = "scoreBoardFactionWidget";

                /// <summary>
                /// Todo
                /// </summary>
                /// <returns>
                /// </returns>
                public static IScoreBoardFactionWidget LoadScoreBoardFactionWidget(GameTypeEnum gameType)
                {
                    GameObject scoreBoardFactionWidgetGameObject = GameObjectResourceLoader.LoadGameObjectResource(
                        ScoreBoardFactionsWidgetsFolderHome + ScoreBoardFactionWidgetName);
                    IScoreBoardFactionWidget scoreBoardFactionWidget;
                    switch (gameType)
                    {
                        case GameTypeEnum.Skirmish:
                            scoreBoardFactionWidget = scoreBoardFactionWidgetGameObject
                                .AddComponent<ScoreBoardFactionWidgetSkirmishImpl>();
                            break;

                        default:
                            throw ArgumentExceptionUtil.Build("Unable to ?. ? is not supported.", new StackFrame().GetMethod().Name, gameType);
                    }
                    scoreBoardFactionWidget.GetTransform().name = ScoreBoardFactionWidgetName;
                    return scoreBoardFactionWidget;
                }
            }
        }
    }
}
