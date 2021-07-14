using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Scores.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Utils.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Scores.Constructions.Implementaions;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Scores.Constructions.Interfaces;
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
        public static IScoreModelConstruction Generate(Random random)
        {
            return new ScoreModelConstruction.Builder()
                .SetScoreType(RandomEnums.GenerateRandomEnum<ScoreType>(random))
                .Build();
        }
    }
}