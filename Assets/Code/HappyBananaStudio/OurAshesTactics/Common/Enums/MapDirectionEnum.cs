/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using System;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Enums
{
    /// <summary>
    /// Todo
    /// </summary>
    public static class MapRotation
    {
        /// <summary>
        /// Todo
        /// </summary>
        public enum MapDirectionEnum
        {
            North,
            NorthEast,
            SouthEast,
            South,
            SouthWest,
            NorthWest,
            NULL
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mapPosition">
        /// </param>
        /// <returns>
        /// </returns>
        public static int GetX(this MapDirectionEnum mapPosition)
        {
            int xVal;
            switch (mapPosition)
            {
                case MapDirectionEnum.North:
                case MapDirectionEnum.South:
                    xVal = 0;
                    break;

                case MapDirectionEnum.NorthWest:
                case MapDirectionEnum.SouthWest:
                    xVal = -1;
                    break;

                case MapDirectionEnum.NorthEast:
                case MapDirectionEnum.SouthEast:
                    xVal = 1;
                    break;

                default:
                    throw new ArgumentException("Unable to GetX. Invalid Parameters=" + mapPosition);
            }
            return xVal;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mapPosition">
        /// </param>
        /// <returns>
        /// </returns>
        public static int GetZ(this MapDirectionEnum mapPosition)
        {
            int zVal;
            switch (mapPosition)
            {
                case MapDirectionEnum.NorthWest:
                case MapDirectionEnum.North:
                case MapDirectionEnum.NorthEast:
                    zVal = 1;
                    break;

                case MapDirectionEnum.SouthEast:
                case MapDirectionEnum.South:
                case MapDirectionEnum.SouthWest:
                    zVal = -1;
                    break;

                default:
                    throw new ArgumentException("Unable to GetZ. Invalid Parameters=" + mapPosition);
            }
            return zVal;
        }
    }
}