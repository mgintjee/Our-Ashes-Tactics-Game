
namespace HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Actions.Orders
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Information;

    /// <summary>
    /// Todo
    /// </summary>
    public interface ITalonActionOrderFireReport
        : ITalonActionOrderReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ITalonIdentificationReport GetTargetTalonIdentificationReport();
    }
}
