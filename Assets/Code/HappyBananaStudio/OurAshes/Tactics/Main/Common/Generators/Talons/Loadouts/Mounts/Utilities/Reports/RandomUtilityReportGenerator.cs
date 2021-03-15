namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Generators.Talons.Loadouts.Mounts.Utilities.Reports
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Randoms.Generators.Numbers;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Common.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Mounts.Common.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Mounts.Utilities.Constants;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Mounts.Utilities.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Mounts.Utilities.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Mounts.Utilities.Reports.Impl;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Todo
    /// </summary>
    public static class RandomUtilityReportGenerator
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static IUtilityReport GenerateRandomUtilityReport()
        {
            return GenerateRandomUtilityReport(LoadoutRarity.None, MountSize.None);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mountSize"></param>
        /// <returns></returns>
        public static IUtilityReport GenerateRandomUtilityReport(MountSize mountSize)
        {
            return GenerateRandomUtilityReport(LoadoutRarity.None, mountSize);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="loadoutRarity"></param>
        /// <returns></returns>
        public static IUtilityReport GenerateRandomUtilityReport(LoadoutRarity loadoutRarity)
        {
            return GenerateRandomUtilityReport(loadoutRarity, MountSize.None);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="loadoutRarity"></param>
        /// <returns></returns>
        public static IUtilityReport GenerateRandomUtilityReport(LoadoutRarity loadoutRarity, MountSize mountSize)
        {
            UtilityId utilityId = (mountSize.Equals(MountSize.None))
                ? GetRandomUtilityId(loadoutRarity)
                : GetRandomUtilityId(loadoutRarity, mountSize);
            // Todo: Only randomize traits for non-unique loadouts
            return new UtilityReport.Builder()
                .SetUtilityId(utilityId)
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="loadoutRarity"></param>
        /// <returns></returns>
        private static UtilityId GetRandomUtilityId(LoadoutRarity loadoutRarity)
        {
            ISet<UtilityId> armorIdSet = UtilityRarityConstants.GetUtilityIdSet(loadoutRarity);
            if (armorIdSet.Count != 0)
            {
                return new List<UtilityId>(armorIdSet)[RandomNumberGeneratorUtil.GetNextInt(armorIdSet.Count - 1)];
            }
            throw ExceptionUtil.Arguments.Build("Unable to ?. Invalid Parameters. ? has no corresponding ?s.",
                    new StackFrame().GetMethod().Name, loadoutRarity, typeof(UtilityId));
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="loadoutRarity"></param>
        /// <returns></returns>
        private static UtilityId GetRandomUtilityId(LoadoutRarity loadoutRarity, MountSize mountSize)
        {
            ISet<UtilityId> utilityIdSet = new HashSet<UtilityId>();
            utilityIdSet.UnionWith(loadoutRarity.Equals(LoadoutRarity.None)
                ? utilityIdSet
                : UtilityRarityConstants.GetUtilityIdSet(loadoutRarity));
            utilityIdSet.IntersectWith(loadoutRarity.Equals(LoadoutRarity.None)
                ? utilityIdSet
                : UtilityMountSizeConstants.GetUtilityIdSet(mountSize));
            if (utilityIdSet.Count != 0)
            {
                return new List<UtilityId>(utilityIdSet)[RandomNumberGeneratorUtil.GetNextInt(utilityIdSet.Count)];
            }
            throw ExceptionUtil.Arguments.Build("Unable to ?. Invalid Parameters. ? and ? have no corresponding ?s.",
                    new StackFrame().GetMethod().Name, loadoutRarity, mountSize, typeof(UtilityId));
        }
    }
}