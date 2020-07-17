using System.Diagnostics;
using UnityEngine;

/// <summary>
/// Todo
/// </summary>
public class LineRendererUtilScript
    : AbstractUnityScript
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    #endregion Private Fields

    #region Public Methods

    public LineRenderer GetLineRenderer()
    {
        return this.GetGameObject().GetComponent<LineRenderer>();
    }

    #endregion Public Methods
}