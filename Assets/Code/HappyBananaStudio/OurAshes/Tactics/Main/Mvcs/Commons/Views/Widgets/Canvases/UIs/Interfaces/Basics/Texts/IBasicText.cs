using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Colors.IDs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Interfaces;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Canvases.UIs.Interfaces.Basics.Texts
{
    /// <summary>
    /// Basic Widget Text Interface
    /// </summary>
    public interface IBasicText : IWidget
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="colorID"></param>
        void UpdateColorID(ColorID colorID);

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