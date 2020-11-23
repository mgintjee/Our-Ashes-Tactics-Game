namespace HappyBananaStudio.OurAshes.Tactics.Constants.Loadouts.Engines.Traits
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
    public static class EngineTraitStructureConstants
    {
        // Todo
        private static readonly IDictionary<EngineTraitStructure, ILoadoutAttributes> engineTraitStructureLoadoutAttributesDictionary =
            new Dictionary<EngineTraitStructure, ILoadoutAttributes>()
            {
                {
                    EngineTraitStructure.None,
                    new LoadoutAttributesImpl.Builder().Build()
                },
            };

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="engineTraitStructure"></param>
        /// <returns></returns>
        public static ILoadoutAttributes GetLoadoutAttributes(EngineTraitStructure engineTraitStructure)
        {
            // Check if the armorTraitStructure is supported
            if (engineTraitStructureLoadoutAttributesDictionary.ContainsKey(engineTraitStructure))
            {
                return engineTraitStructureLoadoutAttributesDictionary[engineTraitStructure];
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                    new StackFrame().GetMethod().Name, engineTraitStructure);
            }
        }
    }
}