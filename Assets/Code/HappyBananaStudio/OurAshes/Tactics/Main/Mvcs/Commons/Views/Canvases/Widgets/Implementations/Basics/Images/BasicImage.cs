using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Colors.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Colors.Rgbs.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Sprites.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Implementations.Basics.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Interfaces.Basics.Images;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.ResourceLoaders.Sprites;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Implementations.Basics.Images
{
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
        /// <param name="colorId"></param>
        void IBasicImage.UpdateColorId(ColorID colorId)
        {
            this.imageComponent.color = RgbsManager.GetUnityColor(colorId);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="spriteId"></param>
        void IBasicImage.UpdateSpriteId(SpriteID spriteId)
        {
            this.imageComponent.sprite = SpriteResourceLoader.LoadSpriteResource(spriteId);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="a"></param>
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
            private ColorID colorId = ColorID.None;

            // Todo
            private Transform parentTransform = null;

            // Todo
            private SpriteID spriteId = SpriteID.None;

            // Todo
            private float transparency = 0f;

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
                    Color color = RgbsManager.GetUnityColor(this.colorId);
                    color.a = this.transparency;
                    image.color = color;
                    basicWidgetImage.SetParent(this.parentTransform);
                    ((IWidget)basicWidgetImage).GetRectTransform().sizeDelta = Vector2.zero;
                    return basicWidgetImage;
                }
                throw ExceptionUtil.Arguments.Build("Unable to construct {}. Invalid Parameters. {}",
                    this.GetType(), string.Join("\n", invalidReasons));
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="colorId"></param>
            /// <returns></returns>
            public Builder SetColorId(ColorID colorId)
            {
                this.colorId = colorId;
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
            /// <param name="spriteId"></param>
            /// <returns></returns>
            public Builder SetSpriteId(SpriteID spriteId)
            {
                this.spriteId = spriteId;
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
            /// <returns></returns>
            private ISet<string> IsInvalid()
            {
                // Default an empty Set: String
                ISet<string> argumentExceptionSet = new HashSet<string>();
                if (this.colorId == ColorID.None)
                {
                    argumentExceptionSet.Add(typeof(ColorID).Name + " cannot be null.");
                }
                if (this.spriteId == SpriteID.None)
                {
                    argumentExceptionSet.Add(typeof(SpriteID).Name + " cannot be null.");
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