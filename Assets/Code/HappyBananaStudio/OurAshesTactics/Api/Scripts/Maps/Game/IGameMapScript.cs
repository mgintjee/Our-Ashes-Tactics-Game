/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Maps.Game;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Maps.Game;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Scripts.Mvc.Models;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Scripts.Unity;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Scripts.Maps.Game
{
    /// <summary>
    /// Map Script Api
    /// </summary>
    public interface IGameMapScript
        : IUnityScript
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IGameMapObject GetGameMapObject();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mcvModelScript">
        /// </param>
        /// <param name="mapConstructionReport">
        /// </param>
        void Initialize(IMvcModelScript mcvModelScript, IGameMapConstructionReport mapConstructionReport);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        bool IsInitialized();
    }
}