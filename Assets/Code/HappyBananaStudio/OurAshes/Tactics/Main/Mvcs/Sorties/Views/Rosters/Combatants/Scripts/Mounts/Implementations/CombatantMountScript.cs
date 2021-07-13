using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Scripts.Unity.Implementations.Abstract;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Rosters.Combatants.Scripts.Mounts.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Rosters.Combatants.Scripts.Mounts.Implementations
{
    /// <summary>
    /// Sortie Combatant Mount Script Implementation
    /// </summary>
    public class CombatantMountScript : AbstractUnityScript, ICombatantMountScript
    {
        // Todo
        [SerializeField]
        private readonly List<Transform> mountTransforms;

        /// <inheritdoc/>
        bool ICombatantMountScript.AvailableMounts()
        {
            foreach (Transform mount in mountTransforms)
            {
                if (mount.childCount == 0)
                {
                    return true;
                }
            }
            return false;
        }

        /// <inheritdoc/>
        IList<Transform> ICombatantMountScript.GetMountTransforms()
        {
            return new List<Transform>(mountTransforms);
        }
    }
}