using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Tiles.Coords.Offsets.Types;
using System.Numerics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Tiles.Coords.Offsets.Inters
{
    /// <summary>
    /// Offset Coordinates Interface
    /// </summary>
    public interface IOffsetCoords
    {
        Vector2 GetVector2();

        OffsetCoordsType GetOffsetCoordsType();
    }
}