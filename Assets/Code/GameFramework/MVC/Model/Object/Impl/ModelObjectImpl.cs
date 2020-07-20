using System.Collections.Generic;
using System.Diagnostics;

/// <summary>
/// Model Object Impl
/// </summary>
public class ModelObjectImpl
    : ModelObject
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    // Todo
    private readonly bool mapModelIsMirrored;

    // Todo
    private readonly int mapModelRadius;

    // Todo
    private readonly int mapModelSeed;

    // Todo
    private readonly int maxMechPerTeam;

    // Todo
    private readonly ModelScript modelScript;

    // Todo
    private readonly Dictionary<TeamIdEnum, ControllerTypeEnum> teamIdControllerTypeDictionary = new Dictionary<TeamIdEnum, ControllerTypeEnum>();

    // Todo
    private readonly Dictionary<TeamIdEnum, HashSet<MechObject>> teamIdMechObjectSetDictionary = new Dictionary<TeamIdEnum, HashSet<MechObject>>();

    // Todo
    private List<MechObject> currentTurnMechObjectOrderList = new List<MechObject>();

    // Todo
    private bool gameIsActive = false;

    // Todo
    private ControllerObject mapControllerObject;

    // Todo
    private ViewObject mapModelObject;

    // Todo
    private List<MechObject> nextTurnMechObjectOrderList = new List<MechObject>();

    private bool readyForNextActionReport = false;

    // Todo
    private int turnCounter;

    #endregion Private Fields

    #region Public Methods

    public override void CreateNewMechFrom(MechConstructionReport mechCreationReport)
    {
        throw new System.NotImplementedException();
    }

    public override void InitializeNewGame()
    {
        throw new System.NotImplementedException();
    }

    public override void InputMechActionReport(ActionReport mechActionReport)
    {
        throw new System.NotImplementedException();
    }

    public override ModelScript GetModelScript()
    {
        return this.modelScript;
    }

    public override MechObject GetNextMechObject()
    {
        throw new System.NotImplementedException();
    }

    public override ControllerTypeEnum GetTeamControllerFor(TeamIdEnum teamId)
    {
        if (this.teamIdControllerTypeDictionary.ContainsKey(teamId))
        {
            return this.teamIdControllerTypeDictionary[teamId];
        }
        else
        {
            logger.Warn("Unable to retrieve ? from ?. ? is not a valid input", typeof(ControllerTypeEnum), typeof(TeamIdEnum), teamId);
            return ControllerTypeEnum.NULL;
        }
    }

    public override Dictionary<TeamIdEnum, ControllerTypeEnum> GetTeamIdTeamControllerDictionary()
    {
        throw new System.NotImplementedException();
    }

    public override int GetTurnCounter()
    {
        return this.turnCounter;
    }

    public override bool ReadyForNewActionReport()
    {
        return this.readyForNextActionReport;
    }

    #endregion Public Methods

    #region Private Methods

    private List<MechObject> GenerateTurnOrderList()
    {
        // Default an empty List: MechObject
        List<MechObject> mechObjectList = new List<MechObject>();
        // Iterate over the TeamIds
        foreach (TeamIdEnum teamId in this.teamIdMechObjectSetDictionary.Keys)
        {
            // Itereate over the MechObjects for the TeamId
            foreach (MechObject mechObject in this.teamIdMechObjectSetDictionary[teamId])
            {
                // Add the MechObject to the List; MechObject
                mechObjectList.Add(mechObject);
            }
        }
        // Sort the List: MechObject by OrderPoints
        mechObjectList.Sort(new OrderPointComparer());
        return mechObjectList;
    }

    #endregion Private Methods
}