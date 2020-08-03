/// <summary>
/// </summary>
public class WeaponAttributes
{
    #region Protected Fields

    // Todo
    protected int accuracyPoints;

    // Todo
    protected int damagePoints;

    // Todo
    protected int penetrationPoints;

    // Todo
    protected int rangePoints;

    // Todo
    protected int rangeProximityPoints;

    // Todo
    protected int shotCountPoints;

    // Todo
    protected WeaponIdEnum weaponId;

    #endregion Protected Fields

    #region Public Methods

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public int GetAccuracyPoints()
    {
        return this.accuracyPoints;
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public int GetDamagePoints()
    {
        return this.damagePoints;
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public int GetPenetrationPoints()
    {
        return this.penetrationPoints;
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public int GetRangePoints()
    {
        return this.rangePoints;
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public int GetRangeProximityPoints()
    {
        return this.rangeProximityPoints;
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public int GetShotCountPoints()
    {
        return this.shotCountPoints;
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public WeaponIdEnum GetWeaponId()
    {
        return this.weaponId;
    }

    #endregion Public Methods

    #region Public Classes

    /// <summary>
    /// Todo
    /// </summary>
    public class MinigunImpl
        : WeaponAttributes
    {
        #region Public Constructors

        /// <summary>
        /// Todo
        /// </summary>
        public MinigunImpl()
        {
            this.weaponId = WeaponIdEnum.Minigun;
            this.accuracyPoints = 1000;
            this.damagePoints = 1;
            this.penetrationPoints = 0;
            this.rangePoints = 3;
            this.rangeProximityPoints = 30;
            this.shotCountPoints = 8;
        }

        #endregion Public Constructors
    }

    #endregion Public Classes
}