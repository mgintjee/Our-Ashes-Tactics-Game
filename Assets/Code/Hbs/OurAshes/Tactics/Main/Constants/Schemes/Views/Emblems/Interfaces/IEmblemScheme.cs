using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Views.Schemes.Emblems.IDs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Views.Sprites.IDs;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Constants.Schemes.Views.Emblems.Interfaces
{
    /// <summary>
    /// Emblem Scheme Interface
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