using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Resources.Loaders.Sprites;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Sprites.IDs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Interfaces.Basics;
using UnityEngine.UI;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Implementations.Abstracts.Basics
{
    /// <summary>
    /// Todo
    /// </summary>
    public abstract class AbstractImageWidget : AbstractWidget, IImageWidget
    {
        protected Image image;
        protected SpriteID spriteID;

        /// <inheritdoc/>
        void IImageWidget.SetSpriteID(SpriteID spriteID)
        {
            this.spriteID = spriteID;
            this.image.sprite = SpriteResourceLoader.LoadSpriteResource(spriteID).GetValue();
        }
    }
}