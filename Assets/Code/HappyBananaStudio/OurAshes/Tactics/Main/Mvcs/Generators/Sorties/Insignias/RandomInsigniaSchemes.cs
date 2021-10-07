﻿using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Utils.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Views.Insignias.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Views.Insignias.Interfaces;
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
        public static IInsigniaReport Generate(Random random)
        {
            return InsigniaReport.Builder.Get()
                .SetEmblemSchemeID(RandomEnums.GenerateRandomEnum<EmblemSchemeID>(random))
                .SetPatternSchemeID(RandomEnums.GenerateRandomEnum<PatternSchemeID>(random))
                .Build();
        }
    }
}