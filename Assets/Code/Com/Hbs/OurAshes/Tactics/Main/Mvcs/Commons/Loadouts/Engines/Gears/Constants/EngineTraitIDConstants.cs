using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Shapes;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Sizes;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Tiles.Algorithms.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Tiles.Algorithms.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Engines.Gears.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Engines.Traits.IDs;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Engines.Gears.Constants
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