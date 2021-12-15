using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Scores.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constrs.Commons.Scores.Constrs.Inters;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constrs.Commons.Scores.Constrs.Impls
{
    /// <summary>
    /// Score Construcion Impl
    /// </summary>
    public struct ScoreConstruction : IScoreConstruction
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
            /// <summary>
            /// Todo
            /// </summary>
            public interface IBuilder : IBuilder<IScoreConstruction>
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
            private class InternalBuilder : AbstractBuilder<IScoreConstruction>, IBuilder
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
                protected override IScoreConstruction BuildObj()
                {
                    return new ScoreConstruction(_scoreType);
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