/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Coordinates;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Maps.Game
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IGameMapConstructionReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        HashSet<ICubeCoordinates> GetCubeCoordinatesSet();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        bool GetIsGameMapMirrored();
    }
}