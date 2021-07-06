using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Colors.IDs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Sprites.IDs;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Interfaces.Basics.Images
{
    /// <summary>
    /// Basic Widget Image Interface
    /// </summary>
    public interface IBasicImage
        : IWidget
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="colorId"></param>
        void UpdateColorId(ColorID colorId);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="spriteId"></param>
        void UpdateSpriteId(SpriteID spriteId);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="a"></param>
        void UpdateTransparency(float a);
    }
}