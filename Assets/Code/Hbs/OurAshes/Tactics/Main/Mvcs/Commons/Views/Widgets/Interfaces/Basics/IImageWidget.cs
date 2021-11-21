using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Views.Colors.IDs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Views.Sprites.IDs;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Interfaces.Basics
{
    /// <summary>
    /// Image Widget Interface
    /// </summary>
    public interface IImageWidget : IWidget
    {
        void SetSpriteID(SpriteID spriteID);

        void SetColorID(ColorID colorID);
    }
}