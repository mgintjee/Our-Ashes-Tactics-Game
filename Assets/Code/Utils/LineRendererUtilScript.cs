using UnityEngine;

/// <summary>
/// Todo
/// </summary>
public class LineRendererUtilScript
    : AbstractUnityScript
{
    #region Public Methods

    public LineRenderer GetLineRenderer()
    {
        return this.GetGameObject().GetComponent<LineRenderer>();
    }

    #endregion Public Methods
}