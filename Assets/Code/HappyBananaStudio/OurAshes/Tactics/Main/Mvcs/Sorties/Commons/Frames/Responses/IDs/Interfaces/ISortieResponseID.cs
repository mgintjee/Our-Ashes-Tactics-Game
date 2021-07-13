namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Responses.IDs.Interfaces
{
    /// <summary>
    /// Sortie Response ID Interface
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
        /// Create a new IMvcResponseID with an incremented Action value
        /// </summary>
        /// <returns></returns>
        ISortieResponseID IncrementAction();

        /// <summary>
        /// Create a new IMvcResponseID with an incremented Phase value
        /// </summary>
        /// <returns></returns>
        ISortieResponseID IncrementPhase();

        /// <summary>
        /// Create a new IMvcResponseID with an incremented Turn value
        /// </summary>
        /// <returns></returns>
        ISortieResponseID IncrementTurn();
    }
}