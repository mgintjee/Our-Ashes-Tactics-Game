using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Scripts.Unity.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Models.Responses.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Controllers.Requests.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Rosters.Combatants.Collections.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Rosters.Combatants.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Rosters.Combatants.Collections.Implementations
{
    /// <summary>
    /// Sortie Combatant View Collection Implementation
    /// </summary>
    public class CombatantViewCollection
        : ICombatantViewCollection
    {
        // Todo
        private readonly IList<ICombatantView> combatantViews = new List<ICombatantView>();

        private CombatantViewCollection()
        {
        }

        void ICombatantViewCollection.Clear()
        {
            foreach (ICombatantView view in combatantViews)
            {
                view.Clear();
            }
            combatantViews.Clear();
        }

        void ICombatantViewCollection.Process(ISortieControllerRequest controllerRequest)
        {
            throw new System.NotImplementedException();
        }

        void ICombatantViewCollection.Process(ISet<ISortieControllerRequest> controllerRequests)
        {
            throw new System.NotImplementedException();
        }

        void ICombatantViewCollection.Process(ISortieModelResponse modelResponse)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private IUnityScript unityScript;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public ICombatantViewCollection Build()
            {
                return new CombatantViewCollection();
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="unityScript"></param>
            /// <returns></returns>
            public Builder SetUnityScript(IUnityScript unityScript)
            {
                this.unityScript = unityScript;
                return this;
            }
        }
    }
}