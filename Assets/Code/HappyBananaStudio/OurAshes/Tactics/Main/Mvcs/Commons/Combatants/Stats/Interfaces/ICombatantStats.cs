using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.IDs.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.Skins.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.Types.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Rarities.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Materials.Indices.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Stats.Interfaces
{
    /// <summary>
    /// Combatant Stats Interface
    /// </summary>
    public interface ICombatantStats
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        string GetName();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        CombatantID GetCombatantID();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        CombatantType GetCombatantType();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        Rarity GetRarity();

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

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ICombatantAttributes GetCombatantAttributes();
    }
}