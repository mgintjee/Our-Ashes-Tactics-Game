
namespace HappyBananaStudio.OurAshes.Tactics.Api.Widgets.ScoreBoards.Entries
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Emblems.Widgets.Emblems;
    using HappyBananaStudio.OurAshes.Tactics.Api.Widgets;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Factions;

    /// <summary>
    /// ScoreBoard Faction Widget Api
    /// </summary>
    public interface IScoreBoardFactionWidget
        : IWidget
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="factionId"></param>
        void Initialize(FactionIdEnum factionId);

        /// <summary>
        /// Todo
        /// </summary>
        void UpdateEntry();
    }
}
