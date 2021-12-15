/*using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Combatants.CallSigns;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Combatants.IDs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Combatants.Skins;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Loadouts.Gears.Skins;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Utils.Enums;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Reports.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Insignias.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Generators.Sorties.Combatants.Loadouts;
using System;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Generators.Sorties.Combatants
{
    /// <summary>
    /// Random Combatant Constrs
    /// </summary>
    public static class RandomCombatantConstrs
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="random">           </param>
        /// <param name="combatantCallSign"></param>
        /// <returns></returns>
        public static ICombatantConstruction Generate(Random random, CombatantCallSign combatantCallSign)
        {
            return Generate(random, combatantCallSign, null);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="random">           </param>
        /// <param name="combatantCallSign"></param>
        /// <param name="insigniaScheme">   </param>
        /// <returns></returns>
        public static ICombatantConstruction Generate(Random random, CombatantCallSign combatantCallSign, IInsigniaReport insigniaScheme)
        {
            return Generate(random, combatantCallSign, RandomEnums.GenerateRandomEnum<CombatantID>(random), insigniaScheme);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="random">           </param>
        /// <param name="combatantCallSign"></param>
        /// <param name="combatantID">      </param>
        /// <returns></returns>
        private static ICombatantConstruction Generate(Random random, CombatantCallSign combatantCallSign, CombatantID combatantID)
        {
            return Generate(random, combatantCallSign, combatantID, null);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="random">           </param>
        /// <param name="combatantCallSign"></param>
        /// <param name="combatantID">      </param>
        /// <param name="insigniaScheme">   </param>
        /// <returns></returns>
        private static ICombatantConstruction Generate(Random random, CombatantCallSign combatantCallSign,
            CombatantID combatantID, IInsigniaReport insigniaScheme)
        {
            ILoadoutReport loadoutReport = RandomLoadoutReports.Generate(random, combatantID);
            CombatantSkin combatantSkin = CombatantSkin.None;
            IList<GearSkin> gearSkins = null;

            if (insigniaScheme != null)
            {
                // Populate the CombatantSkin and GearSkins
            }

            return new CombatantConstruction.Builder()
                .SetCombatantCallSign(combatantCallSign)
                .SetCombatantID(combatantID)
                .SetLoadoutReport(loadoutReport)
                .SetCombatantSkin(combatantSkin)
                .SetGearSkins(gearSkins)
                .SetInsigniaScheme(insigniaScheme)
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="random">     </param>
        /// <param name="combatantID"></param>
        /// <returns></returns>
        private static CombatantSkin Generate(Random random, CombatantID combatantID)
        {
            CombatantSkin combatantSkin = CombatantSkin.None;
            CombatantModelConstantsManager.GetStats(combatantID).IfPresent(combatantStats =>
            {
                IList<CombatantSkin> combatantSkins = new List<CombatantSkin>(combatantStats.GetCombatantSkins());
                if (combatantSkins.Count > 0)
                {
                    combatantSkin = combatantSkins
                        [random.Next(combatantSkins.Count)];
                }
            });

            return combatantSkin;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="random">       </param>
        /// <param name="loadoutReport"></param>
        /// <returns></returns>
        private static IList<GearSkin> Generate(Random random, ILoadoutReport loadoutReport)
        {
            IList<GearSkin> gearSkins = new List<GearSkin>();

            return gearSkins;
        }
    }
}*/