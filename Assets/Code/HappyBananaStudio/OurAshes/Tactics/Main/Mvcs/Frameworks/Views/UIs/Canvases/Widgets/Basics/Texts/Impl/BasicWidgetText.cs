namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Widgets.Basics.Texts.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Widgets.Basics.Abs;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Widgets.Basics.Texts.Api;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// Todo
    /// </summary>
    public class BasicWidgetText
        : AbstractBasicWidget, IBasicWidgetText
    {
        // Todo
        private Text textComponent;

        /// <summary>
        /// Todo
        /// </summary>
        public new void Awake()
        {
            this.textComponent = this.GetComponent<Text>();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="color">
        /// </param>
        void IBasicWidgetText.UpdateColor(Color color)
        {
            this.textComponent.color = color;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="fontSize">
        /// </param>
        void IBasicWidgetText.UpdateFontSize(int fontSize)
        {
            this.textComponent.fontSize = fontSize;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="fontStyle">
        /// </param>
        void IBasicWidgetText.UpdateFontStyle(FontStyle fontStyle)
        {
            this.textComponent.fontStyle = fontStyle;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="text">
        /// </param>
        void IBasicWidgetText.UpdateText(string text)
        {
            textComponent.text = text;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private Color color = Color.white;
            // Todo
            private int fontSize = 0;
            // Todo
            private FontStyle fontStyle = FontStyle.Normal;
            // Todo
            private string fontString = "";
            // Todo
            private Transform parentTransform = null;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IBasicWidgetText Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    BasicWidgetText basicWidgetText = new GameObject(typeof(BasicWidgetText).Name)
                        .AddComponent<BasicWidgetText>();
                    Text text = basicWidgetText.GetGameObject().AddComponent<Text>();
                    text.font = Font.CreateDynamicFontFromOSFont("Arial", this.fontSize);
                    text.alignment = TextAnchor.MiddleCenter;
                    text.horizontalOverflow = HorizontalWrapMode.Overflow;
                    text.verticalOverflow = VerticalWrapMode.Overflow;
                    text.resizeTextForBestFit = true;
                    text.color = this.color;
                    text.text = this.fontString;
                    text.fontStyle = this.fontStyle;
                    basicWidgetText.GetTransform().SetParent(this.parentTransform);
                    basicWidgetText.GetTransform().localPosition = Vector3.zero;
                    basicWidgetText.GetTransform().localScale = Vector3.one;
                    return basicWidgetText;
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
            /// <param name="fontStyle"></param>
            /// <returns></returns>
            public Builder SetFontStyle(FontStyle fontStyle)
            {
                this.fontStyle = fontStyle; ;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="fontString"></param>
            /// <returns></returns>
            public Builder SetFontString(string fontString)
            {
                this.fontString = fontString;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="fontSize"></param>
            /// <returns></returns>
            public Builder SetFontSize(int fontSize)
            {
                this.fontSize = fontSize;
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
                if (this.fontSize == 0)
                {
                    argumentExceptionSet.Add("fontSize cannot be zero.");
                }
                if (this.fontString.Length == 0)
                {
                    argumentExceptionSet.Add("fontString cannot be empty.");
                }

                return argumentExceptionSet;
            }
        }
    }
}