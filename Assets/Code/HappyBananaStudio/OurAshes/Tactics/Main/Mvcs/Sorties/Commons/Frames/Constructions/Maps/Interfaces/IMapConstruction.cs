using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.CallSigns.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Maps.Coordinates.Cube.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Spawns.Positions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Types.Enums;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Constructions.Maps.Interfaces
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