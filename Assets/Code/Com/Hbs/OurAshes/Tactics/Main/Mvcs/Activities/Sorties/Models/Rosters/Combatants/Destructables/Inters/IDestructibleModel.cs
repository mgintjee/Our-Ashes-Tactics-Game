﻿using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Destructibles.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Models.Rosters.Combatants.Characteristics.Inters;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Models.Rosters.Combatants.Destructables.Inters
{
    /// <summary>
    /// Destructible Model Interface
    /// </summary>
    public interface IDestructibleModel : ICharacteristicModel
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IDestructibleAttributes GetCurrentAttributes();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IDestructibleAttributes GetMaximumAttributes();
    }
}