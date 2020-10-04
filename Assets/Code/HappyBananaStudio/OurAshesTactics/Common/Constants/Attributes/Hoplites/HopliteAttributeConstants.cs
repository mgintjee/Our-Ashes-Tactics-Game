/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Attributes.Bonus;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Attributes.Talons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Attributes.Weapons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Builders;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Enums;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Utils.Exceptions;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Constants.Attributes.Hoplites
{
    /// <summary>
    /// Todo
    /// </summary>
    public class HopliteAttributesConstants
    {
        // Todo
        private static readonly Dictionary<HopliteTraitEnum, IBonusAttributes> HOPLITE_TRAIT_ATTRIBUTES_DICTIONARY =
            new Dictionary<HopliteTraitEnum, IBonusAttributes>()
            {
                    {
                        HopliteTraitEnum.HopliteTrait0,
                        AttributesBuilder.Talon.Bonus.GetBuilder()
                            .SetDestructibleAttributes(Destructible.GetAttributes(HopliteTraitEnum.HopliteTrait0))
                            .SetMovableAttributes(Movable.GetAttributes(HopliteTraitEnum.HopliteTrait0))
                            .SetWeaponAttributes(Weapon.GetAttributes(HopliteTraitEnum.HopliteTrait0))
                            .Build()
                    },
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
            if (HOPLITE_TRAIT_ATTRIBUTES_DICTIONARY.ContainsKey(hopliteTrait))
            {
                return HOPLITE_TRAIT_ATTRIBUTES_DICTIONARY[hopliteTrait];
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
        /// <returns>
        /// </returns>
        public static HashSet<HopliteTraitEnum> GetSupportedHopliteTraitSet()
        {
            return new HashSet<HopliteTraitEnum>(HOPLITE_TRAIT_ATTRIBUTES_DICTIONARY.Keys);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonId">
        /// </param>
        /// <returns>
        /// </returns>
        private static IBonusAttributes BuildAttributes(HopliteTraitEnum hopliteTrait)
        {
            return AttributesBuilder.Talon.Bonus.GetBuilder()
                        .SetDestructibleAttributes(Destructible.GetAttributes(hopliteTrait))
                        .SetMovableAttributes(Movable.GetAttributes(hopliteTrait))
                        .SetWeaponAttributes(Weapon.GetAttributes(hopliteTrait))
                        .Build();
        }

        public static class Destructible
        {
            // Todo
            private static readonly Dictionary<HopliteTraitEnum, IDestructibleAttributes> HOPLITE_TRAIT_DESTRUCTIBLE_ATTRIBUTES_DICTIONARY =
                    new Dictionary<HopliteTraitEnum, IDestructibleAttributes>()
                    {
                        {
                            HopliteTraitEnum.HopliteTrait0,
                            AttributesBuilder.Talon.Destructible.GetBuilder()
                                .SetArmourPoints(0)
                                .SetHealthPoints(0)
                                .Build()
                        },
                    };

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="hopliteTrait">
            /// </param>
            /// <returns>
            /// </returns>
            public static IDestructibleAttributes GetAttributes(HopliteTraitEnum hopliteTrait)
            {
                if (HOPLITE_TRAIT_DESTRUCTIBLE_ATTRIBUTES_DICTIONARY.ContainsKey(hopliteTrait))
                {
                    return HOPLITE_TRAIT_DESTRUCTIBLE_ATTRIBUTES_DICTIONARY[hopliteTrait];
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                        new StackFrame().GetMethod().Name, hopliteTrait);
                }
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        public static class Movable
        {
            // Todo
            private static readonly Dictionary<HopliteTraitEnum, IMovableAttributes> HOPLITE_TRAIT_MOVABLE_ATTRIBUTES_DICTIONARY =
                    new Dictionary<HopliteTraitEnum, IMovableAttributes>()
                    {
                        {
                            HopliteTraitEnum.HopliteTrait0,
                            AttributesBuilder.Talon.Movable.GetBuilder()
                                .SetMovePoints(0)
                                .SetTurnPoints(0)
                                .Build()
                        },
                    };

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="hopliteTrait">
            /// </param>
            /// <returns>
            /// </returns>
            public static IMovableAttributes GetAttributes(HopliteTraitEnum hopliteTrait)
            {
                if (HOPLITE_TRAIT_MOVABLE_ATTRIBUTES_DICTIONARY.ContainsKey(hopliteTrait))
                {
                    return HOPLITE_TRAIT_MOVABLE_ATTRIBUTES_DICTIONARY[hopliteTrait];
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                        new StackFrame().GetMethod().Name, hopliteTrait);
                }
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        public static class Weapon
        {
            // Todo
            private static readonly Dictionary<HopliteTraitEnum, IWeaponAttributes> HOPLITE_TRAIT_WEAPON_ATTRIBUTES_DICTIONARY =
                    new Dictionary<HopliteTraitEnum, IWeaponAttributes>()
                    {
                        {
                            HopliteTraitEnum.HopliteTrait0,
                            AttributesBuilder.Weapon.GetBuilder()
                                .SetAccuracyPoints(0)
                                .SetDamagePoints(0)
                                .SetNumberOfShots(0)
                                .SetPenetrationPoints(0)
                                .SetRangePoints(0)
                                .SetRangeProximityPoints(0)
                                .Build()
                        },
                    };

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="hopliteTrait">
            /// </param>
            /// <returns>
            /// </returns>
            public static IWeaponAttributes GetAttributes(HopliteTraitEnum hopliteTrait)
            {
                if (HOPLITE_TRAIT_WEAPON_ATTRIBUTES_DICTIONARY.ContainsKey(hopliteTrait))
                {
                    return HOPLITE_TRAIT_WEAPON_ATTRIBUTES_DICTIONARY[hopliteTrait];
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                        new StackFrame().GetMethod().Name, hopliteTrait);
                }
            }
        }
    }
}