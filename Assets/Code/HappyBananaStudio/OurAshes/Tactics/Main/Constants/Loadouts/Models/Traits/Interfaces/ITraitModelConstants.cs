using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.Attributes.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Traits.IDs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Traits.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Weapons.Attributes.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Rarities;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Constants.Loadouts.Models.Traits.Interfaces
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