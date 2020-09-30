/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Coordinates;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Paths.Object;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Action;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Attributes;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Talons.Behaviors
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface ITalonBehaviorMovable
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
        IMovableReport GetMovableAttributesReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        HashSet<IPathObject> GetPathObjectMoveSet();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonActionOrder">
        /// </param>
        void InputTalonActionOrder(ITalonActionOrderReport talonActionOrder);

        /// <summary>
        /// Todo
        /// </summary>
        void ResetTalonAttributeValues();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates">
        /// </param>
        void SetCubeCoodinates(ICubeCoordinates cubeCoordinates);
    }
}