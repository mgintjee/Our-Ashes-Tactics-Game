namespace HappyBananaStudio.OurAshes.Tactics.Impl.UIs.WidgetUIs.Basics
{
    using HappyBananaStudio.OurAshes.Tactics.Abs.UIs.WidgetUIs;
    using HappyBananaStudio.OurAshes.Tactics.Api.UIs.WidgetUIs.Basics;
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// Todo
    /// </summary>
    public class BasicImageWidgetImpl
        : AbstractWidgetUIImpl, IBasicImageWidget
    {
        // Todo
        private Image imageComponent;

        /// <summary>
        /// Todo
        /// </summary>
        public void Awake()
        {
            this.imageComponent = this.GetGameObject().AddComponent<Image>();
            this.imageComponent.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 100);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="color">
        /// </param>
        void IBasicImageWidget.UpdateColor(Color color)
        {
            this.imageComponent.color = color;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="sprite">
        /// </param>
        void IBasicImageWidget.UpdateImage(Sprite sprite)
        {
            this.imageComponent.sprite = sprite;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="a">
        /// </param>
        void IBasicImageWidget.UpdateTransparency(float a)
        {
            Color color = this.imageComponent.color;
            color.a = a;
            this.imageComponent.color = color;
        }
    }
}