﻿using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.Types.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Gears.IDs.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Gears.Sizes.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Gears.Types.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Rarities.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Reports.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Stats.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Stats.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Randoms.Sorties.Combatants.Loadouts.Traits;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Randoms.Sorties.Combatants.Loadouts.Gears
{
    /// <summary>
    /// Random Gear Reports
    /// </summary>
    public static class RandomGearReports
    {
        // Todo
        private static readonly ILogger _logger = LoggerManager.GetSortieLogger(new StackFrame().GetMethod().DeclaringType);


        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="random"></param>
        /// <returns></returns>
        public static IGearReport Generate(Random random)
        {
            return Generate(random, GearType.None, GearSize.None, CombatantType.None, Rarity.None);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="random">  </param>
        /// <param name="gearType"></param>
        /// <returns></returns>
        public static IGearReport Generate(Random random, GearType gearType)
        {
            return Generate(random, gearType, GearSize.None, CombatantType.None, Rarity.None);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="random">  </param>
        /// <param name="gearSize"></param>
        /// <returns></returns>
        public static IGearReport Generate(Random random, GearSize gearSize)
        {
            return Generate(random, GearType.None, gearSize, CombatantType.None, Rarity.None);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="random">       </param>
        /// <param name="combatantType"></param>
        /// <returns></returns>
        public static IGearReport Generate(Random random, CombatantType combatantType)
        {
            return Generate(random, GearType.None, GearSize.None, combatantType, Rarity.None);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="random"></param>
        /// <param name="rarity"></param>
        /// <returns></returns>
        public static IGearReport Generate(Random random, Rarity rarity)
        {
            return Generate(random, GearType.None, GearSize.None, CombatantType.None, rarity);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="random">  </param>
        /// <param name="gearType"></param>
        /// <param name="gearSize"></param>
        /// <returns></returns>
        public static IGearReport Generate(Random random, GearType gearType, GearSize gearSize)
        {
            return Generate(random, gearType, gearSize, CombatantType.None, Rarity.None);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="random">       </param>
        /// <param name="gearType">     </param>
        /// <param name="combatantType"></param>
        /// <returns></returns>
        public static IGearReport Generate(Random random, GearType gearType, CombatantType combatantType)
        {
            return Generate(random, gearType, GearSize.None, combatantType, Rarity.None);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="random">  </param>
        /// <param name="gearType"></param>
        /// <param name="rarity">  </param>
        /// <returns></returns>
        public static IGearReport Generate(Random random, GearType gearType, Rarity rarity)
        {
            return Generate(random, gearType, GearSize.None, CombatantType.None, rarity);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="random">       </param>
        /// <param name="gearSize">     </param>
        /// <param name="combatantType"></param>
        /// <returns></returns>
        public static IGearReport Generate(Random random, GearSize gearSize, CombatantType combatantType)
        {
            return Generate(random, GearType.None, gearSize, combatantType, Rarity.None);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="random">  </param>
        /// <param name="gearSize"></param>
        /// <param name="rarity">  </param>
        /// <returns></returns>
        public static IGearReport Generate(Random random, GearSize gearSize, Rarity rarity)
        {
            return Generate(random, GearType.None, gearSize, CombatantType.None, rarity);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="random">       </param>
        /// <param name="combatantType"></param>
        /// <param name="rarity">       </param>
        /// <returns></returns>
        public static IGearReport Generate(Random random, CombatantType combatantType, Rarity rarity)
        {
            return Generate(random, GearType.None, GearSize.None, combatantType, rarity);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="random">       </param>
        /// <param name="gearType">     </param>
        /// <param name="gearSize">     </param>
        /// <param name="combatantType"></param>
        /// <returns></returns>
        public static IGearReport Generate(Random random, GearType gearType, GearSize gearSize, CombatantType combatantType)
        {
            return Generate(random, gearType, gearSize, combatantType, Rarity.None);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="random">  </param>
        /// <param name="gearType"></param>
        /// <param name="gearSize"></param>
        /// <param name="rarity">  </param>
        /// <returns></returns>
        public static IGearReport Generate(Random random, GearType gearType, GearSize gearSize, Rarity rarity)
        {
            return Generate(random, gearType, gearSize, CombatantType.None, rarity);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="random">  </param>
        /// <param name="gearType"></param>
        /// <param name="rarity">  </param>
        /// <returns></returns>
        public static IGearReport Generate(Random random, GearType gearType, CombatantType combatantType, Rarity rarity)
        {
            return Generate(random, gearType, GearSize.None, combatantType, rarity);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="random">  </param>
        /// <param name="gearSize"></param>
        /// <param name="gearSize"></param>
        /// <param name="rarity">  </param>
        /// <returns></returns>
        public static IGearReport Generate(Random random, GearSize gearSize, CombatantType combatantType, Rarity rarity)
        {
            return Generate(random, GearType.None, gearSize, combatantType, rarity);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="random">       </param>
        /// <param name="gearType">     </param>
        /// <param name="gearSize">     </param>
        /// <param name="combatantType"></param>
        /// <param name="rarity">       </param>
        /// <returns></returns>
        public static IGearReport Generate(Random random, GearType gearType,
            GearSize gearSize, CombatantType combatantType, Rarity rarity)
        {
            GearID gearID = GenerateGearID(random, gearType, gearSize, combatantType, rarity);
            return new GearReport.Builder()
                .SetGearID(gearID)
                .SetTraitReport(RandomTraitReports.Generate(random, gearID))
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="random">       </param>
        /// <param name="gearType">     </param>
        /// <param name="gearSize">     </param>
        /// <param name="combatantType"></param>
        /// <param name="rarity">       </param>
        /// <returns></returns>
        private static GearID GenerateGearID(Random random, GearType gearType,
            GearSize gearSize, CombatantType combatantType, Rarity rarity)
        {
            ISet<IGearStats> gearStats = new HashSet<IGearStats>();
            gearStats.UnionWith((gearType != GearType.None)
                ? GearStatsManager.GetStats(gearType)
                : GearStatsManager.GetStats());
            gearStats.IntersectWith((gearSize != GearSize.None)
                ? GearStatsManager.GetStats(gearSize)
                : GearStatsManager.GetStats());
            gearStats.IntersectWith((combatantType != CombatantType.None)
                ? GearStatsManager.GetStats(combatantType)
                : GearStatsManager.GetStats());
            gearStats.IntersectWith((rarity != Rarity.None)
                ? GearStatsManager.GetStats(rarity)
                : GearStatsManager.GetStats());
            ISet<GearID> gearIDs = new HashSet<GearID>();
            foreach (IGearStats stats in gearStats)
            {
                gearIDs.Add(stats.GetGearID());
            }
            GearID gearID = GearID.None;
            if (gearIDs.Count > 0)
            {
                gearID = new List<GearID>(gearIDs)
                    [random.Next(gearIDs.Count)];
            }
            return gearID;
        }
    }
}