namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Widgets.Basics.Images.Api
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Colors.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Sprites.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Widgets.Api;

    /// <summary>
    /// Basic Widget Image Api
    /// </summary>
    public interface IBasicImage
        : IWidget
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="colorId">
        /// </param>
        void UpdateColorId(ColorId colorId);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="spriteId">
        /// </param>
        void UpdateSpriteId(SpriteId spriteId);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="a">
        /// </param>
        void UpdateTransparency(float a);
    }
}