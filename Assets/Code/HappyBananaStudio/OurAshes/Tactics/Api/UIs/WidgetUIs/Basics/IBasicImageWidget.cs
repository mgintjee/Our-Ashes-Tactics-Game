namespace HappyBananaStudio.OurAshes.Tactics.Api.UIs.WidgetUIs.Basics
{
    using UnityEngine;

    /// <summary>
    /// Basic Image Widget Api
    /// </summary>
    public interface IBasicImageWidget
        : IWidgetUI
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="color">
        /// </param>
        void UpdateColor(Color color);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="sprite">
        /// </param>
        void UpdateImage(Sprite sprite);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="a">
        /// </param>
        void UpdateTransparency(float a);
    }
}