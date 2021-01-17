namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.GameBoards.Objects.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Coordinates.Cube.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Coordinates.Cube.Utils;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.GameBoards.Objects.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.GameBoards.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.GameBoards.Reports.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.HexTiles.Constants;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.HexTiles.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.HexTiles.Objects.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.HexTiles.Objects.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.HexTiles.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.HexTiles.Utils;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Board Object Impl
    /// </summary>
    public class GameBoardObject
        : IGameBoardObject
    {
        // Todo
        private readonly IDictionary<ICubeCoordinates, IHexTileObject> cubeCoordinatesHexTileObjectDictionary;

        // Todo
        private readonly bool mirroredBoard;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinatesSet"></param>
        /// <param name="mirroredBoard"></param>
        private GameBoardObject(ISet<ICubeCoordinates> cubeCoordinatesSet, bool mirroredBoard)
        {
            this.mirroredBoard = mirroredBoard;
            IDictionary<ICubeCoordinates, HexTileType> cubeCoordinatesHexTileTypeDictionary = HexTileTypeGeneratorUtil
                .BuildCubeCoordinatesHexTileTypeDictionary(cubeCoordinatesSet, this.mirroredBoard);
            this.cubeCoordinatesHexTileObjectDictionary = new Dictionary<ICubeCoordinates, IHexTileObject>();
            foreach (ICubeCoordinates cubeCoordinates in cubeCoordinatesHexTileTypeDictionary.Keys)
            {
                this.cubeCoordinatesHexTileObjectDictionary.Add(cubeCoordinates,
                    new HexTileObject.Builder()
                            .SetCubeCoordinates(cubeCoordinates)
                            .SetHexTileType(cubeCoordinatesHexTileTypeDictionary[cubeCoordinates])
                        .Build());
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="gameBoardObject"></param>
        private GameBoardObject(IGameBoardObject gameBoardObject)
        {
            this.mirroredBoard = gameBoardObject.GetMirroredBoard();
            this.cubeCoordinatesHexTileObjectDictionary = new Dictionary<ICubeCoordinates, IHexTileObject>();
            foreach (KeyValuePair<ICubeCoordinates, IHexTileObject> entry in gameBoardObject.GetCubeCoordinatesHexTileObjectDictionary())
            {
                this.cubeCoordinatesHexTileObjectDictionary.Add(entry.Key,
                    new HexTileObject.Builder().Build(entry.Value));
            }
        }

        /// <inheritdoc/>
        IGameBoardReport IGameBoardObject.GetGameBoardReport()
        {
            // Default an empty Set
            ISet<IHexTileReport> hexTileReportSet = new HashSet<IHexTileReport>();

            foreach (IHexTileObject hexTileObject in this.cubeCoordinatesHexTileObjectDictionary.Values)
            {
                hexTileReportSet.Add(hexTileObject.GetHexTileReport());
            }

            return new GameBoardReport.Builder()
                .SetHexTileReportSet(hexTileReportSet)
                .Build();
        }

        /// <inheritdoc/>
        IDictionary<ICubeCoordinates, IHexTileObject> IGameBoardObject.GetCubeCoordinatesHexTileObjectDictionary()
        {
            return new Dictionary<ICubeCoordinates, IHexTileObject>(this.cubeCoordinatesHexTileObjectDictionary);
        }

        /// <inheritdoc/>
        ISet<ICubeCoordinates> IGameBoardObject.GetCubeCoordinatesSet()
        {
            return new HashSet<ICubeCoordinates>(this.cubeCoordinatesHexTileObjectDictionary.Keys);
        }

        /// <inheritdoc/>
        float IGameBoardObject.GetHexTileObjectFireCostFrom(ICubeCoordinates cubeCoordinates)
        {
            if (cubeCoordinates != null)
            {
                if (this.cubeCoordinatesHexTileObjectDictionary.ContainsKey(cubeCoordinates))
                {
                    IHexTileObject hexTileObject = this.cubeCoordinatesHexTileObjectDictionary[cubeCoordinates];
                    IHexTileReport hexTileReport = hexTileObject.GetHexTileReport();
                    float tileFireCost = !(hexTileReport.GetTalonCallSign().Equals(TalonCallSign.None))
                        // Todo find the constant here
                        ? HexTileAttributesConstants.GetHexTileAttributes(hexTileReport.GetHexTileType()).GetFireCost() + 5
                        : HexTileAttributesConstants.GetHexTileAttributes(hexTileReport.GetHexTileType()).GetFireCost();
                    return tileFireCost;
                }
                else
                {
                    throw ExceptionUtil.Argument.Build("Unable to ?. Invalid Parameters. ? is not tracked.",
                        new StackFrame().GetMethod().Name, cubeCoordinates);
                }
            }
            else
            {
                throw ExceptionUtil.Argument.Build("Unable to ?. Invalid Parameters. ? is null.",
                    new StackFrame().GetMethod().Name, typeof(ICubeCoordinates));
            }
        }

        /// <inheritdoc/>
        IHexTileObject IGameBoardObject.GetHexTileObject(ICubeCoordinates cubeCoordinates)
        {
            if (cubeCoordinates != null)
            {
                if (this.cubeCoordinatesHexTileObjectDictionary.ContainsKey(cubeCoordinates))
                {
                    return this.cubeCoordinatesHexTileObjectDictionary[cubeCoordinates];
                }
                else
                {
                    throw ExceptionUtil.Argument.Build("Unable to ?. Invalid Parameters. ? is not tracked.",
                        new StackFrame().GetMethod().Name, cubeCoordinates);
                }
            }
            else
            {
                throw ExceptionUtil.Argument.Build("Unable to ?. Invalid Parameters. ? is null.",
                    new StackFrame().GetMethod().Name, typeof(ICubeCoordinates));
            }
        }

        /// <inheritdoc/>
        ISet<ICubeCoordinates> IGameBoardObject.GetNeighborCubeCoordinates(ICubeCoordinates cubeCoordinates)
        {
            if (cubeCoordinates != null)
            {
                if (this.cubeCoordinatesHexTileObjectDictionary.ContainsKey(cubeCoordinates))
                {
                    ISet<ICubeCoordinates> neighborCubeCoordinatesSet = CubeCoordinatesCommonUtil
                        .GetPossibleNeighborCubeCoordinatesSet(cubeCoordinates);
                    neighborCubeCoordinatesSet.IntersectWith(this.cubeCoordinatesHexTileObjectDictionary.Keys);
                    return neighborCubeCoordinatesSet;
                }
                else
                {
                    throw ExceptionUtil.Argument.Build("Unable to ?. Invalid Parameters. ? is not tracked.",
                        new StackFrame().GetMethod().Name, cubeCoordinates);
                }
            }
            else
            {
                throw ExceptionUtil.Argument.Build("Unable to ?. Invalid Parameters. ? is null.",
                    new StackFrame().GetMethod().Name, typeof(ICubeCoordinates));
            }
        }

        /// <inheritdoc/>
        bool IGameBoardObject.GetMirroredBoard()
        {
            return this.mirroredBoard;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: MirroredBoard={1}, HexTileReports={3}",
                this.GetType().Name, this.mirroredBoard,
                string.Join("\n\t>", this.cubeCoordinatesHexTileObjectDictionary.Values));
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private ISet<ICubeCoordinates> cubeCoordiantesSet = new HashSet<ICubeCoordinates>();

            // Todo
            private bool mirroredBoard = false;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IGameBoardObject Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Object
                    return new GameBoardObject(this.cubeCoordiantesSet, this.mirroredBoard);
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
            /// <param name="gameBoardObject"></param>
            /// <returns></returns>
            public IGameBoardObject Build(IGameBoardObject gameBoardObject)
            {
                return new GameBoardObject(gameBoardObject);
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="mirroredBoard"></param>
            /// <returns></returns>
            public Builder SetMirroredBoard(bool mirroredBoard)
            {
                this.mirroredBoard = mirroredBoard;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="cubeCoordinatesSet"></param>
            /// <returns></returns>
            public Builder SetCubeCoordinatesSet(ISet<ICubeCoordinates> cubeCoordinatesSet)
            {
                this.cubeCoordiantesSet = new HashSet<ICubeCoordinates>(cubeCoordinatesSet);
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
                // Check that cubeCoordiantesSet has been set
                if (this.cubeCoordiantesSet == null)
                {
                    argumentExceptionSet.Add("Set: " + typeof(ICubeCoordinates) + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}