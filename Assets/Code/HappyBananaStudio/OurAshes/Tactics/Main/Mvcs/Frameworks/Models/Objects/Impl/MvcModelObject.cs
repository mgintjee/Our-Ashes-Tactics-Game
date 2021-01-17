namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Objects.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Loggers.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Loggers.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Combats.Objects.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Combats.Objects.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Combats.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Coordinates.Cube.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.GameBoards.Managers;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.GameBoards.Objects.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.GameBoards.Objects.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.HexTiles.Objects.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Objects.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Reports.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Roes.Managers;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Roes.Objects.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Roes.Objects.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Rosters.Managers;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Rosters.Objects.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Rosters.Objects.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Actions.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Actions.Reports.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Constructions.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Effects.Objects.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Effects.Objects.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Objects.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Orders.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Orders.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Pathing.Objects.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.TurnOrders.Managers;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.TurnOrders.Objects.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.TurnOrders.Objects.Impl;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// MvcModel Object Impl
    /// </summary>
    public class MvcModelObject
        : IMvcModelObject
    {
        // Provide logging capability
        private static readonly ICodeLogger logger = new CodeLogger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly IRoeObject roeObject;

        // Todo
        private readonly IRosterObject rosterObject;

        // Todo
        private readonly ITurnOrderObject turnOrderObject;

        // Todo
        private readonly IGameBoardObject gameBoardObject;

        // Todo
        private readonly ICombatObject combatObject;

        // Todo
        private readonly MatchType matchType;

        // Todo
        private int actionCount;

        // Todo
        private int turnCount;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="friendlyTalonCallSignSets"></param>
        /// <param name="talonCallSignConstructionReportDictionary"></param>
        /// <param name="talonSpawnCubeCoordinatesDictionary"></param>
        /// <param name="cubeCoordinatesSet"></param>
        /// <param name="mirroredBoard"></param>
        /// <param name="matchType"></param>
        private MvcModelObject(ISet<ISet<TalonCallSign>> friendlyTalonCallSignSets,
            IDictionary<TalonCallSign, ITalonConstructionReport> talonCallSignConstructionReportDictionary,
            IDictionary<TalonCallSign, ICubeCoordinates> talonSpawnCubeCoordinatesDictionary,
            ISet<ICubeCoordinates> cubeCoordinatesSet, bool mirroredBoard, MatchType matchType)
        {
            this.matchType = matchType;
            // Need to pass in the Roe, Roster, and TurnOrder info
            this.roeObject = new RoeObject.Builder()
                .SetFriendlyTalonCallSignSets(friendlyTalonCallSignSets)
                .Build();
            this.rosterObject = new RosterObject.Builder()
                .SetTalonCallSignConstructionReportDictionary(talonCallSignConstructionReportDictionary)
                .Build();
            this.gameBoardObject = new GameBoardObject.Builder()
                .SetCubeCoordinatesSet(cubeCoordinatesSet)
                .SetMirroredBoard(mirroredBoard)
                .Build();
            this.turnOrderObject = new TurnOrderObject();
            this.combatObject = new CombatObject();
            // Iterate over the Spawn CubeCoordinates
            foreach (TalonCallSign talonCallSign in talonSpawnCubeCoordinatesDictionary.Keys)
            {
                // Collect the CubeCoordinates
                ICubeCoordinates spawnCubeCoordinates = talonSpawnCubeCoordinatesDictionary[talonCallSign];
                // Collect the TalonObject
                ITalonObject talonObject = this.rosterObject.GetTalonObject(talonCallSign);
                // Collect the HexTileObject
                IHexTileObject hexTileObject = this.gameBoardObject.GetHexTileObject(spawnCubeCoordinates);
                // Set the TalonObject's CubeCoordinates
                talonObject.SetCubeCoordinates(spawnCubeCoordinates);
                // Set the HexTileObject's TalonCallSign
                hexTileObject.SetTalonCallSign(talonCallSign);
            }
            this.SetModelManagers();
        }

        /// <inheritdoc/>
        bool IMvcModelObject.CheckWinConditions()
        {
            bool isGameOver = false;
            // Todo: Have a winConditionObject or something
            switch (this.matchType)
            {
                case MatchType.Deathmatch:
                case MatchType.FactionDeathmatch:
                    ISet<TalonCallSign> activeTalonCallSignSet = this.rosterObject.GetActiveTalonCallSignSet();
                    ISet<ISet<TalonCallSign>> friendlyTalonCallSignSets = this.roeObject.GetRoeReport()
                        .GetFriendlyTalonCallSignSets();
                    int friendlySetsRemaining = 0;
                    foreach(ISet<TalonCallSign> talonCallSignSet in friendlyTalonCallSignSets)
                    {
                        foreach(TalonCallSign talonCallSign in talonCallSignSet)
                        {
                            if(activeTalonCallSignSet.Contains(talonCallSign))
                            {
                                friendlySetsRemaining++;
                                break;
                            }
                        }
                    }
                    isGameOver = friendlySetsRemaining <= 1;
                    break;

                default:
                    break;
            }
            return isGameOver;
        }

        /// <inheritdoc/>
        TalonCallSign IMvcModelObject.GetActingTalonCallSign()
        {
            IList<TalonCallSign> orderedTalonCallSignList = this.turnOrderObject.GetTurnOrderReport()
                .GetOrderedTalonCallSignList();
            logger.Debug("GetActingTalonCallSign");
            foreach (TalonCallSign talonCallSign in orderedTalonCallSignList)
            {
                if (!this.rosterObject.IsTalonCallSignAlive(talonCallSign))
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
                .SetTalonActionOrderReportSet(this.rosterObject.GetTalonObject(talonCallSign).GetTalonOrderReportSet())
                .Build();
        }

        /// <inheritdoc/>
        IMvcModelReport IMvcModelObject.InputTalonOrderReport(ITalonOrderReport talonOrderReport)
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
                    throw ExceptionUtil.Argument.Build();
            }
            ITalonObject actingTalonObject = this.rosterObject.GetTalonObject(talonCallSign);
            actingTalonObject.InputTalonEffect(talonActionEffectObject);
            if (actingTalonObject.GetTalonReport().GetCurrentTalonAttributesReport().GetActionPoints() < 1)
            {
                this.turnOrderObject.TalonCallSignCompletedTurn(talonCallSign);
            }
            return new MvcModelReport.Builder()
                .SetGameBoardReport(this.gameBoardObject.GetGameBoardReport())
                .SetTalonCallSign(talonCallSign)
                .SetRoeReport(this.roeObject.GetRoeReport())
                .SetRosterReport(this.rosterObject.GetRosterReport())
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonCallSign"></param>
        /// <returns></returns>
        private ITalonEffectObject HandleWaitOrder(TalonCallSign talonCallSign)
        {
            ITalonAttributesReport talonAttributesReport = this.rosterObject.GetTalonObject(talonCallSign)
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
                    this.rosterObject.GetTalonObject(targetTalonCallSign).InputTalonEffect(talonEffectObject);
                }
            }
            if (!this.rosterObject.IsTalonCallSignAlive(targetTalonCallSign))
            {
                this.DeactivateTalonCallSign(targetTalonCallSign);
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
            ICubeCoordinates cubeCoordinates = this.rosterObject.GetTalonObject(talonCallSign).GetTalonReport().GetCubeCoordinates();
            this.rosterObject.DeactivateTalonCallSign(talonCallSign);
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
            this.rosterObject.GetTalonObject(talonCallSign).SetCubeCoordinates(endCubeCoordinates);
            return new TalonEffectObject.Builder()
                .SetActionEffect(-1)
                .SetMovementEffect(-pathObject.GetPathObjectCost())
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        private void SetModelManagers()
        {
            RoeManager.SetRoeObject(this.roeObject);
            TurnOrderManager.SetTurnOrderObject(this.turnOrderObject);
            RosterManager.SetRosterObject(this.rosterObject);
            GameBoardManager.SetGameBoardObject(this.gameBoardObject);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private ISet<ISet<TalonCallSign>> friendlyTalonCallSignSets = null;

            // Todo
            private IDictionary<TalonCallSign, ITalonConstructionReport> talonCallSignConstructionReportDictionary = null;

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
                    return new MvcModelObject(this.friendlyTalonCallSignSets,
                        this.talonCallSignConstructionReportDictionary,
                        this.talonSpawnCubeCoordinatesDictionary,
                        this.cubeCoordinatesSet,
                        this.mirroredBoard,
                        this.matchType);
                }
                else
                {
                    throw ExceptionUtil.Argument.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
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
            /// <param name="friendlyTalonCallSignSets"></param>
            /// <returns></returns>
            public Builder SetFriendlyTalonCallSignDictionary(
                ISet<ISet<TalonCallSign>> friendlyTalonCallSignSets)
            {
                if (friendlyTalonCallSignSets != null)
                {
                    this.friendlyTalonCallSignSets = new HashSet<ISet<TalonCallSign>>(
                        friendlyTalonCallSignSets);
                }
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="talonCallSignLoadoutReportDictionary"></param>
            /// <returns></returns>
            public Builder SetTalonCallSignConstructionReportDictionary(
                IDictionary<TalonCallSign, ITalonConstructionReport> talonCallSignLoadoutReportDictionary)
            {
                if (talonCallSignLoadoutReportDictionary != null)
                {
                    this.talonCallSignConstructionReportDictionary =
                        new Dictionary<TalonCallSign, ITalonConstructionReport>(
                        talonCallSignLoadoutReportDictionary);
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
                // Check that cubeCoordinatesSet has been set
                if (this.cubeCoordinatesSet == null)
                {
                    argumentExceptionSet.Add("cubeCoordinatesSet has not been set");
                }
                // Check that friendlyTalonCallSignSets has been set
                if (this.friendlyTalonCallSignSets == null)
                {
                    argumentExceptionSet.Add("friendlyTalonCallSignSets has not been set");
                }
                // Check that talonCallSignConstructionReportDictionary has been set
                if (this.talonCallSignConstructionReportDictionary == null)
                {
                    argumentExceptionSet.Add("talonCallSignConstructionReportDictionary has not been set");
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