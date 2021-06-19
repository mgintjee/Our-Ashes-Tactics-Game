using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.IDs.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.Types.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Gears.Sizes.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Gears.Types.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Rarities.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Loadouts.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Stats.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Reports.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Randoms.Sorties.Combatants.Loadouts.Gears;
using System;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Randoms.Sorties.Combatants.Loadouts
{
    /// <summary>
    /// Random Loadout Reports
    /// </summary>
    public static class RandomLoadoutReports
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="random">     </param>
        /// <param name="combatantID"></param>
        /// <returns></returns>
        public static ILoadoutReport Generate(Random random, CombatantID combatantID)
        {
            ISet<IGearReport> gearReports = new HashSet<IGearReport>();
            CombatantStatsManager.GetStats(combatantID).IfPresent(combatantStats =>
            {
                CombatantType combatantType = combatantStats.GetCombatantType();
                ILoadoutAttributes loadoutAttributes = combatantStats.GetCombatantAttributes().GetLoadoutAttributes();
                gearReports.Add(RandomGearReports.Generate(random, GearType.Armor,
                    loadoutAttributes.GetArmorGearSize(), combatantType, Rarity.None));
                gearReports.Add(RandomGearReports.Generate(random, GearType.Cabin,
                    loadoutAttributes.GetCabinGearSize(), combatantType, Rarity.None));
                gearReports.Add(RandomGearReports.Generate(random, GearType.Engine,
                    loadoutAttributes.GetEngineGearSize(), combatantType, Rarity.None));
                foreach (GearSize gearSize in loadoutAttributes.GetWeaponGearSizes())
                {
                    gearReports.Add(RandomGearReports.Generate(random, GearType.Weapon,
                        gearSize, combatantType, Rarity.None));
                }
            });
            return new LoadoutReport.Builder()
                .SetGearReports(gearReports)
                .Build();
        }
    }
}