/// <summary>
/// Todo
/// </summary>
public class WeaponConstructionReport
{
    #region Private Fields

    private readonly TalonPaintSchemeReport paintSchemeReport;
    private readonly WeaponIdEnum weaponId;

    #endregion Private Fields

    #region Private Constructors

    /// <summary>
    /// Todo
    /// </summary>
    /// <param name="weaponId">         </param>
    /// <param name="paintSchemeReport"></param>
    private WeaponConstructionReport(WeaponIdEnum weaponId, TalonPaintSchemeReport paintSchemeReport)
    {
        this.weaponId = weaponId;
        this.paintSchemeReport = paintSchemeReport;
    }

    #endregion Private Constructors

    #region Public Methods

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public TalonPaintSchemeReport GetPaintSchemeReport()
    {
        return this.paintSchemeReport;
    }

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public WeaponIdEnum GetWeaponId()
    {
        return this.weaponId;
    }

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return this.GetType() + ":" +
            "\n WeaponId=" + this.GetWeaponId() +
            ",\n PaintSchemeReport=" + this.GetPaintSchemeReport().ToString();
    }

    #endregion Public Methods

    #region Public Classes

    /// <summary>
    /// Todo
    /// </summary>
    public class Builder
    {
        #region Private Fields

        private TalonPaintSchemeReport paintSchemeReport;
        private WeaponIdEnum weaponId;

        #endregion Private Fields

        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public WeaponConstructionReport Build()
        {
            /*
            if (this.mechId.Equals(MechIdEnum.NULL) ||
                this.teamId.Equals(TeamIdEnum.NULL) ||
                this.mechTeamIndex < 0 ||
                this.paintSchemeReport == null ||
                this.weaponIdList.Count == 0)
            {
                throw new ArgumentException("Unable to construct ?" + this.GetType().ToString() + ". Invalid Parameters." +
                    "\nmechId=" + this.mechId +
                    "\nteamId=" + this.teamId +
                    "\nmechTeamIndex=" + this.mechTeamIndex +
                    "\npaintSchemeReport=" + this.paintSchemeReport +
                    "\nweaponIdList.Count=" + this.weaponIdList.Count);
            }
            */
            return new WeaponConstructionReport(this.weaponId, this.paintSchemeReport);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="paintSchemeReport"></param>
        /// <returns></returns>
        public Builder SetPaintSchemeReport(TalonPaintSchemeReport paintSchemeReport)
        {
            this.paintSchemeReport = paintSchemeReport;
            return this;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="weaponId"></param>
        /// <returns></returns>
        public Builder SetWeaponId(WeaponIdEnum weaponId)
        {
            this.weaponId = weaponId;
            return this;
        }

        #endregion Public Methods
    }

    #endregion Public Classes
}