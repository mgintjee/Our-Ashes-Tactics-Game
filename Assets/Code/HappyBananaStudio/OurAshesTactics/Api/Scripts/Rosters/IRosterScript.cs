/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Rosters;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Rosters;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Scripts.Mvc.Models;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Scripts.Unity;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Scripts.Rosters
{
    /// <summary>
    /// Roster Script Api
    /// </summary>
    public interface IRosterScript
        : IUnityScript
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IRosterObject GetRosterObject();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mcvModelScript">
        /// </param>
        /// <param name="rosterConstructionReport">
        /// </param>
        void Initialize(IMvcModelScript mcvModelScript, IRosterConstructionReport rosterConstructionReport);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        bool IsInitialized();
    }
}