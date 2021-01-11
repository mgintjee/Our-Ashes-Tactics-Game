namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Objects.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Coordinates.Cube.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.GameBoards.Objects.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.GameBoards.Objects.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.HexTiles.Objects.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Objects.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Reports.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Roes.Objects.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Roes.Objects.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Rosters.Objects.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Rosters.Objects.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Actions.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Actions.Reports.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Constructions.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Objects.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Orders.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.TurnOrders.Objects.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.TurnOrders.Objects.Impl;
    using System.Collections.Generic;

    /// <summary>
    /// MvcModel Object Impl
    /// </summary>
    public class MvcModelObjectImpl
        : IMvcModelObject
    {
        // Todo
        private readonly IRoeObject roeObject;

        // Todo
        private readonly IRosterObject rosterObject;

        // Todo
        private readonly ITurnOrderObject turnOrderObject;

        // Todo
        private readonly IGameBoardObject gameBoardObject;

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
        private MvcModelObjectImpl(ISet<ISet<TalonCallSign>> friendlyTalonCallSignSets,
            IDictionary<TalonCallSign, ITalonConstructionReport> talonCallSignConstructionReportDictionary,
            IDictionary<TalonCallSign, ICubeCoordinates> talonSpawnCubeCoordinatesDictionary,
            ISet<ICubeCoordinates> cubeCoordinatesSet, bool mirroredBoard, MatchType matchType)
        {
            this.matchType = matchType;
            // Need to pass in the Roe, Roster, and TurnOrder info
            this.roeObject = new RoeObjectImpl.Builder()
                .SetFriendlyTalonCallSignSets(friendlyTalonCallSignSets)
                .Build();
            this.rosterObject = new RosterObjectImpl.Builder()
                .SetTalonCallSignConstructionReportDictionary(talonCallSignConstructionReportDictionary)
                .Build();
            this.turnOrderObject = new TurnOrderObjectImpl.Builder().Build();
            this.gameBoardObject = new GameBoardObjectImpl.Builder()
                .SetCubeCoordinatesSet(cubeCoordinatesSet)
                .SetMirroredBoard(mirroredBoard)
                .Build();
            // Iterate over the Spawn CubeCoordinates
            foreach (TalonCallSign talonCallSign in talonSpawnCubeCoordinatesDictionary.Keys)
            {
                // Collect the CubeCoordinates
                ICubeCoordinates spawnCubeCoordinates = talonSpawnCubeCoordinatesDictionary[talonCallSign];
                // Collect the TalonObject
                ITalonObject talonObject = this.rosterObject.GetTalonObject(talonCallSign);
                // Collect the HexTileObject
                IHexTileObject hexTileObject = this.gameBoardObject.GetHexTileObjectFrom(spawnCubeCoordinates);
                // Set the TalonObject's CubeCoordinates
                talonObject.SetCubeCoordinates(spawnCubeCoordinates);
                // Set the HexTileObject's TalonCallSign
                hexTileObject.SetTalonCallSign(talonCallSign);
            }
        }

        /// <inheritdoc/>
        bool IMvcModelObject.CheckWinConditions()
        {
            bool isGameOver = false;
            switch (this.matchType)
            {
                case MatchType.Deathmatch:
                    // Todo: Add a win condition check here for this GameType
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
            return new TalonActionReportImpl.Builder()
                .SetTalonCallSign(talonCallSign)
                .SetTalonActionOrderReportSet(this.rosterObject.GetTalonObject(talonCallSign).GetTalonOrderReportSet())
                .Build();
        }

        /// <inheritdoc/>
        IMvcModelReport IMvcModelObject.InputTalonOrderReport(ITalonOrderReport talonOrderReport)
        {
            ITalonObject actingTalonObject = this.rosterObject.GetTalonObject(talonOrderReport.GetActingTalonCallSign());
            return new MvcModelReportImpl.Builder()
                .SetGameBoardReport(this.gameBoardObject.GetGameBoardReport())
                .SetTalonCallSign(talonOrderReport.GetActingTalonCallSign())
                .SetActionCount(int.MinValue) // The Talon's Actions
                .SetTurnCount(int.MinValue) // The amount of turns so far
                .SetRoeReport(this.roeObject.GetRoeReport())
                .SetRosterReport(this.rosterObject.GetRosterReport())
                .Build();
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
                    return new MvcModelObjectImpl(this.friendlyTalonCallSignSets,
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