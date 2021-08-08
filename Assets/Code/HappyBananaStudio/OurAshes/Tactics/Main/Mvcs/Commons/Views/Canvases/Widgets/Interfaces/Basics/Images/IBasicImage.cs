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
        /// <param name="colorID"></param>
        void UpdateColorID(ColorID colorID);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="spriteID"></param>
        void UpdateSpriteID(SpriteID spriteID);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="a"></param>
        void UpdateTransparency(float a);
    }
}