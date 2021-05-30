using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.Skins.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Materials.Indices.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Stats.Views.Interfaces
{
    /// <summary>
    /// Combatant View Interface
    /// </summary>
    public interface ICombatantViewStats
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IMaterialIndices GetMaterialIndices();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ISet<CombatantSkin> GetCombatantSkins();
    }
}