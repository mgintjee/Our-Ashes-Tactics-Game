/// <summary>
/// Todo
/// </summary>
public class TalonPaintSchemeReport
{
    #region Private Fields

    private readonly TalonColorIdEnum primaryPaintColor;
    private readonly TalonColorIdEnum secondaryPaintColor;

    #endregion Private Fields

    #region Private Constructors

    /// <summary>
    /// Todo
    /// </summary>
    /// <param name="primaryPaintColor">  </param>
    /// <param name="secondaryPaintColor"></param>
    private TalonPaintSchemeReport(TalonColorIdEnum primaryPaintColor,
        TalonColorIdEnum secondaryPaintColor)
    {
        this.primaryPaintColor = primaryPaintColor;
        this.secondaryPaintColor = secondaryPaintColor;
    }

    #endregion Private Constructors

    #region Public Methods

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public TalonColorIdEnum GetPrimaryPaintColor()
    {
        return this.primaryPaintColor;
    }

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public TalonColorIdEnum GetSecondaryPaintColor()
    {
        return this.secondaryPaintColor;
    }

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return this.GetType() + ":" +
            "\n>PrimaryColor=" + this.GetPrimaryPaintColor() +
            "\n>SecondaryColor=" + this.GetSecondaryPaintColor();
    }

    #endregion Public Methods

    #region Public Classes

    /// <summary>
    /// Todo
    /// </summary>
    public class Builder
    {
        #region Private Fields

        private TalonColorIdEnum primaryPaintColor;
        private TalonColorIdEnum secondaryPaintColor;

        #endregion Private Fields

        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public TalonPaintSchemeReport Build()
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
            return new TalonPaintSchemeReport(this.primaryPaintColor, this.secondaryPaintColor);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="primaryPaintColor"></param>
        /// <returns></returns>
        public Builder SetPrimaryPaintColor(TalonColorIdEnum primaryPaintColor)
        {
            this.primaryPaintColor = primaryPaintColor;
            return this;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="secondaryPaintColor"></param>
        /// <returns></returns>
        public Builder SetSecondaryPaintColor(TalonColorIdEnum secondaryPaintColor)
        {
            this.secondaryPaintColor = secondaryPaintColor;
            return this;
        }

        #endregion Public Methods
    }

    #endregion Public Classes
}