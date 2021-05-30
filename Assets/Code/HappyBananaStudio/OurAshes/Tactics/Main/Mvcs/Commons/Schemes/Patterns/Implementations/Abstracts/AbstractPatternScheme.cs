using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Colors.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Schemes.Patterns.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Schemes.Patterns.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Schemes.Patterns.Implementations.Abstracts
{
    /// <summary>
    /// Abstract Pattern Scheme
    /// </summary>
    public abstract class AbstractPatternScheme
        : IPatternScheme
    {
        // Todo
        protected PatternSchemeID patternSchemeID;

        // Todo
        protected ColorID primary;

        // Todo
        protected ColorID secondary;

        // Todo
        protected ColorID tertiary;

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: {1}={2}" +
                "\nPrimary {3}={4}" +
                "\nSecondary {5}={6}" +
                "\nTertiary {7}={8}",
                this.GetType().Name,
                typeof(PatternSchemeID).Name, this.patternSchemeID,
                typeof(ColorID).Name, this.primary,
                typeof(ColorID).Name, this.secondary,
                typeof(ColorID).Name, this.tertiary);
        }

        /// <inheritdoc/>
        PatternSchemeID IPatternScheme.GetPatternSchemeID()
        {
            return patternSchemeID;
        }

        /// <inheritdoc/>
        ColorID IPatternScheme.GetPrimaryColorID()
        {
            return this.primary;
        }

        /// <inheritdoc/>
        ColorID IPatternScheme.GetSecondaryColorID()
        {
            return this.secondary;
        }

        /// <inheritdoc/>
        ColorID IPatternScheme.GetTertiaryColorID()
        {
            return this.tertiary;
        }
    }
}