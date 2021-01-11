namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Mounts.Utilities.Constants
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Mounts.Common.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Mounts.Utilities.Enums;
    using HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Todo
    /// </summary>
    public static class UtilityMountSizeConstants
    {
        // Todo
        private static readonly IDictionary<MountSize, ISet<UtilityId>> mountSizeUtilityIdDictionary =
            new Dictionary<MountSize, ISet<UtilityId>>()
            {
                {
                    MountSize.None,
                    new HashSet<UtilityId>()
                },
                {
                    MountSize.Small,
                    new HashSet<UtilityId>()
                    {
                        UtilityId.Utility1,
                    }
                }
            };

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="utilityId"></param>
        /// <returns></returns>
        public static MountSize GetMountSize(UtilityId utilityId)
        {
            foreach (MountSize mountSize in mountSizeUtilityIdDictionary.Keys)
            {
                if (mountSizeUtilityIdDictionary[mountSize].Contains(utilityId))
                {
                    return mountSize;
                }
            }
            throw ExceptionUtil.Argument.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                    new StackFrame().GetMethod().Name, utilityId);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mountSize"></param>
        /// <returns></returns>
        public static ISet<UtilityId> GetUtilityIdSet(MountSize mountSize)
        {
            // Check if the mountSize is supported
            if (mountSizeUtilityIdDictionary.ContainsKey(mountSize))
            {
                return mountSizeUtilityIdDictionary[mountSize];
            }
            else
            {
                throw ExceptionUtil.Argument.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                    new StackFrame().GetMethod().Name, mountSize);
            }
        }
    }
}