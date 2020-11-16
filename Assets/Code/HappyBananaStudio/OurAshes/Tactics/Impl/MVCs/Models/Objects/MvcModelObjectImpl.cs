

namespace HappyBananaStudio.OurAshes.Tactics.Impl.MVCs.Models.Objects
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Coordinates.Objects.Cube;
    using HappyBananaStudio.OurAshes.Tactics.Api.HexTiles.Objects;
    using HappyBananaStudio.OurAshes.Tactics.Api.Loggers;
    using HappyBananaStudio.OurAshes.Tactics.Api.Maps.Games.Objects;
    using HappyBananaStudio.OurAshes.Tactics.Api.MVCs.Frameworks.Objects;
    using HappyBananaStudio.OurAshes.Tactics.Api.MVCs.GameActions.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Api.MVCs.Initializers.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Api.MVCs.Models.Objects;
    using HappyBananaStudio.OurAshes.Tactics.Api.MVCs.Models.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Objects;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Actions.Orders;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Actions.Results;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Attributes;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Information;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Turn;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Factions;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.GameTypes;
    using HappyBananaStudio.OurAshes.Tactics.Common.Managers.CodeObjects;
    using HappyBananaStudio.OurAshes.Tactics.Common.Managers.GameObjects;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Exceptions;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Talons;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Loggers;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Maps.Games.Objects;
    using HappyBananaStudio.OurAshes.Tactics.Impl.MVCs.GameActions.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Impl.MVCs.Models.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Rosters.Objects;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// MvcModel Object Impl
    /// </summary>
    public class MvcModelObjectImpl
    : IMvcModelObject
    {
        // Provide logging capability
        private static readonly ICodeLogger logger = new CodeLoggerImpl(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly IGameMapObject gameMapObject = null;

        // Todo
        private readonly IMvcFrameworkObject mvcFrameworkObject;

        // Todo
        private readonly IMvcInitializationReport mvcInitializationReport;

        // Todo
        private readonly IFactionRosterObject rosterObject = null;

        // Todo
        private readonly IDictionary<ITalonIdentificationReport, ITalonTurnReport> talonIdentificationActionInformationDictionary =
            new Dictionary<ITalonIdentificationReport, ITalonTurnReport>();

        // Todo
        private int counterAction = 0;

        // Todo
        private int counterPhase = 0;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcModelScript">
        /// </param>
        /// <param name="mapObject">
        /// </param>
        public MvcModelObjectImpl(IMvcFrameworkObject mvcFrameworkObject, IMvcInitializationReport mvcInitializationReport)
        {
            if (mvcFrameworkObject != null &&
                mvcInitializationReport != null)
            {
                logger.Info("Constructing: ?", this.GetType());
                this.mvcFrameworkObject = mvcFrameworkObject;
                this.mvcInitializationReport = mvcInitializationReport;
                this.gameMapObject = new GameMapObjectImpl(this.mvcInitializationReport.GetGameMapConstructionReport());
                this.rosterObject = new RosterObjectImpl(this.mvcInitializationReport.GetRosterConstructionReport());

                foreach (ITalonIdentificationReport talonIdentificationReport in this.rosterObject.GetAllTalonIdentificationReportSet())
                {
                    ICubeCoordinates spawnCubeCoordinates = TalonSpawnCubeCoordinatesUtil
                        .GetSpawningCubeCoordinatesFor(GameTypeEnum.FactionSkirmish);
                    IHexTileObject hexTileObject = GameMapObjectManager.GetHexTileObjectFrom(spawnCubeCoordinates);
                    if (hexTileObject != null)
                    {
                        this.rosterObject.GetTalonObject(talonIdentificationReport).SetCubeCoordinates(spawnCubeCoordinates);
                        TalonGameObjectManager.UpdateTalonWorldPosition(
                            talonIdentificationReport, spawnCubeCoordinates);
                        hexTileObject.SetOccupyingTalonIdentificationReport(talonIdentificationReport);
                    }
                    else
                    {
                        logger.Debug("?=? is not valid", typeof(ICubeCoordinates), spawnCubeCoordinates);
                    }
                }
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. " +
                    "\n\t> ? is null: ?" +
                    "\n\t> ? is null: ?", this.GetType(),
                    typeof(IMvcFrameworkObject), (mvcFrameworkObject == null),
                    typeof(IMvcInitializationReport), (mvcInitializationReport == null));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        bool IMvcModelObject.CheckWinConditions()
        {
            ISet<FactionId> remainingTalonFactionIdSet = new HashSet<FactionId>();
            foreach (ITalonIdentificationReport talonIdentificationReport in this.rosterObject.GetActiveTalonIdentificationReportSet())
            {
                remainingTalonFactionIdSet.Add(talonIdentificationReport.GetFactionId());
            }
            logger.Debug("Remaining Factions: ?", string.Join(", ", remainingTalonFactionIdSet));
            return !(remainingTalonFactionIdSet.Count > 1);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ITalonIdentificationReport IMvcModelObject.GetActingTalonIdentificationReport()
        {
            return TalonTurnOrderManager.GetOrderedTalonIdentificationReportList()[0];
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IMvcModelInformationReport IMvcModelObject.GetMvcModelInformationReport()
        {
            return new MvcModelInformationReportImpl.Builder()
                .SetGameMapInformationReports(this.gameMapObject.GetGameMapInformationReport())
                .SetRosterInformationReport(this.rosterObject.GetRosterInformationReport())
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonIdentificationReport">
        /// </param>
        /// <returns>
        /// </returns>
        ITalonTurnReport IMvcModelObject.GetTalonTurnInformationReport(ITalonIdentificationReport talonIdentificationReport)
        {
            if (this.rosterObject.IsTalonIdentificationReportActive(talonIdentificationReport))
            {
                ITalonObject talonObject = this.rosterObject.GetTalonObject(talonIdentificationReport);

                if (talonObject != null)
                {
                    // Check if the TalonActionInformationReport is not currently cached
                    if (!this.talonIdentificationActionInformationDictionary.ContainsKey(talonIdentificationReport))
                    {
                        logger.Debug("Caching ? for ?", typeof(ITalonTurnReport), talonIdentificationReport);
                        this.talonIdentificationActionInformationDictionary.Add(
                            talonIdentificationReport,
                            talonObject.GetTalonTurnReport());
                    }
                    return this.talonIdentificationActionInformationDictionary[talonIdentificationReport];
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. ? does not have a corresponding ?.",
                        new StackFrame().GetMethod().Name, talonIdentificationReport, typeof(ITalonObject));
                }
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. ? is not active.",
                    new StackFrame().GetMethod().Name, talonIdentificationReport);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonActionOrderReport">
        /// </param>
        /// <returns>
        /// </returns>
        IGameActionReport IMvcModelObject.InputTalonActionOrderReport(ITalonActionOrderReport talonActionOrderReport)
        {
            if (talonActionOrderReport != null)
            {
                ITalonObject actingTalonObject = this.rosterObject.GetTalonObject(
                    talonActionOrderReport.GetActingTalonIdentificationReport());
                logger.Info("Phase: ? Action:?) Inputting ?=?",
                    this.counterPhase, this.counterAction, typeof(ITalonActionOrderReport), talonActionOrderReport);

                ITalonActionResultReport talonActionResultReport = actingTalonObject.InputAction(talonActionOrderReport);

                if (talonActionOrderReport is ITalonActionOrderFireReport talonActionOrderFireReport)
                {
                    ITalonActionResultFireReport talonActionResultFireReport = TalonCombatManager
                        .GetTalonActionResultFireReport(talonActionOrderFireReport);
                    if (talonActionResultFireReport.GetTargetTalonAttributesReport()
                        .GetDestructibleAttributesReport().GetCurrentHealthPoints() <= 0)
                    {
                        ITalonIdentificationReport targetTalonIdentificationReport = talonActionOrderFireReport.GetTargetTalonIdentificationReport();
                        this.rosterObject.GetTalonObject(targetTalonIdentificationReport).SetCubeCoordinates(null);
                        this.talonIdentificationActionInformationDictionary.Remove(targetTalonIdentificationReport);
                        this.rosterObject.DeactivateTalonIdentificationReport(targetTalonIdentificationReport);
                        TalonGameObjectManager.DeactivateTalonIdentificationReport(targetTalonIdentificationReport);
                        TalonTurnOrderManager.RemoveTalonTurn(targetTalonIdentificationReport);
                    }
                    talonActionResultReport = talonActionResultFireReport;
                }

                ITalonAttributesReport talonAttributesReport = talonActionResultReport.GetActingTalonAttributesReport();
                if (talonAttributesReport.GetMovableAttributesReport().GetCurrentActionPoints() < 1)
                {
                    logger.Debug("? completed their turn.", talonActionOrderReport.GetActingTalonIdentificationReport());
                    TalonTurnOrderManager.RemoveTalonTurn(talonActionOrderReport.GetActingTalonIdentificationReport());
                }

                this.counterAction++;
                this.talonIdentificationActionInformationDictionary.Clear();
                return new GameActionReportImpl.Builder()
                    .SetActionCounter(this.counterAction)
                    .SetPhaseCounter(TalonTurnOrderManager.GetPhaseCounter())
                    .SetGameMapInformationReport(this.gameMapObject.GetGameMapInformationReport())
                    .SetTalonActionResultReport(talonActionResultReport)
                    .Build();
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters.", new StackFrame().GetMethod().Name);
            }
            /*
// Check that the parameters are non-null
if (talonActionOrderReport != null)
{
        if (this.rosterObject.IsTalonIdentificationReportActive(actingTalonIdentificationReport))
        {
            return null;
            ITalonObject actingTalonObject = this.rosterObject.GetTalonObject(actingTalonIdentificationReport);
            if (actingTalonObject != null)
            {
                ITalonTurnReport talonTurnInformationReport = this.GetTalonTurnInformationReport(actingTalonIdentificationReport);
                this.processingActionReport = true;
                logger.Info("Phase: ? Action:?) Inputting ?=?", this.counterPhase, this.counterAction, typeof(ITalonActionOrderReport), talonActionOrderReport);

                ITalonCombatResultReport talonCombatResultReport = null;
                ITalonActionResultReport talonActionResultReport = actingTalonObject.InputTalonActionOrderReport(talonActionOrderReport);
                this.mvcModelScript.AnimatePath(talonActionOrderReport);
                if (talonActionOrderReport.GetActionType().Equals(ActionTypeEnum.Fire))
                {
                    ITalonCombatOrderReport talonCombatOrderReport = actingTalonObject.GetTalonCombatOrderReport(talonActionOrderReport.GetPathObject());

                    logger.Info("?=?", typeof(ITalonCombatOrderReport), talonCombatOrderReport);
                    ITalonIdentificationReport targetTalonIdentificationReport = talonActionOrderReport.GetTargetTalonIdentificationReport();
                    if (this.rosterObject.IsTalonIdentificationReportActive(targetTalonIdentificationReport))
                    {
                        ITalonObject targetTalonObject = this.rosterObject.GetTalonObject(targetTalonIdentificationReport);
                        if (targetTalonObject != null)
                        {
                            talonCombatResultReport = targetTalonObject.InputTalonCombatOrderReport(talonCombatOrderReport);
                            logger.Info("?=?", typeof(ITalonCombatResultReport), talonCombatResultReport);
                            if (talonCombatResultReport.GetIsTargetDestroyed())
                            {
                                logger.Info("Destroy ?=?", typeof(ITalonIdentificationReport), targetTalonIdentificationReport);
                                this.rosterObject.DeactivateTalonIdentificationReport(targetTalonIdentificationReport);
                                targetTalonObject.Deactivate();
                                targetTalonObject.GetTalonScript().Destroy();
                                this.orderedTalonIdentificationReportList.Remove(targetTalonIdentificationReport);
                                this.talonIdentificationActionInformationIDictionary.Remove(targetTalonIdentificationReport);
                                GameMapObjectManager.GetHexTileObjectFrom(targetTalonObject.GetCubeCoordinates())
                                    .SetOccupyingTalonIdentificationReport(null);
                            }
                        }
                        else
                        {
                            logger.Error("Unable to input ?. Target ? is null.", typeof(ITalonActionOrderReport), typeof(ITalonObject));
                        }
                    }
                    else
                    {
                        logger.Error("Unable to input ?. Target ? is null.", typeof(ITalonActionOrderReport), typeof(ITalonIdentificationReport));
                    }
            }
            ITalonAttributesReport talonAttributesReport = talonActionResultReport.GetTalonAttributesReport();
                if (talonAttributesReport.GetMovableReport().GetCurrentTurnPoints() < 1)
                {
                    logger.Debug("? completed their turn.", actingTalonIdentificationReport);
                    this.orderedTalonIdentificationReportList.Remove(actingTalonIdentificationReport);
                }

                this.counterAction++;
                this.processingActionReport = false;
                this.talonIdentificationActionInformationIDictionary.Clear();

                return ReportBuilder.Talon.Turn.Result.GetBuilder()
                    .SetTalonActionResultReport(talonActionResultReport)
                    .SetTalonCombatResultReport(talonCombatResultReport)
                    .SetTalonTurnInformationReport(talonTurnInformationReport)
                    .Build();
        }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. " +
                    "\n\t> No ? linked to ?.", new StackFrame().GetMethod().Name,
                    typeof(ITalonObject), actingTalonIdentificationReport);
            }
        }
        else
        {
            throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. " +
                "\n\t> ? is not active.", new StackFrame().GetMethod().Name, actingTalonIdentificationReport);
        }
    }
    else
    {
        throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. " +
            "\n\t> Parameterized ? is not the Acting ?.", new StackFrame().GetMethod().Name,
            parameterizedTalonIdentificationReport, actingTalonIdentificationReport);
    }
}
else
{
    throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. " +
        "\n\t> ? is null.", new StackFrame().GetMethod().Name, typeof(ITalonActionOrderReport));
}
*/
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        bool IMvcModelObject.IsInitialized()
        {
            return this.mvcFrameworkObject != null &&
                this.mvcInitializationReport != null;
        }

        /// <summary>
        /// Todo
        /// </summary>
        void IMvcModelObject.StartNewGame()
        {
            //this.mechObjectTurnList = this.GenerateTalonObjectTurnList();
        }
    }
}
