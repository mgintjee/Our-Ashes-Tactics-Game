using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Interfaces.Basics;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Implementations.Abstracts.Basics
{
    /// <summary>
    /// Todo
    /// </summary>
    public abstract class AbstractButtonWidget : AbstractWidget, IButtonWidget
    {
        /// <inheritdoc/>
        void IButtonWidget.onPress()
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc/>
        void IButtonWidget.onRelease()
        {
            throw new System.NotImplementedException();
        }
    }
}