using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.TurnOrders.Reports.Api;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.TurnOrders.Objects.Api
{
    /// <summary>
    /// TurnOrder Object Api
    /// </summary>
    public interface ITurnOrderObject
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonCallSign"></param>
        void TalonCallSignCompletedTurn(TalonCallSign talonCallSign);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ITurnOrderReport GetTurnOrderReport();
    }
}