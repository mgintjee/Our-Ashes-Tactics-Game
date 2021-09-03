using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Colors.IDs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Sprites.IDs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Canvases.UIs.Interfaces.Basics.Images
{
    /// <summary>
    /// Basic Widget Image Interface
    /// </summary>
    public interface IBasicImage : IWidget
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
        /// <param name="transparency"></param>
        void UpdateTransparency(float transparency);
    }
}