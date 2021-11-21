using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Weapons.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Loadouts.Traits.IDs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Loadouts.Traits.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Rarities;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Constants.Loadouts.Models.Traits.Interfaces
{
    /// <summary>
    /// Trait Model Constants Interface
    /// </summary>
    public interface ITraitModelConstants
    {
        string GetName();

        TraitID GetTraitID();

        ICombatantAttributes GetCombatantAttributes();

        IWeaponAttributes GetWeaponAttributes();

        Rarity GetRarity();

        TraitType GetTraitType();
    }
}