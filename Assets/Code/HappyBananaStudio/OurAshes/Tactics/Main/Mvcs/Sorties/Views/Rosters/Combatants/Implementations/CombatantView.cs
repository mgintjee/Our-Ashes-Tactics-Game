using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Rosters.Combatants.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Rosters.Combatants.Scripts.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Rosters.Weapons.Collections.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Rosters.Combatants.Implementations
{
    /// <summary>
    /// Todo
    /// </summary>
    public class CombatantView
        : ICombatantView
    {
        // Todo
        private readonly ICombatantViewScript viewScript;

        // Todo
        private readonly IWeaponViewCollection weaponViewCollection;

        /// <summary>
        /// Todo
        /// </summary>
        private CombatantView()
        {
        }

        /// <inheritdoc/>
        void ICombatantView.Clear()
        {
            this.weaponViewCollection.Clear();
            this.viewScript.Destroy();
        }
    }
}