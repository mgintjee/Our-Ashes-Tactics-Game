using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Engines.Gears.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Engines.Traits.IDs;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Engines.Gears.Constants
{
    /// <summary>
    /// Todo
    /// </summary>
    public class EngineTraitIDConstants
    {
        private static readonly IDictionary<EngineGearID, ISet<EngineTraitID>> ENGINE_GEAR_ID_TRAIT_IDS = new Dictionary<EngineGearID, ISet<EngineTraitID>>();
        private static readonly IDictionary<EngineGearID, int> ENGINE_GEAR_ID_TRAIT_COUNTS = new Dictionary<EngineGearID, int>();

        public static ISet<EngineTraitID> GetEngineTraitIDs(EngineGearID engineGearID)
        {
            ISet<EngineTraitID> engineTraitIDs = new HashSet<EngineTraitID>();

            if (ENGINE_GEAR_ID_TRAIT_IDS.ContainsKey(engineGearID))
            {
                engineTraitIDs = new HashSet<EngineTraitID>(ENGINE_GEAR_ID_TRAIT_IDS[engineGearID]);
            }

            return engineTraitIDs;
        }

        public static int GetEngineTraitCount(EngineGearID engineGearID)
        {
            int engineTraitCount = 0;

            if (ENGINE_GEAR_ID_TRAIT_COUNTS.ContainsKey(engineGearID))
            {
                engineTraitCount = ENGINE_GEAR_ID_TRAIT_COUNTS[engineGearID];
            }

            return engineTraitCount;
        }
    }
}