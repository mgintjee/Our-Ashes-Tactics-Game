using System.Diagnostics;
using UnityEngine;

/// <summary>
/// Todo
/// </summary>
public class MechCanvasScript
    : AbstractUnityScript
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    private MechCanvas mechCanvas;

    #endregion Private Fields

    #region Public Methods

    public void SetCanvasToUpdate(MechCanvas mechCanvas)
    {
        this.mechCanvas = mechCanvas;
    }

    public void Update()
    {
        if (this.mechCanvas != null)
        {
            Vector3 canvasPosition = Camera.main.WorldToScreenPoint(this.transform.position);
            this.mechCanvas.GetCanvasBackgroundGameObject().transform.position = canvasPosition;
        }
    }

    #endregion Public Methods
}