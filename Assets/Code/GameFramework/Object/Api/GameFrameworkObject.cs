/// <summary>
/// GameFrameworkObject Api
/// </summary>
public abstract class GameFrameworkObject
{
    #region Public Methods

    /// <summary>
    /// </summary>
    /// <param name="mechCreationReport"></param>
    public abstract void CreateNewMechFrom(MechConstructionReport mechCreationReport);

    /// <summary>
    /// </summary>
    public abstract bool GameIsActive();

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public abstract GameFrameworkScript GetGameFrameworkScript();

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public abstract ControllerObject GetMapControllerObject();

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public abstract bool GetMapModelIsMirrored();

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public abstract ViewObject GetMapModelObject();

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public abstract int GetMapModelRadius();

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public abstract int GetMapModelSeed();

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public abstract int GetMaxMechPerTeam();

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public abstract MechObject GetNextMechObject();

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public abstract ControllerTypeEnum GetTeam1Controller();

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public abstract ControllerTypeEnum GetTeam2Controller();

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public abstract int GetTurnCounter();

    /// <summary>
    /// </summary>
    public abstract void InitializeNewGame();

    /// <summary>
    /// </summary>
    public abstract void InitializeNewTurn();

    /// <summary>
    /// </summary>
    /// <param name="mechActionReport"></param>
    public abstract void InputMechActionReport(ActionReport mechActionReport);

    /// <summary>
    /// </summary>
    public abstract bool ProcessingActionReport();

    /// <summary>
    /// </summary>
    /// <param name="mapControllerObject"></param>
    public abstract void SetMapControllerObject(ControllerObject mapControllerObject);

    /// <summary>
    /// </summary>
    /// <param name="mapModelObject"></param>
    public abstract void SetMapModelObject(ViewObject mapModelObject);

    #endregion Public Methods
}