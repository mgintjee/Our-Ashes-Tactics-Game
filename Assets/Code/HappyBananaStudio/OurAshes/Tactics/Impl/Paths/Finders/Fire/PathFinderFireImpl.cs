namespace HappyBananaStudio.OurAshes.Tactics.Impl.Paths.Finders.Fire
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Coordinates.Objects.Cube;
    using HappyBananaStudio.OurAshes.Tactics.Api.HexTiles.Objects;
    using HappyBananaStudio.OurAshes.Tactics.Api.HexTiles.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Api.Loggers;
    using HappyBananaStudio.OurAshes.Tactics.Api.Paths.Objects;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Information;
    using HappyBananaStudio.OurAshes.Tactics.Common.Managers.CodeObjects;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Coordinates;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Exceptions;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Coordinates.Objects.Cube;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Loggers;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Paths.Finders.Abs;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Paths.Objects.Fire;
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
        private readonly int maxAccuracy = int.MinValue;

        // Todo
        private readonly int maxRange = int.MinValue;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinatesStart">
        /// </param>
        public PathFinderFireImpl(ICubeCoordinates cubeCoordinatesStart, int maxRange, int maxAccuracy)
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
            ISet<ICubeCoordinates> allCubeCoordinatesEndSet = GameMapObjectManager.GetAllCubeCoordinatesSet();
            ISet<ICubeCoordinates> validCubeCoordinatesEndSet = new HashSet<ICubeCoordinates>();
            foreach (ICubeCoordinates cubeCoordinates in allCubeCoordinatesEndSet)
            {
                // Check if the cubeCoordinates is not the starting one
                if (!this.cubeCoordinatesStart.Equals(cubeCoordinates))
                {
                    IHexTileObject tileObject = GameMapObjectManager.GetHexTileObjectFrom(cubeCoordinates);
                    if (tileObject != null)
                    {
                        IHexTileInformationReport hexTileInformationReport = tileObject.GetHexTileInformationReport();
                        if (hexTileInformationReport != null)
                        {
                            ITalonIdentificationReport talonIdentificationReport = hexTileInformationReport.GetTalonIdentificationReport();
                            if (talonIdentificationReport != null)
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

                int newXFireCost = (updateX && newX + roundY + roundZ == 0)
                    ? GameMapObjectManager.FindHexTileObjectFireCostFrom(new CubeCoordinatesImpl(newX, roundY, roundZ))
                    : -1;
                int newYFireCost = (updateY && roundX + newY + roundZ == 0)
                    ? GameMapObjectManager.FindHexTileObjectFireCostFrom(new CubeCoordinatesImpl(roundX, newY, roundZ))
                    : -1;
                int newZFireCost = (updateZ && roundX + roundY + newZ == 0)
                    ? GameMapObjectManager.FindHexTileObjectFireCostFrom(new CubeCoordinatesImpl(roundX, roundY, newZ))
                    : -1;
                SortedSet<int> newFireCostSortedSet = new SortedSet<int> { newXFireCost, newYFireCost, newZFireCost };
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
                return new CubeCoordinatesImpl(roundX, roundY, roundZ);
            }
            else
            {
                throw ArgumentExceptionUtil.Build(
                    "Unable to ?. Invalid Parameters. PathIndex=?, Distance=?, ? produced invalid ?, x=?, y=?, z=?",
                    this.GetType(), pathIndex, distance, cubeCoordinatesEnd, typeof(ICubeCoordinates), roundX, roundY, roundZ);
            }
        }

        private float Lerp(int a, int b, float t)
        {
            return a + ((b - a) * t);
        }

        private IList<ICubeCoordinates> PathFindFor(ICubeCoordinates cubeCoordinatesStart, ICubeCoordinates cubeCoordinatesEnd)
        {
            int distance = CubeCoordinatesCommonUtil.GetCubeCoordinatesDistanceFrom(cubeCoordinatesStart, cubeCoordinatesEnd);
            IList<ICubeCoordinates> cubeCoordinatesList = new List<ICubeCoordinates>();
            for (int i = 0; i < distance + 1; ++i)
            {
                try
                {
                    cubeCoordinatesList.Add(this.GetNextCubeCoordinates(i, distance, cubeCoordinatesEnd));
                }
                catch (ArgumentException e)
                {
                    logger.Debug("Error in ?. E=?", new StackFrame().GetMethod().Name, e);
                }
            }

            return cubeCoordinatesList;
        }
    }
}