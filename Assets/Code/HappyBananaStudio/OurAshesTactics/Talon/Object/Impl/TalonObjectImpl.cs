/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Common.Logging;
using HappyBananaStudio.OurAshesTactics.Mvc.Coordinates.Cube;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.HexTile.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Map.Manager;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Enums;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Reports;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Weapon.Api;
using HappyBananaStudio.OurAshesTactics.Pathing.Object.Impl;
using HappyBananaStudio.OurAshesTactics.Talon.Behavior.Api;
using HappyBananaStudio.OurAshesTactics.Talon.Behavior.Impl;
using HappyBananaStudio.OurAshesTactics.Talon.Object.Api;
using HappyBananaStudio.OurAshesTactics.Talon.Visual.Api;
using HappyBananaStudio.OurAshesTactics.Talon.Visual.Impl;
using System;
using System.Diagnostics;

namespace HappyBananaStudio.OurAshesTactics.Talon.Object.Impl
{
    /// <summary>
    /// Talon Object Impl
    /// </summary>
    public class TalonObjectImpl
    : ITalonObject
    {
        #region Private Fields

        // Provide logging capability
        private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly TalonConstructionReport talonConstructionReport = null;

        // Todo
        private readonly TalonScript talonScript = null;

        // Todo
        private ITalonBehavior talonBehavior = null;

        // Todo
        private ITalonVisual talonVisual = null;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonScript">            </param>
        /// <param name="talonConstructionReport"></param>
        public TalonObjectImpl(TalonScript talonScript, TalonConstructionReport talonConstructionReport)
        {
            if (talonScript != null &&
                talonConstructionReport != null)
            {
                logger.Info("Constructing: ?.", this.GetType());
                this.talonScript = talonScript;
                this.talonConstructionReport = talonConstructionReport;
            }
            else
            {
                throw new ArgumentException("Unable to construct " + this.GetType() + ". Invalid Parameters." +
                    "\n\t>" + typeof(TalonScript) + " is null: " + (talonScript == null) +
                    "\n\t>" + typeof(TalonConstructionReport) + " is null: " + (talonConstructionReport == null));
            }
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="weaponObject"></param>
        public void AddWeapon(int index, IWeaponObject weaponObject)
        {
            this.talonVisual.AddWeaponObject(index, weaponObject);
            this.talonBehavior.AddWeaponBehavior(index, weaponObject.GetWeaponBehavior());
        }

        /// <summary>
        /// Todo
        /// </summary>
        public void ApplyPaintScheme()
        {
            this.talonVisual.ApplyPaintScheme();
        }

        /// <summary>
        /// Todo
        /// </summary>
        public void Deactivate()
        {
            CubeCoordinates currentCubeCoordinates = this.talonBehavior.GetCubeCoordinates();
            if (currentCubeCoordinates != null)
            {
                IHexTileObject currentHexTileObject = MapObjectManager.FindHexTileObjectFrom(currentCubeCoordinates);
                currentHexTileObject.SetOccupyingTalonIdentificationReport(null);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public CubeCoordinates GetCubeCoordinates()
        {
            return this.talonBehavior.GetCubeCoordinates();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public TalonActionInformationReport GetTalonActionInformationReport()
        {
            return new TalonActionInformationReport.Builder()
                .SetTalonInformationReport(this.GetTalonInformationReport())
                .SetPossibleTalonActionOrderReportSet(this.talonBehavior.GetPossibleTalonActionOrderReportSet())
                .Build();
        }

        /// <summary>
        /// </summary>
        /// <param name="pathObjectFire"></param>
        /// <returns></returns>
        public TalonCombatOrderReport GetTalonCombatOrderReport(PathObjectFire pathObjectFire)
        {
            return this.talonBehavior.GetTalonCombatOrderReport(pathObjectFire);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public TalonInformationReport GetTalonInformationReport()
        {
            return new TalonInformationReport.Builder()
                .SetTalonAttributesReport(this.talonBehavior.GetTalonAttributesReport())
                .SetTalonIdentifcationReport(this.talonConstructionReport.GetTalonIdentificationReport())
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public TalonScript GetTalonScript()
        {
            return this.talonScript;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public void Initialize()
        {
            if (!this.IsInitialized())
            {
                TalonIdentificationReport talonIdentificationReport = this.talonConstructionReport.GetTalonIdentificationReport();
                if (talonIdentificationReport != null)
                {
                    this.talonBehavior = new TalonBehaviorImpl(talonIdentificationReport);
                    this.talonVisual = new TalonVisualImpl(this, this.talonConstructionReport);
                }
                else
                {
                    throw new ArgumentException("Unable to initialize ?" + this.GetType() + ". Invalid Parameters." +
                        "\n\t>" + typeof(TalonIdentificationReport) + " is null: " + (talonIdentificationReport == null));
                }
            }
            else
            {
                logger.Warn("Unable to Initialize: ?. Already initialized.", this.GetType());
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonActionOrder"></param>
        /// <returns></returns>
        public TalonActionResultReport InputTalonActionOrderReport(TalonActionOrderReport talonActionOrder)
        {
            if (talonActionOrder.GetTalonActionType() == TalonActionTypeEnum.Move)
            {
                this.SetCubeCoordinates(talonActionOrder.GetPathObject().GetCubeCoordinatesEnd());
            }
            return this.talonBehavior.InputTalonActionOrderReport(talonActionOrder);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonCombatOrderReport"></param>
        /// <returns></returns>
        public TalonCombatResultReport InputTalonCombatOrderReport(TalonCombatOrderReport talonCombatOrderReport)
        {
            return this.talonBehavior.InputTalonCombatOrderReport(talonCombatOrderReport);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public bool IsInitialized()
        {
            return this.talonBehavior != null &&
                this.talonVisual != null;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public void ResetTalonBehaviorMoveable()
        {
            this.talonBehavior.ResetForNewTurn();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates"></param>
        public void SetCubeCoordinates(CubeCoordinates cubeCoordinates)
        {
            if (cubeCoordinates != null)
            {
                CubeCoordinates currentCubeCoordinates = this.talonBehavior.GetCubeCoordinates();
                if (currentCubeCoordinates != null)
                {
                    IHexTileObject currentHexTileObject = MapObjectManager.FindHexTileObjectFrom(currentCubeCoordinates);
                    currentHexTileObject.SetOccupyingTalonIdentificationReport(null);
                }

                this.talonBehavior.SetCubeCoordinates(cubeCoordinates);
                this.talonVisual.SetCubeCoordinates(cubeCoordinates);

                IHexTileObject hexTileObject = MapObjectManager.FindHexTileObjectFrom(cubeCoordinates);
                hexTileObject.SetOccupyingTalonIdentificationReport(this.talonConstructionReport.GetTalonIdentificationReport());
            }
            else
            {
                throw new ArgumentException("Unable to SetCubeCoordinates" +
                    "\n\t>" + typeof(CubeCoordinates) + " is null");
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.GetTalonInformationReport().ToString();
        }

        #endregion Public Methods
    }
}