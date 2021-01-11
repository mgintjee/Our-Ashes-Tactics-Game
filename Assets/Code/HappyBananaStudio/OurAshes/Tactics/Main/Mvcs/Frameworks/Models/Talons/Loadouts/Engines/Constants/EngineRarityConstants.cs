namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Engines.Constants
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Common.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Engines.Enums;
    using HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Todo
    /// </summary>
    public static class EngineRarityConstants
    {
        // Todo
        private static readonly IDictionary<LoadoutRarity, int> loadoutRarityEngineTraitCountDictionary =
            new Dictionary<LoadoutRarity, int>()
            {
                { LoadoutRarity.None, 0},
                { LoadoutRarity.Common, 0},
                { LoadoutRarity.Uncommon, 1},
                { LoadoutRarity.Rare, 2},
                { LoadoutRarity.Unique, 0},
            };

        // Todo
        private static readonly IDictionary<LoadoutRarity, ISet<EngineId>> loadoutRarityEngineIdSetDictionary =
            new Dictionary<LoadoutRarity, ISet<EngineId>>()
            {
                {
                    LoadoutRarity.None,
                    new HashSet<EngineId>()
                },
                {
                    LoadoutRarity.Common,
                    new HashSet<EngineId>()
                    {
                        EngineId.Sturdy1,
                        EngineId.Quick1,
                    }
                },
                {
                    LoadoutRarity.Uncommon,
                    new HashSet<EngineId>()
                    {
                    }
                },
                {
                    LoadoutRarity.Rare,
                    new HashSet<EngineId>()
                    {
                    }
                },
                {
                    LoadoutRarity.Unique,
                    new HashSet<EngineId>()
                    {
                    }
                }
            };

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="loadoutRarity"></param>
        /// <returns></returns>
        public static ISet<EngineId> GetEngineIdSet(LoadoutRarity loadoutRarity)
        {
            // Check if the loadoutRarity is supported
            if (loadoutRarityEngineIdSetDictionary.ContainsKey(loadoutRarity))
            {
                return loadoutRarityEngineIdSetDictionary[loadoutRarity];
            }
            else
            {
                throw ExceptionUtil.Argument.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                    new StackFrame().GetMethod().Name, loadoutRarity);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="engineId"></param>
        /// <returns></returns>
        public static LoadoutRarity GetLoadoutRarity(EngineId engineId)
        {
            foreach (LoadoutRarity loadoutRarity in loadoutRarityEngineIdSetDictionary.Keys)
            {
                if (loadoutRarityEngineIdSetDictionary[loadoutRarity].Contains(engineId))
                {
                    return loadoutRarity;
                }
            }
            throw ExceptionUtil.Argument.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                    new StackFrame().GetMethod().Name, engineId);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="loadoutRarity"></param>
        /// <returns></returns>
        public static int GetLoadoutTraitCount(LoadoutRarity loadoutRarity)
        {
            // Check if the loadoutRarity is supported
            if (loadoutRarityEngineTraitCountDictionary.ContainsKey(loadoutRarity))
            {
                return loadoutRarityEngineTraitCountDictionary[loadoutRarity];
            }
            else
            {
                throw ExceptionUtil.Argument.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                    new StackFrame().GetMethod().Name, loadoutRarity);
            }
        }
    }
}