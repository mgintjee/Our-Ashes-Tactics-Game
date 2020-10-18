namespace HappyBananaStudio.OurAshes.Tactics.Impl.Widgets.Emblems
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Emblems.Widgets.Emblems;
    using HappyBananaStudio.OurAshes.Tactics.Api.Widgets;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Schemes.Color;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Schemes.Emblem;
    using HappyBananaStudio.OurAshes.Tactics.Common.ResourceLoaders;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Emblems;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Unity.Scripts;
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// Todo
    /// </summary>
    public class EmblemWidgetImpl
        : UnityScriptImpl, IEmblemWidget
    {
        [SerializeField] private Image backgroundImage;
        [SerializeField] private Image foregroundImage;
        [SerializeField] private Image iconImage;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="color"></param>
        void IEmblemWidget.UpdateBackgroundColor(ColorIdEnum color)
        {
            this.backgroundImage.color = EmblemColorUtil.GetColor(color);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="color">
        /// </param>
        void IEmblemWidget.UpdateForegroundColor(ColorIdEnum color)
        {
            this.foregroundImage.color = EmblemColorUtil.GetColor(color);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="emblemForegroundId">
        /// </param>
        void IEmblemWidget.UpdateForegroundSprite(EmblemForegroundIdEnum emblemForegroundId)
        {
            this.foregroundImage.sprite = SpriteResourceLoader.Foreground.LoadSpriteForegroundResource(emblemForegroundId);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="color">
        /// </param>
        void IEmblemWidget.UpdateIconColor(ColorIdEnum color)
        {
            this.iconImage.color = EmblemColorUtil.GetColor(color);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="emblemIconId">
        /// </param>
        void IEmblemWidget.UpdateIconSprite(EmblemIconIdEnum emblemIconId)
        {
            this.iconImage.sprite = SpriteResourceLoader.Icon.LoadSpriteIconResource(emblemIconId);
        }
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="transparency"></param>
        void IEmblemWidget.UpdateTransparency(float transparency)
        {
            Color backgroundColor = this.backgroundImage.color;
            Color foregroundColor = this.foregroundImage.color;
            Color iconColor = this.iconImage.color;
            backgroundColor.a = transparency;
            foregroundColor.a = transparency;
            iconColor.a = transparency;
            this.backgroundImage.color = backgroundColor;
            this.foregroundImage.color = foregroundColor;
            this.iconImage.color = iconColor;
        }

        /// <summary>
        /// Todo
        /// </summary>
        void IWidget.UpdateWidgetDimensions()
        {
            this.GetTransform().localScale = Vector3.one;
        }
        /// <summary>
        /// Todo
        /// </summary>
        void IWidget.UpdateWidgetPosition()
        {
            this.GetTransform().localPosition = Vector3.zero;
        }
    }
}
