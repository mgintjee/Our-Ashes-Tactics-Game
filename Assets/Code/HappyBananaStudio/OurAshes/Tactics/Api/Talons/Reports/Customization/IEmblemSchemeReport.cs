namespace HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Customization
{
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Schemes.Emblem;

    /// <summary>
    /// Todo
    /// </summary>
    public interface IEmblemSchemeReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        EmblemSpriteIdEnum GetBackgroundId();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        EmblemSpriteIdEnum GetForegroundId();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        EmblemSpriteIdEnum GetIconId();
    }
}