namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.TurnOrders.Managers
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.TurnOrders.Objects.Api;
    using System.Diagnostics;

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
        public static void SetTurnOrderObject(ITurnOrderObject turnOrderObject)
        {
            if (TurnOrderManager.turnOrderObject == null)
            {
                TurnOrderManager.turnOrderObject = turnOrderObject;
            }
            else
            {
                throw ExceptionUtil.Arguments.Build("Unable to ?. ? is already set.",
                    new StackFrame().GetMethod().Name, typeof(ITurnOrderObject));
            }
        }
    }
}