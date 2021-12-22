using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Schemes.Patterns.IDs;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Constants.Schemes.Views.Patterns.Inters
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IPatternScheme
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        PatternSchemeID GetPatternSchemeID();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ColorID GetPrimaryColorID();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ColorID GetSecondaryColorID();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ColorID GetTertiaryColorID();
    }
}