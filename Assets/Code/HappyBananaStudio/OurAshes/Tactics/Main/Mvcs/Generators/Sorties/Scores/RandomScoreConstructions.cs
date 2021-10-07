using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Utils.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Commons.Scores.Constructions.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Commons.Scores.Constructions.Interfaces;
using System;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Generators.Sorties.Scores
{
    /// <summary>
    /// Random Score Constructions
    /// </summary>
    public static class RandomScoreConstructions
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="random"></param>
        /// <returns></returns>
        public static IScoreConstruction Generate(Random random)
        {
            return ScoreConstruction.Builder.Get()
                .SetScoreType(RandomEnums.GenerateRandomEnum<ScoreType>(random))
                .Build();
        }
    }
}