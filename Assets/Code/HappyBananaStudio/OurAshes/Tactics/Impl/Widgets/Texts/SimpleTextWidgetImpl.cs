namespace HappyBananaStudio.OurAshes.Tactics.Impl.Widgets.Texts
{
    using HappyBananaStudio.OurAshes.Tactics.Abs.Widgets;
    using HappyBananaStudio.OurAshes.Tactics.Api.Widgets.Texts;
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// Todo
    /// </summary>
    public class SimpleTextWidgetImpl
        : AbstractWidgetImpl, ISimpleTextWidget
    {
        // Todo
        [SerializeField] private Text text;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="text"></param>
        void ISimpleTextWidget.UpdateText(string text)
        {
            this.text.text = text;
        }
    }
}
