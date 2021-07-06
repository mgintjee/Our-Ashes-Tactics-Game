using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.CallSigns;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Spawns.Positions.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Constructions.Interfaces
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IMapConstruction
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        bool GetMirroredMap();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        int GetRadius();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IDictionary<CombatantCallSign, ISpawnPosition> GetCombatantCallSignSpawnPosition();
    }
}