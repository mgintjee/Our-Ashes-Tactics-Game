/// <summary>
/// Company: HappyBananaStudio
/// Author: Matthew Gintjee
/// </summary>
/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

namespace HappyBananaStudio.OurAshes.Tactics.Common.Managers.GameObjects
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Coordinates.Objects.Cube;
    using HappyBananaStudio.OurAshes.Tactics.Api.Coordinates.Objects.Offset;
    using HappyBananaStudio.OurAshes.Tactics.Common.Constants.Coordinates.Enums;
    using HappyBananaStudio.OurAshes.Tactics.Common.Constants.HexTiles;
    using HappyBananaStudio.OurAshesTactics.Common.Utils.Coordinates;
    using HappyBananaStudio.OurAshesTactics.Common.Utils.Exceptions;
    using System.Collections.Generic;
    using System.Diagnostics;
    using UnityEngine;

    /// <summary>
    /// Todo
    /// </summary>
    public class HexTileGameObjectManager
    {
        private static IDictionary<ICubeCoordinates, GameObject> cubeCoordinatesGameObjectDictionary =
            new Dictionary<ICubeCoordinates, GameObject>();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates">
        /// </param>
        /// <returns>
        /// </returns>
        public static Vector3 GetHexTileWorldPosition(ICubeCoordinates cubeCoordinates)
        {
            if (cubeCoordinatesGameObjectDictionary.ContainsKey(cubeCoordinates))
            {
                return cubeCoordinatesGameObjectDictionary[cubeCoordinates].transform.position;
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. ?=? is not tracked",
                    new StackFrame().GetMethod().Name, typeof(ICubeCoordinates), cubeCoordinates);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates">
        /// </param>
        private static void UpdateHexTilePositionFor(ICubeCoordinates cubeCoordinates)
        {
            // TODO: Not needed. Just put this in the HexTile Buidlder util
            if (cubeCoordinatesGameObjectDictionary.ContainsKey(cubeCoordinates))
            {
                IOffsetCoordinates offsetCoordinates = CoordinatesConvertorUtil.CubeToOffset(
                    cubeCoordinates, OffsetCoordinateTypeEnum.EVEN_Q);
                float xWorldPosition = offsetCoordinates.GetCol() * HexTileGameObjectConstants.GetOffsetX();
                float yWorldPosition = HexTileGameObjectConstants.GetOffsetY();
                float zWorldPosition = offsetCoordinates.GetRow() * HexTileGameObjectConstants.GetOffsetZ() +
                    (offsetCoordinates.GetCol() & 1) * -HexTileGameObjectConstants.GetOffsetZ() / 2;
                cubeCoordinatesGameObjectDictionary[cubeCoordinates].transform.position = new Vector3(xWorldPosition, yWorldPosition, zWorldPosition);
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. ?=? is not tracked",
                    new StackFrame().GetMethod().Name, typeof(ICubeCoordinates), cubeCoordinates);
            }
        }
    }
}
