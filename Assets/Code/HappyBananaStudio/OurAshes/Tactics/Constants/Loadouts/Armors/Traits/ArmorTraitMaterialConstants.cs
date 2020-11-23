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
    public static class ArmorTraitMaterialConstants
    {
        // Todo
        private static readonly IDictionary<ArmorTraitMaterial, ILoadoutAttributes> armorTraitMaterialLoadoutAttributesDictionary =
            new Dictionary<ArmorTraitMaterial, ILoadoutAttributes>()
            {
                {
                    ArmorTraitMaterial.None,
                    new LoadoutAttributesImpl.Builder().Build()
                },
            };

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="armorTraitMaterial"></param>
        /// <returns></returns>
        public static ILoadoutAttributes GetLoadoutAttributes(ArmorTraitMaterial armorTraitMaterial)
        {
            // Check if the armorTraitMaterial is supported
            if (armorTraitMaterialLoadoutAttributesDictionary.ContainsKey(armorTraitMaterial))
            {
                return armorTraitMaterialLoadoutAttributesDictionary[armorTraitMaterial];
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                    new StackFrame().GetMethod().Name, armorTraitMaterial);
            }
        }
    }
}