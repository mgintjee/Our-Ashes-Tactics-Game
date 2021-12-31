using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Frames.Sorties.Maps.Spawns.Areas;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Frames.Sorties.Maps.Spawns.Sides;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Spawns.Positions.Inters
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