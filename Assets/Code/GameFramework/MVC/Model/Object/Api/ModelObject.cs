using System.Collections.Generic;

/// <summary>
/// Model Object Api
/// </summary>
public abstract class ModelObject
{
    #region Public Methods

    /// <summary>
    /// </summary>
    /// <param name="mechCreationReport"></param>
    public abstract void CreateNewMechFrom(MechConstructionReport mechCreationReport);

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public abstract ModelScript GetModelScript();

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public abstract MechObject GetNextMechObject();

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public abstract ControllerTypeEnum GetTeamControllerFor(TeamIdEnum teamId);

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public abstract Dictionary<TeamIdEnum, ControllerTypeEnum> GetTeamIdTeamControllerDictionary();

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public abstract int GetTurnCounter();

    /// <summary>
    /// </summary>
    public abstract void InitializeNewGame();

    /// <summary>
    /// </summary>
    /// <param name="mechActionReport"></param>
    public abstract void InputMechActionReport(ActionReport mechActionReport);

    /// <summary>
    /// </summary>
    public abstract bool ReadyForNewActionReport();

    #endregion Public Methods
}