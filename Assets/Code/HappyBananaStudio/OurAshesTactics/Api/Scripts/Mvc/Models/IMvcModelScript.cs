/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Mvc.Models;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Maps.Game;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Rosters;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Action;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Scripts.Mvc.Frameworks;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Scripts.Unity;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Scripts.Mvc.Models
{
    /// <summary>
    /// MvcModel Script Api
    /// </summary>
    public interface IMvcModelScript
        : IUnityScript
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonActionOrderReport">
        /// </param>
        void AnimatePath(ITalonActionOrderReport talonActionOrderReport);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IMvcModelObject GetMvcModelObject();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameworkScript">
        /// </param>
        /// <param name="mapConstructionReport">
        /// </param>
        /// <param name="rosterConstructionReport">
        /// </param>
        void Initialize(IMvcFrameworkScript mvcFrameworkScript,
            IGameMapConstructionReport mapConstructionReport,
            IRosterConstructionReport rosterConstructionReport);

        /// <summary>
        /// /Todo
        /// </summary>
        /// <returns>
        /// </returns>
        bool IsAnimating();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        bool IsInitialized();
    }
}