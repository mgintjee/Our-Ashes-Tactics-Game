namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Orders.Reports.Api
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Orders.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Pathing.Objects.Api;

    /// <summary>
    /// Todo
    /// </summary>
    public interface ITalonOrderReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        TalonCallSign GetActingTalonCallSign();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        OrderType GetActionType();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IPathObject GetPathObject();
    }
}