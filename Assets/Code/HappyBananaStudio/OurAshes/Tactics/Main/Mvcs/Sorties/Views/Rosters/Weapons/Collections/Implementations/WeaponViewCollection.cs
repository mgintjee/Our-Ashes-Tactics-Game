using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Responses.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Unity.Scripts.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Frames.Requests.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Rosters.Combatants.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Rosters.Weapons.Collections.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Rosters.Weapons.Collections.Implementations
{
    /// <summary>
    /// Sortie Combatant View Collection Implementation
    /// </summary>
    public class WeaponViewCollection
        : IWeaponViewCollection
    {
        // Todo
        private readonly IList<ICombatantView> tileViews = new List<ICombatantView>();

        private WeaponViewCollection()
        {
        }

        void IWeaponViewCollection.Clear()
        {
            foreach (ICombatantView tileView in tileViews)
            {
                tileView.Clear();
            }
            tileViews.Clear();
        }

        void IWeaponViewCollection.Process(ISortieRequest controllerRequest)
        {
            throw new System.NotImplementedException();
        }

        void IWeaponViewCollection.Process(ISet<ISortieRequest> controllerRequests)
        {
            throw new System.NotImplementedException();
        }

        void IWeaponViewCollection.Process(IMvcResponse mvcResponse)
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
            public IWeaponViewCollection Build()
            {
                return new WeaponViewCollection();
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