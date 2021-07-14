namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Rosters.Interfaces
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IRosterModel
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IRosterReport GetReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="controllerRequest"></param>
        /// <returns></returns>
        void Process(ISortieRequest controllerRequest, ICombatReport combatReport);

        /// <summary>
        /// Todo
        /// </summary>
        void ResetForNewPhase();
    }
}