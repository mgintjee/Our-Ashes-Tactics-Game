/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Mvc.Coordinates.Cube;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Coordinates.Util
{
    public static class CubeCoordinatesCommonUtil
    {
        #region Private Fields

        // Provide logging capability
        private static readonly Common.Logging.Logger logger = new Common.Logging.Logger(new StackFrame().GetMethod().DeclaringType);

        #endregion Private Fields

        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates"></param>
        /// <param name="mapRadius">      </param>
        /// <returns></returns>
        public static HashSet<CubeCoordinates> GenerateNeighborCubeCoordinatesSet(CubeCoordinates cubeCoordinates, int mapRadius)
        {
            HashSet<CubeCoordinates> validNeighborCubeCoordinatesSet = new HashSet<CubeCoordinates>();
            HashSet<CubeCoordinates> possibleNeighborCubeCoordinatesSet = new HashSet<CubeCoordinates>
            {
                new CubeCoordinates(cubeCoordinates.GetX() + 1, cubeCoordinates.GetY(), cubeCoordinates.GetZ() - 1),
                new CubeCoordinates(cubeCoordinates.GetX() + 1, cubeCoordinates.GetY() - 1, cubeCoordinates.GetZ()),
                new CubeCoordinates(cubeCoordinates.GetX(), cubeCoordinates.GetY() - 1, cubeCoordinates.GetZ() + 1),
                new CubeCoordinates(cubeCoordinates.GetX() - 1, cubeCoordinates.GetY(), cubeCoordinates.GetZ() + 1),
                new CubeCoordinates(cubeCoordinates.GetX() - 1, cubeCoordinates.GetY() + 1, cubeCoordinates.GetZ())
            };

            foreach (CubeCoordinates cubeCoordinatesToCheck in possibleNeighborCubeCoordinatesSet)
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
        /// <param name="cubeCoordinatesStart"></param>
        /// <param name="cubeCoordinatesEnd">  </param>
        /// <returns></returns>
        public static int GetCubeCoordinatesDistanceFrom(CubeCoordinates cubeCoordinatesStart, CubeCoordinates cubeCoordinatesEnd)
        {
            return Mathf.Max(Mathf.Abs(cubeCoordinatesStart.GetX() - cubeCoordinatesEnd.GetX()),
                Mathf.Abs(cubeCoordinatesStart.GetY() - cubeCoordinatesEnd.GetY()),
                Mathf.Abs(cubeCoordinatesStart.GetZ() - cubeCoordinatesEnd.GetZ()));
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates"></param>
        /// <returns></returns>
        public static int GetCubeCoordinatesDistanceFromCenter(CubeCoordinates cubeCoordinates)
        {
            return GetCubeCoordinatesDistanceFrom(cubeCoordinates, new CubeCoordinates(0, 0, 0));
        }

        #endregion Public Methods
    }
}