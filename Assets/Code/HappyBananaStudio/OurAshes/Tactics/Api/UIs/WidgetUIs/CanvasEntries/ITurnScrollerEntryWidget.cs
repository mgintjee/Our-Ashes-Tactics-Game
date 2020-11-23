namespace HappyBananaStudio.OurAshes.Tactics.Api.UIs.WidgetUIs.CanvasEntries
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Information;

    /// <summary>
    /// Todo
    /// </summary>
    public interface ITurnScrollerEntryWidget
        : ICanvasEntryWidget
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonIdentificationReport">
        /// </param>
        void Initialize(ITalonIdentificationReport talonIdentificationReport);
    }
}