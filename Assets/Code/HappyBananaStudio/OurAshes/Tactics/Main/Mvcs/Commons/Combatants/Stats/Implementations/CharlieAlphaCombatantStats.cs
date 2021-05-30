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
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Stats.Models.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Stats.Views.Implementations;
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
            // Assign the ICombatantStats attributes
            this.combatantID = CombatantID.CharlieAlpha;
            this.name = this.combatantID.ToString();
            this.modelStats = new CombatantModelStats.Builder()
                .SetCombatantType(CombatantType.Charlie)
                .SetRarity(Rarity.Common)
                .SetCombatantAttributes(new CombatantAttributes.Builder()
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
                    .Build())
                .Build();
            this.viewStats = new CombatantViewStats.Builder()
                .SetCombatantSkins(new HashSet<CombatantSkin>()
                    { CombatantSkin.CharlieAlphaAlpha })
                .SetCombatantMaterialIndices(new MaterialIndices.Builder()
                    .SetPrimaryIndex(0)
                    .SetSecondaryIndex(0)
                    .SetTertiaryIndex(0)
                    .Build())
                .Build();
        }
    }
}