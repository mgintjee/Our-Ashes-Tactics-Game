/// <summary>
/// Company: HappyBananaStudio
/// Author: Matthew Gintjee
/// </summary>

namespace HappyBananaStudio.OurAshes.Tactics.Common.Constants.Talons.Attributes
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Attributes;
    using HappyBananaStudio.OurAshes.Tactics.Common.Constants.Talons.Enums;
    using HappyBananaStudio.OurAshesTactics.Common.Utils.Exceptions;
    using HappyBananaStudio.OurAshesTactics.Impl.Attributes.Talons;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Todo
    /// </summary>
    public class TalonAttributesConstants
    {
        // Todo
        private static readonly IDictionary<TalonModelIdEnum, ITalonAttributes> talonModelIdAttributesDictionary =
                new Dictionary<TalonModelIdEnum, ITalonAttributes>();

        // Todo
        private static readonly ISet<TalonModelIdEnum> talonModelIdSet = new HashSet<TalonModelIdEnum>()
        {
            TalonModelIdEnum.Talon0,
            TalonModelIdEnum.Talon1,
            TalonModelIdEnum.Talon2,
        };

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonModelId">
        /// </param>
        /// <returns>
        /// </returns>
        public static ITalonAttributes GetAttributes(TalonModelIdEnum talonModelId)
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
        public static ISet<TalonModelIdEnum> GetSupportedTalonIds()
        {
            return new HashSet<TalonModelIdEnum>(talonModelIdSet);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonModelId">
        /// </param>
        /// <returns>
        /// </returns>
        private static ITalonAttributes BuildAttributes(TalonModelIdEnum talonModelId)
        {
            switch (talonModelId)
            {
                case TalonModelIdEnum.Talon0:
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

                case TalonModelIdEnum.Talon1:
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

                case TalonModelIdEnum.Talon2:
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
