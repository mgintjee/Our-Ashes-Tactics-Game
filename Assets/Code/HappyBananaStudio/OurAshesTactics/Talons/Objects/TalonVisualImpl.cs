/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Coordinates;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.HexTile;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Talons.Models;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Talons.Objects;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Talons.Visuals;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Weapons.Objects;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Paints;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Enums;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Exceptions;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Talons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Managers;
using System;
using System.Diagnostics;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Talons.Objects
{
    /// <summary>
    /// Talon Visual Impl
    /// </summary>
    public class TalonVisualImpl
    : ITalonVisual
    {
        // Provide logging capability
        private static readonly Common.Loggers.Logger logger = new Common.Loggers.Logger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly ITalonConstructionReport talonConstructionReport = null;

        // Todo
        private readonly ITalonModelObject talonModel = null;

        // Todo
        private readonly ITalonObject talonObject = null;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonObject">
        /// </param>
        /// <param name="talonConstructionReport">
        /// </param>
        public TalonVisualImpl(ITalonObject talonObject, ITalonConstructionReport talonConstructionReport)
        {
            if (talonObject != null &&
                talonConstructionReport != null)
            {
                logger.Info("Constructing: ?", this.GetType());
                this.talonObject = talonObject;
                this.talonConstructionReport = talonConstructionReport;
                this.talonModel = new TalonModelImpl(this.talonObject);
            }
            else
            {
                throw new ArgumentException("Unable to construct " + this.GetType() + ". Invalid Parameters." +
                    "\n\t>" + typeof(ITalonObject) + " is null: " + (talonObject == null) +
                    "\n\t>" + typeof(ITalonConstructionReport) + " is null: " + (talonConstructionReport == null));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="index">
        /// </param>
        /// <param name="weaponObject">
        /// </param>
        public void AddWeaponObject(int index, IWeaponObject weaponObject)
        {
            if (weaponObject != null)
            {
                GameObject weaponMountGameObject = this.talonModel.GetWeaponMountGameObject(index);
                if (weaponMountGameObject != null)
                {
                    GameObject weaponGameObject = weaponObject.GetWeaponScript().GetGameObject();
                    weaponGameObject.transform.SetParent(weaponMountGameObject.transform);
                    weaponGameObject.transform.localPosition = Vector3.zero;
                }
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. " +
                    "\n\t> ? is null", new StackFrame().GetMethod().Name, typeof(IWeaponObject));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        public void ApplyPaintScheme()
        {
            this.ApplyTalonPaintSchemeReport(this.talonConstructionReport.GetPaintSchemeReport());
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="hexTileType">
        /// </param>
        public void PaintBase(HexTileTypeEnum hexTileType)
        {
            if (!hexTileType.Equals(HexTileTypeEnum.None))
            {
                TalonObjectPainterUtil.PaintMechGameObjectBase(this.talonObject, hexTileType);
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. " +
                    "\n\t> ? is invalid", new StackFrame().GetMethod().Name, typeof(HexTileTypeEnum));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates">
        /// </param>
        public void SetCubeCoordinates(ICubeCoordinates cubeCoordinates)
        {
            if (cubeCoordinates != null)
            {
                IHexTileObject hexTileObject = GameMapObjectManager.FindHexTileObjectFrom(cubeCoordinates);
                if (hexTileObject != null)
                {
                    this.PaintBase(hexTileObject.GetHexTileType());
                    Vector3 hexTileWorldPosition = hexTileObject.GetHexTileScript().GetGameObject().transform.position;
                    hexTileWorldPosition.y = 0;
                    this.talonObject.GetTalonScript().GetGameObject().transform.position = hexTileWorldPosition;

                    int angle = 90;
                    // Todo: Fix this
                    /*
                     * I would like that the idea to implement is that the talons face the center on spawn based off of the faction they're a part of.
                     * And it would apply to all of the phalanxes of that faction. But I would probably have to update the logic for how they are spawned
                     */
                    switch (this.talonConstructionReport.GetTalonIdentificationReport().GetFactionId())
                    {
                        case FactionIdEnum.CreativeFaction1:
                            angle = 60;
                            break;

                        case FactionIdEnum.CreativeFaction2:
                            angle = 120;
                            break;

                        case FactionIdEnum.CreativeFaction3:
                            angle = 240;
                            break;

                        case FactionIdEnum.CreativeFaction4:
                            angle = 240;
                            break;
                    }
                    angle = 180;
                    // Clean this up
                    this.talonObject.GetTalonScript().GetGameObject().transform.GetChild(0).localEulerAngles = new Vector3(0, angle, 0);
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. " +
                        "\n\t> ? is null", new StackFrame().GetMethod().Name, typeof(IHexTileObject));
                }
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. " +
                    "\n\t> ? is null", new StackFrame().GetMethod().Name, typeof(ICubeCoordinates));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonPaintSchemeReport">
        /// </param>
        private void ApplyTalonPaintSchemeReport(IPaintSchemeReport talonPaintSchemeReport)
        {
            if (talonPaintSchemeReport != null)
            {
                TalonObjectPainterUtil.PaintTalonObject(this.talonObject, talonPaintSchemeReport);
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. " +
                    "\n\t> ? is null", new StackFrame().GetMethod().Name, typeof(IPaintSchemeReport));
            }
        }
    }
}