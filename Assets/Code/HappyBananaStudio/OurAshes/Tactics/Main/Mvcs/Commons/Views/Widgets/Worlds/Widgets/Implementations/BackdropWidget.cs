using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Sprites.IDs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Implementations.Abstracts.Basics;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Interfaces.Basics;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Worlds.Widgets.Implementations
{
    /// <summary>
    /// World Backdrop Widget Interface
    /// </summary>
    public class BackdropWidget : AbstractImageWidget, IImageWidget
    {
        /// <summary>
        /// Todo
        /// </summary>
        public BackdropWidget()
        {
            ((IImageWidget)this).SetSpriteID(SpriteID.Square);
        }
    }
}