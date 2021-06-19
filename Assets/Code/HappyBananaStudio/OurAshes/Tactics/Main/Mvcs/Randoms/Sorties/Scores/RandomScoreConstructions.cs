using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Scores.Types.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Randoms.Commons.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Scores.Constructions.Implementaions;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Scores.Constructions.Interfaces;
using System;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Randoms.Sorties.Scores
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
            return new ScoreConstruction.Builder()
                .SetScoreType(RandomEnums.GenerateRandomEnum<ScoreType>(random))
                .Build();
        }
    }
}