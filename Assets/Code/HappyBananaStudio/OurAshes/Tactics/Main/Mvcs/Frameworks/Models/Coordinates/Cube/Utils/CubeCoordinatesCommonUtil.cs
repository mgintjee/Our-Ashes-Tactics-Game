namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Coordinates.Cube.Utils
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Coordinates.Cube.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Coordinates.Cube.Impl;
    using HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
    using System.Collections.Generic;
    using System.Diagnostics;
    using UnityEngine;

    /// <summary>
    /// Todo
    /// </summary>
    public static class CubeCoordinatesCommonUtil
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates">
        /// </param>
        /// <param name="mapRadius">
        /// </param>
        /// <returns>
        /// </returns>
        public static ISet<ICubeCoordinates> GenerateNeighborCubeCoordinatesSet(ICubeCoordinates cubeCoordinates, int mapRadius)
        {
            ISet<ICubeCoordinates> validNeighborCubeCoordinatesSet = new HashSet<ICubeCoordinates>();
            ISet<ICubeCoordinates> possibleNeighborCubeCoordinatesSet = GetPossibleNeighborCubeCoordinatesSet(cubeCoordinates);
            foreach (ICubeCoordinates cubeCoordinatesToCheck in possibleNeighborCubeCoordinatesSet)
            {
                int distanceFromCenter = GetCubeCoordinatesDistanceFromCenter(cubeCoordinatesToCheck);
                if (distanceFromCenter <= mapRadius)
                {
                    validNeighborCubeCoordinatesSet.Add(cubeCoordinatesToCheck);
                }
            }
            return validNeighborCubeCoordinatesSet;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinatesStart">
        /// </param>
        /// <param name="cubeCoordinatesEnd">
        /// </param>
        /// <returns>
        /// </returns>
        public static int GetCubeCoordinatesDistanceFrom(ICubeCoordinates cubeCoordinatesStart, ICubeCoordinates cubeCoordinatesEnd)
        {
            return Mathf.Max(Mathf.Abs(cubeCoordinatesStart.GetX() - cubeCoordinatesEnd.GetX()),
                Mathf.Abs(cubeCoordinatesStart.GetY() - cubeCoordinatesEnd.GetY()),
                Mathf.Abs(cubeCoordinatesStart.GetZ() - cubeCoordinatesEnd.GetZ()));
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates">
        /// </param>
        /// <returns>
        /// </returns>
        public static int GetCubeCoordinatesDistanceFromCenter(ICubeCoordinates cubeCoordinates)
        {
            return GetCubeCoordinatesDistanceFrom(cubeCoordinates,
                new CubeCoordinatesImpl.Builder()
                    .SetX(0)
                    .SetY(0)
                    .SetZ(0)
                    .Build());
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates">
        /// </param>
        /// <returns>
        /// </returns>
        public static ICubeCoordinates GetNegatedCubeCoordinates(ICubeCoordinates cubeCoordinates)
        {
            if (cubeCoordinates != null)
            {
                return new CubeCoordinatesImpl.Builder()
                    .SetX(-1 * cubeCoordinates.GetX())
                    .SetY(-1 * cubeCoordinates.GetY())
                    .SetZ(-1 * cubeCoordinates.GetZ())
                    .Build();
            }
            else
            {
                throw ExceptionUtil.Argument.Build("Unable to ?. Invalid Parameters. ? is null.",
                    new StackFrame().GetMethod().Name, typeof(ICubeCoordinates));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates">
        /// </param>
        /// <param name="mapRadius">
        /// </param>
        /// <returns>
        /// </returns>
        public static ISet<ICubeCoordinates> GetPossibleNeighborCubeCoordinatesSet(ICubeCoordinates cubeCoordinates)
        {
            return new HashSet<ICubeCoordinates>
            {
                new CubeCoordinatesImpl.Builder()
                    .SetX(cubeCoordinates.GetX() + 1)
                    .SetY(cubeCoordinates.GetY())
                    .SetZ(cubeCoordinates.GetZ() - 1)
                    .Build(),
                new CubeCoordinatesImpl.Builder()
                    .SetX(cubeCoordinates.GetX() + 1)
                    .SetY(cubeCoordinates.GetY() - 1)
                    .SetZ(cubeCoordinates.GetZ())
                    .Build(),
                new CubeCoordinatesImpl.Builder()
                    .SetX(cubeCoordinates.GetX())
                    .SetY(cubeCoordinates.GetY() + 1)
                    .SetZ(cubeCoordinates.GetZ() - 1)
                    .Build(),
                new CubeCoordinatesImpl.Builder()
                    .SetX(cubeCoordinates.GetX())
                    .SetY(cubeCoordinates.GetY() - 1)
                    .SetZ(cubeCoordinates.GetZ() + 1)
                    .Build(),
                new CubeCoordinatesImpl.Builder()
                    .SetX(cubeCoordinates.GetX() - 1)
                    .SetY(cubeCoordinates.GetY())
                    .SetZ(cubeCoordinates.GetZ() + 1)
                    .Build(),
                new CubeCoordinatesImpl.Builder()
                    .SetX(cubeCoordinates.GetX() - 1)
                    .SetY(cubeCoordinates.GetY() + 1)
                    .SetZ(cubeCoordinates.GetZ())
                    .Build()
            }; ;
        }
    }
}