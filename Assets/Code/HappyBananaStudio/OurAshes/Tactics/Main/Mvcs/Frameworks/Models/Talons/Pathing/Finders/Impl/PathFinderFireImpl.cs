namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Pathing.Finders.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Loggers.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Loggers.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Coordinates.Cube.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Coordinates.Cube.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Coordinates.Cube.Utils;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.GameBoards.Managers;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.HexTiles.Objects.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.HexTiles.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Pathing.Finders.Abs;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Pathing.Finders.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Pathing.Objects.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Pathing.Objects.Impl;
    using HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Todo
    /// </summary>
    public class PathFinderFireImpl
        : PathFinderAbstract
    {
        // Provide logging capability
        private static readonly ICodeLogger logger = new CodeLoggerImpl(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly float maxAccuracy = int.MinValue;

        // Todo
        private readonly int maxRange = int.MinValue;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinatesStart">
        /// </param>
        private PathFinderFireImpl(ICubeCoordinates cubeCoordinatesStart, int maxRange, float maxAccuracy)
            : base(cubeCoordinatesStart)
        {
            this.maxRange = maxRange;
            this.maxAccuracy = maxAccuracy;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public override void BeginPathFinding()
        {
            ISet<ICubeCoordinates> allCubeCoordinatesEndSet = GameBoardObjectManager.GetAllCubeCoordinatesSet();
            ISet<ICubeCoordinates> validCubeCoordinatesEndSet = new HashSet<ICubeCoordinates>();
            foreach (ICubeCoordinates cubeCoordinates in allCubeCoordinatesEndSet)
            {
                // Check if the cubeCoordinates is not the starting one
                if (!this.cubeCoordinatesStart.Equals(cubeCoordinates))
                {
                    IHexTileObject tileObject = GameBoardObjectManager.GetHexTileObjectFrom(cubeCoordinates);
                    if (tileObject != null)
                    {
                        IHexTileReport hexTileInformationReport = tileObject.GetHexTileReport();
                        if (hexTileInformationReport != null)
                        {
                            if (!hexTileInformationReport.GetTalonCallSign().Equals(TalonCallSign.None))
                            {
                                validCubeCoordinatesEndSet.Add(cubeCoordinates);
                            }
                        }
                    }
                }
            }

            foreach (ICubeCoordinates cubeCoordinates in validCubeCoordinatesEndSet)
            {
                IList<ICubeCoordinates> straightLinePath = this.PathFindFor(this.cubeCoordinatesStart, cubeCoordinates);
                if (straightLinePath.Count <= this.maxRange)
                {
                    IPathObject pathObject = new PathObjectFireImpl(straightLinePath);
                    if (pathObject.GetPathObjectCost() < this.maxAccuracy)
                    {
                        this.pathObjectDictionary.Add(cubeCoordinates, pathObject);
                    }
                }
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="pathIndex">
        /// </param>
        /// <param name="distance">
        /// </param>
        /// <param name="cubeCoordinatesEnd">
        /// </param>
        /// <returns>
        /// </returns>
        private ICubeCoordinates GetNextCubeCoordinates(int pathIndex, int distance, ICubeCoordinates cubeCoordinatesEnd)
        {
            float t = 1f / distance * pathIndex;
            int roundX, roundY, roundZ;
            float lerpX = this.Lerp(this.cubeCoordinatesStart.GetX(), cubeCoordinatesEnd.GetX(), t);
            float lerpY = this.Lerp(this.cubeCoordinatesStart.GetY(), cubeCoordinatesEnd.GetY(), t);
            float lerpZ = this.Lerp(this.cubeCoordinatesStart.GetZ(), cubeCoordinatesEnd.GetZ(), t);

            roundX = (int)System.Math.Round(lerpX);
            roundY = (int)System.Math.Round(lerpY);
            roundZ = (int)System.Math.Round(lerpZ);

            bool updateX = System.Math.Abs(lerpX) % 1 == 0.5f;
            bool updateY = System.Math.Abs(lerpY) % 1 == 0.5f;
            bool updateZ = System.Math.Abs(lerpZ) % 1 == 0.5f;

            if (updateX ||
                updateY ||
                updateZ)
            {
                int newX = roundX + System.Math.Sign(lerpX);
                int newY = roundY + System.Math.Sign(lerpY);
                int newZ = roundZ + System.Math.Sign(lerpZ);

                float newXFireCost = (updateX && newX + roundY + roundZ == 0)
                    ? GameBoardObjectManager.FindHexTileObjectFireCostFrom(
                        new CubeCoordinatesImpl.Builder()
                            .SetX(newX)
                            .SetY(roundY)
                            .SetZ(roundZ)
                            .Build())
                    : -1;
                float newYFireCost = (updateY && roundX + newY + roundZ == 0)
                    ? GameBoardObjectManager.FindHexTileObjectFireCostFrom(
                        new CubeCoordinatesImpl.Builder()
                            .SetX(roundX)
                            .SetY(newY)
                            .SetZ(roundZ)
                            .Build())
                    : -1;
                float newZFireCost = (updateZ && roundX + roundY + newZ == 0)
                    ? GameBoardObjectManager.FindHexTileObjectFireCostFrom(
                        new CubeCoordinatesImpl.Builder()
                            .SetX(roundX)
                            .SetY(roundY)
                            .SetZ(newZ)
                            .Build())
                    : -1;
                SortedSet<float> newFireCostSortedSet = new SortedSet<float> { newXFireCost, newYFireCost, newZFireCost };
                if (newFireCostSortedSet.Max != -1)
                {
                    if (newXFireCost == newFireCostSortedSet.Max)
                    {
                        roundX = newX;
                    }
                    else if (newYFireCost == newFireCostSortedSet.Max)
                    {
                        roundY = newY;
                    }
                    else if (newZFireCost == newFireCostSortedSet.Max)
                    {
                        roundZ = newZ;
                    }
                }
            }
            if (roundX + roundY + roundZ == 0)
            {
                return new CubeCoordinatesImpl.Builder()
                    .SetX(roundX)
                    .SetY(roundY)
                    .SetZ(roundZ)
                    .Build();
            }
            else
            {
                throw ExceptionUtil.Argument.Build(
                    "Unable to ?. Invalid Parameters. PathIndex=?, Distance=?, ? produced invalid ?, x=?, y=?, z=?",
                    this.GetType(), pathIndex, distance, cubeCoordinatesEnd, typeof(ICubeCoordinates), roundX, roundY, roundZ);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        private float Lerp(int a, int b, float t)
        {
            return a + ((b - a) * t);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="cubeCoordinatesStart"></param>
        /// <param name="cubeCoordinatesEnd"></param>
        /// <returns></returns>
        private IList<ICubeCoordinates> PathFindFor(ICubeCoordinates cubeCoordinatesStart, ICubeCoordinates cubeCoordinatesEnd)
        {
            int distance = CubeCoordinatesCommonUtil.GetCubeCoordinatesDistanceFrom(
                cubeCoordinatesStart, cubeCoordinatesEnd);
            IList<ICubeCoordinates> cubeCoordinatesList = new List<ICubeCoordinates>();
            for (int i = 0; i < distance + 1; ++i)
            {
                try
                {
                    cubeCoordinatesList.Add(this.GetNextCubeCoordinates(i, distance, cubeCoordinatesEnd));
                }
                catch (ArgumentException e)
                {
                    logger.Debug("Unable to ?. E=?", new StackFrame().GetMethod().Name, e);
                }
            }

            return cubeCoordinatesList;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private ICubeCoordinates startingCubeCoordinates = null;

            // Todo
            private int maxRange = int.MinValue;

            // Todo
            private float maxAccuracy = float.MinValue;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IPathFinder Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Object
                    return new PathFinderFireImpl(this.startingCubeCoordinates, this.maxRange, this.maxAccuracy);
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
            /// <param name="startingCubeCoordinates"></param>
            /// <returns></returns>
            public Builder SetStartingCubeCoordinates(ICubeCoordinates startingCubeCoordinates)
            {
                this.startingCubeCoordinates = startingCubeCoordinates;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="maxRange"></param>
            /// <returns></returns>
            public Builder SetMaxRange(int maxRange)
            {
                this.maxRange = maxRange;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="maxAccuracy"></param>
            /// <returns></returns>
            public Builder SetMaxAccuracy(float maxAccuracy)
            {
                this.maxAccuracy = maxAccuracy;
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
                // Check that startingCubeCoordinates has been set
                if (this.startingCubeCoordinates == null)
                {
                    argumentExceptionSet.Add("Starting " + typeof(ICubeCoordinates) + " has not been set");
                }
                // Check that maxRange has been set
                if (this.maxRange == int.MinValue)
                {
                    argumentExceptionSet.Add("maxRange has not been set");
                }
                // Check that maxAccuracy has been set
                if (this.maxAccuracy == float.MinValue)
                {
                    argumentExceptionSet.Add("maxAccuracy has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}