using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Views.Colors.IDs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Views.Schemes.Patterns.IDs;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Constants.Schemes.Views.Patterns.Interfaces
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