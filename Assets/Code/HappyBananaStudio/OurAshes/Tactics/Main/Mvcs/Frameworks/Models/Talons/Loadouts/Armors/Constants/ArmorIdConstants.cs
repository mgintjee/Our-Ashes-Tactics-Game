namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Armors.Constants
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Armors.Attributes.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Armors.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Common.Attributes.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Common.Attributes.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Engines.Attributes.Impl;
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
                    new LoadoutAttributes.Builder().Build()
                },
                {
                    ArmorId.Heavy1,
                    new LoadoutAttributes.Builder()
                    .SetArmorAttributes(new ArmorAttributes.Builder()
                        .SetArmorPoints(1)
                        .SetHealthPoints(1)
                        .Build())
                    .SetEngineAttributes(new EngineAttributes.Builder()
                        .SetMovementPoints(-2)
                        .Build())
                    .Build()
                },
                {
                    ArmorId.Light1,
                    new LoadoutAttributes.Builder()
                    .SetArmorAttributes(new ArmorAttributes.Builder()
                        .SetArmorPoints(-1)
                        .SetHealthPoints(-1)
                        .Build())
                    .SetEngineAttributes(new EngineAttributes.Builder()
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
            throw ExceptionUtil.Arguments.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                new StackFrame().GetMethod().Name, armorId);
        }
    }
}