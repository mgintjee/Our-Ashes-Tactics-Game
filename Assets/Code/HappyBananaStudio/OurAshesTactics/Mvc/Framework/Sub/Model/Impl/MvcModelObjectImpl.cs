/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Common.Exceptions;
using HappyBananaStudio.OurAshesTactics.Common.Logging;
using HappyBananaStudio.OurAshesTactics.Mvc.Coordinates.Cube;
using HappyBananaStudio.OurAshesTactics.Mvc.Framework.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Initializer.Reports;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Reports;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.HexTile.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Map.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Map.Manager;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Roster.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Enums;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Reports;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Util;
using HappyBananaStudio.OurAshesTactics.Pathing.Object.Impl;
using HappyBananaStudio.OurAshesTactics.Talon.Attributes.Reports;
using HappyBananaStudio.OurAshesTactics.Talon.Object.Api;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Model.Impl
{
    /// <summary>
    /// MvcModel Object Impl
    /// </summary>
    public class MvcModelObjectImpl
    : IMvcModelObject
    {
        #region Private Fields

        // Provide logging capability
        private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly IMapObject mapObject = null;

        // Todo
        private readonly MvcModelScript mvcModelScript;

        // Todo
        private readonly IRosterObject rosterObject = null;

        // Todo
        private readonly Dictionary<TalonIdentificationReport, TalonActionInformationReport> talonIdentificationActionInformationDictionary =
            new Dictionary<TalonIdentificationReport, TalonActionInformationReport>();

        // Todo
        private int counterAction = 0;

        // Todo
        private int counterPhase = 0;

        // Todo
        private IMvcFrameworkObject mvcFrameworkObject;

        // Todo
        private MvcInitializationReport mvcInitializationReport;

        // Todo
        private List<TalonIdentificationReport> orderedTalonIdentificationReportList =
            new List<TalonIdentificationReport>();

        // Todo
        private bool processingActionReport = false;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcModelScript"></param>
        /// <param name="mapObject">     </param>
        public MvcModelObjectImpl(MvcModelScript mvcModelScript, IMapObject mapObject, IRosterObject rosterObject)
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
                    typeof(MvcModelScript), (mvcModelScript == null),
                    typeof(IMapObject), (mapObject == null),
                    typeof(IRosterObject), (rosterObject == null));
            }
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public bool CheckWinConditions()
        {
            HashSet<TalonFactionIdEnum> remainingTalonFactionIdSet = new HashSet<TalonFactionIdEnum>();
            foreach (TalonIdentificationReport talonIdentificationReport in this.rosterObject.GetActiveTalonIdentificationReportSet())
            {
                remainingTalonFactionIdSet.Add(talonIdentificationReport.GetTalonFactionId());
            }
            return !(remainingTalonFactionIdSet.Count > 1);
        }

        public TalonIdentificationReport GetActingTalonIdentificationReport()
        {
            if (this.orderedTalonIdentificationReportList.Count == 0)
            {
                this.orderedTalonIdentificationReportList = new List<TalonIdentificationReport>(
                    this.rosterObject.GetActiveTalonIdentificationReportSet());
                this.orderedTalonIdentificationReportList.Sort(this.rosterObject.GetOrderPointComparer());
                foreach (TalonIdentificationReport talonIdentificationReport in this.orderedTalonIdentificationReportList)
                {
                    ITalonObject talonObject = this.rosterObject.GetTalonObject(talonIdentificationReport);
                    talonObject.ResetTalonBehaviorMoveable();
                }
                this.counterPhase++;
                this.counterAction = 0;
            }
            return this.orderedTalonIdentificationReportList[0];
        }

        public MvcModelInformationReport GetMvcModelInformationReport()
        {
            return new MvcModelInformationReport.Builder()
                .SetMapInformationReport(this.mapObject.GetMapInformationReport())
                .SetRosterInformationReport(this.rosterObject.GetRosterInformationReport())
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public MvcModelScript GetMvcModelScript()
        {
            return this.mvcModelScript;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonIdentificationReport"></param>
        /// <returns></returns>
        public TalonActionInformationReport GetTalonActionInformationReport(TalonIdentificationReport talonIdentificationReport)
        {
            if (this.rosterObject.IsTalonIdentificationReportActive(talonIdentificationReport))
            {
                ITalonObject talonObject = this.rosterObject.GetTalonObject(talonIdentificationReport);

                if (talonObject != null)
                {
                    // Check if the TalonActionInformationReport is not currently cached
                    if (!this.talonIdentificationActionInformationDictionary.ContainsKey(talonIdentificationReport))
                    {
                        logger.Debug("Caching ? for ?", typeof(TalonActionInformationReport), talonIdentificationReport);
                        this.talonIdentificationActionInformationDictionary.Add(
                            talonIdentificationReport,
                            talonObject.GetTalonActionInformationReport());
                    }
                    return this.talonIdentificationActionInformationDictionary[talonIdentificationReport];
                }
                else
                {
                    throw new ArgumentException("Unable to GetTalonActionInformationReport. " +
                        talonIdentificationReport + " does not have a corresponding " + typeof(ITalonObject).Name + ".");
                }
            }
            else
            {
                throw new ArgumentException("Unable to GetTalonActionInformationReport. " +
                    talonIdentificationReport + " is not active.");
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameworkObject">     </param>
        /// <param name="mvcInitializationReport"></param>
        public void Initialize(IMvcFrameworkObject mvcFrameworkObject, MvcInitializationReport mvcInitializationReport)
        {
            logger.Info("Initializing: ?", this.GetType());
            if (!this.IsInitialized())
            {
                if (mvcFrameworkObject != null &&
                mvcInitializationReport != null)
                {
                    this.mvcFrameworkObject = mvcFrameworkObject;
                    this.mvcInitializationReport = mvcInitializationReport;
                    int mapRadius = this.mvcInitializationReport.GetMapConstructionReport().GetMapRadius();
                    Dictionary<TalonPhalanxIdEnum, int> talonPhalanxIdCountDictionary = new Dictionary<TalonPhalanxIdEnum, int>();

                    foreach (TalonIdentificationReport talonIdentificationReport in this.rosterObject.GetAllTalonIdentificationReportSet())
                    {
                        if (!talonPhalanxIdCountDictionary.ContainsKey(talonIdentificationReport.GetTalonPhalanxId()))
                        {
                            talonPhalanxIdCountDictionary.Add(talonIdentificationReport.GetTalonPhalanxId(),
                                this.rosterObject.GetAllTalonIdentificationReportSet(talonIdentificationReport.GetTalonPhalanxId()).Count);
                        }
                        CubeCoordinates spawnCubeCoordinates = TalonSpawnCubeCoordinatesUtil.GetSpawningCubeCoordinatesFor(
                            talonIdentificationReport.GetTalonPhalanxId(),
                            talonPhalanxIdCountDictionary[talonIdentificationReport.GetTalonPhalanxId()],
                            talonIdentificationReport.GetTalonPhalanxIndex(),
                            mapRadius);
                        IHexTileObject hexTileObject = MapObjectManager.FindHexTileObjectFrom(spawnCubeCoordinates);
                        if (hexTileObject != null)
                        {
                            this.rosterObject.GetTalonObject(talonIdentificationReport).SetCubeCoordinates(spawnCubeCoordinates);
                            hexTileObject.SetOccupyingTalonIdentificationReport(talonIdentificationReport);
                        }
                        else
                        {
                            logger.Debug("?=? is not valid", typeof(CubeCoordinates), spawnCubeCoordinates);
                        }
                    }
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. " +
                        "\n\t> ? is null: ?" +
                        "\n\t> ? is null: ?", new StackFrame().GetMethod().Name,
                        typeof(IMvcFrameworkObject), (mvcFrameworkObject == null),
                        typeof(MvcInitializationReport), (mvcInitializationReport == null));
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
        /// <param name="talonActionOrderReport"></param>
        /// <returns></returns>
        public TalonTurnResultReport InputTalonActionOrderReport(TalonActionOrderReport talonActionOrderReport)
        {
            // Check that the parameters are non-null
            if (talonActionOrderReport != null)
            {
                TalonIdentificationReport actingTalonIdentificationReport = this.GetActingTalonIdentificationReport();
                TalonIdentificationReport parameterizedTalonIdentificationReport = talonActionOrderReport.GetActingTalonIdentificationReport();
                if (actingTalonIdentificationReport.Equals(parameterizedTalonIdentificationReport))
                {
                    if (this.rosterObject.IsTalonIdentificationReportActive(actingTalonIdentificationReport))
                    {
                        ITalonObject actingTalonObject = this.rosterObject.GetTalonObject(actingTalonIdentificationReport);
                        if (actingTalonObject != null)
                        {
                            this.processingActionReport = true;
                            logger.Info("Phase: ? Action:?) Inputting ?=?", this.counterPhase, this.counterAction, typeof(TalonActionOrderReport), talonActionOrderReport);
                            TalonCombatResultReport talonCombatResultReport = null;
                            TalonActionResultReport talonActionResultReport = actingTalonObject.InputTalonActionOrderReport(talonActionOrderReport);

                            if (talonActionOrderReport.GetTalonActionType().Equals(TalonActionTypeEnum.Fire))
                            {
                                TalonCombatOrderReport talonCombatOrderReport = actingTalonObject.GetTalonCombatOrderReport((PathObjectFire)talonActionOrderReport.GetPathObject());

                                logger.Info("?=?", typeof(TalonCombatOrderReport), talonCombatOrderReport);
                                TalonIdentificationReport targetTalonIdentificationReport = talonActionOrderReport.GetTargetTalonIdentificationReport();
                                if (this.rosterObject.IsTalonIdentificationReportActive(targetTalonIdentificationReport))
                                {
                                    ITalonObject targetTalonObject = this.rosterObject.GetTalonObject(targetTalonIdentificationReport);
                                    if (targetTalonObject != null)
                                    {
                                        talonCombatResultReport = targetTalonObject.InputTalonCombatOrderReport(talonCombatOrderReport);
                                        logger.Info("?=?", typeof(TalonCombatResultReport), talonCombatResultReport);
                                        if (talonCombatResultReport.GetIsTargetDestroyed())
                                        {
                                            logger.Info("Destroy ?=?", typeof(TalonIdentificationReport), targetTalonIdentificationReport);
                                            this.rosterObject.DeactivateTalonIdentificationReport(targetTalonIdentificationReport);
                                            targetTalonObject.Deactivate();
                                        }
                                    }
                                    else
                                    {
                                        logger.Error("Unable to input ?. Target ? is null.", typeof(TalonActionOrderReport), typeof(ITalonObject));
                                    }
                                }
                                else
                                {
                                    logger.Error("Unable to input ?. Target ? is null.", typeof(TalonActionOrderReport), typeof(TalonIdentificationReport));
                                }
                            }

                            TalonAttributesReport talonAttributesReport = talonActionResultReport.GetTalonAttributesReport();
                            if (talonAttributesReport.GetMovableAttributesReport().GetCurrentTurnPoints() < 1)
                            {
                                logger.Debug("? completed their turn.", actingTalonIdentificationReport);
                                this.orderedTalonIdentificationReportList.Remove(actingTalonIdentificationReport);
                            }

                            this.counterAction++;
                            this.processingActionReport = false;
                            this.talonIdentificationActionInformationDictionary.Clear();

                            return new TalonTurnResultReport.Builder()
                                .SetPhaseCounter(this.counterPhase)
                                .SetActionCounter(this.counterAction)
                                .SetTalonActionResultReport(talonActionResultReport)
                                .SetTalonCombatResultReport(talonCombatResultReport)
                                .SetMapInformationReport(this.mapObject.GetMapInformationReport())
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
                    "\n\t> ? is null.", new StackFrame().GetMethod().Name, typeof(TalonActionOrderReport));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public bool IsInitialized()
        {
            return this.mvcFrameworkObject != null &&
                this.mvcInitializationReport != null;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
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

        #endregion Public Methods
    }
}