using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Utils.Strings;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Constants.Schemes.Views.Patterns.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Colors.IDs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Schemes.Patterns.IDs;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Constants.Schemes.Views.Patterns.Impls
{
    /// <summary>
    /// Pattern Scheme Implementation
    /// </summary>
    public class PatternScheme : IPatternScheme
    {
        // Todo
        private readonly PatternSchemeID _patternSchemeID;

        // Todo
        private readonly ColorID _primaryColorID;

        // Todo
        private readonly ColorID _secondaryColorID;

        // Todo
        private readonly ColorID _tertiaryColorID;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="patternSchemeID"> </param>
        /// <param name="primaryColorID">  </param>
        /// <param name="secondaryColorID"></param>
        /// <param name="tertiaryColorID"> </param>
        private PatternScheme(PatternSchemeID patternSchemeID, ColorID primaryColorID, ColorID secondaryColorID, ColorID tertiaryColorID)
        {
            _patternSchemeID = patternSchemeID;
            _primaryColorID = primaryColorID;
            _secondaryColorID = secondaryColorID;
            _tertiaryColorID = tertiaryColorID;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: {1}, Primary {2}, Secondary {3}, Tertiary {4}",
                this.GetType().Name, StringUtils.Format(_patternSchemeID),
                StringUtils.Format(_primaryColorID), StringUtils.Format(_secondaryColorID),
                StringUtils.Format(_tertiaryColorID));
        }

        /// <inheritdoc/>
        PatternSchemeID IPatternScheme.GetPatternSchemeID()
        {
            return _patternSchemeID;
        }

        /// <inheritdoc/>
        ColorID IPatternScheme.GetPrimaryColorID()
        {
            return this._primaryColorID;
        }

        /// <inheritdoc/>
        ColorID IPatternScheme.GetSecondaryColorID()
        {
            return this._secondaryColorID;
        }

        /// <inheritdoc/>
        ColorID IPatternScheme.GetTertiaryColorID()
        {
            return this._tertiaryColorID;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Todo
            /// </summary>
            public interface IBuilder : IBuilder<IPatternScheme>
            {
                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="patternSchemeID"></param>
                /// <returns></returns>
                IBuilder SetPatternSchemeID(PatternSchemeID patternSchemeID);

                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="colorID"></param>
                /// <returns></returns>
                IBuilder SetPrimaryColorID(ColorID colorID);

                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="colorID"></param>
                /// <returns></returns>
                IBuilder SetSecondaryColorID(ColorID colorID);

                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="colorID"></param>
                /// <returns></returns>
                IBuilder SetTertiaryColorID(ColorID colorID);
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
            private class InternalBuilder : AbstractBuilder<IPatternScheme>, IBuilder
            {
                // Todo
                private PatternSchemeID _patternSchemeID;

                // Todo
                private ColorID _primaryColorID;

                // Todo
                private ColorID _secondaryColorID;

                // Todo
                private ColorID _tertiaryColorID;

                /// <inheritdoc/>
                IBuilder IBuilder.SetPatternSchemeID(PatternSchemeID patternSchemeID)
                {
                    _patternSchemeID = patternSchemeID;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetPrimaryColorID(ColorID colorID)
                {
                    _primaryColorID = colorID;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetSecondaryColorID(ColorID colorID)
                {
                    _secondaryColorID = colorID;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetTertiaryColorID(ColorID colorID)
                {
                    _tertiaryColorID = colorID;
                    return this;
                }

                /// <inheritdoc/>
                protected override IPatternScheme BuildObj()
                {
                    return new PatternScheme(_patternSchemeID, _primaryColorID, _secondaryColorID, _tertiaryColorID);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, _patternSchemeID);
                    this.Validate(invalidReasons, _primaryColorID);
                    this.Validate(invalidReasons, _secondaryColorID);
                    this.Validate(invalidReasons, _tertiaryColorID);
                }
            }
        }
    }
}