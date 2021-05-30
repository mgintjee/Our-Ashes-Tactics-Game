using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.Types.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Gears.IDs.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Gears.Sizes.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Gears.Skins.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Gears.Types.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Rarities.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Stats.Gears.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Stats.Gears.Models.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Stats.Gears.Views.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Materials.Indices.Implementations;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Stats.Gears.Implementations
{
    /// <summary>
    /// Armor Alpha Alpha Gear Stats Implementation
    /// </summary>
    public class ArmorAlphaAlphaGearStats
        : AbstractGearStats
    {
        /// <summary>
        /// Todo
        /// </summary>
        public ArmorAlphaAlphaGearStats()
        {
            this._gearID = GearID.ArmorAlphaAlpha;
            this._name = _gearID.ToString();
            this._gearModelStats = new GearModelStats.Builder()
                .SetCombatantAttributes(
                    new CombatantAttributes.Builder()
                    .Build())
                .SetCombatantType(CombatantType.Alpha)
                .SetGearSize(GearSize.Small)
                .SetGearType(GearType.Armor)
                .SetRarity(Rarity.Common)
                .Build();
            this._gearViewStats = new GearViewStats.Builder()
                .SetGearSkins(new HashSet<GearSkin>())
                .SetMaterialIndices(
                    new MaterialIndices.Builder()
                    .Build())
                .Build();
        }
    }
}