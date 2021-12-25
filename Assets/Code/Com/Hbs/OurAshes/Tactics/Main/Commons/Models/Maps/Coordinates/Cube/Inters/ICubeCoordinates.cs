using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Maps.Coordinates.Cube.Inters
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