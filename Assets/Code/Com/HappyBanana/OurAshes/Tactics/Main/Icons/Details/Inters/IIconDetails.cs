using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Sprites.IDs;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Icons.Details.Inters
{
    public interface IIconDetails
    {
        SpriteID GetPrimarySpriteID();

        SpriteID GetSecondarySpriteID();

        SpriteID GetTertiarySpriteID();
    }
}