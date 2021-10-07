﻿using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Widgets.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Widgets.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Interfaces.Basics;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Implementations.Abstracts.Basics
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

                protected override IImageWidget BuildObj()
                {
                    GameObject gameObject = new GameObject();
                    IImageWidget imageWidget = gameObject.AddComponent<ImageWidget>();
                    this.ApplyCommonParams(imageWidget);
                    imageWidget.SetSpriteID(this.spriteID);
                    imageWidget.SetColorID(this.colorID);
                    return imageWidget;
                }

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
            }
        }
    }
}