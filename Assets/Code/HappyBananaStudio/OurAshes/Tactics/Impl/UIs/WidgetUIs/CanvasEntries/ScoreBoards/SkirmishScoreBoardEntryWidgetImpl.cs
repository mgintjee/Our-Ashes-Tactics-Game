namespace HappyBananaStudio.OurAshes.Tactics.Impl.UIs.WidgetUIs.CanvasEntries.ScoreBoards
{
    using HappyBananaStudio.OurAshes.Tactics.Abs.UIs.WidgetUIs.CanvasEntires.ScoreBoards;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Information;
    using HappyBananaStudio.OurAshes.Tactics.Common.Managers.CodeObjects;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public class SkirmishScoreBoardEntryWidgetImpl
        : AbstractScoreBoardEntryWidgetImpl
    {
        /// <summary>
        /// Todo
        /// </summary>
        public override void UpdateEntry()
        {
            int scoreValue = this.GetCurrentScoreValue();
            this.scoreValueWidget.UpdateScoreText(scoreValue.ToString());
            this.scoreValueWidget.UpdateScoreVisual((scoreValue * 1f) / this.maxScoreValue);
        }

        /// <summary>
        /// Todo
        /// </summary>
        protected override void SetMaxScoreValue()
        {
            this.maxScoreValue = this.GetCurrentScoreValue();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        private int GetCurrentScoreValue()
        {
            ISet<ITalonIdentificationReport> factionTalonIdentificationReportSet = RosterObjectManager
                .GetAllTalonIdentificationReportSet(this.factionId);
            ISet<ITalonIdentificationReport> activeTalonIdentificationReportSet = RosterObjectManager
                .GetActiveTalonIdentificationReportSet();
            factionTalonIdentificationReportSet.IntersectWith(activeTalonIdentificationReportSet);
            int factionValue = factionTalonIdentificationReportSet.Count;
            return factionValue;
        }
    }
}