using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Schemes.Emblems.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Schemes.Patterns.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Schemes.Insignias.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Schemes.Insignias.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Randoms.Commons.Enums;
using System;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Randoms.Sorties.Insignias
{
    /// <summary>
    /// Random Insignia Schemes
    /// </summary>
    public static class RandomInsigniaSchemes
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="random"></param>
        /// <returns></returns>
        public static IInsigniaScheme Generate(Random random)
        {
            return new InsigniaScheme.Builder()
                .SetEmblemSchemeID(RandomEnums.GenerateRandomEnum<EmblemSchemeID>(random))
                .SetPatternSchemeID(RandomEnums.GenerateRandomEnum<PatternSchemeID>(random))
                .Build();
        }
    }
}