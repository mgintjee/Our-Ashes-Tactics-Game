/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Coordinates;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.HexTile;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Maps.Game;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Mvc.Frameworks;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Mvc.Models;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Rosters;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Talons.Objects;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Mvc.Initializers;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Mvc.Models;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Action;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Attributes;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Combat;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Turn;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Scripts.Mvc.Models;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Builders;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Enums;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Exceptions;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Loggers;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Managers;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Talons;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Objects.Mvc.Models
{
    /// <summary>
    /// MvcModel Object Impl
    /// </summary>
    public class MvcModelObjectImpl
    : IMvcModelObject
    {
        // Provide logging capability
        private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly IGameMapObject mapObject = null;

        // Todo
        private readonly IMvcModelScript mvcModelScript;

        // Todo
        private readonly IRosterObject rosterObject = null;

        // Todo
        private readonly Dictionary<ITalonIdentificationReport, ITalonTurnInformationReport> talonIdentificationActionInformationDictionary =
            new Dictionary<ITalonIdentificationReport, ITalonTurnInformationReport>();

        // Todo
        private int counterAction = 0;

        // Todo
        private int counterPhase = 0;

        // Todo
        private IMvcFrameworkObject mvcFrameworkObject;

        // Todo
        private IMvcInitializationReport mvcInitializationReport;

        // Todo
        private List<ITalonIdentificationReport> orderedTalonIdentificationReportList =
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
        public MvcModelObjectImpl(IMvcModelScript mvcModelScript, IGameMapObject mapObject, IRosterObject rosterObject)
        {
            if (mvcModelScript != null &&
                mapObject != null &&
                rosterObject != null)
            {
                logger.Info("Constructing: ?", this.GetType());
                this.mvcModelScript = mvcModelScript;
                this.mapObject = mapObject;
                this.rosterObject = rosterObject;
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. " +
                    "\n\t> ? is null: ?" +
                    "\n\t> ? is null: ?" +
                    "\n\t> ? is null: ?", this.GetType(),
                    typeof(IMvcModelScript), (mvcModelScript == null),
                    typeof(IGameMapObject), (mapObject == null),
                    typeof(IRosterObject), (rosterObject == null));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public bool CheckWinConditions()
        {
            HashSet<FactionIdEnum> remainingTalonFactionIdSet = new HashSet<FactionIdEnum>();
            foreach (ITalonIdentificationReport talonIdentificationReport in this.rosterObject.GetActiveTalonIdentificationReportSet())
            {
                remainingTalonFactionIdSet.Add(talonIdentificationReport.GetFactionId());
            }
            logger.Debug("Remaining Factions: ?", string.Join(", ", remainingTalonFactionIdSet));
            return !(remainingTalonFactionIdSet.Count > 1);
        }

        public ITalonIdentificationReport GetActingTalonIdentificationReport()
        {
            if (this.orderedTalonIdentificationReportList.Count == 0)
            {
                this.orderedTalonIdentificationReportList = new List<ITalonIdentificationReport>(
                    this.rosterObject.GetActiveTalonIdentificationReportSet());
                this.orderedTalonIdentificationReportList.Sort(this.rosterObject.GetOrderPointComparer());
                foreach (ITalonIdentificationReport talonIdentificationReport in this.orderedTalonIdentificationReportList)
                {
                    ITalonObject talonObject = this.rosterObject.GetTalonObject(talonIdentificationReport);
                    talonObject.ResetTalonBehaviorMoveable();
                }
                this.counterPhase++;
                this.counterAction = 0;
            }
            return this.orderedTalonIdentificationReportList[0];
        }

        public IMvcModelInformationReport GetMvcModelInformationReport()
        {
            return ReportBuilder.Mvc.Model.GetBuilder()
                .SetGameModelInformationReport(this.mapObject.GetGameMapInformationReport())
                .SetRosterInformationReport(this.rosterObject.GetRosterInformationReport())
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public IMvcModelScript GetMvcModelScript()
        {
            return this.mvcModelScript;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonIdentificationReport">
        /// </param>
        /// <returns>
        /// </returns>
        public ITalonTurnInformationReport GetTalonTurnInformationReport(ITalonIdentificationReport talonIdentificationReport)
        {
            if (this.rosterObject.IsTalonIdentificationReportActive(talonIdentificationReport))
            {
                ITalonObject talonObject = this.rosterObject.GetTalonObject(talonIdentificationReport);

                if (talonObject != null)
                {
                    // Check if the TalonActionInformationReport is not currently cached
                    if (!this.talonIdentificationActionInformationDictionary.ContainsKey(talonIdentificationReport))
                    {
                        logger.Debug("Caching ? for ?", typeof(ITalonTurnInformationReport), talonIdentificationReport);
                        this.talonIdentificationActionInformationDictionary.Add(
                            talonIdentificationReport,
                            talonObject.GetTalonActionInformationReport());
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
        /// <param name="mvcFrameworkObject">
        /// </param>
        /// <param name="mvcInitializationReport">
        /// </param>
        public void Initialize(IMvcFrameworkObject mvcFrameworkObject, IMvcInitializationReport mvcInitializationReport)
        {
            logger.Info("Initializing: ?", this.GetType());
            if (!this.IsInitialized())
            {
                if (mvcFrameworkObject != null &&
                mvcInitializationReport != null)
                {
                    this.mvcFrameworkObject = mvcFrameworkObject;
                    this.mvcInitializationReport = mvcInitializationReport;
                    //int mapRadius = this.mvcInitializationReport.GetGameMapConstructionReport().GetMapRadius();
                    Dictionary<PhalanxIdEnum, int> talonPhalanxIdCountDictionary = new Dictionary<PhalanxIdEnum, int>();

                    foreach (ITalonIdentificationReport talonIdentificationReport in this.rosterObject.GetAllTalonIdentificationReportSet())
                    {
                        if (!talonPhalanxIdCountDictionary.ContainsKey(talonIdentificationReport.GetPhalanxId()))
                        {
                            talonPhalanxIdCountDictionary.Add(talonIdentificationReport.GetPhalanxId(),
                                this.rosterObject.GetAllTalonIdentificationReportSet(talonIdentificationReport.GetPhalanxId()).Count);
                        }
                        // Todo: Update this based off of some GameTypeEnum
                        ICubeCoordinates spawnCubeCoordinates = TalonSpawnCubeCoordinatesUtil.GetSpawningCubeCoordinatesFor(GameTypeEnum.Deathmatch);
                        //talonIdentificationReport.GetPhalanxId(),
                        //talonPhalanxIdCountDictionary[talonIdentificationReport.GetPhalanxId()],
                        //talonIdentificationReport.GetCallSign());
                        IHexTileObject hexTileObject = GameMapObjectManager.FindHexTileObjectFrom(spawnCubeCoordinates);
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
                    throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. " +
                        "\n\t> ? is null: ?" +
                        "\n\t> ? is null: ?", new StackFrame().GetMethod().Name,
                        typeof(IMvcFrameworkObject), (mvcFrameworkObject == null),
                        typeof(IMvcInitializationReport), (mvcInitializationReport == null));
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
        /// <param name="talonActionOrderReport">
        /// </param>
        /// <returns>
        /// </returns>
        public ITalonTurnResultReport InputTalonActionOrderReport(ITalonActionOrderReport talonActionOrderReport)
        {
            // Check that the parameters are non-null
            if (talonActionOrderReport != null)
            {
                ITalonIdentificationReport actingTalonIdentificationReport = this.GetActingTalonIdentificationReport();
                ITalonIdentificationReport parameterizedTalonIdentificationReport = talonActionOrderReport.GetActingTalonIdentificationReport();
                if (actingTalonIdentificationReport.Equals(parameterizedTalonIdentificationReport))
                {
                    if (this.rosterObject.IsTalonIdentificationReportActive(actingTalonIdentificationReport))
                    {
                        ITalonObject actingTalonObject = this.rosterObject.GetTalonObject(actingTalonIdentificationReport);
                        if (actingTalonObject != null)
                        {
                            ITalonTurnInformationReport talonTurnInformationReport = this.GetTalonTurnInformationReport(actingTalonIdentificationReport);
                            this.processingActionReport = true;
                            logger.Info("Phase: ? Action:?) Inputting ?=?", this.counterPhase, this.counterAction, typeof(ITalonActionOrderReport), talonActionOrderReport);
                            ITalonCombatResultReport talonCombatResultReport = null;
                            ITalonActionResultReport talonActionResultReport = actingTalonObject.InputTalonActionOrderReport(talonActionOrderReport);

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
                                            this.talonIdentificationActionInformationDictionary.Remove(targetTalonIdentificationReport);
                                            GameMapObjectManager.FindHexTileObjectFrom(targetTalonObject.GetCubeCoordinates())
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
                            this.talonIdentificationActionInformationDictionary.Clear();

                            return ReportBuilder.Talon.Turn.Result.GetBuilder()
                                .SetTalonActionResultReport(talonActionResultReport)
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
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public bool IsInitialized()
        {
            return this.mvcFrameworkObject != null &&
                this.mvcInitializationReport != null;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public bool IsProcessingAction()
        {
            return this.processingActionReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public void StartNewGame()
        {
            //this.mechObjectTurnList = this.GenerateTalonObjectTurnList();
        }
    }
}