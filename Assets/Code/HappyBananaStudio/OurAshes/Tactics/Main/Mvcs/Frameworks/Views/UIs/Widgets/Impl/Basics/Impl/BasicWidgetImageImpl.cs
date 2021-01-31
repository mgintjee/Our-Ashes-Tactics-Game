namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Widgets.Impl.Basics.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Widgets.Abs;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Widgets.Impl.Basics.Api;
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// Todo
    /// </summary>
    public class BasicWidgetImageImpl
        : BasicWidgetAbstractImpl, IBasicWidgetImage
    {
        // Todo
        private Image imageComponent;

        /// <summary>
        /// Todo
        /// </summary>
        public new void Awake()
        {
            this.imageComponent = this.GetGameObject().AddComponent<Image>();
            this.imageComponent.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 100);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="color">
        /// </param>
        void IBasicWidgetImage.UpdateColor(Color color)
        {
            this.imageComponent.color = color;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="sprite">
        /// </param>
        void IBasicWidgetImage.UpdateImage(Sprite sprite)
        {
            this.imageComponent.sprite = sprite;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="a">
        /// </param>
        void IBasicWidgetImage.UpdateTransparency(float a)
        {
            Color color = this.imageComponent.color;
            color.a = a;
            this.imageComponent.color = color;
        }
    }
}