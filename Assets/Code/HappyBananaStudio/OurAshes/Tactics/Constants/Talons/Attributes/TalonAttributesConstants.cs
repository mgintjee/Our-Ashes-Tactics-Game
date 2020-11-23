namespace HappyBananaStudio.OurAshes.Tactics.Constants.Talons.Attributes
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Attributes;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Talons;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Exceptions;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Talons.Attributes;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Todo
    /// </summary>
    public class TalonAttributesConstants
    {
        // Todo
        private static readonly IDictionary<TalonModelId, ITalonAttributes> talonModelIdAttributesDictionary =
                new Dictionary<TalonModelId, ITalonAttributes>();

        // Todo
        private static readonly ISet<TalonModelId> talonModelIdSet = new HashSet<TalonModelId>()
        {
            TalonModelId.Talon0,
            TalonModelId.Talon1,
            TalonModelId.Talon2,
        };

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonModelId">
        /// </param>
        /// <returns>
        /// </returns>
        public static ITalonAttributes GetAttributes(TalonModelId talonModelId)
        {
            if (talonModelIdSet.Contains(talonModelId))
            {
                if (!talonModelIdAttributesDictionary.ContainsKey(talonModelId))
                {
                    talonModelIdAttributesDictionary.Add(talonModelId, BuildAttributes(talonModelId));
                }
                return talonModelIdAttributesDictionary[talonModelId];
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                    new StackFrame().GetMethod().Name, talonModelId);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public static ISet<TalonModelId> GetSupportedTalonIds()
        {
            return new HashSet<TalonModelId>(talonModelIdSet);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonModelId">
        /// </param>
        /// <returns>
        /// </returns>
        private static ITalonAttributes BuildAttributes(TalonModelId talonModelId)
        {
            switch (talonModelId)
            {
                case TalonModelId.Talon0:
                    return new TalonAttributesImpl.Builder()
                        .SetDestructibleAttributes(new DestructibleAttributesImpl.Builder()
                                .SetArmourPoints(2)
                                .SetHealthPoints(16)
                                .Build())
                        .SetMovableAttributes(new MovableAttributesImpl.Builder()
                                .SetMovePoints(12)
                                .SetTurnPoints(3)
                                .Build())
                        .SetMountableAttributes(new MountableAttributesImpl.Builder()
                                .SetWeaponPoints(2)
                                .SetUtilityPoints(0)
                                .Build())
                        .Build();

                case TalonModelId.Talon1:
                    return new TalonAttributesImpl.Builder()
                        .SetDestructibleAttributes(new DestructibleAttributesImpl.Builder()
                                .SetArmourPoints(1)
                                .SetHealthPoints(14)
                                .Build())
                        .SetMovableAttributes(new MovableAttributesImpl.Builder()
                                .SetMovePoints(16)
                                .SetTurnPoints(4)
                                .Build())
                        .SetMountableAttributes(new MountableAttributesImpl.Builder()
                                .SetWeaponPoints(1)
                                .SetUtilityPoints(0)
                                .Build())
                        .Build();

                case TalonModelId.Talon2:
                    return new TalonAttributesImpl.Builder()
                        .SetDestructibleAttributes(new DestructibleAttributesImpl.Builder()
                                .SetArmourPoints(3)
                                .SetHealthPoints(20)
                                .Build())
                        .SetMovableAttributes(new MovableAttributesImpl.Builder()
                                .SetMovePoints(8)
                                .SetTurnPoints(2)
                                .Build())
                        .SetMountableAttributes(new MountableAttributesImpl.Builder()
                                .SetWeaponPoints(3)
                                .SetUtilityPoints(0)
                                .Build())
                        .Build();

                default:
                    throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                        new StackFrame().GetMethod().Name, talonModelId);
            }
        }
    }
}