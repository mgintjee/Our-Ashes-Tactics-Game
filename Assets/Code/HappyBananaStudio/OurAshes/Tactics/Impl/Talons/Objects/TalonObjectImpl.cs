namespace HappyBananaStudio.OurAshes.Tactics.Impl.Talons.Objects
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Coordinates.Objects.Cube;
    using HappyBananaStudio.OurAshes.Tactics.Api.Hoplites.Objects;
    using HappyBananaStudio.OurAshes.Tactics.Api.Loggers;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Objects;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Actions.Orders;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Actions.Results;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Attributes;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Construction;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Information;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Turn;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Talons;
    using HappyBananaStudio.OurAshes.Tactics.Common.Managers.CodeObjects;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Exceptions;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Hoplites.Objects;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Loggers;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Paths.Objects.Wait;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Talons.Reports.Actions.Orders;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Talons.Reports.Actions.Results;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Talons.Reports.Attributes;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Talons.Reports.Information;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Talons.Reports.Turn;
    using System.Collections.Generic;
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
        private readonly IDestructibleObject destructibleObject;

        // Todo
        private readonly IHopliteObject hopliteObject;

        // Todo
        private readonly IMountableObject mountableObject;

        // Todo
        private readonly IMovableObject movableObject;

        // Todo
        private readonly ITalonObjectConstructionReport talonObjectConstructionReport;

        // Todo
        private ICubeCoordinates cubeCoordinates;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonObjectConstructionReport">
        /// </param>
        public TalonObjectImpl(ITalonObjectConstructionReport talonObjectConstructionReport)
        {
            if (talonObjectConstructionReport != null)
            {
                logger.Info("Constructing: ?.", this.GetType());
                this.talonObjectConstructionReport = talonObjectConstructionReport;
                this.hopliteObject = new HopliteObjectImpl(this.talonConstructionReport);
                this.destructibleObject = new DestructibleObjectImpl(this.talonConstructionReport);
                this.mountableObject = new MountableObjectImpl(this.talonConstructionReport);
                this.movableObject = new MovableObjectImpl(this.talonConstructionReport);
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. " +
                    "\n\t> ? is null: ?", this.GetType().Name,
                    typeof(ITalonObjectConstructionReport), (talonObjectConstructionReport == null));
            }
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
                .SetTalonActionOrderReportSet(this.BuildTalonActionOrderReportSet())
                .SetTalonInformationReport(this.BuildTalonInformationReport())
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonActionOrderReport">
        /// </param>
        /// <returns>
        /// </returns>
        ITalonActionResultReport ITalonObject.InputAction(ITalonActionOrderReport talonActionOrderReport)
        {
            int actionCost = 0;
            int moveCost = 0;
            switch (talonActionOrderReport.GetActionType())
            {
                case ActionType.Wait:
                    actionCost = this.movableObject.GetMovableAttributesReport().GetMaximumActionPoints();
                    break;

                case ActionType.Move:
                    actionCost = 1;
                    moveCost = talonActionOrderReport.GetPathObject().GetPathObjectCost();
                    break;

                case ActionType.Fire:
                    actionCost = 2;
                    moveCost = this.movableObject.GetMovableAttributesReport().GetMaximumMovePoints() * 2;
                    break;
            }
            this.movableObject.InputActionCosts(actionCost, moveCost);
            return new TalonActionResultReportImpl.Builder()
                .SetTalonActionOrderReport(talonActionOrderReport)
                .SetTalonAttributesReport(this.BuildTalonAttributesReport())
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="armorCost">
        /// </param>
        /// <param name="healthCost">
        /// </param>
        void ITalonObject.InputDamage(int armorCost, int healthCost)
        {
            this.destructibleObject.InputDamage(armorCost, healthCost);
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
            if (this.cubeCoordinates != null ||
                cubeCoordinates == null)
            {
                GameMapObjectManager.GetHexTileObjectFrom(this.cubeCoordinates).ClearOccupyingTalonIdentificationReport();
            }
            this.cubeCoordinates = cubeCoordinates;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        private ISet<ITalonActionOrderReport> BuildTalonActionOrderReportSet()
        {
            ISet<ITalonActionOrderReport> talonActionOrderReportSet = new HashSet<ITalonActionOrderReport>()
            {
                new TalonActionOrderReportImpl.Builder()
                    .SetActingTalonIdentificationReport(this.talonConstructionReport.GetTalonIdentificationReport())
                    .SetPathObject(new PathObjectWaitImpl(new List<ICubeCoordinates>(){this.cubeCoordinates }))
                    .Build()
            };
            talonActionOrderReportSet.UnionWith(this.movableObject.GetTalonActionOrderReportSet(this.cubeCoordinates));
            talonActionOrderReportSet.UnionWith(this.mountableObject.GetTalonActionOrderFireReportSet(this.cubeCoordinates));
            return talonActionOrderReportSet;
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
    }
}