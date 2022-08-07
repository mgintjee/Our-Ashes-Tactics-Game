using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Utils.Strings;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Icons.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Sprites.IDs;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Icons.Details.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public class IconDetailsImpl
        : IIconDetails
    {
        private readonly SpriteID primaryID;
        private readonly SpriteID secondaryID;
        private readonly SpriteID tertiaryID;

        private IconDetailsImpl(SpriteID primaryID, SpriteID secondaryID, SpriteID tertiaryID)
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

        SpriteID IIconDetails.GetPrimarySpriteID()
        {
            return primaryID;
        }

        SpriteID IIconDetails.GetSecondarySpriteID()
        {
            return secondaryID;
        }

        SpriteID IIconDetails.GetTertiarySpriteID()
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
                : IBuilder<IIconDetails>
            {
                IInternalBuilder SetPrimaryID(SpriteID id);

                IInternalBuilder SetSecondaryID(SpriteID id);

                IInternalBuilder SetTertiaryID(SpriteID id);
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
                : AbstractBuilder<IIconDetails>, IInternalBuilder
            {
                private SpriteID primaryID;
                private SpriteID secondaryID;
                private SpriteID tertiaryID;

                IInternalBuilder IInternalBuilder.SetPrimaryID(SpriteID id)
                {
                    primaryID = id;
                    return this;
                }

                IInternalBuilder IInternalBuilder.SetSecondaryID(SpriteID id)
                {
                    secondaryID = id;
                    return this;
                }

                IInternalBuilder IInternalBuilder.SetTertiaryID(SpriteID id)
                {
                    tertiaryID = id;
                    return this;
                }

                protected override IIconDetails BuildObj()
                {
                    return new IconDetailsImpl(primaryID, secondaryID, tertiaryID);
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