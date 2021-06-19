using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Phalanxes.CallSigns.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Reports.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Scores.Types.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Utils.Strings;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Scores.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Scores.Tallies.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Scores.Reports.Implementations
{
    /// <summary>
    /// Score Report Implementation
    /// </summary>
    public class ScoreReport
        : AbstractReport, IScoreReport
    {
        // Todo
        private readonly ISet<PhalanxCallSign> _phalanxCallSigns;

        // Todo
        private readonly ScoreType _scoreType;

        // Todo
        private readonly ISet<IScoreTally> _scoreTallies;

        // Todo
        private readonly bool _isScoreReached;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="scoreType">     </param>
        /// <param name="scoreTallies">  </param>
        /// <param name="isScoreReached"></param>
        private ScoreReport(ScoreType scoreType, ISet<IScoreTally> scoreTallies, bool isScoreReached)
        {
            _phalanxCallSigns = new HashSet<PhalanxCallSign>();
            foreach (IScoreTally scoreTally in scoreTallies)
            {
                _phalanxCallSigns.Add(scoreTally.GetPhalanxCallSign());
            }
            _scoreType = scoreType;
            _scoreTallies = scoreTallies;
            _isScoreReached = isScoreReached;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            string scoreTalliesValues = (_scoreTallies.Count != 0)
                ? string.Join(", ", _scoreTallies)
                : "empty";
            return string.Format("{0}: " +
                "\n{1}" +
                "\n{2}" +
                "\nIsScoreReached={3}",
                this.GetType().Name,
                StringUtils.Format(typeof(ScoreType), this._scoreType),
                StringUtils.Format(typeof(IScoreTally), scoreTalliesValues),
                _isScoreReached);
        }

        /// <inheritdoc/>
        ISet<PhalanxCallSign> IScoreReport.GetPhalanxCallSigns()
        {
            return new HashSet<PhalanxCallSign>(_phalanxCallSigns);
        }

        /// <inheritdoc/>
        ScoreType IScoreReport.GetScoreType()
        {
            return _scoreType;
        }

        /// <inheritdoc/>
        Optional<IScoreTally> IScoreReport.GetTallyReport(PhalanxCallSign phalanxCallSign)
        {
            foreach (IScoreTally scoreTally in _scoreTallies)
            {
                if (scoreTally.GetPhalanxCallSign() == phalanxCallSign)
                {
                    return Optional<IScoreTally>.Of(scoreTally);
                }
            }

            return Optional<IScoreTally>.Empty();
        }

        /// <inheritdoc/>
        bool IScoreReport.IsScoreReached()
        {
            return _isScoreReached;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private ScoreType _scoreType = ScoreType.None;

            // Todo
            private ISet<IScoreTally> _scoreTallies = new HashSet<IScoreTally>();

            // Todo
            private bool _isScoreReached = false;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IScoreReport Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new report
                    return new ScoreReport(_scoreType, _scoreTallies, _isScoreReached);
                }
                throw ExceptionUtil.Arguments.Build("Unable to construct {}. Invalid Parameters. {}",
                    this.GetType(), string.Join("\n", invalidReasons));
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="scoreType"></param>
            /// <returns></returns>
            public Builder SetScoreType(ScoreType scoreType)
            {
                _scoreType = scoreType;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="isScoreReached"></param>
            /// <returns></returns>
            public Builder SetIsScoreReached(bool isScoreReached)
            {
                _isScoreReached = isScoreReached;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="scoreTallies"></param>
            /// <returns></returns>
            public Builder SetScoreTallies(ISet<IScoreTally> scoreTallies)
            {
                if (scoreTallies != null)
                {
                    _scoreTallies = new HashSet<IScoreTally>(scoreTallies);
                }
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
                // Check that _scoreType has been set
                if (_scoreType == ScoreType.None)
                {
                    argumentExceptionSet.Add(typeof(ScoreType).Name + " cannot be none.");
                }
                // Check that _scoreTallies has been set
                if (_scoreTallies == null)
                {
                    argumentExceptionSet.Add("Set: " + typeof(IScoreTally).Name + " cannot be null.");
                }
                return argumentExceptionSet;
            }
        }
    }
}