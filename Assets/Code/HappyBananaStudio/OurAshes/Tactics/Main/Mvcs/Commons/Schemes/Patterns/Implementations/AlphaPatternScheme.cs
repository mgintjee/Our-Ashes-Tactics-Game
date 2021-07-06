using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Colors.IDs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Schemes.Patterns.IDs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Schemes.Patterns.Implementations.Abstracts;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Schemes.Patterns.Implementations
{
    /// <summary>
    /// Alpha Pattern Scheme Implementation
    /// </summary>
    public class AlphaPatternScheme
        : AbstractPatternScheme
    {
        /// <summary>
        /// Todo
        /// </summary>
        public AlphaPatternScheme()
        {
            this.patternSchemeID = PatternSchemeID.Alpha;
            this.primary = ColorID.Aqua;
            this.secondary = ColorID.Coral;
            this.tertiary = ColorID.WhiteSmoke;
        }
    }
}