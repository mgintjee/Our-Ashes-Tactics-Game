/*namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Widgets.Impl.Complex.Impl
{
    using System.Diagnostics;
    using UnityEngine;

    /// <summary>
    /// Todo
    /// </summary>
    public class ScoreValueWidgetImpl
        : AbstractComplexWidgetImpl, IScoreValueWidget
    {
        // Provide logging capability
        private static readonly ICodeLogger logger = new CodeLoggerImpl(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private IBasicImageWidget scoreBackgroundWidget;

        // Todo
        private IBasicImageWidget scoreForegroundWidget;

        // Todo
        private IBasicTextWidget scoreValueTextWidget;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="scoreValue">
        /// </param>
        void IScoreValueWidget.UpdateScoreText(string scoreValue)
        {
            this.scoreValueTextWidget.UpdateText(scoreValue);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="percent">
        /// </param>
        void IScoreValueWidget.UpdateScoreVisual(float percent)
        {
            float maxWidth = this.scoreBackgroundWidget.GetGameObject().GetComponent<RectTransform>().rect.width;
            float originalHeight = this.scoreForegroundWidget.GetGameObject().GetComponent<RectTransform>().rect.height;
            this.scoreForegroundWidget.UpdateWidgetDimensions(new Vector2(maxWidth * percent, originalHeight));
        }

        /// <summary>
        /// Todo
        /// </summary>
        protected override void LoadChildWidgets()
        {
            this.GetGameObject().AddComponent<RectTransform>();
            this.scoreBackgroundWidget = UIResourceLoader.WidgetUIs.Basics.LoadBasicImageWidget(this.GetTransform());
            this.scoreForegroundWidget = UIResourceLoader.WidgetUIs.Basics.LoadBasicImageWidget(this.GetTransform());
            this.scoreValueTextWidget = UIResourceLoader.WidgetUIs.Basics.LoadBasicTextWidget(this.GetTransform());
            // Update the aesthetics of the widgets
            this.scoreBackgroundWidget.UpdateColor(Color.black);
            this.scoreForegroundWidget.UpdateColor(Color.white);

            // Add all of the children to the Set
            this.childWidgetSet.Add(this.scoreBackgroundWidget);
            this.childWidgetSet.Add(this.scoreForegroundWidget);
            this.childWidgetSet.Add(this.scoreValueTextWidget);
        }
    }
}*/