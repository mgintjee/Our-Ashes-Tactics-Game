namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Armors.Constants
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Armors.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Common.Enums;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Todo
    /// </summary>
    public static class ArmorRarityConstants
    {
        // Todo
        private static readonly IDictionary<LoadoutRarity, int> loadoutRarityArmorTraitCountDictionary =
            new Dictionary<LoadoutRarity, int>()
            {
                { LoadoutRarity.None, 0},
                { LoadoutRarity.Common, 0},
                { LoadoutRarity.Uncommon, 1},
                { LoadoutRarity.Rare, 2},
                { LoadoutRarity.Unique, 0},
            };

        // Todo
        private static readonly IDictionary<LoadoutRarity, ISet<ArmorId>> loadoutRarityArmorIdSetDictionary =
            new Dictionary<LoadoutRarity, ISet<ArmorId>>()
            {
                {
                    LoadoutRarity.None,
                    new HashSet<ArmorId>()
                },
                {
                    LoadoutRarity.Common,
                    new HashSet<ArmorId>()
                    {
                        ArmorId.Heavy1,
                        ArmorId.Light1,
                    }
                },
                {
                    LoadoutRarity.Uncommon,
                    new HashSet<ArmorId>()
                    {
                    }
                },
                {
                    LoadoutRarity.Rare,
                    new HashSet<ArmorId>()
                    {
                    }
                },
                {
                    LoadoutRarity.Unique,
                    new HashSet<ArmorId>()
                    {
                    }
                }
            };

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="loadoutRarity"></param>
        /// <returns></returns>
        public static ISet<ArmorId> GetArmorIdSet(LoadoutRarity loadoutRarity)
        {
            // Check if the loadoutRarity is supported
            if (loadoutRarityArmorIdSetDictionary.ContainsKey(loadoutRarity))
            {
                return loadoutRarityArmorIdSetDictionary[loadoutRarity];
            }
            else
            {
                throw ExceptionUtil.Arguments.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                    new StackFrame().GetMethod().Name, loadoutRarity);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="armorId"></param>
        /// <returns></returns>
        public static LoadoutRarity GetLoadoutRarity(ArmorId armorId)
        {
            foreach (LoadoutRarity loadoutRarity in loadoutRarityArmorIdSetDictionary.Keys)
            {
                if (loadoutRarityArmorIdSetDictionary[loadoutRarity].Contains(armorId))
                {
                    return loadoutRarity;
                }
            }
            throw ExceptionUtil.Arguments.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                    new StackFrame().GetMethod().Name, armorId);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="loadoutRarity"></param>
        /// <returns></returns>
        public static int GetLoadoutTraitCount(LoadoutRarity loadoutRarity)
        {
            // Check if the loadoutRarity is supported
            if (loadoutRarityArmorTraitCountDictionary.ContainsKey(loadoutRarity))
            {
                return loadoutRarityArmorTraitCountDictionary[loadoutRarity];
            }
            else
            {
                throw ExceptionUtil.Arguments.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                    new StackFrame().GetMethod().Name, loadoutRarity);
            }
        }
    }
}