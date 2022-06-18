using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Managers;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Resources.Loaders.Sprites;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Sprites.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public class ImageWidgetImpl
        : AbstractCanvasWidget, IImageWidget
    {
        private float alpha = 1.0f;

        // Todo
        private SpriteID spriteID;

        // Todo
        private ColorID colorID;

        /// <inheritdoc/>
        void IImageWidget.SetColorID(ColorID colorID)
        {
            this.colorID = colorID;
            this.GetImage().color = RgbManager.GetUnityColor(colorID);
        }

        /// <inheritdoc/>
        void IImageWidget.SetSpriteID(SpriteID spriteID)
        {
            this.spriteID = spriteID;
            this.GetImage().sprite = SpriteResourceLoader.LoadSpriteResource(spriteID).GetValue();
        }

        void IImageWidget.SetAlpha(float alpha)
        {
            this.alpha = alpha;
            this.GetImage().color = RgbManager.GetUnityColor(this.colorID, alpha);
        }

        private UnityEngine.UI.Image GetImage()
        {
            if (this.GetComponent<UnityEngine.UI.Image>() == null)
            {
                this.GetGameObject().AddComponent<UnityEngine.UI.Image>();
            }
            return this.GetComponent<UnityEngine.UI.Image>();
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
                : AbstractWidgetBuilders.IWidgetBuilder<IImageWidget>
            {
                IInternalBuilder SetSpriteID(SpriteID spriteID);

                IInternalBuilder SetColorID(ColorID colorID);

                IInternalBuilder SetAlpha(float alpha);
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
                : AbstractWidgetBuilders.AbstractWidgetBuilder<IImageWidget>, IInternalBuilder
            {
                // Todo
                protected SpriteID spriteID;

                // Todo
                protected ColorID colorID;

                protected float alpha;

                IInternalBuilder IInternalBuilder.SetColorID(ColorID colorID)
                {
                    this.colorID = colorID;
                    return this;
                }

                IInternalBuilder IInternalBuilder.SetSpriteID(SpriteID spriteID)
                {
                    this.spriteID = spriteID;
                    return this;
                }

                IInternalBuilder IInternalBuilder.SetAlpha(float alpha)
                {
                    this.alpha = alpha;
                    return this;
                }

                protected override void ValidateWidgetBuilder(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, this.colorID);
                    this.Validate(invalidReasons, this.spriteID);
                }

                protected override IImageWidget BuildScript(UnityEngine.GameObject gameObject)
                {
                    IImageWidget imageWidget = gameObject.AddComponent<ImageWidgetImpl>();
                    this.ApplyImageValues(imageWidget);
                    return imageWidget;
                }

                protected void ApplyImageValues(IImageWidget imageWidget)
                {
                    this.ApplyCommonValues(imageWidget);
                    imageWidget.SetSpriteID(this.spriteID);
                    imageWidget.SetColorID(this.colorID);
                    imageWidget.SetAlpha(this.alpha);
                }
            }
        }
    }
}