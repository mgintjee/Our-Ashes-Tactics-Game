/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using System;
using System.Diagnostics;
using UnityEngine;

namespace HappyBananaStudio.OurAshesTactics.Cameras
{
    public static class CameraPositionUtil
    {
        #region Private Fields

        private static readonly float CAMERA_DISTANCE = 25;

        // Provide logging capability
        private static readonly Common.Logging.Logger logger = new Common.Logging.Logger(new StackFrame().GetMethod().DeclaringType);

        #endregion Private Fields

        #region Internal Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="zVal"></param>
        /// <param name="xVal"></param>
        /// <returns></returns>
        internal static Vector3 DeterminePositionVector(float zVal, float xVal)
        {
            Vector3 positionVector = Vector3.zero;
            positionVector.y = 2 * CAMERA_DISTANCE;
            if (zVal != 0)
            {
                if (xVal != 0)
                {
                    positionVector.x = CAMERA_DISTANCE * Mathf.Sqrt(3) * xVal;
                    positionVector.z = CAMERA_DISTANCE * zVal;
                }
                else
                {
                    if (zVal > 0)
                    {
                        positionVector.z = 2 * CAMERA_DISTANCE;
                    }
                    else if (zVal < 0)
                    {
                        positionVector.z = -2 * CAMERA_DISTANCE;
                    }
                }
            }
            else
            {
                throw new ArgumentException("Unable to DeterminePositionVector. Invalid parameters.");
            }
            return positionVector;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="zVal"></param>
        /// <param name="xVal"></param>
        /// <returns></returns>
        internal static Vector3 DetermineRotationVector(float zVal, float xVal)
        {
            Vector3 rotationVector = Vector3.zero;
            rotationVector.x = 45;
            if (zVal != 0)
            {
                if (xVal != 0)
                {
                    if (zVal > 0)
                    {
                        rotationVector.y = 240 * xVal;
                    }
                    else if (zVal < 0)
                    {
                        rotationVector.y = 60 * -xVal;
                    }
                }
                else
                {
                    if (zVal > 0)
                    {
                        rotationVector.y = 180;
                    }
                }
            }
            else
            {
                throw new ArgumentException("Unable to DetermineRotationVector. Invalid parameters.");
            }
            return rotationVector;
        }

        #endregion Internal Methods
    }
}