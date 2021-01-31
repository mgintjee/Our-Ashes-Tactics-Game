namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Objects.Api
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Actions.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Orders.Reports.Api;

    /// <summary>
    /// MvcModel Object Api
    /// </summary>
    public interface IMvcModelObject
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
        /// <param name="talonCallSign">
        /// </param>
        /// <returns>
        /// </returns>
        ITalonActionReport GetTalonActionReport(TalonCallSign talonCallSign);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonOrderReport">
        /// </param>
        /// <returns>
        /// </returns>
        void InputTalonOrderReport(ITalonOrderReport talonOrderReport);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IMvcModelReport GetMvcModelReport();
    }
}