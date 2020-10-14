
namespace HappyBananaStudio.OurAshes.Tactics.Api.MVCs.Initializers.Reports
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Maps.Games.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Api.Rosters.Reports;

    /// <summary>
    /// Todo
    /// </summary>
    public interface IMvcInitializationReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IGameMapConstructionReport GetGameMapConstructionReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        int GetGameRNGSeed();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IRosterConstructionReport GetRosterConstructionReport();
    }
}
