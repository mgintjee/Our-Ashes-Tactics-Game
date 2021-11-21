/*using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Combatants.Attributes.Loadouts.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Combatants.IDs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Combatants.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Loadouts.Gears.Sizes;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Loadouts.Gears.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Rarities;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Constants.Combatants.Models.Managers;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Reports.Gears.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Reports.Implementations;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Reports.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Generators.Sorties.Combatants.Loadouts.Gears;
using System;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Generators.Sorties.Combatants.Loadouts
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
            CombatantModelConstantsManager.GetConstants(combatantID).IfPresent(combatantStats =>
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
            return LoadoutReport.Builder.Get()
                .SetGearReports(gearReports)
                .Build();
        }
    }
}*/