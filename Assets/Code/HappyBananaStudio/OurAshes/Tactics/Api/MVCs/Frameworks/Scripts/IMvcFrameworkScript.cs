namespace HappyBananaStudio.OurAshes.Tactics.Api.MVCs.Frameworks.Scripts
{
    using HappyBananaStudio.OurAshes.Tactics.Api.MVCs.Frameworks.Objects;
    using HappyBananaStudio.OurAshes.Tactics.Api.MVCs.Initializers.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Api.Unity.Scripts;

    /// <summary>
    /// MvcFramework Script Api
    /// </summary>
    public interface IMvcFrameworkScript
        : IUnityScript
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IMvcFrameworkObject GetMvcFrameworkObject();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcInitializationReport">
        /// </param>
        void Initialize(IMvcInitializationReport mvcInitializationReport);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        bool IsGameActive();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        bool IsInitialized();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        void ResetMvcFramework();
    }
}