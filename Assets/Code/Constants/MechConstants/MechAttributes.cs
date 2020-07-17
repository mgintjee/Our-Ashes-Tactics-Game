/// <summary>
/// MechAttributes object that will store all of the implementations of the Mechs
/// </summary>
public class MechAttributes
{
    #region Protected Fields

    // Todo
    protected int armourPoints;

    // Todo
    protected int healthPoints;

    // Todo
    protected MechIdEnum mechId;

    // Todo
    protected int movePoints;

    // Todo
    protected int turnPoints;

    // Todo
    protected int weaponPoints;

    #endregion Protected Fields

    #region Public Methods

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public int GetArmourPoints()
    {
        return this.armourPoints;
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public int GetHealthPoints()
    {
        return this.healthPoints;
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public MechIdEnum GetMechId()
    {
        return this.mechId;
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public int GetMovePoints()
    {
        return this.movePoints;
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public int GetTurnPoints()
    {
        return this.turnPoints;
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public int GetWeaponPoints()
    {
        return this.weaponPoints;
    }

    #endregion Public Methods

    #region Public Classes

    /// <summary>
    /// Todo
    /// </summary>
    public class LightImpl
        : MechAttributes
    {
        #region Public Constructors

        /// <summary>
        /// Todo
        /// </summary>
        public LightImpl()
        {
            this.mechId = MechIdEnum.Light;
            this.armourPoints = 1;
            this.movePoints = 10;
            this.turnPoints = 3;
            this.healthPoints = 12;
            this.weaponPoints = 1;
        }

        #endregion Public Constructors
    }

    #endregion Public Classes
}