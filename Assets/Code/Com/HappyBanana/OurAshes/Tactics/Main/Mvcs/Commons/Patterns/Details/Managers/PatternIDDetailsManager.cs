using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Patterns.Details.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Patterns.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Patterns.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Patterns.Details.Managers
{
    /// <summary>
    /// Todo
    /// </summary>
    public class PatternIDDetailsManager
    {
        private static readonly IDictionary<PatternID, IPatternDetails> PATTERN_ID_DETAILS = Internals.BuildModelIDPatternDetails();

        public static Optional<IPatternDetails> GetDetails(PatternID id)
        {
            return Optional<IPatternDetails>.Of(
                (PATTERN_ID_DETAILS.ContainsKey(id))
                    ? PATTERN_ID_DETAILS[id]
                    : null);
        }

        private class Internals
        {
            public static IDictionary<PatternID, IPatternDetails> BuildModelIDPatternDetails()
            {
                return new Dictionary<PatternID, IPatternDetails>()
                {
                    { PatternID.FactionUO, GetFactionUOPatternDetails() },
                    { PatternID.FactionBT, GetFactionBTPatternDetails() },
                    { PatternID.FactionTT, GetFactionTTPatternDetails() },
                    { PatternID.FactionFL, GetFactionFLPatternDetails() }
                };
            }

            private static IPatternDetails GetFactionBTPatternDetails()
            {
                return PatternDetailsImpl.Builder.Get()
                        .SetPrimaryID(ColorID.Blue)
                        .SetSecondaryID(ColorID.Blue)
                        .SetTertiaryID(ColorID.Blue)
                        .Build();
            }

            private static IPatternDetails GetFactionUOPatternDetails()
            {
                return PatternDetailsImpl.Builder.Get()
                        .SetPrimaryID(ColorID.Blue)
                        .SetSecondaryID(ColorID.Blue)
                        .SetTertiaryID(ColorID.Blue)
                        .Build();
            }

            private static IPatternDetails GetFactionTTPatternDetails()
            {
                return PatternDetailsImpl.Builder.Get()
                        .SetPrimaryID(ColorID.Blue)
                        .SetSecondaryID(ColorID.Blue)
                        .SetTertiaryID(ColorID.Blue)
                        .Build();
            }

            private static IPatternDetails GetFactionFLPatternDetails()
            {
                return PatternDetailsImpl.Builder.Get()
                        .SetPrimaryID(ColorID.SlateGray)
                        .SetSecondaryID(ColorID.Gray)
                        .SetTertiaryID(ColorID.White)
                        .Build();
            }
        }
    }
}