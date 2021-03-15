using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Cube.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Cube.Impl;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Cube.Utils
{
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
                new CubeCoordinates(0, 0, 0));
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
                return new CubeCoordinates(
                    cubeCoordinates.GetX() * -1,
                    cubeCoordinates.GetY() * -1,
                    cubeCoordinates.GetZ() * -1);
            }
            throw ExceptionUtil.Arguments.Build("Unable to ?. Invalid Parameters. ? is null.",
                new StackFrame().GetMethod().Name, typeof(ICubeCoordinates));
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates"></param>
        /// <returns></returns>
        public static ISet<ICubeCoordinates> GetPossibleNeighborCubeCoordinatesSet(ICubeCoordinates cubeCoordinates)
        {
            return new HashSet<ICubeCoordinates>
            {
                new CubeCoordinates(
                    cubeCoordinates.GetX() + 1,
                    cubeCoordinates.GetY(),
                    cubeCoordinates.GetZ() - 1),
                new CubeCoordinates(
                    cubeCoordinates.GetX() + 1,
                    cubeCoordinates.GetY() - 1,
                    cubeCoordinates.GetZ()),
                new CubeCoordinates(
                    cubeCoordinates.GetX(),
                    cubeCoordinates.GetY() + 1,
                    cubeCoordinates.GetZ() - 1),
                new CubeCoordinates(
                    cubeCoordinates.GetX(),
                    cubeCoordinates.GetY() - 1,
                    cubeCoordinates.GetZ() + 1),
                new CubeCoordinates(
                    cubeCoordinates.GetX() - 1,
                    cubeCoordinates.GetY(),
                    cubeCoordinates.GetZ() + 1),
                new CubeCoordinates(
                    cubeCoordinates.GetX() - 1,
                    cubeCoordinates.GetY() + 1,
                    cubeCoordinates.GetZ())
            };
        }
    }
}