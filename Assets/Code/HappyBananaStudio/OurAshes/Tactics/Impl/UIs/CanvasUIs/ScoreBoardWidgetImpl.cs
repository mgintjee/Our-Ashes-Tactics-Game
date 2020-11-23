namespace HappyBananaStudio.OurAshes.Tactics.Impl.UIs.CanvasUIs
{
    using HappyBananaStudio.OurAshes.Tactics.Abs.UIs.CanvasUIs;
    using HappyBananaStudio.OurAshes.Tactics.Api.UIs.CanvasUIs;
    using HappyBananaStudio.OurAshes.Tactics.Api.UIs.WidgetUIs.CanvasEntries;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Factions;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.GameTypes;
    using HappyBananaStudio.OurAshes.Tactics.Common.Managers.CodeObjects;
    using HappyBananaStudio.OurAshes.Tactics.Common.ResourceLoaders;
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// ScoreBoard Widget Impl
    /// </summary>
    public class ScoreBoardWidgetImpl
        : AbstractCanvasUIImpl, ICanvasUI
    {
        /// <summary>
        /// Todo
        /// </summary>
        protected override void ImplInitialization()
        {
            float cellWidth = this.GetComponent<RectTransform>().rect.width;
            float cellHeight = this.GetComponent<RectTransform>().rect.height / RosterObjectManager.GetFactionIdSet().Count;
            this.GetComponent<GridLayoutGroup>().cellSize = new Vector2(cellWidth, cellHeight);
            this.GetComponent<GridLayoutGroup>().constraint = GridLayoutGroup.Constraint.FixedColumnCount;
            this.GetComponent<GridLayoutGroup>().constraintCount = 1;

            foreach (FactionId factionId in RosterObjectManager.GetFactionIdSet())
            {
                IScoreBoardEntryWidget scoreBoardEntryWidget = UIResourceLoader.WidgetUIs.CanvasEntries.ScoreBoards
                    .LoadScoreBoardEntryWidget(this.GetTransform(), GameTypeEnum.FactionSkirmish);
                scoreBoardEntryWidget.Initialize(factionId);
                scoreBoardEntryWidget.UpdateWidgetDimensions(this.GetComponent<GridLayoutGroup>().cellSize);
                //scoreBoardEntryWidget.UpdateWidgetDimensions(new Vector2(1, 1));
                this.canvasEntryWidgetSet.Add(scoreBoardEntryWidget);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        protected override void LoadChildWidgets()
        {
            this.GetGameObject().AddComponent<RectTransform>();
            this.GetGameObject().AddComponent<GridLayoutGroup>();
        }

        /*

/// <summary>
/// Todo
/// </summary>
/// <param name="canvasGridPosition">
/// </param>
/// <param name="canvasGridDimensions">
/// </param>
public override void Initialize(ICanvasGridCoordinates canvasGridPosition, ICanvasGridCoordinates canvasGridDimensions)
{
   this.canvasGridPosition = canvasGridPosition;
   this.canvasGridDimensions = canvasGridDimensions;
   this.UpdateWidgetRectTransform();
   Rect widgetRect = this.GetComponent<RectTransform>().rect;
   Debug.Log("Rect.Width=" + widgetRect.width);
   Debug.Log("Rect.Height=" + widgetRect.height);
   this.cellWidth = widgetRect.width;
   this.cellHeight = widgetRect.height / RosterObjectManager.GetFactionIdSet().Count;
   Debug.Log("CellSize.Width=" + cellWidth);
   Debug.Log("CellSize.Height=" + cellHeight);
   this.gridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
   this.gridLayoutGroup.constraintCount = 1;
   this.gridLayoutGroup.cellSize = new Vector2(this.cellWidth, this.cellHeight);
   float horizontalSpacing = this.cellWidth / 10;
   float verticalSpacing = this.cellHeight / 10;
   this.gridLayoutGroup.spacing = new Vector2(horizontalSpacing, verticalSpacing);
   Debug.Log("Spacing.Width=" + horizontalSpacing);
   Debug.Log("Spacing.Height=" + verticalSpacing);
   //this.gridLayoutGroup.padding = new RectOffset(horizontalPadding / 2, horizontalPadding / 2, verticalPadding / 2, verticalPadding / 2);
}
*/
    }
}