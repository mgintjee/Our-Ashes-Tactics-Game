using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Colors.IDs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Schemes.Patterns.IDs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Constants.Schemes.Views.Patterns.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Constants.Schemes.Views.Patterns.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Constants.Schemes.Views.Patterns.Managers
{
    /// <summary>
    /// Pattern Scheme Manager to host the Pattern Scheme Implementations
    /// </summary>
    public static class PatternSchemeManager
    {
        // Todo
        private static readonly ISet<IPatternScheme> PatternSchemes =
            new HashSet<IPatternScheme>()
            {
                PatternScheme.Builder.Get()
                    .SetPatternSchemeID(PatternSchemeID.Alpha)
                    .SetPrimaryColorID(ColorID.Blue)
                    .SetSecondaryColorID(ColorID.Blue)
                    .SetTertiaryColorID(ColorID.Blue)
                    .Build(),
                PatternScheme.Builder.Get()
                    .SetPatternSchemeID(PatternSchemeID.Bravo)
                    .SetPrimaryColorID(ColorID.Red)
                    .SetSecondaryColorID(ColorID.Red)
                    .SetTertiaryColorID(ColorID.Red)
                    .Build(),
                PatternScheme.Builder.Get()
                    .SetPatternSchemeID(PatternSchemeID.Charlie)
                    .SetPrimaryColorID(ColorID.DarkGreen)
                    .SetSecondaryColorID(ColorID.DarkGreen)
                    .SetTertiaryColorID(ColorID.DarkGreen)
                    .Build(),
            };

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="patternSchemeID"></param>
        /// <returns></returns>
        public static Optional<IPatternScheme> GetScheme(PatternSchemeID patternSchemeID)
        {
            foreach (IPatternScheme scheme in PatternSchemes)
            {
                if (patternSchemeID == scheme.GetPatternSchemeID())
                {
                    return Optional<IPatternScheme>.Of(scheme);
                }
            }
            return Optional<IPatternScheme>.Empty();
        }
    }
}