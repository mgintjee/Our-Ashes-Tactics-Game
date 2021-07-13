using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Scripts.Unity.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Responses.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Requests.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Canvases.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Canvases.Implementations
{
    /// <summary>
    /// Todo
    /// </summary>
    public class CanvasView
        : ICanvasView
    {
        private CanvasView(IUnityScript unityScript)
        {
        }

        bool ICanvasView.IsProcessing()
        {
            throw new System.NotImplementedException();
        }

        void ICanvasView.Process(ISortieRequest controllerRequest)
        {
            throw new System.NotImplementedException();
        }

        void ICanvasView.Process(ISet<ISortieRequest> controllerRequests)
        {
            throw new System.NotImplementedException();
        }

        void ICanvasView.Process(IMvcResponse mvcResponse)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            internal IUnityScript unityScript;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public ICanvasView Build()
            {
                return new CanvasView(unityScript);
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="unityScript"></param>
            /// <returns></returns>
            public Builder SetUnityScript(IUnityScript unityScript)
            {
                this.unityScript = unityScript;
                return this;
            }
        }
    }
}

/*
// Provide logging capability
private readonly ILogger _logger = new SortieLogger(new StackFrame().GetMethod().DeclaringType);

// Todo
private readonly IGridConvertor canvasGridConvertor;

// Todo
private readonly ISet<IPanel> canvasPanelSet;

// Todo
private readonly IPanelActionMenu panelActionMenu;

// Todo
private readonly IPanelInformational panelInformational;

// Todo
private readonly IPanelScoreBoard panelScoreBoard;

// Todo
private readonly IPanelSettingMenu panelSettingMenu;

// Todo
private readonly IPanelTurnScroller panelTurnScroller;

/// <summary>
/// Todo
/// </summary>
/// <param name="parentTransform">          </param>
/// <param name="canvasConfigurationReport"></param>
private CanvasObject(Transform parentTransform, ICanvasConfigurationReport canvasConfigurationReport)
{
    GameObject gameObject = new GameObject(this.GetType().Name);
    gameObject.AddComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
    Vector2 sizeDelta = gameObject.GetComponent<RectTransform>().sizeDelta;
    this.canvasGridConvertor = new GridConvertor.Builder()
        .SetGridDimensions(CanvasGridConstants.GetCanvasGridDimensions())
        .SetWorldHeight(sizeDelta.y)
        .SetWorldWidth(sizeDelta.x)
        .Build();
    _logger.Debug("Building {} with {}", this.GetType().Name, canvasConfigurationReport);
    gameObject.transform.SetParent(parentTransform);
    // Should verify that the configurationReport is valid, else use the default value
    this.panelInformational = new PanelInformational.Builder()
        .SetCanvasConfigurationReport(canvasConfigurationReport.GetInformationalGridConfigurationReport())
        .SetParentTransform(gameObject.transform)
        .SetCanvasGridConvertor(this.canvasGridConvertor)
        .Build();
    this.panelActionMenu = new PanelActionMenu.Builder()
        .SetCanvasConfigurationReport(canvasConfigurationReport.GetActionMenuGridConfigurationReport())
        .SetParentTransform(gameObject.transform)
        .SetCanvasGridConvertor(this.canvasGridConvertor)
        .Build();
    this.panelScoreBoard = new PanelScoreBoard.Builder()
        .SetCanvasConfigurationReport(canvasConfigurationReport.GetScoreBoardGridConfigurationReport())
        .SetParentTransform(gameObject.transform)
        .SetCanvasGridConvertor(this.canvasGridConvertor)
        .Build();
    this.panelSettingMenu = new PanelSettingMenu.Builder()
        .SetCanvasConfigurationReport(canvasConfigurationReport.GetSettingMenuGridConfigurationReport())
        .SetParentTransform(gameObject.transform)
        .SetCanvasGridConvertor(this.canvasGridConvertor)
        .Build();
    this.panelTurnScroller = new PanelTurnScroller.Builder()
        .SetCanvasConfigurationReport(canvasConfigurationReport.GetTurnScrollerGridConfigurationReport())
        .SetParentTransform(gameObject.transform)
        .SetCanvasGridConvertor(this.canvasGridConvertor)
        .Build();
    this.canvasPanelSet = new HashSet<IPanel>()
    {
        this.panelInformational, this.panelActionMenu, this.panelScoreBoard,
        this.panelSettingMenu, this.panelTurnScroller
    };
}

/// <inheritdoc/>
void ICanvasObject.UpdateCanvas()
{
    foreach (IPanel canvas in this.canvasPanelSet)
    {
        canvas.UpdatePanelEntries();
    }
}

/// <summary>
/// Todo
/// </summary>
public class Builder
{
    // Todo
    private ICanvasConfigurationReport canvasConfigurationReport = null;

    // Todo
    private Transform parentTransform = null;

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public ICanvasObject Build()
    {
        ISet<string> invalidReasons = this.IsInvalid();
        // Check that the set parameters are valid
        if (invalidReasons.Count == 0)
        {
            // Instantiate a new Object
            return new CanvasObject(this.parentTransform, this.canvasConfigurationReport);
        }
        throw ExceptionUtil.Arguments.Build("Unable to construct {}. Invalid Parameters. {}",
            this.GetType(), string.Join("\n", invalidReasons));
    }

    /// <summary>
    /// Todo
    /// </summary>
    /// <param name="canvasConfigurationReport"></param>
    /// <returns></returns>
    public Builder SetCanvasConfigurationReport(ICanvasConfigurationReport canvasConfigurationReport)
    {
        this.canvasConfigurationReport = canvasConfigurationReport;
        return this;
    }

    /// <summary>
    /// Todo
    /// </summary>
    /// <param name="parentTransform"></param>
    /// <returns></returns>
    public Builder SetParentTransform(Transform parentTransform)
    {
        this.parentTransform = parentTransform;
        return this;
    }

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    private ISet<string> IsInvalid()
    {
        // Default an empty Set: String
        ISet<string> argumentExceptionSet = new HashSet<string>();
        if (this.canvasConfigurationReport == null)
        {
            argumentExceptionSet.Add(typeof(ICanvasConfigurationReport).Name + " can not be null.");
        }
        if (this.parentTransform == null)
        {
            argumentExceptionSet.Add("Parent " + typeof(Transform).Name + " can not be null.");
        }
        return argumentExceptionSet;
    }
}
}
*/