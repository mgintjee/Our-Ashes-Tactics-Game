namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Widgets.Complex.Texts.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Colors.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Widgets.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Widgets.Basics.Images.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Widgets.Basics.Texts.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Widgets.Complex.Abs;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Widgets.Complex.Texts.Api;
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// Todo
    /// </summary>
    public class ComplexText
        : AbstractComplexWidget, IComplexText
    {
        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private Transform parentTransform = null;

            // Todo
            private string textString = null;

            // Todo
            private ColorId imageColorId = ColorId.None;

            // Todo
            private ColorId textColorId = ColorId.None;

            // Todo
            private float imageTransparency = 0.0f;

            // Todo
            private SpriteId imageSpriteId = SpriteId.None;

            // Todo
            private int textFontSize = 0;

            // Todo
            private FontStyle textFontStyle = FontStyle.Normal;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IComplexText Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    IComplexText complexText =
                        new GameObject(typeof(ComplexText).Name)
                        .AddComponent<ComplexText>();
                    ((ComplexText)complexText).childWidgetSet.Add(new BasicImage.Builder()
                        .SetParentTransform(complexText.GetTransform())
                        .SetColorId(this.imageColorId)
                        .SetSpriteId(this.imageSpriteId)
                        .SetTransparency(this.imageTransparency)
                        .Build());
                    ((ComplexText)complexText).childWidgetSet.Add(new BasicText.Builder()
                        .SetParentTransform(complexText.GetTransform())
                        .SetColorId(this.textColorId)
                        .SetFontString(this.textString)
                        .SetFontSize(this.textFontSize)
                        .SetFontStyle(this.textFontStyle)
                        .Build());
                    foreach (IWidget childWidget in ((ComplexText)complexText).childWidgetSet)
                    {
                        childWidget.SetWidgetDimensions(complexText.GetRectTransform().sizeDelta);
                    }
                    complexText.GetTransform().SetParent(this.parentTransform);
                    complexText.GetTransform().localPosition = Vector3.zero;
                    complexText.GetTransform().localScale = Vector3.one;
                    return complexText;
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
            /// <param name="textString"></param>
            /// <returns></returns>
            public Builder SetTextString(string textString)
            {
                this.textString = textString;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="colorId"></param>
            /// <returns></returns>
            public Builder SetImageColorId(ColorId colorId)
            {
                this.imageColorId = colorId;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="colorId"></param>
            /// <returns></returns>
            public Builder SetTextColorId(ColorId colorId)
            {
                this.textColorId = colorId;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="spriteId"></param>
            /// <returns></returns>
            public Builder SetImageSpriteId(SpriteId spriteId)
            {
                this.imageSpriteId = spriteId;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="transparency"></param>
            /// <returns></returns>
            public Builder SetImageTransparency(float transparency)
            {
                this.imageTransparency = transparency;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="fontSize"></param>
            /// <returns></returns>
            public Builder SetTextFontSize(int fontSize)
            {
                this.textFontSize = fontSize;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="fontStyle"></param>
            /// <returns></returns>
            public Builder SetTextFontStyle(FontStyle fontStyle)
            {
                this.textFontStyle = fontStyle;
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
                if (this.parentTransform == null)
                {
                    argumentExceptionSet.Add("Parent " + typeof(Transform).Name + " cannot be null.");
                }
                if (this.textColorId == ColorId.None)
                {
                    argumentExceptionSet.Add("Text " + typeof(ColorId).Name + " cannot be none.");
                }
                if (this.imageColorId == ColorId.None)
                {
                    argumentExceptionSet.Add("Image " + typeof(ColorId).Name + " cannot be none.");
                }
                return argumentExceptionSet;
            }
        }
    }
}