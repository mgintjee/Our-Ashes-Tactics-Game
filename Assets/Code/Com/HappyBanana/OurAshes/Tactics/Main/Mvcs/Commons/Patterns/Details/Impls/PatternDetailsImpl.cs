using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Utils.Strings;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Patterns.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Patterns.Details.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct PatternDetailsImpl
        : IPatternDetails
    {
        private readonly ColorID primaryID;
        private readonly ColorID secondaryID;
        private readonly ColorID tertiaryID;

        private PatternDetailsImpl(ColorID primaryID, ColorID secondaryID, ColorID tertiaryID)
        {
            this.primaryID = primaryID;
            this.secondaryID = secondaryID;
            this.tertiaryID = tertiaryID;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("Primary {0}, Secondary {1}, Tertiary {2}",
                StringUtils.Format(this.primaryID),
                StringUtils.Format(this.secondaryID),
                StringUtils.Format(this.tertiaryID));
        }

        ColorID IPatternDetails.GetPrimaryColorID()
        {
            return primaryID;
        }

        ColorID IPatternDetails.GetSecondaryColorID()
        {
            return secondaryID;
        }

        ColorID IPatternDetails.GetTertiaryColorID()
        {
            return tertiaryID;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Todo
            /// </summary>
            public interface IInternalBuilder
                : IBuilder<IPatternDetails>
            {
                IInternalBuilder SetPrimaryID(ColorID id);

                IInternalBuilder SetSecondaryID(ColorID id);

                IInternalBuilder SetTertiaryID(ColorID id);
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public static IInternalBuilder Get()
            {
                return new InternalBuilder();
            }

            /// <summary>
            /// Todo
            /// </summary>
            private class InternalBuilder
                : AbstractBuilder<IPatternDetails>, IInternalBuilder
            {
                private ColorID primaryID;
                private ColorID secondaryID;
                private ColorID tertiaryID;

                IInternalBuilder IInternalBuilder.SetPrimaryID(ColorID id)
                {
                    primaryID = id;
                    return this;
                }

                IInternalBuilder IInternalBuilder.SetSecondaryID(ColorID id)
                {
                    secondaryID = id;
                    return this;
                }

                IInternalBuilder IInternalBuilder.SetTertiaryID(ColorID id)
                {
                    tertiaryID = id;
                    return this;
                }

                protected override IPatternDetails BuildObj()
                {
                    return new PatternDetailsImpl(primaryID, secondaryID, tertiaryID);
                }

                /// <inheritdoc/>
                protected override void Validate(IList<string> invalidReasons)
                {
                    this.Validate(invalidReasons, primaryID);
                    this.Validate(invalidReasons, secondaryID);
                    this.Validate(invalidReasons, tertiaryID);
                }
            }
        }
    }
}