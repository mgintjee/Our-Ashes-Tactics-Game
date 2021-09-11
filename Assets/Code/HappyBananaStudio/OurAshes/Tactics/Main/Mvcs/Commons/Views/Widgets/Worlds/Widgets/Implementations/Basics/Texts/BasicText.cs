using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Colors.IDs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Constants.Colors.Rgbs.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Interfaces;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Worlds.Widgets.Implementations.Basics.Texts
{
    /// <summary>
    /// Todo
    /// </summary>
    public class BasicText
        : AbstractWidget, IBasicText
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
        /// <param name="colorID"></param>
        void IBasicText.UpdateColorID(ColorID colorID)
        {
            this.textComponent.color = RgbsManager.GetUnityColor(colorID);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="fontSize"></param>
        void IBasicText.UpdateFontSize(int fontSize)
        {
            this.textComponent.fontSize = fontSize;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="fontStyle"></param>
        void IBasicText.UpdateFontStyle(FontStyle fontStyle)
        {
            this.textComponent.fontStyle = fontStyle;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="text"></param>
        void IBasicText.UpdateText(string text)
        {
            textComponent.text = text;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private ColorID colorID = ColorID.DimGray;

            // Todo
            private int fontSize = 0;

            // Todo
            private string fontString = "";

            // Todo
            private FontStyle fontStyle = FontStyle.Normal;

            // Todo
            private Transform parentTransform = null;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IBasicText Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    BasicText basicWidgetText = new GameObject(typeof(BasicText).Name)
                        .AddComponent<BasicText>();
                    Text text = basicWidgetText.GetGameObject().AddComponent<Text>();
                    text.font = Font.CreateDynamicFontFromOSFont("Arial", this.fontSize);
                    text.alignment = TextAnchor.MiddleCenter;
                    text.horizontalOverflow = HorizontalWrapMode.Overflow;
                    text.verticalOverflow = VerticalWrapMode.Overflow;
                    text.resizeTextForBestFit = true;
                    text.color = RgbsManager.GetUnityColor(this.colorID);
                    text.text = this.fontString;
                    text.fontStyle = this.fontStyle;
                    // Todo: Move this to being configurable
                    text.horizontalOverflow = HorizontalWrapMode.Wrap;
                    text.verticalOverflow = VerticalWrapMode.Truncate;
                    basicWidgetText.SetParent(this.parentTransform);
                    ((IWidget)basicWidgetText).GetRectTransform().sizeDelta = Vector2.zero;
                    return basicWidgetText;
                }
                throw ExceptionUtil.Arguments.Build("Unable to construct {}. Invalid Parameters. {}",
                    this.GetType(), string.Join("\n", invalidReasons));
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="Color"></param>
            /// <returns></returns>
            public Builder SetColorID(ColorID colorID)
            {
                this.colorID = colorID;
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
            /// <returns></returns>
            private ISet<string> IsInvalid()
            {
                // Default an empty Set: String
                ISet<string> argumentExceptionSet = new HashSet<string>();
                if (this.colorID == ColorID.None)
                {
                    argumentExceptionSet.Add(typeof(ColorID).Name + " cannot be none.");
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