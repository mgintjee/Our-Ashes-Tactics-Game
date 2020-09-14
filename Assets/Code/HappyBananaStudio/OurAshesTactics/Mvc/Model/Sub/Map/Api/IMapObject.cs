/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Mvc.Coordinates.Cube;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.HexTile.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Map.Reports;
using System.Collections.Generic;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Map.Api
{
    /// <summary>
    /// Map Object Api
    /// </summary>
    public interface IMapObject
    {
        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        Dictionary<CubeCoordinates, IHexTileObject> GetCubeCoordinatesHexTileObjectDictionary();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        HashSet<CubeCoordinates> GetCubeCoordinatesSet();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        MapConstructionReport GetMapConstructionReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        MapInformationReport GetMapInformationReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        MapScript GetMapScript();

        #endregion Public Methods
    }
}