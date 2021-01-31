/*namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Impl
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// TurnScroller Widget Impl
    /// </summary>
    public class TurnScrollerWidgetImpl
        : AbstractCanvasUIImpl, ICanvasUI
    {
        // Provide logging capability
        private static readonly ICodeLogger Logger = new CodeLoggerImpl(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private IList<ITalonIdentificationReport> orderedTalonIdentificationReportList = new List<ITalonIdentificationReport>();

        // Todo
        // Todo: Instantiate all of the game Emblems at the start and assign their parent to the
        // Talon GameObject
        private IDictionary<ITalonIdentificationReport, ITalonEmblemWidget> talonIdentificationEmblemWidgetDictionary =
            new Dictionary<ITalonIdentificationReport, ITalonEmblemWidget>();

        // Todo
        private IDictionary<ITalonIdentificationReport, ITurnScrollerEntryWidget> talonIdentificationTurnScrollerEntryWidgetDictionary =
            new Dictionary<ITalonIdentificationReport, ITurnScrollerEntryWidget>();

        /// <summary>
        /// Todo
        /// </summary>
        protected override void ImplInitialization()
        {
            // Store the cellDimensions in some other static class?
            float cellWidth = this.GetComponent<RectTransform>().rect.width / 5;
            float cellHeight = this.GetComponent<RectTransform>().rect.height * 0.85f;
            this.GetComponent<GridLayoutGroup>().spacing = this.GetComponent<RectTransform>().sizeDelta / 25f;
            this.GetComponent<GridLayoutGroup>().cellSize = new Vector2(cellWidth, cellHeight);
            this.GetComponent<GridLayoutGroup>().constraint = GridLayoutGroup.Constraint.FixedRowCount;
            this.GetComponent<GridLayoutGroup>().constraintCount = 1;
            this.orderedTalonIdentificationReportList = TalonTurnOrderManager.GetOrderedTalonIdentificationReportList();
            this.RebuildTurnScrollerEntries();
        }

        /// <summary>
        /// Todo
        /// </summary>
        protected override void LoadChildWidgets()
        {
            this.GetGameObject().AddComponent<RectTransform>();
            this.GetGameObject().AddComponent<GridLayoutGroup>();
        }

        /// <summary>
        /// Todo
        /// </summary>
        protected override void UpdateEntries()
        {
            if (this.canvasEntryWidgetSet.Count == 0)
            {
            }
            else
            {
                base.UpdateEntries();
            }
            // This seems expensive to run every time
            //this.RebuildTurnScrollerEntries();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonIdentificationReport">
        /// </param>
        private void DestroyTurnScrollerEntryWidget(ITalonIdentificationReport talonIdentificationReport)
        {
            if (this.talonIdentificationTurnScrollerEntryWidgetDictionary.ContainsKey(talonIdentificationReport))
            {
                ITurnScrollerEntryWidget turnScrollerEntryWidget = this.talonIdentificationTurnScrollerEntryWidgetDictionary[talonIdentificationReport];
                this.canvasEntryWidgetSet.Remove(turnScrollerEntryWidget);
                turnScrollerEntryWidget.Destroy();
            }
            this.talonIdentificationTurnScrollerEntryWidgetDictionary.Remove(talonIdentificationReport);
            this.orderedTalonIdentificationReportList.Remove(talonIdentificationReport);
        }

        /// <summary>
        /// Todo
        /// </summary>
        private void RebuildTurnScrollerEntries()
        {
            foreach (ITalonIdentificationReport talonIdentificationReport in this.talonIdentificationTurnScrollerEntryWidgetDictionary.Keys)
            {
                this.talonIdentificationTurnScrollerEntryWidgetDictionary[talonIdentificationReport].Destroy();
            }
            this.talonIdentificationTurnScrollerEntryWidgetDictionary.Clear();
            foreach (ITalonIdentificationReport talonIdentificationReport in this.orderedTalonIdentificationReportList)
            {
                ITalonCustomizationReport talonCustomizationReport = RosterObjectManager.GetTalonObject(talonIdentificationReport)
                    .GetTalonInformationReport().GetTalonCustomizationReport();
                ITurnScrollerEntryWidget turnScrollerEntryWidget;

                // Todo: Have a util for this public static bool isDoubleEmblem
                if (talonCustomizationReport.GetPhalanxColorSchemeReport() != null &&
                    talonCustomizationReport.GetPhalanxEmblemSchemeReport() != null)
                {
                    turnScrollerEntryWidget = UIResourceLoader.WidgetUIs.CanvasEntries.TurnScrollers
                        .LoadSingleTurnScrollerEntryWidget(this.GetTransform());
                }
                else
                {
                    turnScrollerEntryWidget = UIResourceLoader.WidgetUIs.CanvasEntries.TurnScrollers
                        .LoadDoubeTurnScrollerEntryWidget(this.GetTransform());
                }

                turnScrollerEntryWidget.Initialize(talonIdentificationReport);
                turnScrollerEntryWidget.UpdateWidgetDimensions(this.GetComponent<GridLayoutGroup>().cellSize);
                this.canvasEntryWidgetSet.Add(turnScrollerEntryWidget);
                this.talonIdentificationTurnScrollerEntryWidgetDictionary.Add(talonIdentificationReport, turnScrollerEntryWidget);
            }
        }

        /*
        /// <summary>
        /// Todo
        /// </summary>
        protected override void UpdateEntries()
        {
            Logger.Debug("Old List: \n\t>?", string.Join("\n\t>", this.ordererdTalonIdentificationReportList));
            Logger.Debug("New List: \n\t>?", string.Join("\n\t>", newOrdererdTalonIdentificationReportList));
            // Shit's broken
            if (this.ordererdTalonIdentificationReportList.Count == 0)
            {
                Logger.Debug("Assign new list to old");
                this.ordererdTalonIdentificationReportList = new List<ITalonIdentificationReport>(newOrdererdTalonIdentificationReportList);
                foreach (ITalonIdentificationReport talonIdentificationReport in this.ordererdTalonIdentificationReportList)
                {
                    ITalonObject talonObject = RosterObjectManager.GetTalonObject(talonIdentificationReport);
                    ITalonCustomizationReport talonCustomizationReport = talonObject.GetTalonInformationReport().GetTalonCustomizationReport();
                    /*
                     * ITalonEmblemWidget talonEmblemWidget = WidgetResourceLoader.Emblems
                         .LoadTalonEmblemWidgetResource(talonIdentificationReport.GetCallSign(), talonCustomizationReport);
                     talonEmblemWidget.GetTransform().SetParent(this.GetTransform());
                     // Todo: Calculate somewhere else
                     //talonEmblemWidget.UpdateEmblemScale(new Vector3(0.5f, 0.5f, 0.5f));
                     talonEmblemWidget.UpdateWidgetDimensions(new Vector2(1, 1));
                     this.talonIdentificationEmblemWidgetDictionary.Add(talonIdentificationReport, talonEmblemWidget);
                }
            }
            else if (!this.ordererdTalonIdentificationReportList.SequenceEqual(newOrdererdTalonIdentificationReportList))
            {
                Logger.Debug("Find discrepancies");
                ISet<ITalonIdentificationReport> expiredTalonIdentificationReportSet = new HashSet<ITalonIdentificationReport>();
                foreach (ITalonIdentificationReport talonIdentificationReport in this.ordererdTalonIdentificationReportList)
                {
                    if (!newOrdererdTalonIdentificationReportList.Contains(talonIdentificationReport))
                    {
                        expiredTalonIdentificationReportSet.Add(talonIdentificationReport);
                    }
                }
                foreach (ITalonIdentificationReport talonIdentificationReport in this.ordererdTalonIdentificationReportList)
                {
                    if (!talonIdentificationReport.Equals(newOrdererdTalonIdentificationReportList[0]))
                    {
                        expiredTalonIdentificationReportSet.Add(talonIdentificationReport);
                    }
                    else
                    {
                        break;
                    }
                }
                foreach (ITalonIdentificationReport talonIdentificationReport in expiredTalonIdentificationReportSet)
                {
                    this.ordererdTalonIdentificationReportList.Remove(talonIdentificationReport);
                    if (this.talonIdentificationEmblemWidgetDictionary.ContainsKey(talonIdentificationReport))
                    {
                        this.talonIdentificationEmblemWidgetDictionary[talonIdentificationReport].Destroy();
                        this.talonIdentificationEmblemWidgetDictionary.Remove(talonIdentificationReport);
                    }
                }
            }
        if (this.ordererdTalonIdentificationReportList != newOrdererdTalonIdentificationReportList)
        {
            Logger.Debug("Update TurnScroller!");
            foreach(ITalonIdentificationReport talonIdentificationReport in this.ordererdTalonIdentificationReportList)
            {
                if(talonIdentificationReport != newOrdererdTalonIdentificationReportList[0])
            }
            // Iterate over the old list and remove until it matches with the new list If the old
            // list is null/empty, assign the new list
            foreach (ITalonEmblemWidget talonEmblemWidget in this.talonTurnEmblemSet)
            {
                if (talonEmblemWidget != null)
                {
                    talonEmblemWidget.Destroy();
                }
            }

            this.ordererdTalonIdentificationReportList.Clear();
            foreach (ITalonIdentificationReport talonIdentificationReport in ordererdTalonIdentificationReportList)
            {
                ITalonObject talonObject = RosterObjectManager.GetTalonObject(talonIdentificationReport);
                ITalonCustomizationReport talonCustomizationReport = talonObject.GetTalonInformationReport().GetTalonCustomizationReport();
                ITalonEmblemWidget talonEmblemWidget = WidgetResourceLoader.Emblems
                    .LoadTalonEmblemWidgetResource(talonIdentificationReport.GetCallSign(), talonCustomizationReport);
                talonEmblemWidget.GetTransform().SetParent(this.GetTransform());
                // Todo: Calculate somewhere else
                talonEmblemWidget.UpdateEmblemScale(new Vector3(0.5f, 0.5f, 0.5f));
                talonEmblemWidget.ResetWidgetDimensions();
                talonEmblemWidget.ResetWidgetPosition();
                this.ordererdTalonIdentificationReportList.Add(talonIdentificationReport);
                this.talonTurnEmblemSet.Add(talonEmblemWidget);
            }
        }
    }
}*/