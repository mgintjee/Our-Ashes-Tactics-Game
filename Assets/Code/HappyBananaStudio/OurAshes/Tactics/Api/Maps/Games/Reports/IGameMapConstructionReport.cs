/// <summary>
/// Company: HappyBananaStudio
/// Author: Matthew Gintjee
/// </summary>
/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

namespace HappyBananaStudio.OurAshes.Tactics.Api.Maps.Games.Reports
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Coordinates.Objects.Cube;
    using System.Collections.Generic;

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
        ISet<ICubeCoordinates> GetCubeCoordinatesSet();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        bool GetIsGameMapMirrored();
    }
}
