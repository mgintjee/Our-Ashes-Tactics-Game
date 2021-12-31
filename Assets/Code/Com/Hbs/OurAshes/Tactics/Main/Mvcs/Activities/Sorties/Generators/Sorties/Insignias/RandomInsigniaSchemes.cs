using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Utils.Enums;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Schemes.Emblems.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Schemes.Patterns.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Views.Insignias.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Views.Insignias.Inters;
using System;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Generators.Sorties.Insignias
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