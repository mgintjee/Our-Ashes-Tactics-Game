using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Fonts.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Builders.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Builders.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public class TextWidgetImpl
        : AbstractCanvasWidget, ITextWidget
    {
        // Todo
        protected string text;

        protected FontID fontID;

        /// <inheritdoc/>
        void ITextWidget.SetText(string text)
        {
            this.text = text;
            this.GetText().text = text;
        }

        protected UnityEngine.UI.Text GetText()
        {
            if (this.GetComponent<UnityEngine.UI.Text>() == null)
            {
                this.GetGameObject().AddComponent<UnityEngine.UI.Text>();
                this.GetComponent<UnityEngine.UI.Text>().resizeTextForBestFit = true;
            }
            return this.GetComponent<UnityEngine.UI.Text>();
        }

        void ITextWidget.SetFont(FontID fontID)
        {
            this.fontID = fontID;
            this.GetText().font = this.GetFont(this.fontID);
        }

        private UnityEngine.Font GetFont(FontID fontID)
        {
            return UnityEngine.Font.CreateDynamicFontFromOSFont(fontID.ToString(), 10);
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
                : IWidgetBuilder<ITextWidget>
            {
                ITextBuilder SetText(string text);
                ITextBuilder SetFont(FontID fontID);

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
                : AbstractWidgetBuilder<ITextWidget>, ITextBuilder
            {
                // Todo
                protected FontID fontID;
                // Todo
                protected string text;

                protected override void ValidateWidgetBuilder(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, this.text);
                    this.Validate(invalidReasons, this.fontID);
                }

                protected override ITextWidget BuildScript(UnityEngine.GameObject gameObject)
                {
                    ITextWidget TextWidget = gameObject.AddComponent<TextWidgetImpl>();
                    this.ApplyTextValues(TextWidget);
                    return TextWidget;
                }

                protected void ApplyTextValues(ITextWidget TextWidget)
                {
                    this.ApplyCommonValues(TextWidget);
                    TextWidget.SetText(this.text);
                    TextWidget.SetFont(this.fontID);
                }

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
            }
        }
    }
}