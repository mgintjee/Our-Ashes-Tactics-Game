using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Scripts.Unity.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Responses.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Rosters.Combatants.Collections.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Rosters.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Rosters.Scripts.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Rosters.Implementations
{
    /// <summary>
    /// Todo
    /// </summary>
    public class RosterView
        : IRosterView
    {
        // Todo
        private readonly IRosterViewScript rosterViewScript;

        private readonly ICombatantViewCollection combatantViewCollection;

        /// <summary>
        /// Todo
        /// </summary>
        private RosterView(IUnityScript unityScript)
        {
        }

        /// <inheritdoc/>
        bool IRosterView.IsProcessing()
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc/>
        void IRosterView.Process(ISortieResponse modelResponse)
        {
            combatantViewCollection.Process(modelResponse);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            internal IUnityScript unityScript;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IRosterView Build()
            {
                return new RosterView(unityScript);
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