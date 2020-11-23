namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Constants.Loadouts.Engines.Ids
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Loadouts.Armors.Enums;
    using HappyBananaStudio.OurAshes.Tactics.Api.Loadouts.Common.Attributes;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Loadouts.Common.Attributes;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Exceptions;
    using System.Collections.Generic;
    using System.Diagnostics;
    using HappyBananaStudio.OurAshes.Tactics.Api.Loadouts.Engines.Enums;

    /// <summary>
    /// Todo
    /// </summary>
    public static class EngineIdConstants
    {
        // Todo
        private static readonly IDictionary<EngineId, ILoadoutAttributes> engineIdArmorAttributesDictionary =
            new Dictionary<EngineId, ILoadoutAttributes>()
            {
                {
                    EngineId.None,
                    new LoadoutAttributesImpl.Builder().Build()
                },
                {
                    EngineId.Engine1,
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
                    EngineId.Engine2,
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
        /// <param name="engineId"></param>
        /// <returns></returns>
        public static ILoadoutAttributes GetLoadoutAttributes(EngineId engineId)
        {
            // Check if the engineId is supported
            if (engineIdArmorAttributesDictionary.ContainsKey(engineId))
            {
                return engineIdArmorAttributesDictionary[engineId];
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                    new StackFrame().GetMethod().Name, engineId);
            }
        }
    }
}