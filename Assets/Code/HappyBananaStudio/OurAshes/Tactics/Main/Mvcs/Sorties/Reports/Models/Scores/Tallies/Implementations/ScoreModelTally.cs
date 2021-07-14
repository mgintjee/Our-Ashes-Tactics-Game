﻿using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Phalanxes.CallSigns;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Reports.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Utils.Strings;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Scores.Tallies.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Scores.Tallies.Implementations
{
    /// <summary>
    /// Score Model Tally Implementation
    /// </summary>
    public class ScoreModelTally : AbstractReport, IScoreModelTally
    {
        // Todo
        private readonly PhalanxCallSign _callSign;

        // Todo
        private readonly float _score;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="callSign"></param>
        /// <param name="score">   </param>
        private ScoreModelTally(PhalanxCallSign callSign, float score)
        {
            _callSign = callSign;
            _score = score;
        }

        /// <inheritdoc/>
        protected override string GetContent()
        {
            return string.Format("{0}, {1}", StringUtils.Format(_callSign), _score);
        }

        /// <inheritdoc/>
        PhalanxCallSign IScoreModelTally.GetPhalanxCallSign()
        {
            return _callSign;
        }

        /// <inheritdoc/>
        float IScoreModelTally.GetScore()
        {
            return _score;
        }


        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Todo
            /// </summary>
            public interface IBuilder : IBuilder<IScoreModelTally>
            {
                IBuilder SetPhalanxCallSign(PhalanxCallSign phalanxCallSign);

                IBuilder SetScore(float score);
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public static IBuilder Get()
            {
                return new InternalBuilder();
            }

            /// <summary>
            /// Todo
            /// </summary>
            private class InternalBuilder : AbstractBuilder<IScoreModelTally>, IBuilder
            {
                // Todo
                private PhalanxCallSign _phalanxCallSign;

                // Todo
                private float _score;

                /// <inheritdoc/>
                protected override IScoreModelTally BuildObj()
                {
                    return new ScoreModelTally(_phalanxCallSign, _score);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, _score);
                    this.Validate(invalidReasons, _phalanxCallSign);
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetPhalanxCallSign(PhalanxCallSign phalanxCallSign)
                {
                    _phalanxCallSign = phalanxCallSign;
                    return this;
                }
                /// <inheritdoc/>

                IBuilder IBuilder.SetScore(float score)
                {
                    _score = score;
                    return this;
                }
            }
        }
    }
}