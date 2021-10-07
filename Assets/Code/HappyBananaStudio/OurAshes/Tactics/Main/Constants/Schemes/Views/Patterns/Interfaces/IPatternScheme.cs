namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Constants.Schemes.Views.Patterns.Interfaces
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