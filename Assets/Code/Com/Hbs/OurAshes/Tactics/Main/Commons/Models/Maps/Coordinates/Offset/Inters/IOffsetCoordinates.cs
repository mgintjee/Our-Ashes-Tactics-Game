using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Maps.Coordinates.Offset.Types;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Maps.Coordinates.Offset.Inters
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