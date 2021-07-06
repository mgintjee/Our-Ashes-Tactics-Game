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

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Stats.Implementations.Armors
{
    /// <summary>
    /// Armor Bravo Alpha Gear Stats Implementation
    /// </summary>
    public class ArmorBravoAlphaGearStats
        : AbstractGearStats
    {
        /// <summary>
        /// Todo
        /// </summary>
        public ArmorBravoAlphaGearStats()
        {
            _gearID = GearID.ArmorBravoAlpha;
            _name = _gearID.ToString();
            _rarity = Rarity.Common;
            _combatantTypes = new HashSet<CombatantType>() { CombatantType.Alpha, CombatantType.Bravo, CombatantType.Charlie };
            _gearType = GearType.Armor;
            // Model Stats
            _gearSize = GearSize.Small;
            _traitCount = 1;
            _traitTypes = new HashSet<TraitType>()
                { TraitType.ArmorAlpha };
            _combatantAttributes = new CombatantAttributes.Builder()
                    .SetDestructibleAttributes(new DestructibleAttributes.Builder()
                        .SetArmor(3)
                        .SetHealth(8)
                        .Build())
                    .SetMovableAttributes(new MovableAttributes.Builder()
                        .SetMovements(-2)
                        .Build())
                    .SetFireableAttributes(new FireableAttributes.Builder()
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