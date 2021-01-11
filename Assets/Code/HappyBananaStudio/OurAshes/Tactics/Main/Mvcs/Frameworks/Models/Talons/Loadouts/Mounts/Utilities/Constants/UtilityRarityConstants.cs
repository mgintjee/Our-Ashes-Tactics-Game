namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Mounts.Utilities.Constants
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Common.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Mounts.Utilities.Enums;
    using HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Todo
    /// </summary>
    public static class UtilityRarityConstants
    {
        // Todo
        private static readonly IDictionary<LoadoutRarity, ISet<UtilityId>> loadoutRarityUtilityIdSetDictionary =
            new Dictionary<LoadoutRarity, ISet<UtilityId>>()
            {
                {
                    LoadoutRarity.None,
                    new HashSet<UtilityId>()
                },
                {
                    LoadoutRarity.Common,
                    new HashSet<UtilityId>()
                    {
                        UtilityId.Utility1,
                    }
                },
                {
                    LoadoutRarity.Uncommon,
                    new HashSet<UtilityId>()
                    {
                    }
                },
                {
                    LoadoutRarity.Rare,
                    new HashSet<UtilityId>()
                    {
                    }
                },
                {
                    LoadoutRarity.Unique,
                    new HashSet<UtilityId>()
                    {
                    }
                }
            };

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="loadoutRarity"></param>
        /// <returns></returns>
        public static ISet<UtilityId> GetUtilityIdSet(LoadoutRarity loadoutRarity)
        {
            // Check if the loadoutRarity is supported
            if (loadoutRarityUtilityIdSetDictionary.ContainsKey(loadoutRarity))
            {
                return loadoutRarityUtilityIdSetDictionary[loadoutRarity];
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
        /// <param name="utilityId"></param>
        /// <returns></returns>
        public static LoadoutRarity GetLoadoutRarity(UtilityId utilityId)
        {
            foreach (LoadoutRarity loadoutRarity in loadoutRarityUtilityIdSetDictionary.Keys)
            {
                if (loadoutRarityUtilityIdSetDictionary[loadoutRarity].Contains(utilityId))
                {
                    return loadoutRarity;
                }
            }
            throw ExceptionUtil.Argument.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                    new StackFrame().GetMethod().Name, utilityId);
        }
    }
}