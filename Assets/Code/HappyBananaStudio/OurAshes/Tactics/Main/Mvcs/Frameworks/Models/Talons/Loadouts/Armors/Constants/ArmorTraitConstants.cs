namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Armors.Constants
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Armors.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Common.Attributes.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Common.Attributes.Impl;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Todo
    /// </summary>
    public static class ArmorTraitConstants
    {
        /// <summary>
        /// Todo
        /// </summary>
        public static class Materials
        {
            // Todo
            private static readonly IDictionary<ArmorTraitMaterial, ILoadoutAttributes> armorTraitMaterialLoadoutAttributesDictionary =
                new Dictionary<ArmorTraitMaterial, ILoadoutAttributes>()
                {
                    { ArmorTraitMaterial.None, new LoadoutAttributes.Builder().Build() },
                    { ArmorTraitMaterial.Material1, new LoadoutAttributes.Builder().Build() },
                    { ArmorTraitMaterial.Material2, new LoadoutAttributes.Builder().Build() },
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
                throw ExceptionUtil.Arguments.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                    new StackFrame().GetMethod().Name, armorTraitMaterial);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        public static class Structures
        {
            // Todo
            private static readonly IDictionary<ArmorTraitStructure, ILoadoutAttributes> armorTraitStructureLoadoutAttributesDictionary =
                new Dictionary<ArmorTraitStructure, ILoadoutAttributes>()
                {
                    { ArmorTraitStructure.None, new LoadoutAttributes.Builder().Build() },
                    { ArmorTraitStructure.Structure1, new LoadoutAttributes.Builder().Build() },
                    { ArmorTraitStructure.Structure2, new LoadoutAttributes.Builder().Build() },
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
                throw ExceptionUtil.Arguments.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                    new StackFrame().GetMethod().Name, armorTraitStructure);
            }
        }
    }
}