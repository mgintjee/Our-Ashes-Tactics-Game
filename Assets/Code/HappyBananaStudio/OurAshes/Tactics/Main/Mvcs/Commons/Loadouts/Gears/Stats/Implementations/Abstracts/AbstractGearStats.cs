using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Gears.IDs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Gears.Sizes;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Gears.Skins;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Gears.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Traits.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Rarities;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Stats.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Materials.Indices.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Stats.Implementations.Abstracts
{
    /// <summary>
    /// Abstract Gear Stats Implementation
    /// </summary>
    public class AbstractGearStats
        : IGearStats
    {
        // Todo
        protected GearID _gearID;

        // Todo
        protected string _name;

        // Todo
        protected IMaterialIndices _materialIndices;

        // Todo
        protected ISet<GearSkin> _gearSkins;

        // Todo
        protected ICombatantAttributes _combatantAttributes;

        // Todo
        protected ISet<CombatantType> _combatantTypes;

        // Todo
        protected GearSize _gearSize;

        // Todo
        protected GearType _gearType;

        // Todo
        protected Rarity _rarity;

        // Todo
        protected int _traitCount;

        // Todo
        protected ISet<TraitType> _traitTypes;

        /// <inheritdoc/>
        ICombatantAttributes IGearStats.GetCombatantAttributes()
        {
            return _combatantAttributes;
        }

        /// <inheritdoc/>
        ISet<CombatantType> IGearStats.GetCombatantTypes()
        {
            return new HashSet<CombatantType>(_combatantTypes);
        }

        /// <inheritdoc/>
        GearID IGearStats.GetGearID()
        {
            return _gearID;
        }

        /// <inheritdoc/>
        GearSize IGearStats.GetGearSize()
        {
            return _gearSize;
        }

        /// <inheritdoc/>
        GearType IGearStats.GetGearType()
        {
            return _gearType;
        }

        /// <inheritdoc/>
        IMaterialIndices IGearStats.GetMaterialIndices()
        {
            return _materialIndices;
        }

        /// <inheritdoc/>
        string IGearStats.GetName()
        {
            return _name;
        }

        /// <inheritdoc/>
        Rarity IGearStats.GetRarity()
        {
            return _rarity;
        }

        /// <inheritdoc/>
        ISet<GearSkin> IGearStats.GetSkins()
        {
            return new HashSet<GearSkin>(_gearSkins);
        }

        /// <inheritdoc/>
        int IGearStats.GetTraitCount()
        {
            return _traitCount;
        }

        /// <inheritdoc/>
        ISet<TraitType> IGearStats.GetTraitTypes()
        {
            return new HashSet<TraitType>(_traitTypes);
        }
    }
}