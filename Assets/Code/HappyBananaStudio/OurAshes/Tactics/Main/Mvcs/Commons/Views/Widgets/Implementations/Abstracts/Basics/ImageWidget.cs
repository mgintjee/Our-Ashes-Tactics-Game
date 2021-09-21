using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Colors.IDs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Resources.Loaders.Sprites;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Sprites.IDs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Unity.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Interfaces.Basics;
using System.Collections.Generic;
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

        // Todo
        protected IUnityScript parentUnityScript;

        public void Start()
        {
            this.image = this.GetGameObject().AddComponent<Image>();
            this.image.sprite = SpriteResourceLoader.LoadSpriteResource(spriteID).GetValue();
        }

        void IImageWidget.SetColor(ColorID colorID)
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
            public interface IBuilder : IBuilder<IImageWidget>
            {
                IBuilder SetSpriteID(SpriteID spriteID);

                IBuilder SetColorID(ColorID colorID);

                IBuilder SetParentUnityScript(IUnityScript unityScript);
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
            private class InternalBuilder : AbstractBuilder<IImageWidget>, IBuilder
            {
                // Todo
                private SpriteID spriteID;

                // Todo
                private ColorID colorID;

                // Todo
                private IUnityScript unityScript;

                /// <inheritdoc/>

                IBuilder IBuilder.SetParentUnityScript(IUnityScript unityScript)
                {
                    this.unityScript = unityScript;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetSpriteID(SpriteID spriteID)
                {
                    this.spriteID = spriteID;
                    return this;
                }

                /// <inheritdoc/>
                protected override IImageWidget BuildObj()
                {
                    GameObject gameObject = new GameObject(typeof(ImageWidget).Name);
                    IImageWidget imageWidget = gameObject.AddComponent<ImageWidget>();
                    imageWidget.SetParent(this.unityScript);
                    imageWidget.SetSpriteID(this.spriteID);
                    return imageWidget;
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, spriteID);
                    // Todo: Validate the ColorID
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetColorID(ColorID colorID)
                {
                    this.colorID = colorID;
                    return this;
                }
            }
        }
    }
}