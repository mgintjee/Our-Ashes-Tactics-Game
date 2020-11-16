namespace HappyBananaStudio.OurAshes.Tactics.Impl.UIs.WidgetUIs.Basics
{
    using HappyBananaStudio.OurAshes.Tactics.Abs.UIs.WidgetUIs;
    using HappyBananaStudio.OurAshes.Tactics.Api.UIs.WidgetUIs.Basics;
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// Todo
    /// </summary>
    public class BasicTextWidgetImpl
        : AbstractWidgetUIImpl, IBasicTextWidget
    {
        // Todo
        private Text textComponent;

        /// <summary>
        /// Todo
        /// </summary>
        public void Awake()
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
        void IBasicTextWidget.UpdateColor(Color color)
        {
            this.textComponent.color = color;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="fontSize">
        /// </param>
        void IBasicTextWidget.UpdateFontSize(int fontSize)
        {
            this.textComponent.fontSize = fontSize;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="fontStyle">
        /// </param>
        void IBasicTextWidget.UpdateFontStyle(FontStyle fontStyle)
        {
            this.textComponent.fontStyle = fontStyle;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="text">
        /// </param>
        void IBasicTextWidget.UpdateText(string text)
        {
            textComponent.text = text;
        }
    }
}
