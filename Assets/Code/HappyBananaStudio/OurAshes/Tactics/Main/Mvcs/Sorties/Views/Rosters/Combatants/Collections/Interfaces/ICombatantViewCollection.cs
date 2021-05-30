using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Models.Responses.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Controllers.Requests.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Rosters.Combatants.Collections.Interfaces
{
    /// <summary>
    /// Sortie Combatant View Collection Interface
    /// </summary>
    public interface ICombatantViewCollection
    {
        /// <summary>
        /// Todo
        /// </summary>
        void Clear();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="controllerRequest"></param>
        void Process(ISortieControllerRequest controllerRequest);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="controllerRequests"></param>
        void Process(ISet<ISortieControllerRequest> controllerRequests);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="modelResponse"></param>
        void Process(ISortieModelResponse modelResponse);
    }
}