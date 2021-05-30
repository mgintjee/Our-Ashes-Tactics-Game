using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Schemes.Emblems.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Schemes.Patterns.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Schemes.Insignias.Interfaces;

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
                "\n{1}={2}" +
                "\n{3}={4}",
                this.GetType().Name,
                typeof(PatternSchemeID).Name, this.patternSchemeID,
                typeof(EmblemSchemeID).Name, this.emblemSchemeID);
        }

        EmblemSchemeID IInsigniaScheme.GetEmblemSchemeID()
        {
            return emblemSchemeID;
        }

        PatternSchemeID IInsigniaScheme.GetPatternSchemeID()
        {
            return patternSchemeID;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private PatternSchemeID patternSchemeID;

            // Todo
            private EmblemSchemeID emblemSchemeID;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IInsigniaScheme Build()
            {
                return new InsigniaScheme(patternSchemeID, emblemSchemeID);
            }
        }
    }
}