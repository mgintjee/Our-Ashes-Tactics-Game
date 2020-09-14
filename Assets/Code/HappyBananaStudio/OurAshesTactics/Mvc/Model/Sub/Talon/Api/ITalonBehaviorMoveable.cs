/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Mvc.Coordinates.Cube;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Reports;
using HappyBananaStudio.OurAshesTactics.Pathing.Object.Api;
using System.Collections.Generic;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Api
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface ITalonBehaviorMoveable
    {
        #region Public Methods
        /// <summary>
        /// Todo
        /// </summary>
        void BeginPathFinding();
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        int GetCurrentMovePoints();
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        int GetCurrentOrderPoints();
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        int GetCurrentTurnPoints();
/// <summary>
/// Todo
/// </summary>
/// <returns></returns>
        int GetMaximumMovePoints();
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        int GetMaximumOrderPoints();
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        int GetMaximumTurnPoints();
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        HashSet<IPathObject> GetPathObjectMoveSet();
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonActionOrder"></param>
        void InputTalonActionOrder(TalonActionOrderReport talonActionOrder);
        /// <summary>
        /// Todo
        /// </summary>
        void ResetTalonAttributeValues();
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates"></param>
        void SetCubeCoodinates(CubeCoordinates cubeCoordinates);

        #endregion Public Methods
    }
}