/// <summary>
/// Company: HappyBananaStudio
/// Author: Matthew Gintjee
/// </summary>

namespace HappyBananaStudio.OurAshesTactics.Impl.Objects.Mvc.Models
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Coordinates.Objects.Cube;
    using HappyBananaStudio.OurAshes.Tactics.Api.HexTiles.Objects;
    using HappyBananaStudio.OurAshes.Tactics.Api.Loggers;
    using HappyBananaStudio.OurAshes.Tactics.Api.Maps.Games.Objects;
    using HappyBananaStudio.OurAshes.Tactics.Api.MVCs.Frameworks.Objects;
    using HappyBananaStudio.OurAshes.Tactics.Api.MVCs.Initializers.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Api.MVCs.Models.Objects;
    using HappyBananaStudio.OurAshes.Tactics.Api.MVCs.Models.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Api.MVCs.Turns;
    using HappyBananaStudio.OurAshes.Tactics.Api.Rosters.Objects;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Objects;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Actions.Orders;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Information;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Turn;
    using HappyBananaStudio.OurAshes.Tactics.Common.Constants.Factions.Enums;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums;
    using HappyBananaStudio.OurAshes.Tactics.Common.Managers.CodeObjects;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Loggers;
    using HappyBananaStudio.OurAshesTactics.Common.Utils.Exceptions;
    using HappyBananaStudio.OurAshesTactics.Common.Utils.Talons;
    using HappyBananaStudio.OurAshesTactics.Impl.Objects.Maps.Game;
    using HappyBananaStudio.OurAshesTactics.Impl.Objects.Rosters;
    using HappyBananaStudio.OurAshesTactics.Impl.Reports.Mvc.Models;
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
        private readonly IRosterObject rosterObject = null;

        // Todo
        private readonly IDictionary<ITalonIdentificationReport, ITalonTurnReport> talonIdentificationActionInformationIDictionary =
            new Dictionary<ITalonIdentificationReport, ITalonTurnReport>();

        // Todo
        private readonly IMvcFrameworkObject mvcFrameworkObject;

        // Todo
        private readonly IMvcInitializationReport mvcInitializationReport;

        // Todo
        private int counterAction = 0;

        // Todo
        private int counterPhase = 0;

        // Todo
        private IList<ITalonIdentificationReport> orderedTalonIdentificationReportList =
            new List<ITalonIdentificationReport>();

        // Todo
        private bool processingActionReport = false;

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
                // Todo: Construct these
                this.gameMapObject = new GameMapObjectImpl(this.mvcInitializationReport.GetGameMapConstructionReport());
                this.rosterObject = new RosterObjectImpl(this.mvcInitializationReport.GetRosterConstructionReport());
                foreach (ITalonIdentificationReport talonIdentificationReport in this.rosterObject.GetAllTalonIdentificationReportSet())
                {
                    ICubeCoordinates spawnCubeCoordinates = TalonSpawnCubeCoordinatesUtil
                        .GetSpawningCubeCoordinatesFor(GameTypeEnum.Deathmatch);
                    IHexTileObject hexTileObject = GameMapObjectManager.GetHexTileObjectFrom(spawnCubeCoordinates);
                    if (hexTileObject != null)
                    {
                        this.rosterObject.GetTalonObject(talonIdentificationReport).SetCubeCoordinates(spawnCubeCoordinates);
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
            ISet<FactionIdEnum> remainingTalonFactionIdSet = new HashSet<FactionIdEnum>();
            foreach (ITalonIdentificationReport talonIdentificationReport in this.rosterObject.GetActiveTalonIdentificationReportSet())
            {
                remainingTalonFactionIdSet.Add(talonIdentificationReport.GetFactionId());
            }
            logger.Debug("Remaining Factions: ?", string.Join(", ", remainingTalonFactionIdSet));
            return !(remainingTalonFactionIdSet.Count > 1);
        }

        ITalonIdentificationReport IMvcModelObject.GetActingTalonIdentificationReport()
        {
            if (this.orderedTalonIdentificationReportList.Count == 0)
            {
                this.orderedTalonIdentificationReportList = new List<ITalonIdentificationReport>(
                    this.rosterObject.GetActiveTalonIdentificationReportSet());
                ((List<ITalonIdentificationReport>)this.orderedTalonIdentificationReportList).Sort(
                    this.rosterObject.GetOrderPointComparer());
                foreach (ITalonIdentificationReport talonIdentificationReport in this.orderedTalonIdentificationReportList)
                {
                    ITalonObject talonObject = this.rosterObject.GetTalonObject(talonIdentificationReport);
                    talonObject.ResetForNewTurn();
                }
                this.counterPhase++;
                this.counterAction = 0;
            }
            return this.orderedTalonIdentificationReportList[0];
        }

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
                    if (!this.talonIdentificationActionInformationIDictionary.ContainsKey(talonIdentificationReport))
                    {
                        logger.Debug("Caching ? for ?", typeof(ITalonTurnReport), talonIdentificationReport);
                        this.talonIdentificationActionInformationIDictionary.Add(
                            talonIdentificationReport,
                            talonObject.GetTalonTurnReport());
                    }
                    return this.talonIdentificationActionInformationIDictionary[talonIdentificationReport];
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
        IGameTurnResultReport IMvcModelObject.InputTalonActionOrderReport(ITalonActionOrderReport talonActionOrderReport)
        {
            return null;
            /*
// Check that the parameters are non-null
if (talonActionOrderReport != null)
{
    ITalonIdentificationReport actingTalonIdentificationReport = this.GetActingTalonIdentificationReport();
    ITalonIdentificationReport parameterizedTalonIdentificationReport = talonActionOrderReport.GetActingTalonIdentificationReport();
    if (actingTalonIdentificationReport.Equals(parameterizedTalonIdentificationReport))
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
        /// <returns>
        /// </returns>
        bool IMvcModelObject.IsProcessingAction()
        {
            return this.processingActionReport;
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
