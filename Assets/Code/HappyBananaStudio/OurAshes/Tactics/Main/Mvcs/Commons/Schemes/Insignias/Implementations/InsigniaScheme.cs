using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Schemes.Emblems.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Schemes.Patterns.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Utils.Strings;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Schemes.Insignias.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Schemes.Insignias.Implementations
{
    /// <summary>
    /// Insignia Scheme Implementation
    /// </summary>
    public struct InsigniaScheme
        : IInsigniaScheme
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
        public override string ToString()
        {
            return string.Format("{0}: " +
                "\n{1}" +
                "\n{2}",
                this.GetType().Name,
                StringUtils.Format(typeof(PatternSchemeID), this.patternSchemeID),
                StringUtils.Format(typeof(EmblemSchemeID), this.emblemSchemeID));
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

        /// <summary>
        /// Builder class for this object
        /// </summary>
        public class Builder
            : AbstractBuilder<IInsigniaScheme>
        {
            // Todo
            private PatternSchemeID patternSchemeID = PatternSchemeID.None;

            // Todo
            private EmblemSchemeID emblemSchemeID = EmblemSchemeID.None;

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="patternSchemeID"></param>
            /// <returns></returns>
            public Builder SetPatternSchemeID(PatternSchemeID patternSchemeID)
            {
                this.patternSchemeID = patternSchemeID;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="emblemSchemeID"></param>
            /// <returns></returns>
            public Builder SetEmblemSchemeID(EmblemSchemeID emblemSchemeID)
            {
                this.emblemSchemeID = emblemSchemeID;
                return this;
            }

            /// <inheritdoc/>
            protected override IInsigniaScheme BuildObj()
            {
                return new InsigniaScheme(patternSchemeID, emblemSchemeID);
            }

            /// <inheritdoc/>
            protected override ISet<string> GetInvalidReasons()
            {
                ISet<string> invalidReasons = new HashSet<string>();

                if (patternSchemeID == PatternSchemeID.None)
                {
                }
                if (emblemSchemeID == EmblemSchemeID.None)
                {
                }

                return invalidReasons;
            }
        }
    }
}