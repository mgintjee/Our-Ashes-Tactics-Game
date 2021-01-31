namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Mounts.Utilities.Constants
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Common.Attributes.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Common.Attributes.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Mounts.Utilities.Enums;
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
                    new LoadoutAttributes.Builder().Build()
                },
                {
                    UtilityId.Small1,
                    new LoadoutAttributes.Builder().Build()
                },
                {
                    UtilityId.Large1,
                    new LoadoutAttributes.Builder().Build()
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
                throw ExceptionUtil.Arguments.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                    new StackFrame().GetMethod().Name, utilityId);
            }
        }
    }
}