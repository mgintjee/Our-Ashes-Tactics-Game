using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Constructions.Scores.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Scores.Types.Enums;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Constructions.Scores.Implementaions
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct ScoreConstruction
        : IScoreConstruction
    {
        // Todo
        private readonly ScoreType _scoreType;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="scoreType"></param>
        private ScoreConstruction(ScoreType scoreType)
        {
            _scoreType = scoreType;
        }

        /// <inheritdoc/>
        ScoreType IScoreConstruction.GetScoreType()
        {
            return _scoreType;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private ScoreType _scoreType = ScoreType.None;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IScoreConstruction Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new construction
                    return new ScoreConstruction(_scoreType);
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

                return argumentExceptionSet;
            }
        }
    }
}