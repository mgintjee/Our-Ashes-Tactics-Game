
namespace HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Actions.Orders
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Paths.Objects;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Information;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Talons;

    /// <summary>
    /// Todo
    /// </summary>
    public interface ITalonActionOrderReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ITalonIdentificationReport GetActingTalonIdentificationReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ActionType GetActionType();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IPathObject GetPathObject();
    }
}
