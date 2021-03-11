namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Attributes.Constants
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Armors.Attributes.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Attributes.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Attributes.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Engines.Attributes.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Mounts.Common.Enums;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Todo
    /// </summary>
    public class TalonLoadoutAttributesConstants
    {
        // Todo
        private static readonly IDictionary<TalonId, ITalonLoadoutAttributes> talonIdLoadoutAttributesDictionary =
                new Dictionary<TalonId, ITalonLoadoutAttributes>()
                {
                    {
                        TalonId.TalonLight1,
                        new TalonLoadoutAttributes.Builder()
                            .SetArmorAttributes(new ArmorAttributes.Builder()
                                .SetArmorPoints(3)
                                .SetHealthPoints(14)
                                .Build())
                            .SetEngineAttributes(new EngineAttributes.Builder()
                                .SetActionPoints(3)
                                .SetMovementPoints(20)
                                .Build())
                            .SetMountSizeList(new List<MountSize>()
                            {
                                MountSize.Small,
                                MountSize.Small,
                            })
                        .Build()
                    },
                    {
                        TalonId.TalonMedium1,
                        new TalonLoadoutAttributes.Builder()
                            .SetArmorAttributes(new ArmorAttributes.Builder()
                                .SetArmorPoints(5)
                                .SetHealthPoints(20)
                                .Build())
                            .SetEngineAttributes(new EngineAttributes.Builder()
                                .SetActionPoints(2)
                                .SetMovementPoints(12)
                                .Build())
                            .SetMountSizeList(new List<MountSize>()
                            {
                                MountSize.Small,
                                MountSize.Small,
                                MountSize.Large,
                            })
                        .Build()
                    },
                    {
                        TalonId.TalonHeavy1,
                        new TalonLoadoutAttributes.Builder()
                            .SetArmorAttributes(new ArmorAttributes.Builder()
                                .SetArmorPoints(8)
                                .SetHealthPoints(24)
                                .Build())
                            .SetEngineAttributes(new EngineAttributes.Builder()
                                .SetActionPoints(2)
                                .SetMovementPoints(8)
                                .Build())
                            .SetMountSizeList(new List<MountSize>()
                            {
                                MountSize.Small,
                                MountSize.Small,
                                MountSize.Small,
                                MountSize.Large,
                                MountSize.Large,
                            })
                        .Build()
                    },
                };

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonId"></param>
        /// <returns></returns>
        public static ITalonLoadoutAttributes GetTalonLoadoutAttributes(TalonId talonId)
        {
            // Check if the talonId is supported
            if (talonIdLoadoutAttributesDictionary.ContainsKey(talonId))
            {
                return talonIdLoadoutAttributesDictionary[talonId];
            }
            else
            {
                throw ExceptionUtil.Arguments.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                    new StackFrame().GetMethod().Name, talonId);
            }
        }
    }
}