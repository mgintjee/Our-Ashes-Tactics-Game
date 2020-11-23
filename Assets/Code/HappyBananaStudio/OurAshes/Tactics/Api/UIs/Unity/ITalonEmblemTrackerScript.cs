namespace HappyBananaStudio.OurAshes.Tactics.Api.UIs.Unity
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Information;
    using HappyBananaStudio.OurAshes.Tactics.Api.Unity.Scripts;

    /// <summary>
    /// Todo
    /// </summary>
    public interface ITalonEmblemTrackerScript
        : IUnityScript
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonIdentificationReport">
        /// </param>
        void SetTalonIdentificationReport(ITalonIdentificationReport talonIdentificationReport);
    }
}