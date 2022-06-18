using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Sprites.IDs;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters
{
    /// <summary>
    /// Image Widget Interface
    /// </summary>
    public interface IImageWidget
        : ICanvasWidget
    {
        void SetSpriteID(SpriteID spriteID);

        void SetColorID(ColorID colorID);

        void SetAlpha(float transparency);
    }
}