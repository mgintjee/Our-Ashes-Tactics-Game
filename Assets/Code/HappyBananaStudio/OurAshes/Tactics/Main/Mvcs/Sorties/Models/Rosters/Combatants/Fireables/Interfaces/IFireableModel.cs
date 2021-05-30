﻿using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Fireables.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Rosters.Combatants.Characteristics.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Rosters.Combatants.Fireables.Interfaces
{
    /// <summary>
    /// Fireable Model Interface
    /// </summary>
    public interface IFireableModel
        : ICharacteristicModel
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IFireableAttributes GetCurrentAttributes();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IFireableAttributes GetMaximumAttributes();
    }
}