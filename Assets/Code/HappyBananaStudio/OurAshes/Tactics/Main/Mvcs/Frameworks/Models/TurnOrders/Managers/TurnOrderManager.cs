namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.TurnOrders.Managers
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.TurnOrders.Objects.Api;

    /// <summary>
    /// Roster Manager
    /// </summary>
    public class TurnOrderManager
    {
        // Todo
        private static ITurnOrderObject turnOrderObject;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="turnOrderObject"></param>
        public static void SetRoeObject(ITurnOrderObject turnOrderObject)
        {
            TurnOrderManager.turnOrderObject = turnOrderObject;
        }
    }
}