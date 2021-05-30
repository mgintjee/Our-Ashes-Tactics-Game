using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Scripts.Unity.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Rosters.Combatants.Scripts.Mounts.Interfaces
{
    /// <summary>
    /// Sortie Combatant Mount Script Interface
    /// </summary>
    public interface ICombatantMountScript
        : IUnityScript
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IList<Transform> GetMountTransforms();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        bool AvailableMounts();
    }
}