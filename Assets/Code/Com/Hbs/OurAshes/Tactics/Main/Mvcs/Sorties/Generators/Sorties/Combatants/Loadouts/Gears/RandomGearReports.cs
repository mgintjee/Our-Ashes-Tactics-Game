/*using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Combatants.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Loadouts.Gears.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Loadouts.Gears.Sizes;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Loadouts.Gears.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Rarities;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Constants.Loadouts.Models.Gears.Managers;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Reports.Gears.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Reports.Gears.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Generators.Sorties.Combatants.Loadouts.Traits;
using System;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Generators.Sorties.Combatants.Loadouts.Gears
{
    /// <summary>
    /// Random Gear Reports
    /// </summary>
    public static class RandomGearReports
    {
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
                ? GearModelConstantsManager.GetStats(gearType)
                : GearModelConstantsManager.GetStats());
            gearStats.IntersectWith((gearSize != GearSize.None)
                ? GearModelConstantsManager.GetStats(gearSize)
                : GearModelConstantsManager.GetStats());
            gearStats.IntersectWith((combatantType != CombatantType.None)
                ? GearModelConstantsManager.GetStats(combatantType)
                : GearModelConstantsManager.GetStats());
            gearStats.IntersectWith((rarity != Rarity.None)
                ? GearModelConstantsManager.GetStats(rarity)
                : GearModelConstantsManager.GetStats());
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
}*/