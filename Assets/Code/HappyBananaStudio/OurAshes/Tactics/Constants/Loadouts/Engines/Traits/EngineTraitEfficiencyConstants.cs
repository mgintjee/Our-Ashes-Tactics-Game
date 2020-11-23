namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Constants.Loadouts.Engines.Traits
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Loadouts.Common.Attributes;
    using HappyBananaStudio.OurAshes.Tactics.Api.Loadouts.Mounts.Weapons.Enums;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Loadouts.Common.Attributes;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Exceptions;
    using System.Collections.Generic;
    using System.Diagnostics;
    using HappyBananaStudio.OurAshes.Tactics.Api.Loadouts.Armors.Enums;
    using HappyBananaStudio.OurAshes.Tactics.Api.Loadouts.Engines.Enums;

    /// <summary>
    /// Todo
    /// </summary>
    public static class EngineTraitEfficiencyConstants
    {
        // Todo
        private static readonly IDictionary<EngineTraitEfficiency, ILoadoutAttributes> engineTraitEfficiencyLoadoutAttributesDictionary =
            new Dictionary<EngineTraitEfficiency, ILoadoutAttributes>()
            {
                {
                    EngineTraitEfficiency.None,
                    new LoadoutAttributesImpl.Builder().Build()
                },
            };

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="engineTraitEfficiency"></param>
        /// <returns></returns>
        public static ILoadoutAttributes GetLoadoutAttributes(EngineTraitEfficiency engineTraitEfficiency)
        {
            // Check if the engineTraitEfficiency is supported
            if (engineTraitEfficiencyLoadoutAttributesDictionary.ContainsKey(engineTraitEfficiency))
            {
                return engineTraitEfficiencyLoadoutAttributesDictionary[engineTraitEfficiency];
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                    new StackFrame().GetMethod().Name, engineTraitEfficiency);
            }
        }
    }
}