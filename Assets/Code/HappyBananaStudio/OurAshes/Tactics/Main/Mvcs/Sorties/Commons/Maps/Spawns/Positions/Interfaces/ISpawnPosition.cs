﻿namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Spawns.Positions.Interfaces
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