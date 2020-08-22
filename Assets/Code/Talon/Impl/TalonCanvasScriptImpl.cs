using System;
using System.Diagnostics;
using UnityEngine;

/// <summary>
/// Talon Canvas Script Impl
/// </summary>
public class TalonCanvasScriptImpl
    : TalonCanvasScript
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    private GameObject talonCanvasBackgroundGameObject = null;
    private TalonCanvasObject talonCanvasObject = null;

    #endregion Private Fields

    #region Public Methods

    public override TalonCanvasObject GetTalonCanvasObject()
    {
        return this.talonCanvasObject;
    }

    public override void Initialize(TalonObject talonObject)
    {
        if (talonObject != null)
        {
            this.GetGameObject().transform.SetParent(talonObject.GetTalonScript().GetGameObject().transform);
            this.transform.position = new Vector3(0, 7.5f, 0);

            GameObject talonCanvasGameObject = GameObjectResourceLoader.Canvas.LoadTalonCanvasGameObject();
            talonCanvasGameObject.transform.SetParent(this.GetGameObject().transform);
            this.talonCanvasObject = new TalonCanvasObjectImpl(talonObject, talonCanvasGameObject);
            this.talonCanvasBackgroundGameObject = talonCanvasGameObject.transform.GetChild(0).gameObject;
        }
        else
        {
            throw new ArgumentException("Unable to initialize " + this.GetType() + ". Invalid Parameters." +
                "\n\t>" + typeof(TalonObject) + " is null");
        }
    }

    public void Update()
    {
        if (this.talonCanvasBackgroundGameObject != null)
        {
            logger.Info("Updating ?'s position to ?'s", this.talonCanvasBackgroundGameObject.name, this.name);
            Vector3 canvasPosition = Camera.main.WorldToScreenPoint(this.transform.position);
            this.talonCanvasBackgroundGameObject.transform.position = canvasPosition;
            logger.Debug("Update to ?", canvasPosition);
        }
    }

    #endregion Public Methods
}