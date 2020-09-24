/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Mvc.Coordinates.Cube;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Reports;
using HappyBananaStudio.OurAshesTactics.Pathing.Object.Api;
using HappyBananaStudio.OurAshesTactics.Talon.Attributes.Reports;
using System.Collections.Generic;

namespace HappyBananaStudio.OurAshesTactics.Talon.Behavior.Api
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface ITalonBehaviorMovable
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
        MovableAttributesReport GetMovableAttributesReport();

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