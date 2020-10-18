
namespace HappyBananaStudio.OurAshes.Tactics.Api.Widgets.ScoreBoards
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Widgets;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.GameTypes;

    /// <summary>
    /// ScoreBoard Widget Script Api
    /// </summary>
    public interface IScoreBoardWidget
        : IWidget
    {
        /// <summary>
        /// Todo
        /// </summary>
        void LoadEntryWidgets(GameTypeEnum gameType);

        /// <summary>
        /// Todo
        /// </summary>
        void UpdateEntryWidgets();
    }
}
