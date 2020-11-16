

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
        private static readonly IDictionary<UtilityModelId, IBonusAttributes> utilityModelIdBonusAttributesDictionary =
            new Dictionary<UtilityModelId, IBonusAttributes>();

        // Todo
        private static readonly ISet<UtilityModelId> utilityModelIdSet = new HashSet<UtilityModelId>()
        {
            UtilityModelId.Default,
        };

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="utilityModelId">
        /// </param>
        /// <returns>
        /// </returns>
        public static IBonusAttributes GetAttributes(UtilityModelId utilityModelId)
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
        public static IBonusAttributes GetAttributes(ISet<UtilityModelId> utilityModelIdSet)
        {
            ISet<IBonusAttributes> bonusAttributesSet = new HashSet<IBonusAttributes>()
            { BuildAttributes(UtilityModelId.None) };
            foreach (UtilityModelId utilityModelId in utilityModelIdSet)
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
        public static ISet<UtilityModelId> GetSupportedUtilityModelIds()
        {
            return new HashSet<UtilityModelId>(utilityModelIdSet);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="utilityModelId">
        /// </param>
        /// <returns>
        /// </returns>
        private static IBonusAttributes BuildAttributes(UtilityModelId utilityModelId)
        {
            switch (utilityModelId)
            {
                case UtilityModelId.None:
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
