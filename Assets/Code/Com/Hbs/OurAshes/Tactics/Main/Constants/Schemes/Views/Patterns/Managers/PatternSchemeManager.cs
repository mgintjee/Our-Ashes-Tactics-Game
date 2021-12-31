﻿using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Constants.Schemes.Views.Patterns.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Constants.Schemes.Views.Patterns.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Schemes.Patterns.IDs;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Constants.Schemes.Views.Patterns.Managers
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
                    .SetPrimaryColorID(ColorID.White)
                    .SetSecondaryColorID(ColorID.White)
                    .SetTertiaryColorID(ColorID.White)
                    .Build(),
                PatternScheme.Builder.Get()
                    .SetPatternSchemeID(PatternSchemeID.Bravo)
                    .SetPrimaryColorID(ColorID.White)
                    .SetSecondaryColorID(ColorID.White)
                    .SetTertiaryColorID(ColorID.White)
                    .Build(),
                PatternScheme.Builder.Get()
                    .SetPatternSchemeID(PatternSchemeID.Charlie)
                    .SetPrimaryColorID(ColorID.White)
                    .SetSecondaryColorID(ColorID.White)
                    .SetTertiaryColorID(ColorID.White)
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