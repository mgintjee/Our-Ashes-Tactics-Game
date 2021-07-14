using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Scores.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Utils.Strings;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Scores.Constructions.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Commons.Scores.Constructions.Implementaions
{
    /// <summary>
    /// Score Model Construcion Implementation
    /// </summary>
    public struct ScoreModelConstruction : IScoreModelConstruction
    {
        // Todo
        private readonly ScoreType _scoreType;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="scoreType"></param>
        private ScoreModelConstruction(ScoreType scoreType)
        {
            _scoreType = scoreType;
        }

        /// <inheritdoc/>
        ScoreType IScoreModelConstruction.GetScoreType()
        {
            return _scoreType;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Todo
            /// </summary>
            public interface IBuilder : IBuilder<IScoreModelConstruction>
            {
                IBuilder SetScoreType(ScoreType scoreType);
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
            private class InternalBuilder : AbstractBuilder<IScoreModelConstruction>, IBuilder
            {
                // Todo
                private ScoreType _scoreType = ScoreType.None;

                /// <inheritdoc/>
                IBuilder IBuilder.SetScoreType(ScoreType scoreType)
                {
                    _scoreType = scoreType;
                    return this;
                }

                /// <inheritdoc/>
                protected override IScoreModelConstruction BuildObj()
                {
                    return new ScoreModelConstruction(_scoreType);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, _scoreType);
                }
            }
        }
    }
}