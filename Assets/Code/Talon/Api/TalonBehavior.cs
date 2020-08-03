/// <summary>
/// Talon Behavior Api
/// </summary>
public abstract class TalonBehavior
{
    #region Public Methods

    public abstract TalonAttributesReport GetCurrentTalonAttributesReport();

    public abstract TalonAttributesReport GetMaximumTalonAttributesReport();

    public abstract TalonBehaviorDestructable GetTalonBehaviorDestructable();

    public abstract TalonBehaviorFireable GetTalonBehaviorFireable();

    public abstract TalonBehaviorMoveable GetTalonBehaviorMoveable();
    public abstract void SetCubeCoordinates(CubeCoordinates cubeCoordinates);

    #endregion Public Methods
}