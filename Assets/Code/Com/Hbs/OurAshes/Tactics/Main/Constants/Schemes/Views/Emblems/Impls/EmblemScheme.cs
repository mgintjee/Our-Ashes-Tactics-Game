using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Constants.Schemes.Views.Emblems.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Schemes.Emblems.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Sprites.IDs;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Constants.Schemes.Views.Emblems.Impls
{
    /// <summary>
    /// Emblem Scheme Impl
    /// </summary>
    public class EmblemScheme
        : IEmblemScheme
    {
        // Todo
        private readonly SpriteID _backgroundSpriteID;

        // Todo
        private readonly SpriteID _forgroundSpriteID;

        // Todo
        private readonly SpriteID _iconSpriteID;

        // Todo
        private readonly EmblemSchemeID _emblemSchemeID;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="emblemSchemeID">    </param>
        /// <param name="iconSpriteID">      </param>
        /// <param name="foregroundSpriteID"></param>
        /// <param name="backgroundSpriteID"></param>
        private EmblemScheme(EmblemSchemeID emblemSchemeID, SpriteID iconSpriteID, SpriteID foregroundSpriteID, SpriteID backgroundSpriteID)
        {
            _emblemSchemeID = emblemSchemeID;
            _iconSpriteID = iconSpriteID;
            _forgroundSpriteID = foregroundSpriteID;
            _backgroundSpriteID = backgroundSpriteID;
        }

        /// <inheritdoc/>
        SpriteID IEmblemScheme.GetBackgroundID()
        {
            return _backgroundSpriteID;
        }

        /// <inheritdoc/>
        EmblemSchemeID IEmblemScheme.GetEmblemSchemeID()
        {
            return _emblemSchemeID;
        }

        /// <inheritdoc/>
        SpriteID IEmblemScheme.GetForegroundID()
        {
            return _forgroundSpriteID;
        }

        /// <inheritdoc/>
        SpriteID IEmblemScheme.GetIconID()
        {
            return _iconSpriteID;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Todo
            /// </summary>
            public interface IBuilder : IBuilder<IEmblemScheme>
            {
                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="emblemSchemeID"></param>
                /// <returns></returns>
                IBuilder SetEmblemSchemeID(EmblemSchemeID emblemSchemeID);

                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="spriteID"></param>
                /// <returns></returns>
                IBuilder SetBackgroundSpriteID(SpriteID spriteID);

                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="spriteID"></param>
                /// <returns></returns>
                IBuilder SetForegroundSpriteID(SpriteID spriteID);

                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="spriteID"></param>
                /// <returns></returns>
                IBuilder SetIconSpriteID(SpriteID spriteID);
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
            private class InternalBuilder : AbstractBuilder<IEmblemScheme>, IBuilder
            {
                // Todo
                private EmblemSchemeID _emblemSchemeID;

                // Todo
                private SpriteID _backgroundSpriteID;

                // Todo
                private SpriteID _foregroundSpriteID;

                // Todo
                private SpriteID _iconSpriteID;

                /// <inheritdoc/>
                IBuilder IBuilder.SetEmblemSchemeID(EmblemSchemeID emblemSchemeID)
                {
                    _emblemSchemeID = emblemSchemeID;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetBackgroundSpriteID(SpriteID colorID)
                {
                    _backgroundSpriteID = colorID;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetForegroundSpriteID(SpriteID colorID)
                {
                    _foregroundSpriteID = colorID;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetIconSpriteID(SpriteID colorID)
                {
                    _iconSpriteID = colorID;
                    return this;
                }

                /// <inheritdoc/>
                protected override IEmblemScheme BuildObj()
                {
                    return new EmblemScheme(_emblemSchemeID, _iconSpriteID, _foregroundSpriteID, _backgroundSpriteID);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, _emblemSchemeID);
                    this.Validate(invalidReasons, _backgroundSpriteID);
                    this.Validate(invalidReasons, _foregroundSpriteID);
                    this.Validate(invalidReasons, _iconSpriteID);
                }
            }
        }
    }
}