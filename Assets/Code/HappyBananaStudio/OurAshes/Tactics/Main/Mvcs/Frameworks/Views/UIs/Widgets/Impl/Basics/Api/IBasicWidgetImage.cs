namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Widgets.Impl.Basics.Api
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Widgets.Api;
    using UnityEngine;

    /// <summary>
    /// Basic Image Widget Api
    /// </summary>
    public interface IBasicWidgetImage
        : IWidget
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