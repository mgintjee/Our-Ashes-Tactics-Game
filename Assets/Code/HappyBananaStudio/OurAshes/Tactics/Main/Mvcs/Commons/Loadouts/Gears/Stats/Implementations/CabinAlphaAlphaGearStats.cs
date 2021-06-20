using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.Types.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Gears.IDs.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Gears.Sizes.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Gears.Skins.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Gears.Types.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Traits.Types.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Rarities.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Destructibles.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Fireables.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Movables.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Stats.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Materials.Indices.Implementations;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Stats.Implementations
{
    /// <summary>
    /// Cabin Alpha Alpha Gear Stats Implementation
    /// </summary>
    public class CabinAlphaAlphaGearStats
        : AbstractGearStats
    {
        /// <summary>
        /// Todo
        /// </summary>
        public CabinAlphaAlphaGearStats()
        {
            _gearID = GearID.CabinAlphaAlpha;
            _name = _gearID.ToString();
            _gearType = GearType.Cabin;
            _rarity = Rarity.Common;
            _combatantTypes = new HashSet<CombatantType>() { CombatantType.Alpha, CombatantType.Bravo, CombatantType.Charlie };
            // Model Stats
            _gearSize = GearSize.Small;
            _traitCount = 1;
            _traitTypes = new HashSet<TraitType>()
                { TraitType.CabinAlpha };
            _combatantAttributes = new CombatantAttributes.Builder()
                    .SetDestructibleAttributes(
                        new DestructibleAttributes.Builder()
                        .Build())
                    .SetMovableAttributes(
                        new MovableAttributes.Builder()
                        .Build())
                    .SetFireableAttributes(
                        new FireableAttributes.Builder()
                        .SetAccuracy(5)
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