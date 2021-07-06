using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Colors.IDs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Sprites.IDs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Implementations.Basics.Images;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Implementations.Basics.Texts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Implementations.Complexes.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Interfaces.Complexes.Texts;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Implementations.Complexes.Texts
{   /// <summary>
    /// Todo </summary>
    public class ComplexText
        : AbstractComplexWidget, IComplexText
    {
        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private ColorID _imageColorId = ColorID.None;

            // Todo
            private SpriteID _imageSpriteId = SpriteID.None;

            // Todo
            private float _imageTransparency = 0.0f;

            // Todo
            private Transform _parentTransform = null;

            // Todo
            private ColorID _textColorId = ColorID.None;

            // Todo
            private int _textFontSize = 0;

            // Todo
            private FontStyle _textFontStyle = FontStyle.Normal;

            // Todo
            private string _textString = null;

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
                    ComplexText complexText =
                        new GameObject(typeof(ComplexText).Name)
                        .AddComponent<ComplexText>();
                    complexText.childWidgetSet.Add(new BasicImage.Builder()
                        .SetParentTransform(complexText.GetTransform())
                        .SetColorId(_imageColorId)
                        .SetSpriteId(_imageSpriteId)
                        .SetTransparency(_imageTransparency)
                        .Build());
                    complexText.childWidgetSet.Add(new BasicText.Builder()
                        .SetParentTransform(complexText.GetTransform())
                        .SetColorId(_textColorId)
                        .SetFontString(_textString)
                        .SetFontSize(_textFontSize)
                        .SetFontStyle(_textFontStyle)
                        .Build());
                    complexText.SetParent(_parentTransform);
                    return complexText;
                }
                throw ExceptionUtil.Arguments.Build("Unable to construct {}. Invalid Parameters. {}",
                    this.GetType(), string.Join("\n", invalidReasons));
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="colorId"></param>
            /// <returns></returns>
            public Builder SetImageColorId(ColorID colorId)
            {
                _imageColorId = colorId;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="spriteId"></param>
            /// <returns></returns>
            public Builder SetImageSpriteId(SpriteID spriteId)
            {
                _imageSpriteId = spriteId;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="transparency"></param>
            /// <returns></returns>
            public Builder SetImageTransparency(float transparency)
            {
                _imageTransparency = transparency;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="parentTransform"></param>
            /// <returns></returns>
            public Builder SetParentTransform(Transform parentTransform)
            {
                _parentTransform = parentTransform;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="colorId"></param>
            /// <returns></returns>
            public Builder SetTextColorId(ColorID colorId)
            {
                _textColorId = colorId;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="fontSize"></param>
            /// <returns></returns>
            public Builder SetTextFontSize(int fontSize)
            {
                _textFontSize = fontSize;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="fontStyle"></param>
            /// <returns></returns>
            public Builder SetTextFontStyle(FontStyle fontStyle)
            {
                _textFontStyle = fontStyle;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="textString"></param>
            /// <returns></returns>
            public Builder SetTextString(string textString)
            {
                _textString = textString;
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
                if (_parentTransform == null)
                {
                    argumentExceptionSet.Add("Parent " + typeof(Transform).Name + " cannot be null.");
                }
                if (_textColorId == ColorID.None)
                {
                    argumentExceptionSet.Add("Text " + typeof(ColorID).Name + " cannot be none.");
                }
                if (_imageColorId == ColorID.None)
                {
                    argumentExceptionSet.Add("Image " + typeof(ColorID).Name + " cannot be none.");
                }
                return argumentExceptionSet;
            }
        }
    }
}