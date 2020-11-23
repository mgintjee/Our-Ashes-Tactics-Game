namespace HappyBananaStudio.OurAshes.Tactics.Api.UIs.WidgetUIs.Complex
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IScoreValueWidget
        : IWidgetUI
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="scoreValue">
        /// </param>
        void UpdateScoreText(string scoreValue);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="percent">
        /// </param>
        void UpdateScoreVisual(float percent);
    }
}