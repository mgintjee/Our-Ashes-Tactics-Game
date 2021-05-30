using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Scripts.Unity.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Rosters.Combatants.Scripts.Mounts.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Rosters.Combatants.Scripts.Interfaces
{
    /// <summary>
    /// Sortie Combatant View Script Interface
    /// </summary>
    public interface ICombatantViewScript
        : IUnityScript
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ICombatantMountScript GetCombatantMountScript();
    }
}