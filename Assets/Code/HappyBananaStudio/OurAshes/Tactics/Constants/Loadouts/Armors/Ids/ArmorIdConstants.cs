namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Constants.Loadouts.Armors.Ids
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Loadouts.Armors.Enums;
    using HappyBananaStudio.OurAshes.Tactics.Api.Loadouts.Common.Attributes;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Loadouts.Common.Attributes;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Exceptions;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Todo
    /// </summary>
    public static class ArmorIdConstants
    {
        // Todo
        private static readonly IDictionary<ArmorId, ILoadoutAttributes> armorIdArmorAttributesDictionary =
            new Dictionary<ArmorId, ILoadoutAttributes>()
            {
                {
                    ArmorId.None,
                    new LoadoutAttributesImpl.Builder().Build()
                },
                {
                    ArmorId.Heavy1,
                    new LoadoutAttributesImpl.Builder()
                    .SetArmorAttributes(new ArmorAttributesImpl.Builder()
                        .SetArmorPoints(1)
                        .SetHealthPoints(1)
                        .Build())
                    .SetEngineAttributes(new EngineAttributesImpl.Builder()
                        .SetMovementPoints(-2)
                        .Build())
                    .Build()
                },
                {
                    ArmorId.Light1,
                    new LoadoutAttributesImpl.Builder()
                    .SetArmorAttributes(new ArmorAttributesImpl.Builder()
                        .SetArmorPoints(-1)
                        .SetHealthPoints(-1)
                        .Build())
                    .SetEngineAttributes(new EngineAttributesImpl.Builder()
                        .SetMovementPoints(+2)
                        .Build())
                    .Build()
                }

            };

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="armorId"></param>
        /// <returns></returns>
        public static ILoadoutAttributes GetLoadoutAttributes(ArmorId armorId)
        {
            // Check if the armorId is supported
            if (armorIdArmorAttributesDictionary.ContainsKey(armorId))
            {
                return armorIdArmorAttributesDictionary[armorId];
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                    new StackFrame().GetMethod().Name, armorId);
            }
        }
    }
}