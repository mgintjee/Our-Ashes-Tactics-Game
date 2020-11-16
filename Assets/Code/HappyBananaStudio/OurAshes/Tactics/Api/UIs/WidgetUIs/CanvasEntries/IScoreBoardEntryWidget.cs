namespace HappyBananaStudio.OurAshes.Tactics.Api.UIs.WidgetUIs.CanvasEntries
{
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Factions;

    /// <summary>
    /// ScoreBoardEntry Widget Api
    /// </summary>
    public interface IScoreBoardEntryWidget
        : ICanvasEntryWidget
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="factionId">
        /// </param>
        void Initialize(FactionId factionId);
    }
}
