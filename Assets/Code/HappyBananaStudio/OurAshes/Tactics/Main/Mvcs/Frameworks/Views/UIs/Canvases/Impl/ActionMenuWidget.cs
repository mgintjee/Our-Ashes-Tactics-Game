/*namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Loggers.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Loggers.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Abs;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Api;
    using System.Diagnostics;
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// ActionMenu Widget Impl
    /// </summary>
    public class ActionMenuWidget
        : CanvasAbstractImpl, ICanvas
    {
        // Provide logging capability
        private static readonly ICodeLogger Logger = new CodeLogger(new StackFrame().GetMethod().DeclaringType);

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
            this.GetGameObject().AddComponent<RectTransform>();
            this.GetGameObject().AddComponent<GridLayoutGroup>();
        }
    }
}*/