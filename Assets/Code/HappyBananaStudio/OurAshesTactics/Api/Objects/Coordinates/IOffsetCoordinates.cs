/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Enums;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Coordinates
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IOffsetCoordinates
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        int GetCol();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        OffsetCoordinateTypeEnum GetOffsetCoordinateType();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        int GetRow();
    }
}