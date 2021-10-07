using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Interfaces.Basics;
using UnityEngine.UI;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Implementations.Abstracts.Basics
{
    /// <summary>
    /// Todo
    /// </summary>
    public class TextWidget : AbstractWidget, ITextWidget
    {
        protected Text text;

        /// <inheritdoc/>
        void ITextWidget.setText(string text)
        {
            this.text.text = text;
        }
    }
}