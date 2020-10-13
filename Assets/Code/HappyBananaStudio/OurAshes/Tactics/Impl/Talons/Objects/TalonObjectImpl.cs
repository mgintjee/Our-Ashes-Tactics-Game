/// <summary>
/// Company: HappyBananaStudio
/// Author: Matthew Gintjee
/// </summary>

namespace HappyBananaStudio.OurAshesTactics.Impl.Objects.Talons
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Coordinates.Objects.Cube;
    using HappyBananaStudio.OurAshes.Tactics.Api.Hoplites.Objects;
    using HappyBananaStudio.OurAshes.Tactics.Api.Loggers;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Objects;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Attributes;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Construction;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Information;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Turn;
    using HappyBananaStudio.OurAshes.Tactics.Common.Managers.CodeObjects;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Hoplites.Objects;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Loggers;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Talons.Objects;
    using HappyBananaStudio.OurAshesTactics.Common.Utils.Exceptions;
    using HappyBananaStudio.OurAshesTactics.Impl.Reports.Talons;
    using HappyBananaStudio.OurAshesTactics.Impl.Reports.Talons.Attributes;
    using HappyBananaStudio.OurAshesTactics.Impl.Reports.Talons.Turn;
    using System.Diagnostics;

    /// <summary>
    /// Talon Object Impl
    /// </summary>
    public class TalonObjectImpl
    : ITalonObject
    {
        // Provide logging capability
        private static readonly ICodeLogger logger = new CodeLoggerImpl(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly IHopliteObject hopliteObject;

        // Todo
        private readonly IDestructibleObject destructibleObject;

        // Todo
        private readonly IMountableObject mountableObject;

        // Todo
        private readonly IMovableObject movableObject;

        // Todo
        private readonly ITalonConstructionReport talonConstructionReport;

        // Todo
        private ICubeCoordinates cubeCoordinates;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonConstructionReport">
        /// </param>
        public TalonObjectImpl(ITalonConstructionReport talonConstructionReport)
        {
            if (talonConstructionReport != null)
            {
                logger.Info("Constructing: ?.", this.GetType());
                this.talonConstructionReport = talonConstructionReport;
                this.hopliteObject = new HopliteObjectImpl(this.talonConstructionReport);
                this.destructibleObject = new DestructibleObjectImpl(this.talonConstructionReport);
                this.mountableObject = new MountableObjectImpl(this.talonConstructionReport);
                this.movableObject = new MovableObjectImpl(this.talonConstructionReport);
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. " +
                    "\n\t> ? is null: ?", this.GetType().Name,
                    typeof(ITalonConstructionReport), (talonConstructionReport == null));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        void ITalonObject.ResetForNewTurn()
        {
            this.movableObject.ResetForNewTurn();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates">
        /// </param>
        void ITalonObject.SetCubeCoordinates(ICubeCoordinates cubeCoordinates)
        {
            if (this.cubeCoordinates != null)
            {
                GameMapObjectManager.GetHexTileObjectFrom(this.cubeCoordinates).ClearOccupyingTalonIdentificationReport();
            }
            this.cubeCoordinates = cubeCoordinates;
        }

        /// <summary>
        /// Todo
        /// </summary>
        void ITalonObject.DeactivateTalonObject()
        {
            if (this.cubeCoordinates != null)
            {
                GameMapObjectManager.GetHexTileObjectFrom(this.cubeCoordinates).ClearOccupyingTalonIdentificationReport();
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. ? is null." +
                    new StackFrame().GetMethod().Name, typeof(ICubeCoordinates));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ITalonInformationReport ITalonObject.GetTalonInformationReport()
        {
            return this.BuildTalonInformationReport();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ITalonTurnReport ITalonObject.GetTalonTurnReport()
        {
            return new TalonTurnReportImpl.Builder()
                .SetTalonActionOrderReportSet(null)
                .SetTalonInformationReport(this.BuildTalonInformationReport())
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        private ITalonInformationReport BuildTalonInformationReport()
        {
            return new TalonInformationReportImpl.Builder()
                .SetHopliteInformationReport(this.hopliteObject.GetHopliteInformationReport())
                .SetTalonAttributesReport(this.BuildTalonAttributesReport())
                .SetTalonConstructionReport(this.talonConstructionReport)
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        private ITalonAttributesReport BuildTalonAttributesReport()
        {
            return new TalonAttributesReportImpl.Builder()
                .SetDestructableReport(this.destructibleObject.GetDestructibleAttributesReport())
                .SetMountableReport(this.mountableObject.GetMountableAttributesReport())
                .SetMovableReport(this.movableObject.GetMovableAttributesReport())
                .Build();
        }
    }
}
