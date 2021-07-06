using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Schemes.Emblems.IDs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Sprites.IDs;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Schemes.Emblems.Interfaces
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IEmblemScheme
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        EmblemSchemeID GetEmblemSchemeID();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        SpriteID GetBackgroundID();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        SpriteID GetForegroundID();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        SpriteID GetIconID();
    }
}