using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Schemes.Emblems.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Sprites.IDs;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Constants.Schemes.Views.Emblems.Inters
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