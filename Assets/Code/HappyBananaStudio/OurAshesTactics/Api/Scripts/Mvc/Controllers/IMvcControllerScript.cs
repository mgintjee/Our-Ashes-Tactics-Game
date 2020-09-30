/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Mvc.Controller;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Scripts.Mvc.Frameworks;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Scripts.Unity;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Scripts.Mvc.Controllers
{
    /// <summary>
    /// MvcController Script Api
    /// </summary>
    public interface IMvcControllerScript
        : IUnityScript
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IMvcControllerObject GetMvcControllerObject();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="gameFrameworkScript">
        /// </param>
        void Initialize(IMvcFrameworkScript gameFrameworkScript);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        bool IsInitialized();
    }
}