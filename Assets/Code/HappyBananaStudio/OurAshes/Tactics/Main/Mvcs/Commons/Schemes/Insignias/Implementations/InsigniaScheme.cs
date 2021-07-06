using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Reports.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Schemes.Emblems.IDs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Schemes.Patterns.IDs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Schemes.Insignias.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Schemes.Insignias.Implementations
{
    /// <summary>
    /// Insignia Scheme Implementation
    /// </summary>
    public class InsigniaScheme
        : AbstractReport, IInsigniaScheme
    {
        // Todo
        private readonly PatternSchemeID patternSchemeID;

        // Todo
        private readonly EmblemSchemeID emblemSchemeID;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="patternSchemeID"></param>
        /// <param name="emblemSchemeID"> </param>
        private InsigniaScheme(PatternSchemeID patternSchemeID, EmblemSchemeID emblemSchemeID)
        {
            this.patternSchemeID = patternSchemeID;
            this.emblemSchemeID = emblemSchemeID;
        }

        /// <inheritdoc/>
        EmblemSchemeID IInsigniaScheme.GetEmblemSchemeID()
        {
            return emblemSchemeID;
        }

        /// <inheritdoc/>
        PatternSchemeID IInsigniaScheme.GetPatternSchemeID()
        {
            return patternSchemeID;
        }

        /// <inheritdoc/>
        protected override string GetContent()
        {
            return string.Format("{0}, {1}", patternSchemeID, emblemSchemeID);
        }

        /// <summary>
        /// Builder class for this object
        /// </summary>
        public class Builder
            : AbstractBuilder<IInsigniaScheme>
        {
            // Todo
            private PatternSchemeID _patternSchemeID = PatternSchemeID.None;

            // Todo
            private EmblemSchemeID _emblemSchemeID = EmblemSchemeID.None;

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="patternSchemeID"></param>
            /// <returns></returns>
            public Builder SetPatternSchemeID(PatternSchemeID patternSchemeID)
            {
                _patternSchemeID = patternSchemeID;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="emblemSchemeID"></param>
            /// <returns></returns>
            public Builder SetEmblemSchemeID(EmblemSchemeID emblemSchemeID)
            {
                _emblemSchemeID = emblemSchemeID;
                return this;
            }

            /// <inheritdoc/>
            protected override IInsigniaScheme BuildObj()
            {
                return new InsigniaScheme(_patternSchemeID, _emblemSchemeID);
            }

            /// <inheritdoc/>
            protected override void Validate(ISet<string> invalidReasons)
            {
                ValidateEnum(invalidReasons, _patternSchemeID);
                ValidateEnum(invalidReasons, _emblemSchemeID);
            }
        }
    }
}