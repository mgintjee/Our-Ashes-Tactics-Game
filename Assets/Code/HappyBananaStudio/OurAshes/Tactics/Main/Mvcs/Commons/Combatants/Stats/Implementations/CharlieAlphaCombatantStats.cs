using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.IDs.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.Skins.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.Types.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Gears.Sizes.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Rarities.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Destructibles.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Fireables.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Loadouts.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Movables.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Stats.Implementations.Abstract;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Materials.Indices.Implementations;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Stats.Implementations
{
    /// <summary>
    /// Charlie Alpha Combatant Stats Implementation
    /// </summary>
    public class CharlieAlphaCombatantStats
        : AbstractCombatantStats
    {
        /// <summary>
        /// Todo
        /// </summary>
        public CharlieAlphaCombatantStats()
            : base()
        {
            // Common Stats
            this._combatantID = CombatantID.CharlieAlpha;
            this._name = this._combatantID.ToString();
            this._combatantType = CombatantType.Charlie;
            this._rarity = Rarity.Common;
            // Model Stats
            this._combatantAttributes = new CombatantAttributes.Builder()
                    .SetDestructibleAttributes(
                        new DestructibleAttributes.Builder()
                        .Build())
                    .SetMovableAttributes(
                        new MovableAttributes.Builder()
                        .Build())
                    .SetFireableAttributes(
                        new FireableAttributes.Builder()
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
            this._combatantSkins = new HashSet<CombatantSkin>() { CombatantSkin.CharlieAlphaAlpha };
            this._materialIndices = new MaterialIndices.Builder()
                    .SetPrimaryIndex(0)
                    .SetSecondaryIndex(0)
                    .SetTertiaryIndex(0)
                    .Build();
        }
    }
}