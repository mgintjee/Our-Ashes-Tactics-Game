using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Maps.Coordinates.Offset.Types;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Maps.Coordinates.Offset.Interfaces
{
    /// <summary>
    /// Offset Coordinates Interface
    /// </summary>
    public interface IOffsetCoordinates
    {
        int GetCol();

        OffsetCoordinateType GetOffsetCoordinateType();

        int GetRow();
    }
}