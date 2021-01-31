/*namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Impl
{
    using System.Diagnostics;
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// SettingsMenu Widget Impl
    /// </summary>
    public class SettingsMenuWidgetImpl
        : AbstractCanvasUIImpl, ICanvasUI
    {
        // Provide logging capability
        private static readonly ICodeLogger Logger = new CodeLoggerImpl(new StackFrame().GetMethod().DeclaringType);

        /// <summary>
        /// Todo
        /// </summary>
        protected override void ImplInitialization()
        {
            float cellWidth = this.GetComponent<RectTransform>().rect.width;
            float cellHeight = this.GetComponent<RectTransform>().rect.height;
            this.GetComponent<GridLayoutGroup>().cellSize = new Vector2(cellWidth, cellHeight);
            this.GetComponent<GridLayoutGroup>().constraint = GridLayoutGroup.Constraint.FixedRowCount;
            this.GetComponent<GridLayoutGroup>().constraintCount = 1;
        }

        /// <summary>
        /// Todo
        /// </summary>
        protected override void LoadChildWidgets()
        {
            //this.GetGameObject().AddComponent<RectTransform>();
            this.GetGameObject().AddComponent<GridLayoutGroup>();
        }
    }
}*/