namespace HappyBananaStudio.OurAshes.Tactics.Api.UIs.WidgetUIs.Basics
{
    using UnityEngine;

    /// <summary>
    /// Basic Text Widget Api
    /// </summary>
    public interface IBasicTextWidget
        : IWidgetUI
    {
        /// <summary>
        /// Todo
        /// </summary>
        void UpdateColor(Color color);

        /// <summary>
        /// Todo
        /// </summary>
        void UpdateFontSize(int fontSize);

        /// <summary>
        /// Todo
        /// </summary>
        void UpdateFontStyle(FontStyle fontStyle);

        /// <summary>
        /// Todo
        /// </summary>
        void UpdateText(string text);

        // Todo: Have methods for font/size/style/color
    }
}