/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using System;

namespace HappyBananaStudio.OurAshesTactics.Cameras
{
    public static class MapRotation
    {
        #region Public Enums

        public enum MapPositionEnum
        {
            North,
            NorthEast,
            SouthEast,
            South,
            SouthWest,
            NorthWest,
            NULL
        }

        #endregion Public Enums

        #region Public Methods

        public static int GetX(this MapPositionEnum mapPosition)
        {
            int xVal;
            switch (mapPosition)
            {
                case MapPositionEnum.North:
                case MapPositionEnum.South:
                    xVal = 0;
                    break;

                case MapPositionEnum.NorthWest:
                case MapPositionEnum.SouthWest:
                    xVal = -1;
                    break;

                case MapPositionEnum.NorthEast:
                case MapPositionEnum.SouthEast:
                    xVal = 1;
                    break;

                default:
                    throw new ArgumentException("Unable to GetX. Invalid Parameters=" + mapPosition);
            }
            return xVal;
        }

        public static int GetZ(this MapPositionEnum mapPosition)
        {
            int zVal;
            switch (mapPosition)
            {
                case MapPositionEnum.NorthWest:
                case MapPositionEnum.North:
                case MapPositionEnum.NorthEast:
                    zVal = 1;
                    break;

                case MapPositionEnum.SouthEast:
                case MapPositionEnum.South:
                case MapPositionEnum.SouthWest:
                    zVal = -1;
                    break;

                default:
                    throw new ArgumentException("Unable to GetZ. Invalid Parameters=" + mapPosition);
            }
            return zVal;
        }

        #endregion Public Methods
    }
}