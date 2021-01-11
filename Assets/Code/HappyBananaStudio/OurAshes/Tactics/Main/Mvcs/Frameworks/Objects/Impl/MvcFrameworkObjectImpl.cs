namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Objects.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Generators.GameBoards.Coordinates.Cube;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Controllers.Objects.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Controllers.Objects.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Coordinates.Cube.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Objects.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Objects.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Constructions.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Objects.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.Objects.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.Objects.Impl;
    using System.Collections.Generic;

    /// <summary>
    /// MvcFramework Object Api
    /// </summary>
    public class MvcFrameworkObjectImpl
        : IMvcFrameworkObject
    {
        // Todo
        private IMvcModelObject mvcModelObject;

        // Todo
        private IMvcControllerObject mvcControllerObject;

        // Todo
        private IMvcViewObject mvcViewObject;

        // Todo
        private SimulationType simulationType;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="simulationType"></param>
        /// <param name="matchType"></param>
        /// <param name="gameBoardShape"></param>
        /// <param name="gameBoardLimit"></param>
        /// <param name="mirroredBoard"></param>
        /// <param name="factionIdPhalanxIdSetDictionary"></param>
        /// <param name="phalanxTalonCallSignSetDictionary"></param>
        /// <param name="talonCallSignConstructionReportDictionary"></param>
        private MvcFrameworkObjectImpl(SimulationType simulationType, MatchType matchType,
            GameBoardShape gameBoardShape, int gameBoardLimit, bool mirroredBoard,
            IDictionary<FactionCallSign, ISet<PhalanxCallSign>> factionIdPhalanxIdSetDictionary,
            IDictionary<PhalanxCallSign, ISet<TalonCallSign>> phalanxTalonCallSignSetDictionary,
            IDictionary<TalonCallSign, ITalonConstructionReport> talonCallSignConstructionReportDictionary)
        {
            this.simulationType = simulationType;
            if (this.simulationType != SimulationType.BlackBox)
            {
                // Then the view is required
            }
            else
            {
            }
            ISet<ISet<TalonCallSign>> friendlyTalonCallSignSets = new HashSet<ISet<TalonCallSign>>();
            foreach (ISet<PhalanxCallSign> phalanxIdSet in factionIdPhalanxIdSetDictionary.Values)
            {
                ISet<TalonCallSign> friendlyTalonCallSignSet = new HashSet<TalonCallSign>();
                foreach (PhalanxCallSign phalanxId in phalanxIdSet)
                {
                    friendlyTalonCallSignSet.UnionWith(phalanxTalonCallSignSetDictionary[phalanxId]);
                }
                friendlyTalonCallSignSets.Add(friendlyTalonCallSignSet);
            }
            ISet<ICubeCoordinates> cubeCoordinateSet = CubeCoordinatesSetGenerator
                .GenerateCubeCoordinates(gameBoardShape, gameBoardLimit);
            IDictionary<TalonCallSign, ICubeCoordinates> talonSpawnCubeCoordinatesDictionary =
                TalonSpawnCubeCoordinatesGenerator.GenerateSpawnCubeCoordinates(friendlyTalonCallSignSets, cubeCoordinateSet);
            this.mvcViewObject = new MvcViewObjectImpl.Builder()
                .Build();
            this.mvcControllerObject = new MvcControllerObjectImpl.Builder()
                .Build();
            this.mvcModelObject = new MvcModelObjectImpl.Builder()
                .SetCubeCoordinatesSet(cubeCoordinateSet)
                .SetFriendlyTalonCallSignDictionary(friendlyTalonCallSignSets)
                .SetMatchType(matchType)
                .SetMirroredBoad(mirroredBoard)
                .SetTalonSpawnCubeCoordinatesDictionary(talonSpawnCubeCoordinatesDictionary)
                .SetTalonCallSignConstructionReportDictionary(talonCallSignConstructionReportDictionary)
                .Build();
        }

        /// <inheritdoc/>
        bool IMvcFrameworkObject.ContinueGame()
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc/>
        IMvcControllerObject IMvcFrameworkObject.GetMvcControllerObject()
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc/>
        IMvcModelObject IMvcFrameworkObject.GetMvcModelObject()
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc/>
        IMvcViewObject IMvcFrameworkObject.GetMvcViewObject()
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc/>
        void IMvcFrameworkObject.Initialize()
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc/>
        void IMvcFrameworkObject.Start()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private SimulationType simulationType = SimulationType.None;

            // Todo
            private MatchType matchType = MatchType.None;

            // Todo
            private GameBoardShape gameBoardShape = GameBoardShape.Hexagon;

            // Todo
            private int gameBoardLimit = 0;

            // Todo
            private bool setGameBoardLimit = false;

            // Todo
            private bool mirroredBoard = false;

            // Todo
            private bool setMirroredBoard = false;

            // Todo
            private IDictionary<FactionCallSign, ISet<PhalanxCallSign>> factionIdPhalanxIdSetDictionary = null;

            // Todo
            private IDictionary<PhalanxCallSign, ISet<TalonCallSign>> phalanxTalonCallSignSetDictionary = null;

            // Todo
            private IDictionary<TalonCallSign, ITalonConstructionReport> talonCallSignConstructionReportDictionary = null;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IMvcFrameworkObject Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Object
                    return new MvcFrameworkObjectImpl(this.simulationType, this.matchType,
                        this.gameBoardShape, this.gameBoardLimit, this.mirroredBoard,
                        this.factionIdPhalanxIdSetDictionary, this.phalanxTalonCallSignSetDictionary,
                        this.talonCallSignConstructionReportDictionary);
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
            /// <param name="gameBoardShape"></param>
            /// <returns></returns>
            public Builder SetGameBoardShape(GameBoardShape gameBoardShape)
            {
                this.gameBoardShape = gameBoardShape;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="gameBoardLimit"></param>
            /// <returns></returns>
            public Builder SetGameBoardLimit(int gameBoardLimit)
            {
                this.gameBoardLimit = gameBoardLimit;
                this.setGameBoardLimit = true;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="mirroredBoard"></param>
            /// <returns></returns>
            public Builder SetMirroredBoard(bool mirroredBoard)
            {
                this.mirroredBoard = mirroredBoard;
                this.setMirroredBoard = true;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="factionIdPhalanxIdSetDictionary"></param>
            /// <returns></returns>
            public Builder SetFactionIdPhalanxIdSetDictionary(
                IDictionary<FactionCallSign, ISet<PhalanxCallSign>> factionIdPhalanxIdSetDictionary)
            {
                this.factionIdPhalanxIdSetDictionary = new Dictionary<FactionCallSign, ISet<PhalanxCallSign>>(
                    factionIdPhalanxIdSetDictionary);
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="phalanxTalonCallSignSetDictionary"></param>
            /// <returns></returns>
            public Builder SetPhalanxTalonCallSignSetDictionary(
                IDictionary<PhalanxCallSign, ISet<TalonCallSign>> phalanxTalonCallSignSetDictionary)
            {
                this.phalanxTalonCallSignSetDictionary = new Dictionary<PhalanxCallSign, ISet<TalonCallSign>>(
                    phalanxTalonCallSignSetDictionary);
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="talonCallSignConstructionReportDictionary"></param>
            /// <returns></returns>
            public Builder SetTalonCallSignConstructionReportDictionary(
                IDictionary<TalonCallSign, ITalonConstructionReport> talonCallSignConstructionReportDictionary)
            {
                if (talonCallSignConstructionReportDictionary != null)
                {
                    this.talonCallSignConstructionReportDictionary =
                        new Dictionary<TalonCallSign, ITalonConstructionReport>(
                        talonCallSignConstructionReportDictionary);
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
                if (this.simulationType == SimulationType.None)
                {
                    argumentExceptionSet.Add(typeof(SimulationType).Name + " is not set");
                }
                if (this.matchType == MatchType.None)
                {
                    argumentExceptionSet.Add(typeof(MatchType).Name + " is not set");
                }
                if (this.gameBoardShape == GameBoardShape.None)
                {
                    argumentExceptionSet.Add(typeof(GameBoardShape).Name + " is not set");
                }
                if (!this.setGameBoardLimit)
                {
                    argumentExceptionSet.Add("gameBoardLimit is not set");
                }
                if (!this.setMirroredBoard)
                {
                    argumentExceptionSet.Add("mirroredBoard is not set");
                }
                if (this.factionIdPhalanxIdSetDictionary == null)
                {
                    argumentExceptionSet.Add("factionIdPhalanxIdSetDictionary is not set");
                }
                if (this.phalanxTalonCallSignSetDictionary == null)
                {
                    argumentExceptionSet.Add("phalanxTalonCallSignSetDictionary is not set");
                }
                if (this.talonCallSignConstructionReportDictionary == null)
                {
                    argumentExceptionSet.Add("talonCallSignLoadoutReportDictionary is not set");
                }
                return argumentExceptionSet;
            }
        }
    }
}