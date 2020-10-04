/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Attributes.Hoplites;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Coordinates;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.HexTile;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Paths.Object;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Talons.Behaviors;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Talons.Objects;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Talons.Visuals;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Weapons.Objects;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Action;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Combat;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Customization;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Turn;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Scripts.Talons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Builders;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Loggers;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Managers;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Utils.Exceptions;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Objects.Talons
{
    /// <summary>
    /// Talon Object Impl
    /// </summary>
    public class TalonObjectImpl
    : ITalonObject
    {
        // Provide logging capability
        private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly IHopliteAttributes hopliteAttributes;

        // Todo
        private readonly ITalonConstructionReport talonConstructionReport;

        // Todo
        private readonly ITalonCustomizationReport talonCustomizationReport;

        // Todo
        private readonly ITalonScript talonScript;

        // Todo
        private ITalonBehavior talonBehavior;

        // Todo
        private ITalonVisual talonVisual;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonScript">
        /// </param>
        /// <param name="talonConstructionReport">
        /// </param>
        public TalonObjectImpl(ITalonScript talonScript, ITalonConstructionReport talonConstructionReport)
        {
            if (talonScript != null &&
                talonConstructionReport != null)
            {
                logger.Info("Constructing: ?.", this.GetType());
                this.talonScript = talonScript;
                this.talonConstructionReport = talonConstructionReport;
                this.hopliteAttributes = this.talonConstructionReport.GetHopliteAttributes();
                this.talonCustomizationReport = this.talonConstructionReport.GetTalonCustomizationReport();
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. " +
                    "\n\t> ? is null: ?" +
                    "\n\t> ? is null: ?", this.GetType().Name,
                    typeof(ITalonScript), (talonScript == null),
                    typeof(ITalonConstructionReport), (talonConstructionReport == null));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="weaponObject">
        /// </param>
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
            ICubeCoordinates currentCubeCoordinates = this.talonBehavior.GetCubeCoordinates();
            if (currentCubeCoordinates != null)
            {
                IHexTileObject currentHexTileObject = GameMapObjectManager.GetHexTileObjectFrom(currentCubeCoordinates);
                currentHexTileObject.SetOccupyingTalonIdentificationReport(null);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public ICubeCoordinates GetCubeCoordinates()
        {
            return this.talonBehavior.GetCubeCoordinates();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public ITalonTurnInformationReport GetTalonActionInformationReport()
        {
            return ReportBuilder.Talon.Turn.Information.GetBuilder()
                .SetTalonInformationReport(this.GetTalonInformationReport())
                .SetTalonActionOrderReportSet(this.talonBehavior.GetPossibleTalonActionOrderReportSet())
                .Build();
        }

        /// <summary>
        /// </summary>
        /// <param name="pathObjectFire">
        /// </param>
        /// <returns>
        /// </returns>
        public ITalonCombatOrderReport GetTalonCombatOrderReport(IPathObject pathObjectFire)
        {
            return this.talonBehavior.GetTalonCombatOrderReport(pathObjectFire);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public ITalonCustomizationReport GetTalonCustomizationReport()
        {
            return this.talonCustomizationReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public ITalonInformationReport GetTalonInformationReport()
        {
            return ReportBuilder.Talon.Information.GetBuilder()
                .SetTalonAttributesReport(this.talonBehavior.GetTalonAttributesReport())
                .SetTalonIdentificationReport(this.talonConstructionReport.GetTalonIdentificationReport())
                .SetHopliteReport(ReportBuilder.Hoplite.GetBuilder()
                .SetControllerId(this.hopliteAttributes.GetControllerId())
                .SetHopliteAttributes(this.hopliteAttributes)
                .Build())
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public ITalonScript GetTalonScript()
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
                ITalonIdentificationReport talonIdentificationReport = this.talonConstructionReport.GetTalonIdentificationReport();
                if (talonIdentificationReport != null)
                {
                    this.talonBehavior = new TalonBehaviorImpl(talonIdentificationReport);
                    this.talonVisual = new TalonVisualImpl(this, this.talonConstructionReport);
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to initialize ?. Invalid Parameters. " +
                        "\n\t> ? is null", this.GetType().Name, typeof(ITalonIdentificationReport));
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
        /// <param name="talonActionOrder">
        /// </param>
        /// <returns>
        /// </returns>
        public ITalonActionResultReport InputTalonActionOrderReport(ITalonActionOrderReport talonActionOrder)
        {
            /*
            if (talonActionOrder.GetActionType() == ActionTypeEnum.Move)
            {
                this.SetCubeCoordinates(talonActionOrder.GetPathObject().GetCubeCoordinatesEnd());
            }
            */
            return this.talonBehavior.InputTalonActionOrderReport(talonActionOrder);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonCombatOrderReport">
        /// </param>
        /// <returns>
        /// </returns>
        public ITalonCombatResultReport InputTalonCombatOrderReport(ITalonCombatOrderReport talonCombatOrderReport)
        {
            return this.talonBehavior.InputTalonCombatOrderReport(talonCombatOrderReport);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
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
        /// <param name="cubeCoordinates">
        /// </param>
        public void SetCubeCoordinates(ICubeCoordinates cubeCoordinates)
        {
            if (cubeCoordinates != null)
            {
                ICubeCoordinates currentCubeCoordinates = this.talonBehavior.GetCubeCoordinates();
                if (currentCubeCoordinates != null)
                {
                    IHexTileObject currentHexTileObject = GameMapObjectManager.GetHexTileObjectFrom(currentCubeCoordinates);
                    currentHexTileObject.SetOccupyingTalonIdentificationReport(null);
                }

                this.talonBehavior.SetCubeCoordinates(cubeCoordinates);
                this.talonVisual.SetCubeCoordinates(cubeCoordinates);

                IHexTileObject hexTileObject = GameMapObjectManager.GetHexTileObjectFrom(cubeCoordinates);
                hexTileObject.SetOccupyingTalonIdentificationReport(this.talonConstructionReport.GetTalonIdentificationReport());
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
        /// <returns>
        /// </returns>
        public override string ToString()
        {
            return this.GetTalonInformationReport().ToString();
        }
    }
}