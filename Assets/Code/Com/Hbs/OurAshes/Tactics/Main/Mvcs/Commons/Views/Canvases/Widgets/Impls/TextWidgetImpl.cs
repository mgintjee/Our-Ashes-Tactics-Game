using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Utils.Strings;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Managers;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Fonts.Aligns;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Fonts.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Impls
{
    /// <summary>
    /// Text Widget Implementation
    /// </summary>
    public class TextWidgetImpl
        : AbstractCanvasWidget, ITextWidget
    {
        // Todo
        private string text;

        // Todo
        private FontID fontID;

        // Todo
        private int size;

        // Todo
        private bool bestFit;

        // Todo
        private ColorID colorID;

        // Todo
        private AlignType alignType;

        /// <inheritdoc/>
        void ITextWidget.SetText(string text)
        {
            logger.Debug("W|{}: Setting Text={}", this.widgetName, text);
            this.text = text;
            this.GetText().text = text;
        }
        /// <inheritdoc/>
        void ITextWidget.SetText(object obj)
        {
            ((ITextWidget)this).SetText(obj.ToString());
        }

        /// <inheritdoc/>
        void ITextWidget.SetFont(FontID fontID)
        {
            logger.Debug("W|{}: Setting {}", this.widgetName, StringUtils.Format(fontID));
            this.fontID = fontID;
            this.GetText().font = this.GetFont(this.fontID);
        }

        /// <inheritdoc/>
        void ITextWidget.SetSize(int size)
        {
            logger.Debug("W|{}: Setting Size={}", this.widgetName, size);
            this.size = size;
            this.GetText().fontSize = size;
        }

        /// <inheritdoc/>
        void ITextWidget.SetBestFit(bool bestFit, int minSize, int maxSize)
        {
            this.bestFit = bestFit;
            this.GetText().resizeTextForBestFit = bestFit;
            this.GetText().resizeTextMinSize = minSize;
            this.GetText().resizeTextMaxSize = maxSize;
        }

        /// <inheritdoc/>
        void ITextWidget.SetColorID(ColorID colorID)
        {
            logger.Debug("W|{}: Setting {}", this.widgetName, StringUtils.Format(colorID));
            this.colorID = colorID;
            this.GetText().color = RgbManager.GetUnityColor(colorID);
        }

        /// <inheritdoc/>
        void ITextWidget.SetAlignType(AlignType alignType)
        {
            logger.Debug("W|{}: Setting {}", this.widgetName, StringUtils.Format(alignType));
            this.alignType = alignType;
            this.GetText().alignment = this.GetTextAnchor(this.alignType);
        }

        private UnityEngine.UI.Text GetText()
        {
            if (this.GetComponent<UnityEngine.UI.Text>() == null)
            {
                this.GetGameObject().AddComponent<UnityEngine.UI.Text>();
            }
            return this.GetComponent<UnityEngine.UI.Text>();
        }

        private UnityEngine.Font GetFont(FontID fontID)
        {
            // Todo
            return UnityEngine.Font.CreateDynamicFontFromOSFont(fontID.ToString(), 10);
        }

        private UnityEngine.TextAnchor GetTextAnchor(AlignType alignType)
        {
            switch (alignType)
            {
                case AlignType.TopLeft:
                    return UnityEngine.TextAnchor.UpperLeft;

                case AlignType.TopCenter:
                    return UnityEngine.TextAnchor.UpperCenter;

                case AlignType.TopRight:
                    return UnityEngine.TextAnchor.UpperRight;

                case AlignType.MiddleLeft:
                    return UnityEngine.TextAnchor.MiddleLeft;

                case AlignType.MiddleCenter:
                    return UnityEngine.TextAnchor.MiddleCenter;

                case AlignType.MiddleRight:
                    return UnityEngine.TextAnchor.MiddleRight;

                case AlignType.BottomLeft:
                    return UnityEngine.TextAnchor.LowerLeft;

                case AlignType.BottomCenter:
                    return UnityEngine.TextAnchor.LowerCenter;

                case AlignType.BottomRight:
                    return UnityEngine.TextAnchor.LowerRight;

                default:
                    return UnityEngine.TextAnchor.MiddleCenter;
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
            public interface ITextBuilder
                : AbstractWidgetBuilders.IWidgetBuilder<ITextWidget>
            {
                ITextBuilder SetText(string text);

                ITextBuilder SetText(object obj);

                ITextBuilder SetFont(FontID fontID);

                ITextBuilder SetColor(ColorID colorID);

                ITextBuilder SetAlign(AlignType alignType);

                ITextBuilder SetBestFit(bool bestFit, int minSize, int maxSize);

                ITextBuilder SetSize(int size);
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public static ITextBuilder Get()
            {
                return new InternalBuilder();
            }

            /// <summary>
            /// Todo
            /// </summary>
            private class InternalBuilder
                : AbstractWidgetBuilders.AbstractWidgetBuilder<ITextWidget>, ITextBuilder
            {
                // Todo
                protected FontID fontID;

                // Todo
                protected string text;

                // Todo
                protected int size;

                // Todo
                protected int minSize;

                // Todo
                protected int maxSize;

                // Todo
                protected bool bestFit;

                // Todo
                protected AlignType alignType;

                // Todo
                protected ColorID colorID;

                ITextBuilder ITextBuilder.SetText(string text)
                {
                    this.text = text;
                    return this;
                }

                ITextBuilder ITextBuilder.SetFont(FontID fontID)
                {
                    this.fontID = fontID;
                    return this;
                }

                ITextBuilder ITextBuilder.SetAlign(AlignType alignType)
                {
                    this.alignType = alignType;
                    return this;
                }

                ITextBuilder ITextBuilder.SetBestFit(bool bestFit, int minSize, int maxSize)
                {
                    this.bestFit = bestFit;
                    this.minSize = minSize;
                    this.maxSize = maxSize;
                    return this;
                }

                ITextBuilder ITextBuilder.SetSize(int size)
                {
                    this.size = size;
                    return this;
                }

                ITextBuilder ITextBuilder.SetText(object obj)
                {
                    this.text = obj.ToString();
                    return this;
                }

                ITextBuilder ITextBuilder.SetColor(ColorID colorID)
                {
                    this.colorID = colorID;
                    return this;
                }

                protected override void ValidateWidgetBuilder(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, this.text);
                    this.Validate(invalidReasons, this.fontID);
                    this.Validate(invalidReasons, this.size);
                    this.Validate(invalidReasons, this.alignType);
                    this.Validate(invalidReasons, this.colorID);
                }

                protected override ITextWidget BuildScript(UnityEngine.GameObject gameObject)
                {
                    ITextWidget textWidget = gameObject.AddComponent<TextWidgetImpl>();
                    this.ApplyTextValues(textWidget);
                    return textWidget;
                }

                protected void ApplyTextValues(ITextWidget textWidget)
                {
                    this.ApplyCommonValues(textWidget);
                    textWidget.SetText(this.text);
                    textWidget.SetFont(this.fontID);
                    textWidget.SetAlignType(this.alignType);
                    textWidget.SetBestFit(this.bestFit, this.minSize, this.maxSize);
                    textWidget.SetSize(this.size);
                    textWidget.SetColorID(this.colorID);
                }
            }
        }
    }
}