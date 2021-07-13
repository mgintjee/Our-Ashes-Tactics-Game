using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.Attributes.Destructibles.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.Attributes.Fireables.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.Attributes.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.Attributes.Loadouts.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.Attributes.Movables.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.IDs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Gears.Sizes;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Gears.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Rarities;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Constants.Combatants.Models.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Constants.Combatants.Models.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Constants.Combatants.Models.Managers
{
    /// <summary>
    /// Todo
    /// </summary>
    public static class CombatantModelConstantsManager
    {
        private static readonly IDictionary<CombatantID, ICombatantModelConstants> IDModelConstants =
            new Dictionary<CombatantID, ICombatantModelConstants>()
        {
            {
                CombatantID.LightAlpha,
                CombatantModelConstants.Builder.Get()
                    .SetCombatantID(CombatantID.LightAlpha)
                    .SetCombatantType(CombatantType.Alpha)
                    .SetRarity(Rarity.Common)
                    .SetName(CombatantID.LightAlpha.ToString())
                    .SetGearTypes(new HashSet<GearType>() { GearType.Armor, GearType.Cabin, GearType.Engine, GearType.Weapon } )
                .SetCombatantAttributes(CombatantAttributes.Builder.Get()
                    .SetDestructibleAttributes(DestructibleAttributes.Builder.Get()
                        .SetArmor(5)
                        .SetHealth(15)
                        .Build())
                    .SetFireableAttributes(FireableAttributes.Builder.Get()
                        .SetAccuracy(0)
                        .SetRange(0)
                        .Build())
                    .SetMovableAttributes(MovableAttributes.Builder.Get()
                        .SetActions(2)
                        .SetMovements(10)
                        .Build())
                    .SetLoadoutAttributes(LoadoutAttributes.Builder.Get()
                        .SetArmorGearSize(GearSize.Small)
                        .SetCabinGearSize(GearSize.Small)
                        .SetEngineGearSize(GearSize.Small)
                        .SetWeaponGearSizes(new List<GearSize>(){ GearSize.Small })
                        .Build())
                    .Build())
                .Build()
            },
            {
                CombatantID.MediumAlpha,
                CombatantModelConstants.Builder.Get()
                    .SetCombatantID(CombatantID.MediumAlpha)
                    .SetCombatantType(CombatantType.Bravo)
                    .SetRarity(Rarity.Uncommon)
                    .SetName(CombatantID.MediumAlpha.ToString())
                    .SetGearTypes(new HashSet<GearType>() { GearType.Armor, GearType.Cabin, GearType.Engine, GearType.Weapon } )
                .SetCombatantAttributes(CombatantAttributes.Builder.Get()
                    .SetDestructibleAttributes(DestructibleAttributes.Builder.Get()
                        .SetArmor(5)
                        .SetHealth(15)
                        .Build())
                    .SetFireableAttributes(FireableAttributes.Builder.Get()
                        .SetAccuracy(0)
                        .SetRange(0)
                        .Build())
                    .SetMovableAttributes(MovableAttributes.Builder.Get()
                        .SetActions(2)
                        .SetMovements(10)
                        .Build())
                    .SetLoadoutAttributes(LoadoutAttributes.Builder.Get()
                        .SetArmorGearSize(GearSize.Small)
                        .SetCabinGearSize(GearSize.Small)
                        .SetEngineGearSize(GearSize.Small)
                        .SetWeaponGearSizes(new List<GearSize>(){ GearSize.Small })
                        .Build())
                    .Build())
                .Build()
            },
            {
                CombatantID.HeavyAlpha,
                CombatantModelConstants.Builder.Get()
                    .SetCombatantID(CombatantID.HeavyAlpha)
                    .SetCombatantType(CombatantType.Charlie)
                    .SetRarity(Rarity.Rare)
                    .SetName(CombatantID.HeavyAlpha.ToString())
                    .SetGearTypes(new HashSet<GearType>() { GearType.Armor, GearType.Cabin, GearType.Engine, GearType.Weapon } )
                .SetCombatantAttributes(CombatantAttributes.Builder.Get()
                    .SetDestructibleAttributes(DestructibleAttributes.Builder.Get()
                        .SetArmor(5)
                        .SetHealth(15)
                        .Build())
                    .SetFireableAttributes(FireableAttributes.Builder.Get()
                        .SetAccuracy(0)
                        .SetRange(0)
                        .Build())
                    .SetMovableAttributes(MovableAttributes.Builder.Get()
                        .SetActions(2)
                        .SetMovements(10)
                        .Build())
                    .SetLoadoutAttributes(LoadoutAttributes.Builder.Get()
                        .SetArmorGearSize(GearSize.Small)
                        .SetCabinGearSize(GearSize.Small)
                        .SetEngineGearSize(GearSize.Small)
                        .SetWeaponGearSizes(new List<GearSize>(){ GearSize.Small })
                        .Build())
                    .Build())
                .Build()
            },
        };

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="combatantID"></param>
        /// <returns></returns>
        public static Optional<ICombatantModelConstants> GetConstants(CombatantID combatantID)
        {
            return (IDModelConstants.ContainsKey(combatantID))
                ? Optional<ICombatantModelConstants>.Of(IDModelConstants[combatantID])
                : Optional<ICombatantModelConstants>.Empty();
        }
    }
}