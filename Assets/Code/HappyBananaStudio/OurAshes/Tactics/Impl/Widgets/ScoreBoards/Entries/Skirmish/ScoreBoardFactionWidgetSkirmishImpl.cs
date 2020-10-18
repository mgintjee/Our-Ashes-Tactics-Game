namespace HappyBananaStudio.OurAshes.Tactics.Impl.Widgets.WinConditions.Entries
{
    using HappyBananaStudio.OurAshes.Tactics.Abs.Widgets.ScoreBoards.Entries;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Information;
    using HappyBananaStudio.OurAshes.Tactics.Common.Managers.CodeObjects;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Widgets;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// Todo
    /// </summary>
    public class ScoreBoardFactionWidgetSkirmishImpl
        : AbstractScoreBoardFactionWidgetImpl
    {
        /// <summary>
        /// Todo
        /// </summary>
        private void Start()
        {
            float parentCellWidth = this.GetTransform().parent.GetComponent<GridLayoutGroup>().cellSize.x;
            float parentCellHeight = this.GetTransform().parent.GetComponent<GridLayoutGroup>().cellSize.y;
            this.GetComponent<RectTransform>().sizeDelta = new Vector2(parentCellWidth, parentCellHeight);
            float cellWidth = this.GetComponent<RectTransform>().rect.width;
            float cellHeight = this.GetComponent<RectTransform>().rect.height;
            this.GetComponent<GridLayoutGroup>().cellSize = new Vector2(cellWidth, cellHeight);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public override void UpdateEntry()
        {
            ISet<ITalonIdentificationReport> factionTalonIdentificationReportSet = RosterObjectManager
                .GetAllTalonIdentificationReportSet(this.factionId);
            ISet<ITalonIdentificationReport> activeTalonIdentificationReportSet = RosterObjectManager
                .GetActiveTalonIdentificationReportSet();
            factionTalonIdentificationReportSet.IntersectWith(activeTalonIdentificationReportSet);
            int factionValue = factionTalonIdentificationReportSet.Count;
            this.scoreBoardValueTextWidget.UpdateText(factionValue.ToString());
        }

    }
}
