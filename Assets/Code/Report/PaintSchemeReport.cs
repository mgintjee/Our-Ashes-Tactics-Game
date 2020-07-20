/// <summary>
/// Todo
/// </summary>
public class PaintSchemeReport
{
    #region Private Fields

    private readonly ColorIdEnum primaryPaintColor;
    private readonly ColorIdEnum secondaryPaintColor;

    #endregion Private Fields

    #region Private Constructors

    /// <summary>
    /// Todo
    /// </summary>
    /// <param name="primaryPaintColor">  </param>
    /// <param name="secondaryPaintColor"></param>
    private PaintSchemeReport(ColorIdEnum primaryPaintColor,
        ColorIdEnum secondaryPaintColor)
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
    public ColorIdEnum GetPrimaryPaintColor()
    {
        return this.primaryPaintColor;
    }

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public ColorIdEnum GetSecondaryPaintColor()
    {
        return this.secondaryPaintColor;
    }

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return this.GetType().ToString() + ":" +
            ",\n PrimaryColor=" + this.GetPrimaryPaintColor() +
            ",\n SecondaryColor=" + this.GetSecondaryPaintColor();
    }

    #endregion Public Methods

    #region Public Classes

    /// <summary>
    /// Todo
    /// </summary>
    public class Builder
    {
        #region Private Fields

        private ColorIdEnum primaryPaintColor;
        private ColorIdEnum secondaryPaintColor;

        #endregion Private Fields

        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public PaintSchemeReport Build()
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
            return new PaintSchemeReport(this.primaryPaintColor, this.secondaryPaintColor);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="primaryPaintColor"></param>
        /// <returns></returns>
        public Builder SetPrimaryPaintColor(ColorIdEnum primaryPaintColor)
        {
            this.primaryPaintColor = primaryPaintColor;
            return this;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="secondaryPaintColor"></param>
        /// <returns></returns>
        public Builder SetSecondaryPaintColor(ColorIdEnum secondaryPaintColor)
        {
            this.secondaryPaintColor = secondaryPaintColor;
            return this;
        }

        #endregion Public Methods
    }

    #endregion Public Classes
}