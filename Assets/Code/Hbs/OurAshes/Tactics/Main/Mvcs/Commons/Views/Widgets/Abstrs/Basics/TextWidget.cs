using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Inters.Basics;
using UnityEngine.UI;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Abstrs.Basics
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