using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Gears.IDs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Gears.Sizes;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Gears.Skins;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Gears.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Traits.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Rarities;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Destructibles.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Fireables.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Movables.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Stats.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Materials.Indices.Implementations;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Stats.Implementations.Weapons
{
    /// <summary>
    /// Weapon Alpha Alpha Gear Stats Implementation
    /// </summary>
    public class WeaponAlphaAlphaGearStats
        : AbstractGearStats
    {
        /// <summary>
        /// Todo
        /// </summary>
        public WeaponAlphaAlphaGearStats()
        {
            _gearID = GearID.WeaponAlphaAlpha;
            _name = _gearID.ToString();
            _gearType = GearType.Weapon;
            _rarity = Rarity.Common;
            _combatantTypes = new HashSet<CombatantType>() { CombatantType.Alpha, CombatantType.Bravo, CombatantType.Charlie };
            // Model Stats
            _gearSize = GearSize.Small;
            _traitCount = 1;
            _traitTypes = new HashSet<TraitType>()
                { TraitType.WeaponAlpha };
            _combatantAttributes = new CombatantAttributes.Builder()
                    .SetDestructibleAttributes(
                        new DestructibleAttributes.Builder()
                        .Build())
                    .SetMovableAttributes(
                        new MovableAttributes.Builder()
                        .Build())
                    .SetFireableAttributes(
                        new FireableAttributes.Builder()
                        .SetAccuracy(75)
                        .SetArmorDamage(0.5f)
                        .SetArmorPenetration(0.5f)
                        .SetHealthDamage(1.0f)
                        .SetRange(3)
                        .SetSalvo(5)
                        .Build())
                .Build();
            // View Stats
            _gearSkins = new HashSet<GearSkin>();
            _materialIndices = new MaterialIndices.Builder()
                    .SetPrimaryIndex(0)
                    .SetSecondaryIndex(0)
                    .SetTertiaryIndex(0)
                    .Build();
        }
    }
}