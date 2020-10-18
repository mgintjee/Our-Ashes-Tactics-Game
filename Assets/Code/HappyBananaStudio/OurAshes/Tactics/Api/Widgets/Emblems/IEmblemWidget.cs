namespace HappyBananaStudio.OurAshes.Tactics.Api.Emblems.Widgets.Emblems
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Unity.Scripts;
    using HappyBananaStudio.OurAshes.Tactics.Api.Widgets;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Schemes.Color;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Schemes.Emblem;

    /// <summary>
    /// Todo
    /// </summary>
    public interface IEmblemWidget
        : IWidget
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="transparency">
        /// </param>
        void UpdateTransparency(float transparency);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="emblemForegroundId">
        /// </param>
        void UpdateForegroundSprite(EmblemForegroundIdEnum emblemForegroundId);

        /// <summary>
        /// </summary>
        /// <param name="emblemIconId">
        /// </param>
        void UpdateIconSprite(EmblemIconIdEnum emblemIconId);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="color">
        /// </param>
        void UpdateBackgroundColor(ColorIdEnum color);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="color">
        /// </param>
        void UpdateForegroundColor(ColorIdEnum color);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="color">
        /// </param>
        void UpdateIconColor(ColorIdEnum color);
    }
}
