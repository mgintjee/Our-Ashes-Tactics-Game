namespace HappyBananaStudio.OurAshes.Tactics.Impl.Widgets.WinConditions
{
    using HappyBananaStudio.OurAshes.Tactics.Abs.Widgets;
    using HappyBananaStudio.OurAshes.Tactics.Api.Loggers;
    using HappyBananaStudio.OurAshes.Tactics.Api.Widgets;
    using HappyBananaStudio.OurAshes.Tactics.Api.Widgets.ScoreBoards;
    using HappyBananaStudio.OurAshes.Tactics.Api.Widgets.ScoreBoards.Entries;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Factions;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.GameTypes;
    using HappyBananaStudio.OurAshes.Tactics.Common.Managers.CodeObjects;
    using HappyBananaStudio.OurAshes.Tactics.Common.ResourceLoaders;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Widgets;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Loggers;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Unity.Scripts;
    using System.Collections.Generic;
    using System.Diagnostics;
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// ScoreBoard Widget Impl
    /// </summary>
    public class ScoreBoardWidgetImpl
        : AbstractCanvasWidgetImpl, IScoreBoardWidget
    {
        // Todo
        private readonly Vector2 widgetDimension = new Vector2(2, 2);
        // Todo
        private readonly Vector2 widgetPosition = new Vector2(0, 7);
        // Todo
        private readonly IList<IScoreBoardFactionWidget> scoreBoardFactionWidgetList = new List<IScoreBoardFactionWidget>();

        /// <summary>
        /// Todo
        /// </summary>
        private void Start()
        {
            this.GetComponent<RectTransform>().anchoredPosition = WidgetGridUtil.GetWidgetPositionFrom(
                this.widgetPosition, this.widgetDimension);
            this.GetComponent<RectTransform>().sizeDelta = WidgetGridUtil.GetWidgetDimensionsFrom(this.widgetDimension);
            float cellWidth = this.GetComponent<RectTransform>().rect.width / 2;
            float cellHeight = this.GetComponent<RectTransform>().rect.height / RosterObjectManager.GetFactionIdSet().Count;
            this.GetComponent<GridLayoutGroup>().cellSize = new Vector2(cellWidth, cellHeight);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="gameType">
        /// </param>
        void IScoreBoardWidget.LoadEntryWidgets(GameTypeEnum gameType)
        {
            Rect rect = this.GetComponent<RectTransform>().rect;
            this.GetComponent<GridLayoutGroup>().cellSize = new Vector2(
                1, rect.height / RosterObjectManager.GetFactionIdSet().Count);

            foreach (FactionIdEnum factionId in RosterObjectManager.GetFactionIdSet())
            {
                IScoreBoardFactionWidget scoreBoardFactionWidget = WidgetResourceLoader.ScoreBoards.Factions
                    .LoadScoreBoardFactionWidget(gameType);
                scoreBoardFactionWidget.Initialize(factionId);

                scoreBoardFactionWidget.GetTransform().SetParent(this.transform);

                scoreBoardFactionWidget.UpdateWidgetPosition();
                scoreBoardFactionWidget.UpdateWidgetDimensions();

                this.scoreBoardFactionWidgetList.Add(scoreBoardFactionWidget);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        void IScoreBoardWidget.UpdateEntryWidgets()
        {
            // Todo
            foreach (IScoreBoardFactionWidget winConditionEntry in this.scoreBoardFactionWidgetList)
            {
                winConditionEntry.UpdateEntry();
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        void IWidget.UpdateWidgetPosition()
        {
            this.GetTransform().localPosition = Vector3.zero;
        }

        /// <summary>
        /// Todo
        /// </summary>
        void IWidget.UpdateWidgetDimensions()
        {
            this.GetTransform().localScale = Vector3.one;
        }
    }
}
