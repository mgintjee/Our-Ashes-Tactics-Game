namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Widgets.Basics.Images.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Colors.Constants;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Colors.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.ResourceLoaders.Sprites;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Sprites.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Widgets.Basics.Abs;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Widgets.Basics.Images.Api;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// Todo
    /// </summary>
    public class BasicImage
        : AbstractBasicWidget, IBasicImage
    {
        // Todo
        private Image imageComponent;

        /// <summary>
        /// Todo
        /// </summary>
        public new void Awake()
        {
            this.imageComponent = this.GetComponent<Image>();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="colorId">
        /// </param>
        void IBasicImage.UpdateColorId(ColorId colorId)
        {
            this.imageComponent.color = ColorIdConstants.GetUnityColor(colorId);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="spriteId">
        /// </param>
        void IBasicImage.UpdateSpriteId(SpriteId spriteId)
        {
            this.imageComponent.sprite = SpriteResourceLoader.LoadSpriteResource(spriteId);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="a">
        /// </param>
        void IBasicImage.UpdateTransparency(float a)
        {
            Color color = this.imageComponent.color;
            color.a = a;
            this.imageComponent.color = color;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private ColorId colorId = ColorId.None;

            // Todo
            private SpriteId spriteId = SpriteId.None;

            // Todo
            private float transparency = 0f;

            // Todo
            private Transform parentTransform = null;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IBasicImage Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    BasicImage basicWidgetImage = new GameObject(typeof(BasicImage).Name)
                        .AddComponent<BasicImage>();
                    Image image = basicWidgetImage.GetGameObject().AddComponent<Image>();
                    image.sprite = SpriteResourceLoader.LoadSpriteResource(this.spriteId);
                    Color color = ColorIdConstants.GetUnityColor(this.colorId);
                    color.a = this.transparency;
                    image.color = color;
                    basicWidgetImage.GetTransform().SetParent(this.parentTransform);
                    basicWidgetImage.GetTransform().localPosition = Vector3.zero;
                    basicWidgetImage.GetTransform().localScale = Vector3.one;
                    return basicWidgetImage;
                }
                else
                {
                    throw ExceptionUtil.Arguments.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="colorId"></param>
            /// <returns></returns>
            public Builder SetColorId(ColorId colorId)
            {
                this.colorId = colorId;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="spriteId"></param>
            /// <returns></returns>
            public Builder SetSpriteId(SpriteId spriteId)
            {
                this.spriteId = spriteId;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="parentTransform"></param>
            /// <returns></returns>
            public Builder SetParentTransform(Transform parentTransform)
            {
                this.parentTransform = parentTransform;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="transparency"></param>
            /// <returns></returns>
            public Builder SetTransparency(float transparency)
            {
                this.transparency = transparency;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns>
            /// </returns>
            private ISet<string> IsInvalid()
            {
                // Default an empty Set: String
                ISet<string> argumentExceptionSet = new HashSet<string>();
                if (this.colorId == ColorId.None)
                {
                    argumentExceptionSet.Add(typeof(ColorId).Name + " cannot be null.");
                }
                if (this.spriteId == SpriteId.None)
                {
                    argumentExceptionSet.Add(typeof(SpriteId).Name + " cannot be null.");
                }
                if (this.parentTransform == null)
                {
                    argumentExceptionSet.Add("Parent " + typeof(Transform).Name + " cannot be null.");
                }

                return argumentExceptionSet;
            }
        }
    }
}