using System;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Talon Canvas Object Impl
/// </summary>
public class TalonCanvasObjectImpl
    : TalonCanvasObject
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    private readonly TalonObject talonObject = null;
    private Text talonArmourText = null;
    private GameObject talonCanvasGameObject = null;
    private Text talonHealthText = null;
    private Text talonIdText = null;

    #endregion Private Fields

    #region Public Constructors

    public TalonCanvasObjectImpl(TalonObject talonObject, GameObject talonCanvasGameObject)
    {
        if (talonObject != null)
        {
            this.talonObject = talonObject;
            this.talonCanvasGameObject = talonCanvasGameObject;
            logger.Debug("talonCanvasGameObject=?", talonCanvasGameObject.name);
        }
        else
        {
            throw new ArgumentException("Unable to initialize " + this.GetType() + ". Invalid Parameters." +
                "\n\t>" + typeof(TalonScript) + " is null");
        }
    }

    #endregion Public Constructors
}