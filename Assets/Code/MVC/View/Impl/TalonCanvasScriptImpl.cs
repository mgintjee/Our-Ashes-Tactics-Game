using System;
using System.Diagnostics;
using UnityEngine;

/// <summary>
/// Talon Canvas Script Impl
/// TODO: Shamelessly copy Battle Brothers' UI for pawns
/// </summary>
public class TalonCanvasScriptImpl
    : TalonCanvasScript
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    private GameObject talonCanvasBackgroundGameObject = null;
    private TalonCanvasObject talonCanvasObject = null;
    private TalonIdentificationReport talonIdentificationReport = null;

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
            talonIdentificationReport = talonObject.GetTalonIdentificationReport();
            logger.Info("Initializing: ? for ?", this.GetType(), talonIdentificationReport);
            //this.GetGameObject().transform.SetParent(talonObject.GetTalonScript().GetGameObject().transform);
            //Vector3 parentPosition = talonObject.GetTalonScript().GetGameObject().transform.position;
            //this.transform.localPosition = new Vector3(parentPosition.x, 7.5f, parentPosition.z);

            //GameObject talonCanvasGameObject = GameObjectResourceLoader.Canvas.LoadTalonCanvasGameObject();
            //talonCanvasGameObject.transform.SetParent(this.GetGameObject().transform);
            //talonCanvasGameObject.transform.localPosition = Vector3.zero;
            //this.talonCanvasObject = new TalonCanvasObjectImpl(this, talonObject, talonCanvasGameObject);
            //this.talonCanvasBackgroundGameObject = talonCanvasGameObject.transform.GetChild(0).gameObject;
            this.UpdateCanvas();
        }
        else
        {
            throw new ArgumentException("Unable to initialize " + this.GetType() + ". Invalid Parameters." +
                "\n\t>" + typeof(TalonObject) + " is null");
        }
    }

    public override void UpdateCanvas()
    {
        if (this.talonCanvasBackgroundGameObject != null)
        {
            Vector3 canvasPosition = Camera.main.WorldToScreenPoint(this.transform.position);
            logger.Info("For ?: Converting World=? to Camera=?", talonIdentificationReport, this.transform.position, canvasPosition);
            this.talonCanvasBackgroundGameObject.transform.position = canvasPosition;
        }
    }

    #endregion Public Methods
}