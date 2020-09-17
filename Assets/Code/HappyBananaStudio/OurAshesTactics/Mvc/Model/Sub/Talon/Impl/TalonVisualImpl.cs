/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Mvc.Coordinates.Cube;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.HexTile.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.HexTile.Enums;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.HexTile.Util;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Enums;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Reports;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Util;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Weapon.Api;
using System;
using System.Diagnostics;
using UnityEngine;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Impl
{
    /// <summary>
    /// Talon Visual Impl
    /// </summary>
    public class TalonVisualImpl
    : ITalonVisual
    {
        #region Private Fields

        // Provide logging capability
        private static readonly Common.Logging.Logger logger = new Common.Logging.Logger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly TalonConstructionReport talonConstructionReport = null;

        // Todo
        private readonly ITalonModel talonModel = null;

        // Todo
        private readonly ITalonObject talonObject = null;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonObject">            </param>
        /// <param name="talonConstructionReport"></param>
        public TalonVisualImpl(ITalonObject talonObject, TalonConstructionReport talonConstructionReport)
        {
            if (talonObject != null &&
                talonConstructionReport != null)
            {
                logger.Info("Contructing: ?", this.GetType());
                this.talonObject = talonObject;
                this.talonConstructionReport = talonConstructionReport;
                this.talonModel = new TalonModelImpl(this.talonObject);
            }
            else
            {
                throw new ArgumentException("Unable to construct " + this.GetType() + ". Invalid Parameters." +
                    "\n\t>" + typeof(ITalonObject) + " is null: " + (talonObject == null) +
                    "\n\t>" + typeof(TalonConstructionReport) + " is null: " + (talonConstructionReport == null));
            }
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="weaponObject"></param>
        public void AddWeaponObject(IWeaponObject weaponObject)
        {
            if (weaponObject != null)
            {
                GameObject weaponMountGameObject = this.talonModel.GetNextEmptyWeaponMountGameObject();
                if (weaponMountGameObject != null)
                {
                    GameObject weaponGameObject = weaponObject.GetWeaponScript().GetGameObject();
                    weaponGameObject.transform.SetParent(weaponMountGameObject.transform);
                    weaponGameObject.transform.localPosition = Vector3.zero;
                }
            }
            else
            {
                throw new ArgumentException("Unable to add AddWeaponObject. Invalid Parameters." +
                    "\n\t>" + typeof(IWeaponObject) + " is null");
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        public void ApplyPaintScheme()
        {
            this.ApplyTalonPaintSchemeReport(this.talonConstructionReport.GetTalonPaintSchemeReport());
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="hexTileType"></param>
        public void PaintBase(HexTileTypeEnum hexTileType)
        {
            if (!hexTileType.Equals(HexTileTypeEnum.NULL))
            {
                TalonObjectPainterUtil.PaintMechGameObjectBase(this.talonObject, hexTileType);
            }
            else
            {
                throw new ArgumentException("Unable to ApplyTalonPaintSchemeReport. Invalid Parameters." +
                    "\n\t>" + typeof(HexTileTypeEnum) + " is invalid");
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates"></param>
        public void SetCubeCoordinates(CubeCoordinates cubeCoordinates)
        {
            if (cubeCoordinates != null)
            {
                IHexTileObject hexTileObject = HexTileObjectFinderUtil.FindHexTileObjectFrom(cubeCoordinates);
                if (hexTileObject != null)
                {
                    this.PaintBase(hexTileObject.GetHexTileType());
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
                    // Clean this up
                    this.talonObject.GetTalonScript().GetGameObject().transform.GetChild(0).localEulerAngles = new Vector3(0, angle, 0);
                }
                else
                {
                    throw new ArgumentException("Unable to SetCubeCoordinates" +
                        "\n\t>" + typeof(IHexTileObject) + " is null");
                }
            }
            else
            {
                throw new ArgumentException("Unable to SetCubeCoordinates" +
                    "\n\t>" + typeof(CubeCoordinates) + " is null");
            }
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonPaintSchemeReport"></param>
        private void ApplyTalonPaintSchemeReport(TalonPaintSchemeReport talonPaintSchemeReport)
        {
            if (talonPaintSchemeReport != null)
            {
                TalonObjectPainterUtil.PaintTalonObject(this.talonObject, talonPaintSchemeReport);
            }
            else
            {
                throw new ArgumentException("Unable to ApplyTalonPaintSchemeReport. Invalid Parameters." +
                    "\n\t>" + typeof(TalonPaintSchemeReport) + " is null: " + (talonPaintSchemeReport == null));
            }
        }

        #endregion Private Methods
    }
}