using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Maps.Coordinates.Cube.Interfaces
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface ICubeCoordinates
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates"></param>
        /// <returns></returns>
        int GetDistanceFrom(ICubeCoordinates cubeCoordinates);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ICubeCoordinates GetNegatedCoordinates();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ISet<ICubeCoordinates> GetNeighbors();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        int GetX();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        int GetY();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        int GetZ();
    }
}