
namespace HappyBananaStudio.OurAshes.Tactics.Api.Talons.Objects
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Coordinates.Objects.Cube;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Actions.Orders;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Attributes;
    using System.Collections.Generic;

    /// <summary>
    /// Movable Object Api
    /// </summary>
    public interface IMovableObject
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IMovableAttributesReport GetMovableAttributesReport();

        /// <summary>
        /// Todo
        /// </summary>
        void ResetForNewTurn();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ISet<ITalonActionOrderReport> GetTalonActionOrderReportSet(ICubeCoordinates cubeCoordinates);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="actionCost"></param>
        /// <param name="moveCost"></param>
        void InputActionCosts(int actionCost, int moveCost);
    }
}
