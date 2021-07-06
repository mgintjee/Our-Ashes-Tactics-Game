using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Phalanxes.CallSigns;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Utils.Strings;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Scores.Tallies.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Scores.Tallies.Implementations
{
    /// <summary>
    /// Score Tally Implementation
    /// </summary>
    public class ScoreTally
        : IScoreTally
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
        private ScoreTally(PhalanxCallSign callSign, float score)
        {
            _callSign = callSign;
            _score = score;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: {1}, _score={2}",
                this.GetType().Name,
                StringUtils.Format(_callSign),
                _score);
        }

        /// <inheritdoc/>
        PhalanxCallSign IScoreTally.GetPhalanxCallSign()
        {
            return _callSign;
        }

        /// <inheritdoc/>
        float IScoreTally.GetScore()
        {
            return _score;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private PhalanxCallSign _callSign;

            // Todo
            private float _score;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IScoreTally Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new report
                    return new ScoreTally(_callSign, _score);
                }
                throw ExceptionUtil.Arguments.Build("Unable to construct {}. Invalid Parameters. {}",
                    this.GetType(), string.Join("\n", invalidReasons));
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="callSign"></param>
            public Builder SetCallSign(PhalanxCallSign callSign)
            {
                _callSign = callSign;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="gearReport"></param>
            public Builder SetScore(float score)
            {
                _score = score;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            private ISet<string> IsInvalid()
            {
                // Default an empty Set: String
                ISet<string> argumentExceptionSet = new HashSet<string>();
                // Check that _callSign has been set
                if (_callSign == PhalanxCallSign.None)
                {
                    argumentExceptionSet.Add(typeof(PhalanxCallSign).Name + " cannot be null.");
                }
                // Check that _gearReport has been set
                if (_score < 0 || _score > 100f)
                {
                    argumentExceptionSet.Add("_score=" + _score + " cannot be outside of [0,100].");
                }
                return argumentExceptionSet;
            }
        }
    }
}