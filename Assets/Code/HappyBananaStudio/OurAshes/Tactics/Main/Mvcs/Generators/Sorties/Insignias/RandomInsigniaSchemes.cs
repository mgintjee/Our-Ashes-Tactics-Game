using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Schemes.Emblems.IDs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Schemes.Patterns.IDs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Utils.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Schemes.Insignias.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Schemes.Insignias.Interfaces;
using System;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Generators.Sorties.Insignias
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