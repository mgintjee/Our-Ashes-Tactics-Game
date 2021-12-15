using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Phalanxes.CallSigns;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Scores.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Reports.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Utils.Strings;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Scores.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Tallies.Inters;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Scores.Impls
{
    /// <summary>
    /// Score Report Impl
    /// </summary>
    public class ScoreReport : AbstractReport, IScoreReport
    {
        // Todo
        private readonly ISet<PhalanxCallSign> _phalanxCallSigns;

        // Todo
        private readonly ScoreType _scoreType;

        // Todo
        private readonly ISet<IScoreModelTally> _scoreTallies;

        // Todo
        private readonly bool _isScoreReached;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="scoreType">     </param>
        /// <param name="scoreTallies">  </param>
        /// <param name="isScoreReached"></param>
        private ScoreReport(ScoreType scoreType, ISet<IScoreModelTally> scoreTallies, bool isScoreReached)
        {
            _phalanxCallSigns = new HashSet<PhalanxCallSign>();
            foreach (IScoreModelTally scoreTally in scoreTallies)
            {
                _phalanxCallSigns.Add(scoreTally.GetPhalanxCallSign());
            }
            _scoreType = scoreType;
            _scoreTallies = scoreTallies;
            _isScoreReached = isScoreReached;
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
        Optional<IScoreModelTally> IScoreReport.GetTallyReport(PhalanxCallSign phalanxCallSign)
        {
            foreach (IScoreModelTally scoreTally in _scoreTallies)
            {
                if (scoreTally.GetPhalanxCallSign() == phalanxCallSign)
                {
                    return Optional<IScoreModelTally>.Of(scoreTally);
                }
            }

            return Optional<IScoreModelTally>.Empty();
        }

        /// <inheritdoc/>
        bool IScoreReport.IsScoreReached()
        {
            return _isScoreReached;
        }

        /// <inheritdoc/>
        protected override string GetContent()
        {
            return string.Format("{0}, _isScoreReached={1}, {2}",
                StringUtils.Format(_scoreType), _isScoreReached,
                StringUtils.FormatCollection(_scoreTallies));
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private ScoreType _scoreType = ScoreType.None;

            // Todo
            private ISet<IScoreModelTally> _scoreTallies = new HashSet<IScoreModelTally>();

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
            public Builder SetScoreTallies(ISet<IScoreModelTally> scoreTallies)
            {
                if (scoreTallies != null)
                {
                    _scoreTallies = new HashSet<IScoreModelTally>(scoreTallies);
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
                    argumentExceptionSet.Add("Set: " + typeof(IScoreModelTally).Name + " cannot be null.");
                }
                return argumentExceptionSet;
            }
        }
    }
}