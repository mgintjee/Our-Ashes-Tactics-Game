using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.CallSigns.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Maps.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Maps.Spawns.Sides.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Maps.Coordinates.Cube.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Types.Enums;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Spawns.Positions.Interfaces
{
    /// <summary>
    /// Spawn Position Interface
    /// </summary>
    public interface ISpawnPosition
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        SpawnArea GetSpawnArea();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        SpawnSide GetSpawnSide();
    }
}