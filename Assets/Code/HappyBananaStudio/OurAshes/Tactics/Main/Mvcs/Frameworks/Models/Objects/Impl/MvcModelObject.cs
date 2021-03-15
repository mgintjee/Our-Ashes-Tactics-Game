using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Cube.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Loggers.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Loggers.Impl;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Combats.Objects.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Combats.Objects.Impl;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Combats.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.GameBoards.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.GameBoards.Objects.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.GameBoards.Objects.Impl;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Objects.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Reports.Impl;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Rosters.Phalanxes.Mangers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Rosters.Phalanxes.Objects.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Rosters.Phalanxes.Objects.Impl;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Rosters.Talons.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Rosters.Talons.Objects.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Rosters.Talons.Objects.Impl;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.TurnOrders.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.TurnOrders.Objects.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.TurnOrders.Objects.Impl;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.WinConditions.Objects.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.WinConditions.Objects.Impl;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Reports.Phalanxes.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.HexTiles.Models.Objects.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Common.Actions.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Common.Actions.Reports.Impl;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Common.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Common.Orders.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Common.Orders.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Constructions.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Effects.Objects.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Effects.Objects.Impl;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Attributes.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Objects.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Pathing.Objects.Api;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Objects.Impl
{
    /// <summary>
    /// MvcModel Object Impl
    /// </summary>
    public class MvcModelObject
        : IMvcModelObject
    {
        // Provide logging capability
        private static readonly ICodeLogger logger = new CodeLogger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly IPhalanxRosterObject phalanxRosterObject;

        // Todo
        private readonly ITalonRosterObject talonRosterObject;

        // Todo
        private readonly ITurnOrderObject turnOrderObject;

        // Todo
        private readonly IGameBoardObject gameBoardObject;

        // Todo
        private readonly ICombatObject combatObject;

        // Todo
        private readonly IWinConditionObject winConditionObject;

        // Todo
        private readonly SimulationType simulationType;

        // Todo
        private int actionCount;

        // Todo
        private int turnCount;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="phalanxReportSet"></param>
        /// <param name="talonConstructionReportSet"></param>
        /// <param name="talonSpawnCubeCoordinatesDictionary"></param>
        /// <param name="cubeCoordinatesSet"></param>
        /// <param name="mirroredBoard"></param>
        /// <param name="matchType"></param>
        private MvcModelObject(ISet<IPhalanxReport> phalanxReportSet,
            ISet<ITalonConstructionReport> talonConstructionReportSet,
            IDictionary<TalonCallSign, ICubeCoordinates> talonSpawnCubeCoordinatesDictionary,
            ISet<ICubeCoordinates> cubeCoordinatesSet, bool mirroredBoard,
            MatchType matchType, SimulationType simulationType)
        {
            this.simulationType = simulationType;
            this.phalanxRosterObject = new PhalanxRosterObject.Builder()
                .SetPhalanxReportSet(phalanxReportSet)
                .Build();
            this.talonRosterObject = new TalonRosterObject.Builder()
                .SetTalonConstructionReportSet(talonConstructionReportSet)
                .Build();
            this.gameBoardObject = new GameBoardObject.Builder()
                .SetCubeCoordinatesSet(cubeCoordinatesSet)
                .SetMirroredBoard(mirroredBoard)
                .Build();
            this.winConditionObject = new WinConditionObject.Builder()
                .SetPhalanxRosterObject(this.phalanxRosterObject)
                .SetTalonRosterObject(this.talonRosterObject)
                .SetMatchType(matchType)
                .Build();
            this.turnOrderObject = new TurnOrderObject.Builder()
                .SetTalonRosterObject(this.talonRosterObject)
                .Build();
            this.combatObject = new CombatObject.Builder()
                .SetTalonRosterObject(this.talonRosterObject)
                .Build();
            this.SetTalonSpawnCubeCoordinates(talonSpawnCubeCoordinatesDictionary);
            this.SetModelManagers();
        }

        /// <inheritdoc/>
        TalonCallSign IMvcModelObject.GetActingTalonCallSign()
        {
            IList<TalonCallSign> orderedTalonCallSignList = this.turnOrderObject.GetTurnOrderReport()
                .GetOrderedTalonCallSignList();
            logger.Debug("GetActingTalonCallSign");
            foreach (TalonCallSign talonCallSign in orderedTalonCallSignList)
            {
                if (!this.talonRosterObject.IsTalonCallSignActive(talonCallSign))
                {
                    this.DeactivateTalonCallSign(talonCallSign);
                }
            }
            if (orderedTalonCallSignList.Count > 0)
            {
                return orderedTalonCallSignList[0];
            }
            else
            {
                return TalonCallSign.None;
            }
        }

        /// <inheritdoc/>
        ITalonActionReport IMvcModelObject.GetTalonActionReport(TalonCallSign talonCallSign)
        {
            return new TalonActionReport.Builder()
                .SetTalonCallSign(talonCallSign)
                .SetTalonActionOrderReportSet(this.talonRosterObject.GetTalonObject(talonCallSign).GetTalonOrderReportSet())
                .Build();
        }

        /// <inheritdoc/>
        void IMvcModelObject.InputTalonOrderReport(ITalonOrderReport talonOrderReport)
        {
            TalonCallSign talonCallSign = talonOrderReport.GetActingTalonCallSign();
            ITalonEffectObject talonActionEffectObject;
            switch (talonOrderReport.GetOrderType())
            {
                case OrderType.Wait:
                    talonActionEffectObject = this.HandleWaitOrder(talonCallSign);
                    break;

                case OrderType.Fire:
                    talonActionEffectObject = this.HandleFireOrder(talonCallSign, talonOrderReport.GetPathObject());
                    break;

                case OrderType.Move:
                    talonActionEffectObject = this.HandleMoveOrder(talonCallSign, talonOrderReport.GetPathObject());
                    break;

                default:
                    throw ExceptionUtil.Arguments.Build();
            }
            ITalonObject actingTalonObject = this.talonRosterObject.GetTalonObject(talonCallSign);
            actingTalonObject.InputTalonEffect(talonActionEffectObject);
            if (actingTalonObject.GetTalonReport().GetCurrentTalonAttributesReport().GetActionPoints() < 1)
            {
                this.turnOrderObject.TalonCallSignCompletedTurn(talonCallSign);
            }
        }

        /// <inheritdoc/>
        IMvcModelReport IMvcModelObject.GetMvcModelReport()
        {
            return new MvcModelReport.Builder()
                .SetGameBoardReport(this.gameBoardObject.GetGameBoardReport())
                .SetPhalanxRosterReport(this.phalanxRosterObject.GetPhalanxRosterReport())
                .SetTalonRosterReport(this.talonRosterObject.GetTalonRosterReport())
                .SetWinConditionReport(this.winConditionObject.GetWinConditionReport())
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonCallSign"></param>
        /// <returns></returns>
        private ITalonEffectObject HandleWaitOrder(TalonCallSign talonCallSign)
        {
            ITalonAttributesReport talonAttributesReport = this.talonRosterObject.GetTalonObject(talonCallSign)
                .GetTalonReport().GetCurrentTalonAttributesReport();
            return new TalonEffectObject.Builder()
                 .SetActionEffect(-talonAttributesReport.GetActionPoints())
                 .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonCallSign"></param>
        /// <returns></returns>
        private ITalonEffectObject HandleFireOrder(TalonCallSign talonCallSign, IPathObject pathObject)
        {
            ICubeCoordinates endCubeCoordinates = pathObject.GetCubeCoordinatesEnd();
            TalonCallSign targetTalonCallSign = this.gameBoardObject.GetHexTileObject(endCubeCoordinates)
                .GetHexTileReport().GetTalonCallSign();
            IList<ICombatReport> actualCombatReportList = this.combatObject.GetActualCombatReport(
                talonCallSign, targetTalonCallSign, pathObject.GetPathObjectCost());
            IList<ICombatReport> averageombatReportList = this.combatObject.GetAverageCombatReport(
                talonCallSign, targetTalonCallSign, pathObject.GetPathObjectCost());
            logger.Debug("actualCombatReportList=[\n\t>?]", string.Join("\n\t>", actualCombatReportList));
            logger.Debug("averageCombatReportList=[\n\t>?]", string.Join("\n\t>", averageombatReportList));
            foreach (ICombatReport combatReport in actualCombatReportList)
            {
                logger.Debug("Inputing ? into ?", combatReport, targetTalonCallSign);
                foreach (ITalonEffectObject talonEffectObject in combatReport.GetTalonEffectObjectSet())
                {
                    this.talonRosterObject.GetTalonObject(targetTalonCallSign).InputTalonEffect(talonEffectObject);
                }
            }
            if (!this.talonRosterObject.IsTalonCallSignActive(targetTalonCallSign))
            {
                this.DeactivateTalonCallSign(targetTalonCallSign);
            }
            if (this.simulationType != SimulationType.BlackBox)
            {
                // Send some information to the MvcView Canvas Manager or something
            }
            return new TalonEffectObject.Builder()
                .SetActionEffect(-1)
                .SetMovementEffect(-pathObject.GetPathObjectCost())
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonCallSign"></param>
        private void DeactivateTalonCallSign(TalonCallSign talonCallSign)
        {
            logger.Debug("Deactivating ?", talonCallSign);
            ICubeCoordinates cubeCoordinates = this.talonRosterObject.GetTalonObject(talonCallSign).GetTalonReport().GetCubeCoordinates();
            this.talonRosterObject.DeactivateTalonCallSign(talonCallSign);
            this.gameBoardObject.GetHexTileObject(cubeCoordinates).ClearTalonCallSign();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonCallSign"></param>
        /// <returns></returns>
        private ITalonEffectObject HandleMoveOrder(TalonCallSign talonCallSign, IPathObject pathObject)
        {
            ICubeCoordinates startCubeCoordinates = pathObject.GetCubeCoordinatesStart();
            ICubeCoordinates endCubeCoordinates = pathObject.GetCubeCoordinatesEnd();
            this.gameBoardObject.GetHexTileObject(startCubeCoordinates).ClearTalonCallSign();
            this.gameBoardObject.GetHexTileObject(endCubeCoordinates).SetTalonCallSign(talonCallSign);
            this.talonRosterObject.GetTalonObject(talonCallSign).SetCubeCoordinates(endCubeCoordinates);
            return new TalonEffectObject.Builder()
                .SetActionEffect(-1)
                .SetMovementEffect(-pathObject.GetPathObjectCost())
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonSpawnCubeCoordinatesDictionary"></param>
        private void SetTalonSpawnCubeCoordinates(
            IDictionary<TalonCallSign, ICubeCoordinates> talonSpawnCubeCoordinatesDictionary)
        {
            // Iterate over the Spawn CubeCoordinates
            foreach (TalonCallSign talonCallSign in talonSpawnCubeCoordinatesDictionary.Keys)
            {
                // Collect the CubeCoordinates
                ICubeCoordinates spawnCubeCoordinates = talonSpawnCubeCoordinatesDictionary[talonCallSign];
                // Collect the TalonObject
                ITalonObject talonObject = this.talonRosterObject.GetTalonObject(talonCallSign);
                // Collect the HexTileObject
                IHexTileObject hexTileObject = this.gameBoardObject.GetHexTileObject(spawnCubeCoordinates);
                // Set the TalonObject's CubeCoordinates
                talonObject.SetCubeCoordinates(spawnCubeCoordinates);
                // Set the HexTileObject's TalonCallSign
                hexTileObject.SetTalonCallSign(talonCallSign);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        private void SetModelManagers()
        {
            GameBoardManager.SetGameBoardObject(this.gameBoardObject);
            TurnOrderManager.SetTurnOrderObject(this.turnOrderObject);
            TalonRosterManager.SetTalonRosterObject(this.talonRosterObject);
            PhalanxRosterManager.SetPhalanxRosterObject(this.phalanxRosterObject);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private ISet<IPhalanxReport> phalanxReports = null;

            // Todo
            private ISet<ITalonConstructionReport> talonConstructionReports = null;

            // Todo
            private IDictionary<TalonCallSign, ICubeCoordinates> talonSpawnCubeCoordinatesDictionary = null;

            // Todo
            private ISet<ICubeCoordinates> cubeCoordinatesSet = null;

            // Todo
            private bool mirroredBoard = false;

            // Todo
            private bool setMirroredBoard = false;

            // Todo
            private MatchType matchType = MatchType.None;

            // Todo
            private SimulationType simulationType = SimulationType.None;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IMvcModelObject Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Object
                    return new MvcModelObject(this.phalanxReports, this.talonConstructionReports,
                        this.talonSpawnCubeCoordinatesDictionary, this.cubeCoordinatesSet,
                        this.mirroredBoard, this.matchType, this.simulationType);
                }
                throw ExceptionUtil.Arguments.Build("Unable to construct ?. Invalid Parameters. ?",
                    this.GetType(), string.Join("\n", invalidReasons));
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="matchType"></param>
            /// <returns></returns>
            public Builder SetMatchType(MatchType matchType)
            {
                this.matchType = matchType;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="simulationType"></param>
            /// <returns></returns>
            public Builder SetSimulationType(SimulationType simulationType)
            {
                this.simulationType = simulationType;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="mirroredBoard"></param>
            /// <returns></returns>
            public Builder SetMirroredBoad(bool mirroredBoard)
            {
                this.mirroredBoard = mirroredBoard;
                this.setMirroredBoard = true;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="cubeCoordinatesSet"></param>
            /// <returns></returns>
            public Builder SetCubeCoordinatesSet(ISet<ICubeCoordinates> cubeCoordinatesSet)
            {
                if (cubeCoordinatesSet != null)
                {
                    this.cubeCoordinatesSet = new HashSet<ICubeCoordinates>(cubeCoordinatesSet);
                }
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="phalanxReports"></param>
            /// <returns></returns>
            public Builder SetPhalanxReports(ISet<IPhalanxReport> phalanxReports)
            {
                if (phalanxReports != null)
                {
                    this.phalanxReports = new HashSet<IPhalanxReport>(phalanxReports);
                }
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="talonConstructionReports"></param>
            /// <returns></returns>
            public Builder SetTalonConstructionReports(
                ISet<ITalonConstructionReport> talonConstructionReports)
            {
                if (talonConstructionReports != null)
                {
                    this.talonConstructionReports = new HashSet<ITalonConstructionReport>(talonConstructionReports);
                }
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="talonSpawnCubeCoordinatesDictionary"></param>
            /// <returns></returns>
            public Builder SetTalonSpawnCubeCoordinatesDictionary(
            IDictionary<TalonCallSign, ICubeCoordinates> talonSpawnCubeCoordinatesDictionary)
            {
                if (talonSpawnCubeCoordinatesDictionary != null)
                {
                    this.talonSpawnCubeCoordinatesDictionary = new Dictionary<TalonCallSign, ICubeCoordinates>(
                        talonSpawnCubeCoordinatesDictionary);
                }
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns>
            /// </returns>
            private ISet<string> IsInvalid()
            {
                // Default an empty Set: String
                ISet<string> argumentExceptionSet = new HashSet<string>();
                // Check that matchType has been set
                if (this.matchType == MatchType.None)
                {
                    argumentExceptionSet.Add(typeof(MatchType).Name + " has not been set");
                }
                // Check that simulationType has been set
                if (this.simulationType == SimulationType.None)
                {
                    argumentExceptionSet.Add(typeof(SimulationType).Name + " has not been set");
                }
                // Check that cubeCoordinatesSet has been set
                if (this.cubeCoordinatesSet == null)
                {
                    argumentExceptionSet.Add("cubeCoordinatesSet has not been set");
                }
                // Check that phalanxReports has been set
                if (this.phalanxReports == null)
                {
                    argumentExceptionSet.Add("Set: " + typeof(IPhalanxReport).Name + " cannot be null.");
                }
                // Check that talonConstructionReports has been set
                if (this.talonConstructionReports == null)
                {
                    argumentExceptionSet.Add("Set: " + typeof(ITalonConstructionReport).Name + " cannot be null.");
                }
                // Check that talonSpawnCubeCoordinatesDictionary has been set
                if (this.talonSpawnCubeCoordinatesDictionary == null)
                {
                    argumentExceptionSet.Add("talonSpawnCubeCoordinatesDictionary has not been set");
                }
                // Check that mirroredBoard has been set
                if (!this.setMirroredBoard)
                {
                    argumentExceptionSet.Add("mirroredBoard has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}