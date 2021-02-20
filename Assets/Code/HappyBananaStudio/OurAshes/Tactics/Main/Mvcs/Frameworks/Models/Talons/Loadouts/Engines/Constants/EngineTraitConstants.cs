namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Engines.Constants
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Common.Attributes.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Common.Attributes.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Engines.Enums;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Todo
    /// </summary>
    public static class EngineTraitConstants
    {
        /// <summary>
        /// Todo
        /// </summary>
        public static class Efficiency
        {
            // Todo
            private static readonly IDictionary<EngineTraitEfficiency, ILoadoutAttributes>
                engineTraitEfficiencyLoadoutAttributesDictionary = new Dictionary<EngineTraitEfficiency, ILoadoutAttributes>()
                {
                    { EngineTraitEfficiency.None, new LoadoutAttributes.Builder().Build() },
                    { EngineTraitEfficiency.Efficiency1, new LoadoutAttributes.Builder().Build() },
                    { EngineTraitEfficiency.Efficiency2, new LoadoutAttributes.Builder().Build() },
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
                    throw ExceptionUtil.Arguments.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                        new StackFrame().GetMethod().Name, engineTraitEfficiency);
                }
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        public static class Structures
        {
            // Todo
            private static readonly IDictionary<EngineTraitStructure, ILoadoutAttributes>
                engineTraitStructureLoadoutAttributesDictionary = new Dictionary<EngineTraitStructure, ILoadoutAttributes>()
                {
                    { EngineTraitStructure.None, new LoadoutAttributes.Builder().Build() },
                    { EngineTraitStructure.Structure1, new LoadoutAttributes.Builder().Build() },
                    { EngineTraitStructure.Structure2, new LoadoutAttributes.Builder().Build() },
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
                    throw ExceptionUtil.Arguments.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                        new StackFrame().GetMethod().Name, engineTraitStructure);
                }
            }
        }
    }
}