namespace HappyBananaStudio.OurAshes.Tactics.Common.ResourceLoaders
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Customization;
    using HappyBananaStudio.OurAshes.Tactics.Api.UIs.CanvasUIs;
    using HappyBananaStudio.OurAshes.Tactics.Api.UIs.WidgetUIs.Basics;
    using HappyBananaStudio.OurAshes.Tactics.Api.UIs.WidgetUIs.CanvasEntries;
    using HappyBananaStudio.OurAshes.Tactics.Api.UIs.WidgetUIs.Complex;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.GameTypes;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Exceptions;
    using HappyBananaStudio.OurAshes.Tactics.Impl.UIs.CanvasUIs;
    using HappyBananaStudio.OurAshes.Tactics.Impl.UIs.WidgetUIs.Basics;
    using HappyBananaStudio.OurAshes.Tactics.Impl.UIs.WidgetUIs.CanvasEntries.ScoreBoards;
    using HappyBananaStudio.OurAshes.Tactics.Impl.UIs.WidgetUIs.Complex;
    using System.Diagnostics;
    using UnityEngine;

    /// <summary>
    /// Todo
    /// </summary>
    public class UIResourceLoader
    {
        /// <summary>
        /// Todo
        /// </summary>
        public class CanvasUIs
        {
            // Todo
            private static readonly string ActionMenuWidgetName = "actionMenuWidget";

            // Todo
            private static readonly string InformationWidgetName = "informationWidget";

            // Todo
            private static readonly string ScoreBoardWidgetName = "scoreBoardWidget";

            // Todo
            private static readonly string SettingsMenuWidgetName = "settingsMenuWidget";

            // Todo
            private static readonly string TurnScollerWidgetName = "turnScrollerWidget";

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="parentTransform">
            /// </param>
            /// <returns>
            /// </returns>
            public static ICanvasUI LoadActionMenuWidget(Transform parentTransform)
            {
                ICanvasUI actionMenuWidget = LoadActionMenuWidget();
                actionMenuWidget.GetTransform().SetParent(parentTransform);
                actionMenuWidget.GetTransform().localPosition = Vector3.zero;
                return actionMenuWidget;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="parentTransform">
            /// </param>
            /// <returns>
            /// </returns>
            public static ICanvasUI LoadInformationWidget(Transform parentTransform)
            {
                ICanvasUI informationWidget = LoadInformationWidget();
                informationWidget.GetTransform().SetParent(parentTransform);
                informationWidget.GetTransform().localPosition = Vector3.zero;
                return informationWidget;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="parentTransform">
            /// </param>
            /// <returns>
            /// </returns>
            public static ICanvasUI LoadScoreBoardWidget(Transform parentTransform)
            {
                ICanvasUI scoreBoardWidget = LoadScoreBoardWidget();
                scoreBoardWidget.GetTransform().SetParent(parentTransform);
                scoreBoardWidget.GetTransform().localPosition = Vector3.zero;
                return scoreBoardWidget;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="parentTransform">
            /// </param>
            /// <returns>
            /// </returns>
            public static ICanvasUI LoadSettingsMenuWidget(Transform parentTransform)
            {
                ICanvasUI settingsMenuWidget = LoadSettingsMenuWidget();
                settingsMenuWidget.GetTransform().SetParent(parentTransform);
                settingsMenuWidget.GetTransform().localPosition = Vector3.zero;
                return settingsMenuWidget;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="parentTransform">
            /// </param>
            /// <returns>
            /// </returns>
            public static ICanvasUI LoadTurnScrollerWidget(Transform parentTransform)
            {
                ICanvasUI turnScrollerWidget = LoadTurnScrollerWidget();
                turnScrollerWidget.GetTransform().SetParent(parentTransform);
                turnScrollerWidget.GetTransform().localPosition = Vector3.zero;
                return turnScrollerWidget;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns>
            /// </returns>
            private static ICanvasUI LoadActionMenuWidget()
            {
                return new GameObject(ActionMenuWidgetName).AddComponent<ActionMenuWidgetImpl>();
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns>
            /// </returns>
            private static ICanvasUI LoadInformationWidget()
            {
                return new GameObject(InformationWidgetName).AddComponent<InformationWidgetImpl>();
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns>
            /// </returns>
            private static ICanvasUI LoadScoreBoardWidget()
            {
                return new GameObject(ScoreBoardWidgetName).AddComponent<ScoreBoardWidgetImpl>();
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns>
            /// </returns>
            private static ICanvasUI LoadSettingsMenuWidget()
            {
                return new GameObject(SettingsMenuWidgetName).AddComponent<SettingsMenuWidgetImpl>();
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns>
            /// </returns>
            private static ICanvasUI LoadTurnScrollerWidget()
            {
                return new GameObject(TurnScollerWidgetName).AddComponent<TurnScrollerWidgetImpl>();
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class WidgetUIs
        {
            /// <summary>
            /// Todo
            /// </summary>
            public class Basics
            {
                // Todo
                private static readonly string BasicImageWidgetName = "basicImageWidget";

                // Todo
                private static readonly string BasicTextWidgetName = "basicTextWidget";

                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="parentTransform">
                /// </param>
                /// <returns>
                /// </returns>
                public static IBasicImageWidget LoadBasicImageWidget(Transform parentTransform)
                {
                    IBasicImageWidget basicImageWidget = LoadSimpleImageWidget();
                    basicImageWidget.GetTransform().SetParent(parentTransform);
                    basicImageWidget.GetTransform().localPosition = Vector3.zero;
                    return basicImageWidget;
                }

                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="parentTransform">
                /// </param>
                /// <returns>
                /// </returns>
                public static IBasicTextWidget LoadBasicTextWidget(Transform parentTransform)
                {
                    IBasicTextWidget basicTextWidget = LoadBasicTextWidget();
                    basicTextWidget.GetTransform().SetParent(parentTransform);
                    basicTextWidget.GetTransform().localPosition = Vector3.zero;
                    return basicTextWidget;
                }

                /// <summary>
                /// Todo
                /// </summary>
                /// <returns>
                /// </returns>
                private static IBasicTextWidget LoadBasicTextWidget()
                {
                    return new GameObject(BasicTextWidgetName).AddComponent<BasicTextWidgetImpl>();
                }

                /// <summary>
                /// Todo
                /// </summary>
                /// <returns>
                /// </returns>
                private static IBasicImageWidget LoadSimpleImageWidget()
                {
                    return new GameObject(BasicImageWidgetName).AddComponent<BasicImageWidgetImpl>();
                }
            }

            /// <summary>
            /// Todo
            /// </summary>
            public class CanvasEntries
            {
                /// <summary>
                /// Todo
                /// </summary>
                public class ScoreBoards
                {
                    // Todo
                    private static readonly string SkirmishScoreBoardWidgetName = "skirmishScoreBoardEntryWidget";

                    /// <summary>
                    /// Todo
                    /// </summary>
                    /// <param name="parentTransform">
                    /// </param>
                    /// <returns>
                    /// </returns>
                    public static IScoreBoardEntryWidget LoadScoreBoardEntryWidget(Transform parentTransform, GameTypeEnum gameType)
                    {
                        IScoreBoardEntryWidget scoreBoardEntryWidget;
                        switch (gameType)
                        {
                            case GameTypeEnum.FactionSkirmish:
                                scoreBoardEntryWidget = LoadSkirmishScoreBoardEntryWidget();
                                break;

                            default:
                                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid parameters. ? is not supported.",
                                    new StackFrame().GetMethod().Name, gameType);
                        }
                        scoreBoardEntryWidget.GetTransform().SetParent(parentTransform);
                        scoreBoardEntryWidget.GetTransform().localPosition = Vector3.zero;
                        return scoreBoardEntryWidget;
                    }

                    /// <summary>
                    /// Todo
                    /// </summary>
                    /// <returns>
                    /// </returns>
                    private static IScoreBoardEntryWidget LoadSkirmishScoreBoardEntryWidget()
                    {
                        return new GameObject(SkirmishScoreBoardWidgetName).AddComponent<SkirmishScoreBoardEntryWidgetImpl>();
                    }
                }

                /// <summary>
                /// Todo
                /// </summary>
                public class TurnScrollers
                {
                    // Todo
                    private static readonly string DoubleTurnScrollerEntryWidgetName = "doubleTurnScrollerEntryWidget";

                    // Todo
                    private static readonly string SingleTurnScrollerEntryWidgetName = "singleTurnScrollerEntryWidget";

                    /// <summary>
                    /// Todo
                    /// </summary>
                    /// <param name="parentTransform">
                    /// </param>
                    /// <returns>
                    /// </returns>
                    public static ITurnScrollerEntryWidget LoadDoubeTurnScrollerEntryWidget(Transform parentTransform)
                    {
                        ITurnScrollerEntryWidget turnScrollerEntryWidget = LoadDoubeTurnScrollerEntryWidget();
                        turnScrollerEntryWidget.GetTransform().SetParent(parentTransform);
                        turnScrollerEntryWidget.GetTransform().localPosition = Vector3.zero;
                        return turnScrollerEntryWidget;
                    }

                    /// <summary>
                    /// Todo
                    /// </summary>
                    /// <param name="parentTransform">
                    /// </param>
                    /// <returns>
                    /// </returns>
                    public static ITurnScrollerEntryWidget LoadSingleTurnScrollerEntryWidget(Transform parentTransform)
                    {
                        ITurnScrollerEntryWidget turnScrollerEntryWidget = LoadSingleTurnScrollerEntryWidget();
                        turnScrollerEntryWidget.GetTransform().SetParent(parentTransform);
                        turnScrollerEntryWidget.GetTransform().localPosition = Vector3.zero;
                        return turnScrollerEntryWidget;
                    }

                    /// <summary>
                    /// Todo
                    /// </summary>
                    /// <returns>
                    /// </returns>
                    private static ITurnScrollerEntryWidget LoadDoubeTurnScrollerEntryWidget()
                    {
                        return new GameObject(DoubleTurnScrollerEntryWidgetName).AddComponent<DoubleTurnScrollerEntryWidgetImpl>();
                    }

                    /// <summary>
                    /// Todo
                    /// </summary>
                    /// <returns>
                    /// </returns>
                    private static ITurnScrollerEntryWidget LoadSingleTurnScrollerEntryWidget()
                    {
                        return new GameObject(SingleTurnScrollerEntryWidgetName).AddComponent<SingleTurnScrollerEntryWidgetImpl>();
                    }
                }
            }

            /// <summary>
            /// Todo
            /// </summary>
            public class Complex
            {
                // Todo
                private static readonly string EmblemWidgetName = "emblemWidget";

                // Todo
                private static readonly string ScoreValueWidgetName = "scoreValueWidget";

                // Todo
                private static readonly string TalonDoubleEmblemWidgetName = "talonDoubleEmblemWidget";

                // Todo
                private static readonly string TalonSingleEmblemWidgetName = "talonSingleEmblemWidget";

                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="parentTransform">
                /// </param>
                /// <returns>
                /// </returns>
                public static IEmblemWidget LoadEmblemWidget(Transform parentTransform)
                {
                    IEmblemWidget emblemWidget = LoadEmblemWidget();
                    emblemWidget.GetTransform().SetParent(parentTransform);
                    emblemWidget.GetTransform().localPosition = Vector3.zero;
                    return emblemWidget;
                }

                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="parentTransform">
                /// </param>
                /// <returns>
                /// </returns>
                public static IScoreValueWidget LoadScoreValueWidget(Transform parentTransform)
                {
                    IScoreValueWidget scoreValueWidget = LoadScoreValueWidget();
                    scoreValueWidget.GetTransform().SetParent(parentTransform);
                    scoreValueWidget.GetTransform().localPosition = Vector3.zero;
                    return scoreValueWidget;
                }

                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="parentTransform">
                /// </param>
                /// <returns>
                /// </returns>
                public static ITalonEmblemWidget LoadTalonDoubleEmblemWidget(Transform parentTransform)
                {
                    ITalonEmblemWidget talonEmblemWidget = LoadTalonDoubleEmblemWidget();
                    talonEmblemWidget.GetTransform().SetParent(parentTransform);
                    talonEmblemWidget.GetTransform().localPosition = Vector3.zero;
                    return talonEmblemWidget;
                }

                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="talonCustomizationReport">
                /// </param>
                /// <param name="parentTransform">
                /// </param>
                /// <returns>
                /// </returns>
                public static ITalonEmblemWidget LoadTalonEmblemWidget(ITalonCustomizationReport talonCustomizationReport, Transform parentTransform)
                {
                    if (talonCustomizationReport.GetPhalanxColorSchemeReport() == null &&
                        talonCustomizationReport.GetPhalanxEmblemSchemeReport() == null)
                    {
                        return LoadTalonSingleEmblemWidget(parentTransform);
                    }
                    else
                    {
                        return LoadTalonDoubleEmblemWidget(parentTransform);
                    }
                }

                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="parentTransform">
                /// </param>
                /// <returns>
                /// </returns>
                public static ITalonEmblemWidget LoadTalonSingleEmblemWidget(Transform parentTransform)
                {
                    ITalonEmblemWidget talonEmblemWidget = LoadTalonSingleEmblemWidget();
                    talonEmblemWidget.GetTransform().SetParent(parentTransform);
                    talonEmblemWidget.GetTransform().localPosition = Vector3.zero;
                    return talonEmblemWidget;
                }

                /// <summary>
                /// Todo
                /// </summary>
                /// <returns>
                /// </returns>
                private static IEmblemWidget LoadEmblemWidget()
                {
                    return new GameObject(EmblemWidgetName).AddComponent<EmblemWidgetImpl>();
                }

                /// <summary>
                /// Todo
                /// </summary>
                /// <returns>
                /// </returns>
                private static IScoreValueWidget LoadScoreValueWidget()
                {
                    return new GameObject(ScoreValueWidgetName).AddComponent<ScoreValueWidgetImpl>();
                }

                /// <summary>
                /// Todo
                /// </summary>
                /// <returns>
                /// </returns>
                private static ITalonEmblemWidget LoadTalonDoubleEmblemWidget()
                {
                    return new GameObject(TalonDoubleEmblemWidgetName).AddComponent<TalonDoubleEmblemWidgetImpl>();
                }

                /// <summary>
                /// Todo
                /// </summary>
                /// <returns>
                /// </returns>
                private static ITalonEmblemWidget LoadTalonSingleEmblemWidget()
                {
                    return new GameObject(TalonSingleEmblemWidgetName).AddComponent<TalonSingleEmblemWidgetImpl>();
                }
            }
        }
    }
}