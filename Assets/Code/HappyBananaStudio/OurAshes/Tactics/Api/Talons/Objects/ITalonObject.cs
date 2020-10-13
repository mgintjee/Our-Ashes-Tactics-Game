/// <summary>
/// Company: HappyBananaStudio
/// Author: Matthew Gintjee
/// </summary>
/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

namespace HappyBananaStudio.OurAshes.Tactics.Api.Talons.Objects
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Coordinates.Objects.Cube;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Information;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Turn;

    /// <summary>
    /// Talon Object Api
    /// </summary>
    public interface ITalonObject
    {
        /// <summary>
        /// Todo
        /// </summary>
        void DeactivateTalonObject();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ITalonInformationReport GetTalonInformationReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ITalonTurnReport GetTalonTurnReport();

        /// <summary>
        /// Todo
        /// </summary>
        void ResetForNewTurn();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates">
        /// </param>
        void SetCubeCoordinates(ICubeCoordinates cubeCoordinates);
    }
}
