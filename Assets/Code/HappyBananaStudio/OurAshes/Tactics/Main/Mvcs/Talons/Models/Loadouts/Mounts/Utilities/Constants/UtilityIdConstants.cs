using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Common.Attributes.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Common.Attributes.Impl;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Mounts.Utilities.Enums;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Mounts.Utilities.Constants
{
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
            throw ExceptionUtil.Arguments.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                new StackFrame().GetMethod().Name, utilityId);
        }
    }
}