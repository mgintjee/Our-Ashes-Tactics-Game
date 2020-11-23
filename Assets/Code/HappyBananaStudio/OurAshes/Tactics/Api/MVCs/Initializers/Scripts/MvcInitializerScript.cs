namespace HappyBananaStudio.OurAshes.Tactics.Api.MVCs.Initializers.Scripts
{
    using HappyBananaStudio.OurAshes.Tactics.Api.MVCs.Initializers.Reports;

    /// <summary>
    /// MvcInitializer Script Api
    /// Todo: Have an object initializer too
    /// </summary>
    public interface IMvcInitializerScript
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IMvcInitializationReport BuildMvcInitializationReport();
    }
}