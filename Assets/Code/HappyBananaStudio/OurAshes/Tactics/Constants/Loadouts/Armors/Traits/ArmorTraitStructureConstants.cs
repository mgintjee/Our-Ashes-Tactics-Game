namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Constants.Loadouts.Armors.Traits
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Loadouts.Common.Attributes;
    using HappyBananaStudio.OurAshes.Tactics.Api.Loadouts.Mounts.Weapons.Enums;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Loadouts.Common.Attributes;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Exceptions;
    using System.Collections.Generic;
    using System.Diagnostics;
    using HappyBananaStudio.OurAshes.Tactics.Api.Loadouts.Armors.Enums;

    /// <summary>
    /// Todo
    /// </summary>
    public static class ArmorTraitStructureConstants
    {
        // Todo
        private static readonly IDictionary<ArmorTraitStructure, ILoadoutAttributes> armorTraitStructureLoadoutAttributesDictionary =
            new Dictionary<ArmorTraitStructure, ILoadoutAttributes>()
            {
                {
                    ArmorTraitStructure.None,
                    new LoadoutAttributesImpl.Builder().Build()
                },
            };

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="armorTraitStructure"></param>
        /// <returns></returns>
        public static ILoadoutAttributes GetLoadoutAttributes(ArmorTraitStructure armorTraitStructure)
        {
            // Check if the armorTraitStructure is supported
            if (armorTraitStructureLoadoutAttributesDictionary.ContainsKey(armorTraitStructure))
            {
                return armorTraitStructureLoadoutAttributesDictionary[armorTraitStructure];
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                    new StackFrame().GetMethod().Name, armorTraitStructure);
            }
        }
    }
}