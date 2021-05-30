using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Maps.Coordinates.Offset.Enums;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Maps.Coordinates.Offset.Interfaces
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IOffsetCoordinates
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        int GetCol();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        OffsetCoordinateType GetOffsetCoordinateType();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        int GetRow();
    }
}