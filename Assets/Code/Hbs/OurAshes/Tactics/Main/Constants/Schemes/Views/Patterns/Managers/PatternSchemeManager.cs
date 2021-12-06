using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Views.Colors.IDs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Views.Schemes.Patterns.IDs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Constants.Schemes.Views.Patterns.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Constants.Schemes.Views.Patterns.Inters;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Constants.Schemes.Views.Patterns.Managers
{
    /// <summary>
    /// Pattern Scheme Manager to host the Pattern Scheme Impls
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