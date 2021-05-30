namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Models.Responses.IDs.Interfaces
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface ISortieResponseID
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        int GetAction();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        int GetPhase();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        int GetTurn();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ISortieResponseID IncrementAction();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ISortieResponseID IncrementPhase();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ISortieResponseID IncrementTurn();
    }
}