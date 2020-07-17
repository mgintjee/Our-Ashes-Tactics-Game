/// <summary>
/// Todo
/// </summary>
public class PaintSchemeReport
{
    #region Private Fields

    private readonly PaintColorEnum primaryPaintColor;
    private readonly PaintColorEnum secondaryPaintColor;

    #endregion Private Fields

    #region Private Constructors

    /// <summary>
    /// Todo
    /// </summary>
    /// <param name="primaryPaintColor">  </param>
    /// <param name="secondaryPaintColor"></param>
    private PaintSchemeReport(PaintColorEnum primaryPaintColor,
        PaintColorEnum secondaryPaintColor)
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
    public PaintColorEnum GetPrimaryPaintColor()
    {
        return this.primaryPaintColor;
    }

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public PaintColorEnum GetSecondaryPaintColor()
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

        private PaintColorEnum primaryPaintColor;
        private PaintColorEnum secondaryPaintColor;

        #endregion Private Fields

        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public PaintSchemeReport Build()
        {
            return new PaintSchemeReport(this.primaryPaintColor, this.secondaryPaintColor);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="primaryPaintColor"></param>
        /// <returns></returns>
        public Builder SetPrimaryPaintColor(PaintColorEnum primaryPaintColor)
        {
            this.primaryPaintColor = primaryPaintColor;
            return this;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="secondaryPaintColor"></param>
        /// <returns></returns>
        public Builder SetSecondaryPaintColor(PaintColorEnum secondaryPaintColor)
        {
            this.secondaryPaintColor = secondaryPaintColor;
            return this;
        }

        #endregion Public Methods
    }

    #endregion Public Classes
}