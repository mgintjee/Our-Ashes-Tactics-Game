using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.IDs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.Skins;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Gears.Sizes;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Rarities;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Destructibles.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Fireables.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Loadouts.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Movables.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Stats.Implementations.Abstract;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Materials.Indices.Implementations;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Stats.Implementations.Alphas
{
    /// <summary>
    /// Alpha Alpha Combatant Stats Implementation
    /// </summary>
    public class AlphaAlphaCombatantStats
        : AbstractCombatantStats
    {
        /// <summary>
        /// Todo
        /// </summary>
        public AlphaAlphaCombatantStats()
            : base()
        {
            // Common Stats
            _combatantID = CombatantID.AlphaAlpha;
            _name = _combatantID.ToString();
            _combatantType = CombatantType.Alpha;
            _rarity = Rarity.Common;
            // Model Stats
            _combatantAttributes = new CombatantAttributes.Builder()
                    .SetDestructibleAttributes(
                        new DestructibleAttributes.Builder()
                        .SetArmor(5)
                        .SetHealth(15)
                        .Build())
                    .SetMovableAttributes(
                        new MovableAttributes.Builder()
                        .SetActions(3)
                        .SetMovements(10)
                        .Build())
                    .SetFireableAttributes(
                        new FireableAttributes.Builder()
                        .SetAccuracy(0)
                        .SetArmorDamage(0)
                        .SetArmorPenetration(0)
                        .SetHealthDamage(0)
                        .SetRange(0)
                        .SetSalvo(0)
                        .Build())
                    .SetLoadoutAttributes(
                        new LoadoutAttributes.Builder()
                            .SetArmorGearSize(GearSize.Small)
                            .SetCabinGearSize(GearSize.Small)
                            .SetEngineGearSize(GearSize.Small)
                            .SetWeaponGearSizes(new List<GearSize>() { GearSize.Small })
                            .Build())
                    .Build();
            // View Stats
            _combatantSkins = new HashSet<CombatantSkin>() { CombatantSkin.AlphaAlphaAlpha };
            _materialIndices = new MaterialIndices.Builder()
                    .SetPrimaryIndex(0)
                    .SetSecondaryIndex(0)
                    .SetTertiaryIndex(0)
                    .Build();
        }
    }
}