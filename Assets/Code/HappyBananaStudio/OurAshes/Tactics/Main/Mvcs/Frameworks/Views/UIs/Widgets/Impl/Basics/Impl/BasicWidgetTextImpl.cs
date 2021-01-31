namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Widgets.Impl.Basics.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Widgets.Abs;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Widgets.Impl.Basics.Api;
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// Todo
    /// </summary>
    public class BasicWidgetTextImpl
        : BasicWidgetAbstractImpl, IBasicWidgetText
    {
        // Todo
        private Text textComponent;

        /// <summary>
        /// Todo
        /// </summary>
        public new void Awake()
        {
            this.textComponent = this.GetGameObject().AddComponent<Text>();
            this.textComponent.font = Font.CreateDynamicFontFromOSFont("Arial", 14);
            this.textComponent.alignment = TextAnchor.MiddleCenter;
            this.textComponent.horizontalOverflow = HorizontalWrapMode.Overflow;
            this.textComponent.verticalOverflow = VerticalWrapMode.Overflow;
            this.textComponent.resizeTextForBestFit = true;
            this.textComponent.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 100);
            this.textComponent.color = Color.black;
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
    }
}