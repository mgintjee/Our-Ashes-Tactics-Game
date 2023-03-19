using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Icons.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Patterns.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Constants;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Impls
{
    /// <summary>
    /// Icon Panel Impl
    /// </summary>
    public class IconWidgetImpl
        : AbstractPanelWidget, IIconWidget
    {
        private IIconDetails iconDetails;
        private IPatternDetails patternDetails;
        private IImageWidget primaryImage;
        private IImageWidget secondaryImage;
        private IImageWidget tertiaryImage;

        /// <inheritdoc/>
        public IImageWidget GetPrimaryImage()
        {
            return primaryImage;
        }

        /// <inheritdoc/>
        public IImageWidget GetSecondaryImage()
        {
            return secondaryImage;
        }

        /// <inheritdoc/>
        public IImageWidget GetTertiaryImage()
        {
            return tertiaryImage;
        }

        /// <inheritdoc/>
        protected override void InitialBuild()
        {
            // Todo: Move the Vector2 into some constants file
            primaryImage = BuildImage("PrimaryImage", IconConstants.PRIMARY_SPRITE_SPEC,
                1, 1, patternDetails.GetPrimaryColorID(), iconDetails.GetPrimarySpriteID());
            secondaryImage = BuildImage("SecondaryImage", IconConstants.SECONDARY_SPRITE_SPEC,
                1, 1, patternDetails.GetSecondaryColorID(), iconDetails.GetSecondarySpriteID());
            tertiaryImage = BuildImage("TertiaryImage", IconConstants.TERTIARY_SPRITE_SPEC,
                1, 1, patternDetails.GetTertiaryColorID(), iconDetails.GetTertiarySpriteID());
            InternalAddWidget(primaryImage);
            InternalAddWidget(secondaryImage);
            InternalAddWidget(tertiaryImage);
        }

        /*
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="spriteID"></param>
        /// <param name="colorID"> </param>
        /// <param name="size">    </param>
        /// <returns></returns>
        private IImageWidget BuildImage(SpriteID spriteID, ColorID colorID, Vector2 size, Vector2 co)
        {
            return ImageWidgetImpl.Builder.Get()
                .SetAlpha(1f)
                .SetSpriteID(spriteID)
                .SetColorID(colorID)
                .SetMvcType(mvcType)
                .SetCanvasLevel(1)
                .SetInteractable(true)
                .SetEnabled(true)
                .SetWidgetGridSpec(new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(coords)
                    .SetCanvasGridSize(size))
                .SetParent(this)
                .SetName(CanvasWidgetType.Image.ToString())
                .Build();
        }
        */

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Todo
            /// </summary>
            public interface IInternalBuilder
                : PanelWidgetBuilders.IPanelWidgetBuilder
            {
                /// <summary>
                /// TOdo
                /// </summary>
                /// <param name="details"></param>
                /// <returns></returns>
                IInternalBuilder SetIconDetails(IIconDetails details);

                /// <summary>
                /// TOdo
                /// </summary>
                /// <param name="details"></param>
                /// <returns></returns>
                IInternalBuilder SetPatternDetails(IPatternDetails details);
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
                : PanelWidgetBuilders.InternalPanelWidgetBuilder, IInternalBuilder
            {
                private IIconDetails iconDetails;
                private IPatternDetails patternDetails;

                /// <inheritdoc/>
                public IInternalBuilder SetIconDetails(IIconDetails details)
                {
                    iconDetails = details;
                    return this;
                }

                /// <inheritdoc/>
                public IInternalBuilder SetPatternDetails(IPatternDetails details)
                {
                    patternDetails = details;
                    return this;
                }

                /// <inheritdoc/>
                protected override IPanelWidget BuildScript(UnityEngine.GameObject gameObject)
                {
                    IconWidgetImpl widget = gameObject.AddComponent<IconWidgetImpl>();
                    widget.iconDetails = iconDetails;
                    widget.patternDetails = patternDetails;
                    this.ApplyPanelValues(widget);
                    return widget;
                }
            }
        }
    }
}