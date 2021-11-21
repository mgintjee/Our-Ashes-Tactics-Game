using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Weapons.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Loadouts.Gears.IDs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Loadouts.Gears.Sizes;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Loadouts.Gears.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Loadouts.Traits.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Rarities;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Constants.Loadouts.Models.Gears.Interfaces
{
    /// <summary>
    /// Gear Model Cosntants Interface
    /// </summary>
    public interface IGearModelConstants
    {
        string GetName();

        GearID GetGearID();

        ICombatantAttributes GetCombatantAttributes();

        IWeaponAttributes GetWeaponAttributes();

        ISet<CombatantType> GetCombatantTypes();

        Rarity GetRarity();

        GearSize GetGearSize();

        GearType GetGearType();

        ISet<TraitType> GetTraitTypes();
    }
}