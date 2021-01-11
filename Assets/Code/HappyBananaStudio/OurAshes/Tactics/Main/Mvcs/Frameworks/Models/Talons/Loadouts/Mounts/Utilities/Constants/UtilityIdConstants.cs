namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Mounts.Utilities.Constants
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Common.Attributes.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Common.Attributes.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Mounts.Utilities.Enums;
    using HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Todo
    /// </summary>
    public static class UtilityIdConstants
    {
        // Todo
        private static readonly IDictionary<UtilityId, ILoadoutAttributes> utilityIdLoadoutAttributesDictionary =
            new Dictionary<UtilityId, ILoadoutAttributes>()
            {
                {
                    UtilityId.None,
                    new LoadoutAttributesImpl.Builder().Build()
                },
                {
                    UtilityId.Utility1,
                    new LoadoutAttributesImpl.Builder().Build()
                }
            };

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="utilityId"></param>
        /// <returns></returns>
        public static ILoadoutAttributes GetLoadoutAttributes(UtilityId utilityId)
        {
            // Check if the utilityId is supported
            if (utilityIdLoadoutAttributesDictionary.ContainsKey(utilityId))
            {
                return utilityIdLoadoutAttributesDictionary[utilityId];
            }
            else
            {
                throw ExceptionUtil.Argument.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                    new StackFrame().GetMethod().Name, utilityId);
            }
        }
    }
}