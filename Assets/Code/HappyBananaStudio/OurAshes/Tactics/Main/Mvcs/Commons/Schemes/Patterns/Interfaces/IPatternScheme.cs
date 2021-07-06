using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Colors.IDs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Schemes.Patterns.IDs;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Schemes.Patterns.Interfaces
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