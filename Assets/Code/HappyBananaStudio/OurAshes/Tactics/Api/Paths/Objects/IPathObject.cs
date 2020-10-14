
namespace HappyBananaStudio.OurAshes.Tactics.Api.Paths.Objects
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Coordinates.Objects.Cube;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public interface IPathObject
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ICubeCoordinates GetCubeCoordinatesEnd();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ICubeCoordinates GetCubeCoordinatesStart();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IList<ICubeCoordinates> GetCubeCoordinatesStepList();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        int GetPathObjectCost();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        int GetPathObjectLength();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        bool IsValid();
    }
}
