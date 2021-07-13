using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.Attributes.Destructibles.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.Attributes.Fireables.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.Attributes.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.Attributes.Movables.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Gears.IDs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Gears.Sizes;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Gears.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Weapons.Attributes.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Rarities;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Constants.Loadouts.Models.Gears.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Constants.Loadouts.Models.Gears.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Constants.Loadouts.Models.Gears.Managers
{
    /// <summary>
    /// Gear Model Constants Manager to host the Gear Model Constants Implementations
    /// </summary>
    public static class GearModelConstantsManager
    {
        private static readonly IDictionary<GearID, IGearModelConstants> IDModelConstants =
            new Dictionary<GearID, IGearModelConstants>()
        {
            {
                GearID.ArmorAlphaAlpha,
                GearModelConstants.Builder.Get()
                    .SetGearID(GearID.ArmorAlphaAlpha)
                    .SetGearSize(GearSize.Small)
                    .SetGearType(GearType.Armor)
                    .SetName(GearID.ArmorAlphaAlpha.ToString())
                    .SetRarity(Rarity.Common)
                    .SetCombatantTypes(new HashSet<CombatantType>(){ CombatantType.Alpha, CombatantType.Bravo, CombatantType.Charlie } )
                    .SetCombatantAttributes(CombatantAttributes.Builder.Get()
                        .SetDestructibleAttributes(DestructibleAttributes.Builder.Get()
                        .SetArmor(5)
                        .SetHealth(10)
                        .Build())
                    .Build())
                    .Build()
            },
            {
                GearID.ArmorBravoAlpha,
                GearModelConstants.Builder.Get()
                    .SetGearID(GearID.ArmorBravoAlpha)
                    .SetGearSize(GearSize.Small)
                    .SetGearType(GearType.Armor)
                    .SetName(GearID.ArmorBravoAlpha.ToString())
                    .SetRarity(Rarity.Common)
                    .SetCombatantTypes(new HashSet<CombatantType>(){ CombatantType.Alpha, CombatantType.Bravo, CombatantType.Charlie } )
                    .SetCombatantAttributes(CombatantAttributes.Builder.Get()
                        .SetDestructibleAttributes(DestructibleAttributes.Builder.Get()
                        .SetArmor(5)
                        .SetHealth(10)
                        .Build())
                    .Build())
                    .Build()
            },
            {
                GearID.CabinAlphaAlpha,
                GearModelConstants.Builder.Get()
                    .SetGearID(GearID.CabinAlphaAlpha)
                    .SetGearSize(GearSize.Small)
                    .SetGearType(GearType.Cabin)
                    .SetName(GearID.CabinAlphaAlpha.ToString())
                    .SetRarity(Rarity.Common)
                    .SetCombatantTypes(new HashSet<CombatantType>(){ CombatantType.Alpha, CombatantType.Bravo, CombatantType.Charlie } )
                    .SetCombatantAttributes(CombatantAttributes.Builder.Get()
                        .SetFireableAttributes(FireableAttributes.Builder.Get()
                        .SetAccuracy(5.0f)
                        .SetRange(0.0f)
                        .Build())
                    .Build())
                    .Build()
            },
            {
                GearID.CabinBravoAlpha,
                GearModelConstants.Builder.Get()
                    .SetGearID(GearID.CabinBravoAlpha)
                    .SetGearSize(GearSize.Small)
                    .SetGearType(GearType.Cabin)
                    .SetName(GearID.CabinBravoAlpha.ToString())
                    .SetRarity(Rarity.Common)
                    .SetCombatantTypes(new HashSet<CombatantType>(){ CombatantType.Alpha, CombatantType.Bravo, CombatantType.Charlie } )
                    .SetCombatantAttributes(CombatantAttributes.Builder.Get()
                        .SetFireableAttributes(FireableAttributes.Builder.Get()
                        .SetAccuracy(5.0f)
                        .SetRange(0.0f)
                        .Build())
                    .Build())
                    .Build()
            },
            {
                GearID.EngineAlphaAlpha,
                GearModelConstants.Builder.Get()
                    .SetGearID(GearID.EngineAlphaAlpha)
                    .SetGearSize(GearSize.Small)
                    .SetGearType(GearType.Engine)
                    .SetName(GearID.EngineAlphaAlpha.ToString())
                    .SetRarity(Rarity.Common)
                    .SetCombatantTypes(new HashSet<CombatantType>(){ CombatantType.Alpha, CombatantType.Bravo, CombatantType.Charlie } )
                    .SetCombatantAttributes(CombatantAttributes.Builder.Get()
                        .SetMovableAttributes(MovableAttributes.Builder.Get()
                        .SetActions(0.0f)
                        .SetMovements(5.0f)
                        .Build())
                    .Build())
                    .Build()
            },
            {
                GearID.EngineBravoAlpha,
                GearModelConstants.Builder.Get()
                    .SetGearID(GearID.EngineBravoAlpha)
                    .SetGearSize(GearSize.Small)
                    .SetGearType(GearType.Engine)
                    .SetName(GearID.EngineBravoAlpha.ToString())
                    .SetRarity(Rarity.Common)
                    .SetCombatantTypes(new HashSet<CombatantType>(){ CombatantType.Alpha, CombatantType.Bravo, CombatantType.Charlie } )
                    .SetCombatantAttributes(CombatantAttributes.Builder.Get()
                        .SetMovableAttributes(MovableAttributes.Builder.Get()
                        .SetActions(1.0f)
                        .SetMovements(0.0f)
                        .Build())
                    .Build())
                    .Build()
            },
            {
                GearID.WeaponAlphaAlpha,
                GearModelConstants.Builder.Get()
                    .SetGearID(GearID.WeaponAlphaAlpha)
                    .SetGearSize(GearSize.Small)
                    .SetGearType(GearType.Weapon)
                    .SetName(GearID.WeaponAlphaAlpha.ToString())
                    .SetRarity(Rarity.Common)
                    .SetCombatantTypes(new HashSet<CombatantType>(){ CombatantType.Alpha, CombatantType.Bravo, CombatantType.Charlie } )
                    .SetWeaponAttributes(WeaponAttributes.Builder.Get()
                        .SetAccuracy(75)
                        .SetArmorDamage(5)
                        .SetArmorPenetration(1)
                        .SetHealthDamage(3)
                        .SetRange(5)
                        .SetSalvo(3)
                        .Build())
                    .Build()
            },
            {
                GearID.WeaponBravoAlpha,
                GearModelConstants.Builder.Get()
                    .SetGearID(GearID.WeaponBravoAlpha)
                    .SetGearSize(GearSize.Small)
                    .SetGearType(GearType.Weapon)
                    .SetName(GearID.WeaponBravoAlpha.ToString())
                    .SetRarity(Rarity.Common)
                    .SetCombatantTypes(new HashSet<CombatantType>(){ CombatantType.Alpha, CombatantType.Bravo, CombatantType.Charlie } )
                    .SetWeaponAttributes(WeaponAttributes.Builder.Get()
                        .SetAccuracy(75)
                        .SetArmorDamage(5)
                        .SetArmorPenetration(1)
                        .SetHealthDamage(3)
                        .SetRange(5)
                        .SetSalvo(3)
                        .Build())
                    .Build()
            },
        };

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="combatantID"></param>
        /// <returns></returns>
        public static Optional<IGearModelConstants> GetConstants(GearID combatantID)
        {
            return (IDModelConstants.ContainsKey(combatantID))
                ? Optional<IGearModelConstants>.Of(IDModelConstants[combatantID])
                : Optional<IGearModelConstants>.Empty();
        }
    }
}