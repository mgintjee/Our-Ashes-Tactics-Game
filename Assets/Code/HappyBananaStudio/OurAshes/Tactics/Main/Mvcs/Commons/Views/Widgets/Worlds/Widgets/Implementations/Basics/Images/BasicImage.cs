using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Colors.IDs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Sprites.IDs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Constants.Colors.Rgbs.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.ResourceLoaders.Sprites;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Canvases.UIs.Interfaces.Basics.Images;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Interfaces;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Canvases.Widgets.Implementations.Basics.Images
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
        /// <param name="colorID"></param>
        void IBasicImage.UpdateColorID(ColorID colorID)
        {
            this.imageComponent.color = RgbsManager.GetUnityColor(colorID);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="spriteID"></param>
        void IBasicImage.UpdateSpriteID(SpriteID spriteID)
        {
            this.imageComponent.sprite = SpriteResourceLoader.LoadSpriteResource(spriteID);
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
            private ColorID colorID = ColorID.None;

            // Todo
            private Transform parentTransform = null;

            // Todo
            private SpriteID spriteID = SpriteID.None;

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
                    image.sprite = SpriteResourceLoader.LoadSpriteResource(this.spriteID);
                    Color color = RgbsManager.GetUnityColor(this.colorID);
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
            /// <param name="colorID"></param>
            /// <returns></returns>
            public Builder SetColorID(ColorID colorID)
            {
                this.colorID = colorID;
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
            /// <param name="spriteID"></param>
            /// <returns></returns>
            public Builder SetSpriteID(SpriteID spriteID)
            {
                this.spriteID = spriteID;
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
                if (this.colorID == ColorID.None)
                {
                    argumentExceptionSet.Add(typeof(ColorID).Name + " cannot be null.");
                }
                if (this.spriteID == SpriteID.None)
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