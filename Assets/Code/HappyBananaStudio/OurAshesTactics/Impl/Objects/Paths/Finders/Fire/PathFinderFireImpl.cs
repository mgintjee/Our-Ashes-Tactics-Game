/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Coordinates;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.HexTile;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.HexTiles;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Loggers;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Managers;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Utils.Coordinates;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Utils.Exceptions;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Objects.Coordinates.Cube;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Objects.Paths.Finders.Abs;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Objects.Paths.Objects.Fire;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Objects.Paths.Finders.Fire
{
    /// <summary>
    /// Todo
    /// </summary>
    public class PathFinderFireImpl
    : PathFinderAbstract
    {
        // Provide logging capability
        private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

        public PathFinderFireImpl(ICubeCoordinates cubeCoordinatesStart)
            : base(cubeCoordinatesStart)
        {
        }

        public override void BeginPathFinding()
        {
            HashSet<ICubeCoordinates> allCubeCoordinatesEndSet = GameMapObjectManager.GetAllCubeCoordinatesSet();
            HashSet<ICubeCoordinates> validCubeCoordinatesEndSet = new HashSet<ICubeCoordinates>();
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
                List<ICubeCoordinates> straightLinePath = this.PathFindFor(this.cubeCoordinatesStart, cubeCoordinates);
                this.pathObjectDictionary[cubeCoordinates] = new PathObjectFireImpl(straightLinePath);
            }
        }

        private ICubeCoordinates GetNextCubeCoordinates(int pathIndex, int distance, ICubeCoordinates cubeCoordinatesEnd)
        {
            float t = 1f / distance * pathIndex;
            int roundX, roundY, roundZ;
            float lerpX = Lerp(this.cubeCoordinatesStart.GetX(), cubeCoordinatesEnd.GetX(), t);
            float lerpY = Lerp(this.cubeCoordinatesStart.GetY(), cubeCoordinatesEnd.GetY(), t);
            float lerpZ = Lerp(this.cubeCoordinatesStart.GetZ(), cubeCoordinatesEnd.GetZ(), t);

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
                    //this.logger.Debug("New Fire Cost: ?", string.Join(", ", newFireCostSortedSet));
                    if (newXFireCost == newFireCostSortedSet.Max)
                    {
                        //this.logger.Debug("Updated X=", newX);
                        roundX = newX;
                    }
                    else if (newYFireCost == newFireCostSortedSet.Max)
                    {
                        //this.logger.Debug("Updated Y=", newY);
                        roundY = newY;
                    }
                    else if (newZFireCost == newFireCostSortedSet.Max)
                    {
                        //this.logger.Debug("Updated Z=", newZ);
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
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. PathIndex=?, Distance=?, " +
                    "? produced invalid ?, x=?, y=?, z=?",
                    this.GetType(), pathIndex, distance, cubeCoordinatesEnd, typeof(ICubeCoordinates), roundX, roundY, roundZ);
            }
        }

        private float Lerp(int a, int b, float t)
        {
            return a + (b - a) * t;
        }

        private List<ICubeCoordinates> PathFindFor(ICubeCoordinates cubeCoordinatesStart, ICubeCoordinates cubeCoordinatesEnd)
        {
            int distance = CubeCoordinatesCommonUtil.GetCubeCoordinatesDistanceFrom(cubeCoordinatesStart, cubeCoordinatesEnd);
            List<ICubeCoordinates> cubeCoordinatesList = new List<ICubeCoordinates>();
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