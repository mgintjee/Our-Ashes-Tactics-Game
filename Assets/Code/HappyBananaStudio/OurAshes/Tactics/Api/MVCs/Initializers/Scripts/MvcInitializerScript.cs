/// <summary>
/// Company: HappyBananaStudio
/// Author: Matthew Gintjee
/// </summary>
/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshes.Tactics.Api.MVCs.Initializers.Reports;

namespace HappyBananaStudio.OurAshes.Tactics.Api.MVCs.Initializers.Scripts
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
