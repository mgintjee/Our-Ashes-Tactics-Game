namespace HappyBananaStudio.OurAshes.Tactics.Abs.UIs.WidgetUIs.CanvasEntires.ScoreBoards
{
    using HappyBananaStudio.OurAshes.Tactics.Abs.UIs.WidgetUIs.Complex;
    using HappyBananaStudio.OurAshes.Tactics.Api.Loggers;
    using HappyBananaStudio.OurAshes.Tactics.Api.UIs.WidgetUIs.CanvasEntries;
    using HappyBananaStudio.OurAshes.Tactics.Api.UIs.WidgetUIs.Complex;
    using HappyBananaStudio.OurAshes.Tactics.Common.Constants.Factions.Schemes;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Factions;
    using HappyBananaStudio.OurAshes.Tactics.Common.ResourceLoaders;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Exceptions;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Loggers;
    using System.Diagnostics;
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// Abstract ScoreBoardEntry Widget Impl
    /// </summary>
    public abstract class AbstractScoreBoardEntryWidgetImpl
        : AbstractComplexWidgetImpl, IScoreBoardEntryWidget
    {
        // Todo
        protected IEmblemWidget factionEmblemWidget;

        // Todo
        protected FactionId factionId = FactionId.None;

        // Todo
        protected int maxScoreValue = int.MinValue;

        // Todo
        protected IScoreValueWidget scoreValueWidget;

        // Provide logging capability
        private static readonly ICodeLogger logger = new CodeLoggerImpl(new StackFrame().GetMethod().DeclaringType);

        /// <summary>
        /// Todo
        /// </summary>
        public abstract void UpdateEntry();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="factionId">
        /// </param>
        void IScoreBoardEntryWidget.Initialize(FactionId factionId)
        {
            logger.Debug("Initializing ? with ?=?", this.GetType(), typeof(FactionId), factionId);
            if (!factionId.Equals(FactionId.None))
            {
                if (this.factionId.Equals(FactionId.None))
                {
                    this.factionId = factionId;
                    this.factionEmblemWidget.Initialize(FactionSchemeConstants.GetFactionEmblemSchemeReport(this.factionId),
                    FactionSchemeConstants.GetFactionColorSchemeReport(this.factionId));

                    float parentCellWidth = this.GetTransform().parent.GetComponent<GridLayoutGroup>().cellSize.x;
                    float parentCellHeight = this.GetTransform().parent.GetComponent<GridLayoutGroup>().cellSize.y;

                    this.GetComponent<RectTransform>().sizeDelta = new Vector2(parentCellWidth, parentCellHeight);

                    float cellWidth = this.GetComponent<RectTransform>().rect.width / 2;
                    float cellHeight = this.GetComponent<RectTransform>().rect.height;

                    this.GetComponent<GridLayoutGroup>().cellSize = new Vector2(cellWidth, cellHeight);
                    this.GetComponent<GridLayoutGroup>().constraint = GridLayoutGroup.Constraint.FixedRowCount;
                    this.GetComponent<GridLayoutGroup>().constraintCount = 1;

                    this.factionEmblemWidget.UpdateWidgetDimensions(this.GetComponent<GridLayoutGroup>().cellSize);
                    this.scoreValueWidget.UpdateWidgetDimensions(this.GetComponent<GridLayoutGroup>().cellSize);

                    this.SetMaxScoreValue();
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to ?. ? is already initialized.",
                        new StackFrame().GetMethod().Name, this.GetType());
                }
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid parameters.", new StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        protected override void LoadChildWidgets()
        {
            this.GetGameObject().AddComponent<RectTransform>();
            this.GetGameObject().AddComponent<GridLayoutGroup>();
            this.factionEmblemWidget = UIResourceLoader.WidgetUIs.Complex.LoadEmblemWidget(this.GetTransform());
            this.scoreValueWidget = UIResourceLoader.WidgetUIs.Complex.LoadScoreValueWidget(this.GetTransform());
            // Add all of the children to the Set
            this.childWidgetSet.Add(this.factionEmblemWidget);
            this.childWidgetSet.Add(this.scoreValueWidget);
        }

        /// <summary>
        /// Todo
        /// </summary>
        protected abstract void SetMaxScoreValue();
    }
}
