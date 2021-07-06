﻿using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Gears.IDs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Gears.Sizes;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Gears.Skins;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Gears.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Traits.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Rarities;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Materials.Indices.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Stats.Interfaces
{
    /// <summary>
    /// Gear Stats Interface
    /// </summary>
    public interface IGearStats
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
        GearID GetGearID();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ICombatantAttributes GetCombatantAttributes();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ISet<CombatantType> GetCombatantTypes();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        Rarity GetRarity();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        GearSize GetGearSize();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        GearType GetGearType();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IMaterialIndices GetMaterialIndices();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ISet<GearSkin> GetSkins();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ISet<TraitType> GetTraitTypes();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        int GetTraitCount();
    }
}