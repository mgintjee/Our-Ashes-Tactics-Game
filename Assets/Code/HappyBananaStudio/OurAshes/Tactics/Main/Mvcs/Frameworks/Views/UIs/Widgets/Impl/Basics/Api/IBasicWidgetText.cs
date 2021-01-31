namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Widgets.Impl.Basics.Api
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Widgets.Api;
    using UnityEngine;

    /// <summary>
    /// Basic Text Widget Api
    /// </summary>
    public interface IBasicWidgetText
        : IWidget
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