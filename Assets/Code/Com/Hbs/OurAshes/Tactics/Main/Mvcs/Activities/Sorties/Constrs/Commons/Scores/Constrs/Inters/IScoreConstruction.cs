﻿using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Scores.Types;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Constrs.Commons.Scores.Constrs.Inters
{
    /// <summary>
    /// Score Model Construcion Interface
    /// </summary>
    public interface IScoreConstruction
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ScoreType GetScoreType();
    }
}