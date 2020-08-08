using System;
using UnityEngine;

/// <summary>
/// Talon Visual Impl
/// </summary>
public class TalonVisualImpl
    : TalonVisual
{
    #region Private Fields

    private readonly TalonConstructionReport talonConstructionReport = null;
    private readonly TalonObject talonObject = null;

    #endregion Private Fields

    #region Public Constructors

    public TalonVisualImpl(TalonObject talonObject, TalonConstructionReport talonConstructionReport)
    {
        if (talonObject != null &&
            talonConstructionReport != null)
        {
            this.talonObject = talonObject;
            this.talonConstructionReport = talonConstructionReport;
            this.ApplyTalonPaintSchemeReport(this.talonConstructionReport.GetTalonPaintSchemeReport());
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

    public override void SetCubeCoordinates(CubeCoordinates cubeCoordinates)
    {
        if (cubeCoordinates != null)
        {
            HexTileObject hexTileObject = HexTileObjectFinderUtil.FindHexTileObjectFrom(cubeCoordinates);
            if (hexTileObject != null)
            {
                Vector3 hexTileWorldPosition = hexTileObject.GetHexTileScript().GetGameObject().transform.position;
                hexTileWorldPosition.y = 0;
                this.talonObject.GetTalonScript().GetGameObject().transform.position = hexTileWorldPosition;

                int angle = 90;
                switch (this.talonConstructionReport.GetTalonIdentificationReport().GetTalonPhalanxId())
                {
                    case TalonPhalanxIdEnum.PhalanxEast:
                        angle = 0;
                        break;

                    case TalonPhalanxIdEnum.PhalanxSouthEast:
                        angle = 60;
                        break;

                    case TalonPhalanxIdEnum.PhalanxSouthWest:
                        angle = 120;
                        break;

                    case TalonPhalanxIdEnum.PhalanxWest:
                        angle = 180;
                        break;

                    case TalonPhalanxIdEnum.PhalanxNorthWest:
                        angle = 240;
                        break;

                    case TalonPhalanxIdEnum.PhalanxNorthEast:
                        angle = 300;
                        break;
                }
                this.talonObject.GetTalonScript().GetGameObject().transform.localEulerAngles = new Vector3(0, angle, 0);
            }
            else
            {
                throw new ArgumentException("Unable to SetCubeCoordinates" +
                    "\n>" + typeof(HexTileObject) + " is null");
            }
        }
        else
        {
            throw new ArgumentException("Unable to SetCubeCoordinates" +
                "\n>" + typeof(CubeCoordinates) + " is null");
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