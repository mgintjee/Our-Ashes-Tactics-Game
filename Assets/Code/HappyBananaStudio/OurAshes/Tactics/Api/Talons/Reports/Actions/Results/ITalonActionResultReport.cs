
namespace HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Actions.Results
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Actions.Orders;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Attributes;

    /// <summary>
    /// Todo
    /// </summary>
    public interface ITalonActionResultReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ITalonActionOrderReport GetTalonActionOrder();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ITalonAttributesReport GetActingTalonAttributesReport();
    }
}
