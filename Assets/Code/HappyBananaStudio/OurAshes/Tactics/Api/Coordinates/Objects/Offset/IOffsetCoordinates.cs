/// <summary>
/// Company: HappyBananaStudio
/// Author: Matthew Gintjee
/// </summary>
/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

namespace HappyBananaStudio.OurAshes.Tactics.Api.Coordinates.Objects.Offset
{
    using HappyBananaStudio.OurAshes.Tactics.Common.Constants.Coordinates.Enums;

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
