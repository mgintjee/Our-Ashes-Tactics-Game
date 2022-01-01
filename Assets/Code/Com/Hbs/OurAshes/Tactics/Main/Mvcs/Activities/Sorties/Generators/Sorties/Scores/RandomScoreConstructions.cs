using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Scores.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Utils.Enums;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Constrs.Commons.Scores.Constrs.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Constrs.Commons.Scores.Constrs.Inters;
using System;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Generators.Sorties.Scores
{
    /// <summary>
    /// Random Score Constrs
    /// </summary>
    public static class RandomScoreConstrs
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