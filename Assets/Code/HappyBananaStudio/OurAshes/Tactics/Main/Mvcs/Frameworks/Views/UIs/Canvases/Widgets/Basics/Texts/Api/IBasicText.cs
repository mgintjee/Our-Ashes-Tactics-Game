namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Widgets.Basics.Texts.Api
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Widgets.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Colors.Enums;
    using UnityEngine;

    /// <summary>
    /// Basic Widget Text Api
    /// </summary>
    public interface IBasicText
        : IWidget
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="colorId"></param>
        void UpdateColorId(ColorId colorId);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="fontSize"></param>
        void UpdateFontSize(int fontSize);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="fontStyle"></param>
        void UpdateFontStyle(FontStyle fontStyle);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="text"></param>
        void UpdateText(string text);

        // Todo: Have methods for font/size/style/color
    }
}