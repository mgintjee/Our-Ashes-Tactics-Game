namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Widgets.Basics.Images.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Widgets.Basics.Abs;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Widgets.Basics.Images.Api;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// Todo
    /// </summary>
    public class BasicWidgetImage
        : AbstractBasicWidget, IBasicWidgetImage
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
        /// <param name="color">
        /// </param>
        void IBasicWidgetImage.UpdateColor(Color color)
        {
            this.imageComponent.color = color;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="sprite">
        /// </param>
        void IBasicWidgetImage.UpdateImage(Sprite sprite)
        {
            this.imageComponent.sprite = sprite;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="a">
        /// </param>
        void IBasicWidgetImage.UpdateTransparency(float a)
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
            private Color color = Color.white;
            // Todo
            private Sprite sprite = null;
            // Todo
            private float transparency = 0f;
            // Todo
            private Transform parentTransform = null;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IBasicWidgetImage Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    BasicWidgetImage basicWidgetImage = new GameObject(typeof(BasicWidgetImage).Name)
                        .AddComponent<BasicWidgetImage>();
                    Image image = basicWidgetImage.GetGameObject().AddComponent<Image>();
                    image.sprite = this.sprite;
                    this.color.a = this.transparency;
                    image.color = this.color;
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
            /// <param name="Color"></param>
            /// <returns></returns>
            public Builder SetColor(Color color)
            {
                this.color = color;
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
            /// <param name="sprite"></param>
            /// <returns></returns>
            public Builder SetSprite(Sprite sprite )
            {
                this.sprite = sprite;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="transparency"></param>
            /// <returns></returns>
            public Builder SetTransparency( float transparency)
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
                if (this.color == null)
                {
                    argumentExceptionSet.Add(typeof(Color).Name + " cannot be null.");
                }
                if (this.parentTransform == null)
                {
                    argumentExceptionSet.Add("Parent " + typeof(Transform).Name + " cannot be null.");
                }
                if (this.sprite == null)
                {
                    argumentExceptionSet.Add(typeof(Sprite).Name + " cannot be null.");
                }

                return argumentExceptionSet;
            }
        }
    }
}