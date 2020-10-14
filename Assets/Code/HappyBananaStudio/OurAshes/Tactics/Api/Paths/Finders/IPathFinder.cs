/// <summary>
/// Company: HappyBananaStudio
/// Author: Matthew Gintjee
/// </summary>
/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshes.Tactics.Api.Coordinates.Objects.Cube;
using HappyBananaStudio.OurAshes.Tactics.Api.Paths.Objects;
using System.Collections.Generic;

namespace HappyBananaStudio.OurAshes.Tactics.Api.Paths.Finders
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IPathFinder
    {
        /// <summary>
        /// Todo
        /// </summary>
        void BeginPathFinding();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ISet<ICubeCoordinates> GetCubeCoordiantesEndSet();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinatesEnd">
        /// </param>
        /// <returns>
        /// </returns>
        IPathObject GetPathObjectForCubeCoordinatesEnd(ICubeCoordinates cubeCoordinatesEnd);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IDictionary<ICubeCoordinates, IPathObject> GetPathObjectDictionary();
    }
}
