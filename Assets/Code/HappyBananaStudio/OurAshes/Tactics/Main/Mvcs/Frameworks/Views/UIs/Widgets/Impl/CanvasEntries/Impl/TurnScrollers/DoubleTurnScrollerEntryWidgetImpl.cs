/*namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Widgets.Impl.CanvasEntries.Impl.TurnScrollers
{
    using System.Diagnostics;
    using UnityEngine;

    /// <summary>
    /// DoubleTurnScrollerEntry Widget Impl
    /// </summary>
    public class DoubleTurnScrollerEntryWidgetImpl
        : AbstractComplexWidgetImpl, ITurnScrollerEntryWidget
    {
        // Provide logging capability
        private static readonly ICodeLogger logger = new CodeLoggerImpl(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private IBasicTextWidget remainingActionsTextWidget;

        // Todo
        private ITalonEmblemWidget talonEmblemWidget;

        // Todo
        private ITalonIdentificationReport talonIdentificationReport;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonIdentificationReport">
        /// </param>
        void ITurnScrollerEntryWidget.Initialize(ITalonIdentificationReport talonIdentificationReport)
        {
            this.talonIdentificationReport = talonIdentificationReport;
            ITalonCustomizationReport talonCustomizationReport = RosterObjectManager.GetTalonObject(this.talonIdentificationReport)
                .GetTalonInformationReport().GetTalonCustomizationReport();
            this.talonEmblemWidget.Initialize(this.talonIdentificationReport.GetCallSign(), talonCustomizationReport);
            // Todo: Have a TurnValue widget for the actions remaining?
        }

        /// <summary>
        /// Todo
        /// </summary>
        void ICanvasEntryWidget.UpdateEntry()
        {
            if (!RosterObjectManager.GetActiveTalonIdentificationReportSet()
                .Contains(this.talonIdentificationReport))
            {
                this.Destroy();
            }
            if (!TalonTurnOrderManager.GetOrderedTalonIdentificationReportList()
                .Contains(this.talonIdentificationReport))
            {
                this.Destroy();
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        protected override void LoadChildWidgets()
        {
            this.GetGameObject().AddComponent<RectTransform>();
            this.talonEmblemWidget = UIResourceLoader.WidgetUIs.Complex.LoadTalonDoubleEmblemWidget(this.GetTransform());
            this.remainingActionsTextWidget = UIResourceLoader.WidgetUIs.Basics.LoadBasicTextWidget(this.GetTransform());
            // Add all of the children to the Set
            this.childWidgetSet.Add(this.talonEmblemWidget);
            this.childWidgetSet.Add(this.remainingActionsTextWidget);
        }
    }
}*/