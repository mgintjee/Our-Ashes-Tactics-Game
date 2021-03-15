using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Armors.Attributes.Impl;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Common.Attributes.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Common.Attributes.Impl;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Engines.Attributes.Impl;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Engines.Enums;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Engines.Constants
{
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
                    new LoadoutAttributes.Builder().Build()
                },
                {
                    EngineId.Sturdy1,
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
                    EngineId.Quick1,
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
        /// <param name="engineId"></param>
        /// <returns></returns>
        public static ILoadoutAttributes GetLoadoutAttributes(EngineId engineId)
        {
            // Check if the engineId is supported
            if (engineIdArmorAttributesDictionary.ContainsKey(engineId))
            {
                return engineIdArmorAttributesDictionary[engineId];
            }
            throw ExceptionUtil.Arguments.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                new StackFrame().GetMethod().Name, engineId);
        }
    }
}