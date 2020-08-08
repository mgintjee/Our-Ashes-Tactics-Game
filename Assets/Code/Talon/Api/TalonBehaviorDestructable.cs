/// <summary>
/// Talon Behavior Destructable Api
/// </summary>
public abstract class TalonBehaviorDestructable
{
    #region Public Methods

    public abstract int GetCurrentArmourPoints();

    public abstract int GetCurrentHealthPoints();

    public abstract int GetMaximumArmourPoints();

    public abstract int GetMaximumHealthPoints();

    public abstract TalonCombatResultReport InputTalonCombatOrderReport(TalonCombatOrderReport talonCombatOrderReport);

    #endregion Public Methods
}