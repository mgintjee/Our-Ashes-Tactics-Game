using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Widgets.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Widgets.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Colors.IDs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Resources.Loaders.Sprites;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Sprites.IDs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Inters.Basics;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Abstrs.Basics
{
    /// <summary>
    /// Todo
    /// </summary>
    public class ImageWidget : AbstractWidget, IImageWidget
    {
        // Todo
        protected Image image;

        // Todo
        protected SpriteID spriteID;

        // Todo
        protected ColorID colorID;

        /// <inheritdoc/>
        public void Start()
        {
            this.image = this.GetGameObject().AddComponent<Image>();
        }

        /// <inheritdoc/>
        void IImageWidget.SetColorID(ColorID colorID)
        {
            this.colorID = colorID;
        }

        /// <inheritdoc/>
        void IImageWidget.SetSpriteID(SpriteID spriteID)
        {
            this.spriteID = spriteID;
            if (this.image != null)
            {
                this.image.sprite = SpriteResourceLoader.LoadSpriteResource(spriteID).GetValue();
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Todo
            /// </summary>
            public interface IImageBuilder : IWidgetBuilder<IImageWidget>
            {
                IImageBuilder SetSpriteID(SpriteID spriteID);

                IImageBuilder SetColorID(ColorID colorID);
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public static IImageBuilder Get()
            {
                return new InternalBuilder();
            }

            /// <summary>
            /// Todo
            /// </summary>
            private class InternalBuilder : AbstractWidgetBuilder<IImageWidget>, IImageBuilder
            {
                // Todo
                protected SpriteID spriteID;

                // Todo
                protected ColorID colorID;

                IImageBuilder IImageBuilder.SetColorID(ColorID colorID)
                {
                    this.colorID = colorID;
                    return this;
                }

                IImageBuilder IImageBuilder.SetSpriteID(SpriteID spriteID)
                {
                    this.spriteID = spriteID;
                    return this;
                }

                protected override IImageWidget BuildObj()
                {
                    GameObject gameObject = new GameObject();
                    IImageWidget imageWidget = gameObject.AddComponent<ImageWidget>();
                    this.ApplyCommonParams(imageWidget);
                    imageWidget.SetSpriteID(this.spriteID);
                    imageWidget.SetColorID(this.colorID);
                    return imageWidget;
                }
            }
        }
    }
}