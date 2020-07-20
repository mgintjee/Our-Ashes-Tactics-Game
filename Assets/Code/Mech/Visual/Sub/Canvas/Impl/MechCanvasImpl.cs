using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Todo
/// </summary>
public class MechCanvasImpl
    : MechCanvas
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    private GameObject armourCanvasTextGameObject;
    private Text armourText;
    private Canvas canvas;
    private GameObject canvasBackgroundGameObject;
    private GameObject canvasGameObject;
    private GameObject healthCanvasTextGameObject;
    private Text healthText;
    private MechConstructionReport mechConstructionReport;
    private MechScript mechScript;
    private GameObject teamIdCanvasTextGameObject;
    private Text teamIdText;

    #endregion Private Fields

    #region Public Constructors

    /// <summary>
    /// Todo
    /// </summary>
    /// <param name="mechScript"></param>
    public MechCanvasImpl(MechScript mechScript, MechConstructionReport mechConstructionReport)

    {
        // Todo: Clean this up. Yikes
        logger.Debug("Constructing Object=?", this.GetType().ToString());
        this.mechScript = mechScript;
        this.mechConstructionReport = mechConstructionReport;
        this.Initialize();
        logger.Debug("Constructed Object=?", this.GetType().ToString());
    }

    #endregion Public Constructors

    #region Public Methods

    public override GameObject GetCanvasBackgroundGameObject()
    {
        return this.canvasBackgroundGameObject;
    }

    /// <summary>
    /// Todo
    /// </summary>
    public override void UpdateCanvasDisplay()
    {
        string teamIdString = "";
        string healthString = "";
        string armourString = "";
        if (this.mechScript != null &&
            this.mechScript.GetMechObject() != null)
        {
            teamIdString = this.mechScript.GetMechBehavior().GetMechTeamIndex().ToString();
            healthString = this.mechScript.GetMechBehavior().GetCurrentHealthPoints().ToString();
            armourString = this.mechScript.GetMechBehavior().GetCurrentArmourPoints().ToString();
        }
        else if (this.mechConstructionReport != null)
        {
            MechIdEnum mechId = this.mechConstructionReport.GetMechId();
            MechAttributes mechAttributes = MechAttributeConstants.GetImplementedMechAttributes(mechId);
            teamIdString = this.mechConstructionReport.GetMechTeamIndex().ToString();
            healthString = mechAttributes.GetHealthPoints().ToString();
            armourString = mechAttributes.GetArmourPoints().ToString();
        }
        else
        {
            logger.Warn("Unable to update ?. ?, ?, and ? are null. No information to present.", this.GetType(),
                typeof(MechScript), typeof(MechBehavior), typeof(MechConstructionReport));
        }

        this.teamIdText.text = teamIdString;
        this.healthText.text = healthString;
        this.armourText.text = armourString;
    }

    #endregion Public Methods

    #region Private Methods

    /// <summary>
    /// Todo
    /// </summary>
    private void CollectCanvasUiObjects()
    {
        if (this.canvasGameObject != null)
        {
            Transform canvasBackgroundTransform = this.canvasGameObject.transform.Find(MechCanvasConstants.GetCanvasBackgroundGameObjectName());
            if (canvasBackgroundTransform != null)
            {
                this.canvasBackgroundGameObject = canvasBackgroundTransform.gameObject;
            }

            this.teamIdText = CollectTextObjectFrom(MechCanvasConstants.GetTeamIdBackgroundGameObjectName(),
                MechCanvasConstants.GetTeamIdTextGameObjectName());
            this.armourText = CollectTextObjectFrom(MechCanvasConstants.GetArmourBackgroundGameObjectName(),
                MechCanvasConstants.GetArmourTextGameObjectName());
            this.healthText = CollectTextObjectFrom(MechCanvasConstants.GetHealthBackgroundGameObjectName(),
                MechCanvasConstants.GetHealthTextGameObjectName());
        }
        // Check that the collection process was a success
        if (this.teamIdText == null ||
            this.healthText == null ||
            this.armourText == null)
        {
            logger.Error("Failed to collect Text objects for ?.", this.GetType());
        }
    }

    /// <summary>
    /// Todo
    /// </summary>
    /// <param name="backgroundId"></param>
    /// <param name="textId">      </param>
    /// <returns></returns>
    private Text CollectTextObjectFrom(string backgroundId, string textId)
    {
        Text text = null;
        if (this.canvasBackgroundGameObject != null)
        {
            Transform backgroundTransform = this.canvasBackgroundGameObject.transform.Find(backgroundId);
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

    private void ConstructCanvasPlaceHolder()
    {
        GameObject canvasPlaceHolder = new GameObject("CanvasPlaceHolder");
        canvasPlaceHolder.transform.SetParent(mechScript.GetGameObject().transform);
        canvasPlaceHolder.transform.position = Vector3.zero;
        canvasPlaceHolder.transform.position = new Vector3(0, 7.5f, 0); canvasPlaceHolder.AddComponent<MechCanvasScript>().SetCanvasToUpdate(this);
        this.canvasGameObject.transform.SetParent(canvasPlaceHolder.transform);
    }

    private void Initialize()
    {
        this.canvasGameObject = GameObjectSpawnerUtil.SpawnCanvas();
        this.canvasGameObject.name = "MechCanvas";
        this.ConstructCanvasPlaceHolder();
        this.CollectCanvasUiObjects();
        this.UpdateCanvasDisplay();
    }

    #endregion Private Methods
}