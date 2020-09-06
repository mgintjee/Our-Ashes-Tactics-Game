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

    private readonly GameObject talonCanvasGameObject = null;
    private readonly TalonCanvasScript talonCanvasScript = null;
    private readonly TalonObject talonObject = null;
    private Text talonArmourText = null;
    private GameObject talonCanvasBackgroundGameObject = null;
    private Text talonHealthText = null;
    private Text talonPhalanxIndexText = null;

    #endregion Private Fields

    #region Public Constructors

    public TalonCanvasObjectImpl(TalonCanvasScript talonCanvasScript, TalonObject talonObject, GameObject talonCanvasGameObject)
    {
        if (talonObject != null)
        {
            logger.Info("Contructing: ?", this.GetType());
            this.talonCanvasScript = talonCanvasScript;
            this.talonObject = talonObject;
            this.talonCanvasGameObject = talonCanvasGameObject;
            this.CollectCanvasUiObjects();
            this.UpdateCanvas();
        }
        else
        {
            throw new ArgumentException("Unable to initialize " + this.GetType() + ". Invalid Parameters." +
                "\n\t>" + typeof(TalonScript) + " is null");
        }
    }

    #endregion Public Constructors

    #region Public Methods

    public override void DestroyTalonCanvas()
    {
        // Todo: Destroy this Canvas
    }

    public override void UpdateCanvas()
    {
        string teamIdString = "Null";
        string healthString = "Null";
        string armourString = "Null";

        if (this.talonObject != null)
        {
            TalonAttributesReport talonAttributesReport = this.talonObject.GetTalonAttributesReport();
            TalonIdentificationReport talonIdentificationReport = this.talonObject.GetTalonIdentificationReport();
            teamIdString = talonIdentificationReport.GetTalonPhalanxIndex().ToString();
            healthString = talonAttributesReport.GetHealthPoints().ToString();
            armourString = talonAttributesReport.GetArmourPoints().ToString();
        }
        else
        {
            logger.Warn("Unable to update ?. ? is null. No information to present.", this.GetType(),
                typeof(TalonCanvasObject), typeof(TalonObject));
        }

        this.talonPhalanxIndexText.text = teamIdString;
        this.talonHealthText.text = healthString;
        this.talonArmourText.text = armourString;
        this.talonCanvasScript.UpdateCanvas();
    }

    #endregion Public Methods

    #region Private Methods

    private void CollectCanvasUiObjects()
    {
        if (this.talonCanvasGameObject != null)
        {
            Transform canvasBackgroundTransform = this.talonCanvasGameObject.transform.Find(TalonCanvasConstants.GetCanvasBackgroundGameObjectName());
            if (canvasBackgroundTransform != null)
            {
                this.talonCanvasBackgroundGameObject = canvasBackgroundTransform.gameObject;
            }

            this.talonPhalanxIndexText = CollectTextObjectFrom(
                TalonCanvasConstants.GetTeamIdBackgroundGameObjectName(),
                TalonCanvasConstants.GetTeamIdTextGameObjectName());

            this.talonArmourText = CollectTextObjectFrom(
                TalonCanvasConstants.GetArmourBackgroundGameObjectName(),
                TalonCanvasConstants.GetArmourTextGameObjectName());

            this.talonHealthText = CollectTextObjectFrom(
                TalonCanvasConstants.GetHealthBackgroundGameObjectName(),
                TalonCanvasConstants.GetHealthTextGameObjectName());
        }
        // Check that the collection process was a success
        if (this.talonPhalanxIndexText == null ||
            this.talonArmourText == null ||
            this.talonHealthText == null)
        {
            logger.Error("Failed to collect Text objects for ?.", this.GetType());
        }
    }

    private Text CollectTextObjectFrom(string backgroundId, string textId)
    {
        Text text = null;
        if (this.talonCanvasBackgroundGameObject != null)
        {
            Transform backgroundTransform = this.talonCanvasBackgroundGameObject.transform.Find(backgroundId);
            if (backgroundTransform != null)
            {
                Transform textTransform = backgroundTransform.Find(textId);
                if (textTransform != null)
                {
                    text = textTransform.GetComponent<Text>();
                }
            }
        }
        return text;
    }

    #endregion Private Methods
}