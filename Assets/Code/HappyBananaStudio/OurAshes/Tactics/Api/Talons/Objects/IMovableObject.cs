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
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Attributes;

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
    }
}
