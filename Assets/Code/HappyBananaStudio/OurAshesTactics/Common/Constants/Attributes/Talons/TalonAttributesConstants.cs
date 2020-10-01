/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Attributes.Talons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Builders;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Enums;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Exceptions;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Constants.Attributes.Talons
{
    /// <summary>
    /// Todo
    /// </summary>
    public class TalonAttributesConstants
    {
        // Todo
        private static readonly Dictionary<TalonModelIdEnum, ITalonAttributes> TALON_ID_ATTRIBUTES_DICTIONARY =
                new Dictionary<TalonModelIdEnum, ITalonAttributes>()
                {
                    {
                        TalonModelIdEnum.Talon0, BuildAttributes(TalonModelIdEnum.Talon0)
                    },
                    {
                        TalonModelIdEnum.Talon1, BuildAttributes(TalonModelIdEnum.Talon1)
                    },
                    {
                        TalonModelIdEnum.Talon2, BuildAttributes(TalonModelIdEnum.Talon2)
                    },
                };

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonId">
        /// </param>
        /// <returns>
        /// </returns>
        public static ITalonAttributes GetAttributes(TalonModelIdEnum talonId)
        {
            if (TALON_ID_ATTRIBUTES_DICTIONARY.ContainsKey(talonId))
            {
                return TALON_ID_ATTRIBUTES_DICTIONARY[talonId];
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                    new StackFrame().GetMethod().Name, talonId);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public static HashSet<TalonModelIdEnum> GetSupportedTalonIds()
        {
            return new HashSet<TalonModelIdEnum>(TALON_ID_ATTRIBUTES_DICTIONARY.Keys);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonId">
        /// </param>
        /// <returns>
        /// </returns>
        private static ITalonAttributes BuildAttributes(TalonModelIdEnum talonId)
        {
            return AttributesBuilder.Talon.GetBuilder()
                        .SetDestructibleAttributes(Destructible.GetAttributes(talonId))
                        .SetFireableAttributes(Fireable.GetAttributes(talonId))
                        .SetMovableAttributes(Movable.GetAttributes(talonId))
                        .SetUtilityAttributes(Utility.GetAttributes(talonId))
                        .Build();
        }

        public static class Destructible
        {
            // Todo
            private static readonly Dictionary<TalonModelIdEnum, IDestructibleAttributes> TALON_ID_DESTRUCTIBLE_ATTRIBUTES_DICTIONARY =
                    new Dictionary<TalonModelIdEnum, IDestructibleAttributes>()
                    {
                        {
                            TalonModelIdEnum.Talon0,
                            AttributesBuilder.Talon.Destructible.GetBuilder()
                                .SetArmourPoints(2)
                                .SetHealthPoints(16)
                                .Build()
                        },
                        {
                            TalonModelIdEnum.Talon1,
                            AttributesBuilder.Talon.Destructible.GetBuilder()
                                .SetArmourPoints(1)
                                .SetHealthPoints(12)
                                .Build()
                        },
                        {
                            TalonModelIdEnum.Talon2,
                            AttributesBuilder.Talon.Destructible.GetBuilder()
                                .SetArmourPoints(3)
                                .SetHealthPoints(20)
                                .Build()
                        },
                    };

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="talonId">
            /// </param>
            /// <returns>
            /// </returns>
            public static IDestructibleAttributes GetAttributes(TalonModelIdEnum talonId)
            {
                if (TALON_ID_DESTRUCTIBLE_ATTRIBUTES_DICTIONARY.ContainsKey(talonId))
                {
                    return TALON_ID_DESTRUCTIBLE_ATTRIBUTES_DICTIONARY[talonId];
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                        new StackFrame().GetMethod().Name, talonId);
                }
            }
        }

        public static class Fireable
        {
            // Todo
            private static readonly Dictionary<TalonModelIdEnum, IFireableAttributes> TALON_ID_FIREABLE_ATTRIBUTES_DICTIONARY =
                    new Dictionary<TalonModelIdEnum, IFireableAttributes>()
                    {
                        {
                            TalonModelIdEnum.Talon0,
                            AttributesBuilder.Talon.Fireable.GetBuilder()
                                .SetWeaponPoints(2)
                                .Build()
                        },
                        {
                            TalonModelIdEnum.Talon1,
                            AttributesBuilder.Talon.Fireable.GetBuilder()
                                .SetWeaponPoints(1)
                                .Build()
                        },
                        {
                            TalonModelIdEnum.Talon2,
                            AttributesBuilder.Talon.Fireable.GetBuilder()
                                .SetWeaponPoints(3)
                                .Build()
                        },
                    };

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="talonId">
            /// </param>
            /// <returns>
            /// </returns>
            public static IFireableAttributes GetAttributes(TalonModelIdEnum talonId)
            {
                if (TALON_ID_FIREABLE_ATTRIBUTES_DICTIONARY.ContainsKey(talonId))
                {
                    return TALON_ID_FIREABLE_ATTRIBUTES_DICTIONARY[talonId];
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                        new StackFrame().GetMethod().Name, talonId);
                }
            }
        }

        public static class Movable
        {
            // Todo
            private static readonly Dictionary<TalonModelIdEnum, IMovableAttributes> TALON_ID_MOVABLE_ATTRIBUTES_DICTIONARY =
                    new Dictionary<TalonModelIdEnum, IMovableAttributes>()
                    {
                        {
                            TalonModelIdEnum.Talon0,
                            AttributesBuilder.Talon.Movable.GetBuilder()
                                .SetMovePoints(12)
                                .SetTurnPoints(3)
                                .Build()
                        },
                        {
                            TalonModelIdEnum.Talon1,
                            AttributesBuilder.Talon.Movable.GetBuilder()
                                .SetMovePoints(16)
                                .SetTurnPoints(4)
                                .Build()
                        },
                        {
                            TalonModelIdEnum.Talon2,
                            AttributesBuilder.Talon.Movable.GetBuilder()
                                .SetMovePoints(8)
                                .SetTurnPoints(2)
                                .Build()
                        },
                    };

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="talonId">
            /// </param>
            /// <returns>
            /// </returns>
            public static IMovableAttributes GetAttributes(TalonModelIdEnum talonId)
            {
                if (TALON_ID_MOVABLE_ATTRIBUTES_DICTIONARY.ContainsKey(talonId))
                {
                    return TALON_ID_MOVABLE_ATTRIBUTES_DICTIONARY[talonId];
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                        new StackFrame().GetMethod().Name, talonId);
                }
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        public static class Utility
        {
            // Todo
            private static readonly Dictionary<TalonModelIdEnum, IUtilityAttributes> TALON_ID_UTILITY_ATTRIBUTES_DICTIONARY =
                    new Dictionary<TalonModelIdEnum, IUtilityAttributes>()
                    {
                        {
                            TalonModelIdEnum.Talon0,
                            AttributesBuilder.Talon.Utility.GetBuilder()
                                .SetUtilityPoints(0)
                                .Build()
                        },
                        {
                            TalonModelIdEnum.Talon1,
                            AttributesBuilder.Talon.Utility.GetBuilder()
                                .SetUtilityPoints(0)
                                .Build()
                        },
                        {
                            TalonModelIdEnum.Talon2,
                            AttributesBuilder.Talon.Utility.GetBuilder()
                                .SetUtilityPoints(0)
                                .Build()
                        },
                    };

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="talonId">
            /// </param>
            /// <returns>
            /// </returns>
            public static IUtilityAttributes GetAttributes(TalonModelIdEnum talonId)
            {
                if (TALON_ID_UTILITY_ATTRIBUTES_DICTIONARY.ContainsKey(talonId))
                {
                    return TALON_ID_UTILITY_ATTRIBUTES_DICTIONARY[talonId];
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                        new StackFrame().GetMethod().Name, talonId);
                }
            }
        }
    }
}