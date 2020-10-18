
namespace HappyBananaStudio.OurAshes.Tactics.Api.Widgets.Texts
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Widgets;

    /// <summary>
    /// SimpleText Widget Script Api
    /// </summary>
    public interface ISimpleTextWidget
        : IWidget
    {
        /// <summary>
        /// Todo
        /// </summary>
        void UpdateText(string text);
    }
}
