/// <summary>
/// Company: HappyBananaStudio
/// Author: Matthew Gintjee
/// </summary>
/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

namespace HappyBananaStudio.OurAshes.Tactics.Common.Constants.Hoplites.Attributes
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Attributes;
    using HappyBananaStudio.OurAshes.Tactics.Common.Constants.Hoplites.Enums;
    using HappyBananaStudio.OurAshesTactics.Common.Utils.Exceptions;
    using HappyBananaStudio.OurAshesTactics.Impl.Attributes.Bonus;
    using HappyBananaStudio.OurAshesTactics.Impl.Attributes.Talons;
    using HappyBananaStudio.OurAshesTactics.Impl.Attributes.Weapons;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Todo
    /// </summary>
    public class HopliteAttributesConstants
    {
        // Todo
        private static readonly IDictionary<HopliteTraitEnum, IBonusAttributes> hopliteTraitBonusAttributesDictionary =
            new Dictionary<HopliteTraitEnum, IBonusAttributes>();

        // Todo
        private static readonly ISet<HopliteTraitEnum> supportedHopliteTraitSet = new HashSet<HopliteTraitEnum>()
        {
            HopliteTraitEnum.Default
        };

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="hopliteTrait">
        /// </param>
        /// <returns>
        /// </returns>
        public static IBonusAttributes GetAttributes(HopliteTraitEnum hopliteTrait)
        {
            if (supportedHopliteTraitSet.Contains(hopliteTrait))
            {
                if (!hopliteTraitBonusAttributesDictionary.ContainsKey(hopliteTrait))
                {
                    hopliteTraitBonusAttributesDictionary.Add(hopliteTrait, BuildAttributes(hopliteTrait));
                }
                return hopliteTraitBonusAttributesDictionary[hopliteTrait];
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                    new StackFrame().GetMethod().Name, hopliteTrait);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="hopliteTraitSet">
        /// </param>
        /// <returns>
        /// </returns>
        public static IBonusAttributes GetAttributes(ISet<HopliteTraitEnum> hopliteTraitSet)
        {
            ISet<IBonusAttributes> bonusAttributesSet = new HashSet<IBonusAttributes>()
            {BuildAttributes(HopliteTraitEnum.None) };
            foreach (HopliteTraitEnum hopliteTrait in hopliteTraitSet)
            {
                if (!hopliteTrait.Equals(HopliteTraitEnum.None))
                {
                    bonusAttributesSet.Add(GetAttributes(hopliteTrait));
                }
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
        public static ISet<HopliteTraitEnum> GetSupportedHopliteTraitSet()
        {
            return new HashSet<HopliteTraitEnum>(supportedHopliteTraitSet);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="hopliteTrait">
        /// </param>
        /// <returns>
        /// </returns>
        private static IBonusAttributes BuildAttributes(HopliteTraitEnum hopliteTrait)
        {
            switch (hopliteTrait)
            {
                case HopliteTraitEnum.None:
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

                case HopliteTraitEnum.Default:
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
                        new StackFrame().GetMethod().Name, hopliteTrait);
            }
        }
    }
}
