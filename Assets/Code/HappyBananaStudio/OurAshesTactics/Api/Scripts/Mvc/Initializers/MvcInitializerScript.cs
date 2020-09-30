/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Mvc.Initializers;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Scripts.Mvc.Initializers
{
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