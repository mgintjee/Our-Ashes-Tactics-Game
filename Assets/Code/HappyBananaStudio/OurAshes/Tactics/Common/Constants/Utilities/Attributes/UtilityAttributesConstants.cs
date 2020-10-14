

namespace HappyBananaStudio.OurAshes.Tactics.Common.Constants.Utilities.Attributes
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Attributes;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Utilities;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Exceptions;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Talons.Attributes;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Weapons.Attributes;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Todo
    /// </summary>
    public class UtilityAttributesConstants
    {
        // Todo
        private static readonly IDictionary<UtilityModelIdEnum, IBonusAttributes> utilityModelIdBonusAttributesDictionary =
            new Dictionary<UtilityModelIdEnum, IBonusAttributes>();

        // Todo
        private static readonly ISet<UtilityModelIdEnum> utilityModelIdSet = new HashSet<UtilityModelIdEnum>()
        {
            UtilityModelIdEnum.Default,
        };

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="utilityModelId">
        /// </param>
        /// <returns>
        /// </returns>
        public static IBonusAttributes GetAttributes(UtilityModelIdEnum utilityModelId)
        {
            if (utilityModelIdSet.Contains(utilityModelId))
            {
                if (!utilityModelIdBonusAttributesDictionary.ContainsKey(utilityModelId))
                {
                    utilityModelIdBonusAttributesDictionary.Add(utilityModelId, BuildAttributes(utilityModelId));
                }
                return utilityModelIdBonusAttributesDictionary[utilityModelId];
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                    new StackFrame().GetMethod().Name, utilityModelId);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="utilityModelIdSet">
        /// </param>
        /// <returns>
        /// </returns>
        public static IBonusAttributes GetAttributes(ISet<UtilityModelIdEnum> utilityModelIdSet)
        {
            ISet<IBonusAttributes> bonusAttributesSet = new HashSet<IBonusAttributes>()
            { BuildAttributes(UtilityModelIdEnum.None) };
            foreach (UtilityModelIdEnum utilityModelId in utilityModelIdSet)
            {
                bonusAttributesSet.Add(GetAttributes(utilityModelId));
            }
            return new BonusAttributesImpl.Builder()
                .SetBonusAttributesCollection(bonusAttributesSet)
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public static ISet<UtilityModelIdEnum> GetSupportedUtilityModelIds()
        {
            return new HashSet<UtilityModelIdEnum>(utilityModelIdSet);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="utilityModelId">
        /// </param>
        /// <returns>
        /// </returns>
        private static IBonusAttributes BuildAttributes(UtilityModelIdEnum utilityModelId)
        {
            switch (utilityModelId)
            {
                case UtilityModelIdEnum.None:
                    return new BonusAttributesImpl.Builder()
                        .SetDestructibleAttributes(new DestructibleAttributesImpl.Builder()
                                .SetArmourPoints(0)
                                .SetHealthPoints(0)
                                .Build())
                        .SetMovableAttributes(new MovableAttributesImpl.Builder()
                                .SetMovePoints(0)
                                .SetTurnPoints(0)
                                .Build())
                        .SetWeaponAttributes(new WeaponAttributesImpl.Builder()
                                .SetAccuracyPoints(0)
                                .SetDamagePoints(0)
                                .SetNumberOfShots(0)
                                .SetPenetrationPoints(0)
                                .SetRangePoints(0)
                                .Build())
                        .Build();

                default:
                    throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                        new StackFrame().GetMethod().Name, utilityModelId);
            }
        }
    }
}
