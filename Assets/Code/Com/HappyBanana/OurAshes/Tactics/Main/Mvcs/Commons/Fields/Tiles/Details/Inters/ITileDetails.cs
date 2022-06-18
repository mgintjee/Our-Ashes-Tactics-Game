using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Tiles.Types;
using System.Numerics;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Tiles.Details.Inters
{
    public interface ITileDetails
    {
        Vector3 GetVector3();

        TileType GetTileType();
    }
}