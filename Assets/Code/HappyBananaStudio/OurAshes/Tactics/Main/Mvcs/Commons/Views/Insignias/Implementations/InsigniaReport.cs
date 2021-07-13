using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Reports.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Schemes.Emblems.IDs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Schemes.Patterns.IDs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Insignias.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Insignias.Implementations
{
    /// <summary>
    /// Insignia Report Implementation
    /// </summary>
    public class InsigniaReport : AbstractReport, IInsigniaReport
    {
        // Todo
        private readonly PatternSchemeID _patternSchemeID;

        // Todo
        private readonly EmblemSchemeID _emblemSchemeID;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="patternSchemeID"></param>
        /// <param name="emblemSchemeID"> </param>
        private InsigniaReport(PatternSchemeID patternSchemeID, EmblemSchemeID emblemSchemeID)
        {
            this._patternSchemeID = patternSchemeID;
            this._emblemSchemeID = emblemSchemeID;
        }

        /// <inheritdoc/>
        EmblemSchemeID IInsigniaReport.GetEmblemSchemeID()
        {
            return _emblemSchemeID;
        }

        /// <inheritdoc/>
        PatternSchemeID IInsigniaReport.GetPatternSchemeID()
        {
            return _patternSchemeID;
        }

        /// <inheritdoc/>
        protected override string GetContent()
        {
            return string.Format("{0}, {1}", _patternSchemeID, _emblemSchemeID);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Todo
            /// </summary>
            public interface IBuilder : IBuilder<IInsigniaReport>
            {

                IBuilder SetPatternSchemeID(PatternSchemeID patternSchemeID);

                IBuilder SetEmblemSchemeID(EmblemSchemeID emblemSchemeID);
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
            private class InternalBuilder : AbstractBuilder<IInsigniaReport>, IBuilder
            {
                // Todo
                private  PatternSchemeID _patternSchemeID;

                // Todo
                private  EmblemSchemeID _emblemSchemeID;

                /// <inheritdoc/>
                IBuilder IBuilder.SetEmblemSchemeID(EmblemSchemeID emblemSchemeID)
                {
                    _emblemSchemeID = emblemSchemeID;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetPatternSchemeID(PatternSchemeID patternSchemeID)
                {
                    _patternSchemeID  = patternSchemeID;
                    return this;
                }

                /// <inheritdoc/>
                protected override IInsigniaReport BuildObj()
                {
                    return new InsigniaReport(_patternSchemeID, _emblemSchemeID);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, _patternSchemeID);
                    this.Validate(invalidReasons, _emblemSchemeID);
                }
            }
        }
    }
}