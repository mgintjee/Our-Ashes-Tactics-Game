using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Responses.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Requests.Interfaces;
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
        void Process(ISortieRequest controllerRequest);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="controllerRequests"></param>
        void Process(ISet<ISortieRequest> controllerRequests);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcResponse"></param>
        void Process(IMvcResponse mvcResponse);
    }
}