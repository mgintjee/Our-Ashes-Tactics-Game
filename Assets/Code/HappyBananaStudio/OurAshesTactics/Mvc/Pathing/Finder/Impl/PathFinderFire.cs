/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Common.Logging;
using HappyBananaStudio.OurAshesTactics.Mvc.Coordinates.Cube;
using HappyBananaStudio.OurAshesTactics.Mvc.Coordinates.Util;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.HexTile.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.HexTile.Reports;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.HexTile.Util;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Reports;
using HappyBananaStudio.OurAshesTactics.Pathing.Object.Impl;
using System.Collections.Generic;
using System.Diagnostics;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Pathing.Finder.Impl
{
    /// <summary>
    /// Todo
    /// </summary>
    public class PathFinderFire
    : PathFinderAbstract
    {
        #region Private Fields

        // Provide logging capability
        private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

        #endregion Private Fields

        #region Public Constructors

        public PathFinderFire(CubeCoordinates cubeCoordinatesStart)
            : base(cubeCoordinatesStart)
        {
        }

        #endregion Public Constructors

        #region Public Methods

        public override void BeginPathFinding()
        {
            HashSet<CubeCoordinates> allCubeCoordinatesEndSet = HexTileObjectFinderUtil.GetTileCoordinatesSet();
            HashSet<CubeCoordinates> validCubeCoordinatesEndSet = new HashSet<CubeCoordinates>();
            foreach (CubeCoordinates cubeCoordinates in allCubeCoordinatesEndSet)
            {
                // Check if the cubeCoordinates is not the starting one
                if (!this.cubeCoordinatesStart.Equals(cubeCoordinates))
                {
                    IHexTileObject tileObject = HexTileObjectFinderUtil.FindHexTileObjectFrom(cubeCoordinates);
                    if (tileObject != null)
                    {
                        HexTileInformationReport hexTileInformationReport = tileObject.GetHexTileInformationReport();
                        if (hexTileInformationReport != null)
                        {
                            TalonIdentificationReport talonIdentificationReport = hexTileInformationReport.GetTalonIdentificationReport();
                            if (talonIdentificationReport != null)
                            {
                                validCubeCoordinatesEndSet.Add(cubeCoordinates);
                            }
                        }
                    }
                }
            }

            foreach (CubeCoordinates cubeCoordinates in validCubeCoordinatesEndSet)
            {
                List<CubeCoordinates> straightLinePath = this.PathFindFor(this.cubeCoordinatesStart, cubeCoordinates);
                logger.Debug("Start=?, End=?, straightLinePath=[?]", this.cubeCoordinatesStart, cubeCoordinates, string.Join(",", straightLinePath));
                this.pathObjectDictionary[cubeCoordinates] = new PathObjectFire(straightLinePath);
            }
        }

        #endregion Public Methods

        #region Private Methods

        private CubeCoordinates GetNextCubeCoordinates(int pathIndex, int distance, CubeCoordinates cubeCoordinatesEnd)
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
                    ? HexTileObjectFinderUtil.FindHexTileObjectFireCostFrom(new CubeCoordinates(newX, roundY, roundZ))
                    : -1;
                int newYFireCost = (updateY && roundX + newY + roundZ == 0)
                    ? HexTileObjectFinderUtil.FindHexTileObjectFireCostFrom(new CubeCoordinates(roundX, newY, roundZ))
                    : -1;
                int newZFireCost = (updateZ && roundX + roundY + newZ == 0)
                    ? HexTileObjectFinderUtil.FindHexTileObjectFireCostFrom(new CubeCoordinates(roundX, roundY, newZ))
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
            return (roundX + roundY + roundZ == 0)
                ? new CubeCoordinates(roundX, roundY, roundZ)
                : null;
        }

        private float Lerp(int a, int b, float t)
        {
            return a + (b - a) * t;
        }

        private List<CubeCoordinates> PathFindFor(CubeCoordinates cubeCoordinatesStart, CubeCoordinates cubeCoordinatesEnd)
        {
            int distance = CubeCoordinatesCommonUtil.GetCubeCoordinatesDistanceFrom(cubeCoordinatesStart, cubeCoordinatesEnd);
            List<CubeCoordinates> cubeCoordinatesList = new List<CubeCoordinates>();
            for (int i = 0; i < distance + 1; ++i)
            {
                cubeCoordinatesList.Add(this.GetNextCubeCoordinates(i, distance, cubeCoordinatesEnd));
            }
            return cubeCoordinatesList;
        }

        #endregion Private Methods
    }
}