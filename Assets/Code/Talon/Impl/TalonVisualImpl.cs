using System;

/// <summary>
/// Talon Visual Impl
/// </summary>
public class TalonVisualImpl
    : TalonVisual
{
    #region Private Fields

    private TalonObject talonObject = null;
    private TalonPaintSchemeReport talonPaintSchemeReport = null;

    #endregion Private Fields

    #region Public Constructors

    public TalonVisualImpl(TalonObject talonObject, TalonConstructionReport talonConstructionReport)
    {
        if (talonObject != null &&
            talonConstructionReport != null)
        {
            this.talonObject = talonObject;
            this.talonPaintSchemeReport = talonConstructionReport.GetTalonPaintSchemeReport();
            this.ApplyTalonPaintSchemeReport(this.talonPaintSchemeReport);
        }
        else
        {
            throw new ArgumentException("Unable to construct " + this.GetType() + ". Invalid Parameters." +
                "\n>" + typeof(TalonObject) + " is null: " + (talonObject == null) +
                "\n>" + typeof(TalonConstructionReport) + " is null: " + (talonConstructionReport == null));
        }
    }

    #endregion Public Constructors

    #region Public Methods

    public override void AddWeapon(WeaponVisual weaponVisual)
    {
        //throw new System.NotImplementedException();
    }

    public override void PaintBase(HexTileTypeEnum hexTileType)
    {
        if (!hexTileType.Equals(HexTileTypeEnum.NULL))
        {
            TalonObjectPainterUtil.PaintMechGameObjectBase(this.talonObject, hexTileType);
        }
        else
        {
            throw new ArgumentException("Unable to ApplyTalonPaintSchemeReport. Invalid Parameters." +
                "\n>" + typeof(HexTileTypeEnum) + " is invalid");
        }
    }

    public override void UpdateMechCanvas()
    {
        //throw new System.NotImplementedException();
    }

    #endregion Public Methods

    #region Private Methods

    private void ApplyTalonPaintSchemeReport(TalonPaintSchemeReport talonPaintSchemeReport)
    {
        if (talonPaintSchemeReport != null)
        {
            TalonObjectPainterUtil.PaintTalonObject(this.talonObject, talonPaintSchemeReport);
        }
        else
        {
            throw new ArgumentException("Unable to ApplyTalonPaintSchemeReport. Invalid Parameters." +
                "\n>" + typeof(TalonPaintSchemeReport) + " is null: " + (talonPaintSchemeReport == null));
        }
    }

    #endregion Private Methods
}