using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.IDs.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.Skins.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.Types.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Rarities.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Stats.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Materials.Indices.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Stats.Implementations.Abstract
{
    /// <summary>
    /// Abstract Combatant Stats Implementation
    /// </summary>
    public class AbstractCombatantStats
        : ICombatantStats
    {
        // Todo
        protected string _name;

        // Todo
        protected CombatantID _combatantID;

        // Todo
        protected CombatantType _combatantType;

        // Todo
        protected Rarity _rarity;

        // Todo
        protected IMaterialIndices _materialIndices;

        // Todo
        protected ICombatantAttributes _combatantAttributes;

        // Todo
        protected ISet<CombatantSkin> _combatantSkins;

        CombatantID ICombatantStats.GetCombatantID()
        {
            return _combatantID;
        }

        string ICombatantStats.GetName()
        {
            return _name;
        }

        CombatantType ICombatantStats.GetCombatantType()
        {
            return _combatantType;
        }

        Rarity ICombatantStats.GetRarity()
        {
            return _rarity;
        }

        IMaterialIndices ICombatantStats.GetMaterialIndices()
        {
            return _materialIndices;
        }

        ISet<CombatantSkin> ICombatantStats.GetCombatantSkins()
        {
            return new HashSet<CombatantSkin>(_combatantSkins);
        }

        ICombatantAttributes ICombatantStats.GetCombatantAttributes()
        {
            return _combatantAttributes;
        }
    }
}