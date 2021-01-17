namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Mounts.Utilities.Constants
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Mounts.Utilities.Enums;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Todo
    /// </summary>
    public static class UtilityTypeConstants
    {
        // Todo
        private static readonly IDictionary<UtilityType, ISet<UtilityId>> utilityTypeUtilityIdSetDictionary =
            new Dictionary<UtilityType, ISet<UtilityId>>()
            {
                {
                    UtilityType.None,
                    new HashSet<UtilityId>()
                },
                {
                    UtilityType.Support,
                    new HashSet<UtilityId>()
                    {
                        UtilityId.Small1,
                        UtilityId.Large1
                    }
                },
            };

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="utilityType"></param>
        /// <returns></returns>
        public static ISet<UtilityId> GetUtilityIdSet(UtilityType utilityType)
        {
            // Check if the utilityType is supported
            if (utilityTypeUtilityIdSetDictionary.ContainsKey(utilityType))
            {
                return utilityTypeUtilityIdSetDictionary[utilityType];
            }
            throw ExceptionUtil.Argument.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                    new StackFrame().GetMethod().Name, utilityType);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="utilityId"></param>
        /// <returns></returns>
        public static UtilityType GetUtilityType(UtilityId utilityId)
        {
            foreach (UtilityType utilityType in utilityTypeUtilityIdSetDictionary.Keys)
            {
                if (utilityTypeUtilityIdSetDictionary[utilityType].Contains(utilityId))
                {
                    return utilityType;
                }
            }
            throw ExceptionUtil.Argument.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                    new StackFrame().GetMethod().Name, utilityId);
        }
    }
}