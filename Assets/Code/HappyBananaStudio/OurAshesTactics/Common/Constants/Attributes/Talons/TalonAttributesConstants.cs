/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Attributes.Api.Talons;
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
        private static readonly Dictionary<TalonIdEnum, ITalonAttributes> TALON_ID_ATTRIBUTES_DICTIONARY =
                new Dictionary<TalonIdEnum, ITalonAttributes>()
                {
                    {
                        TalonIdEnum.Talon0, BuildAttributes(TalonIdEnum.Talon0)
                    },
                    {
                        TalonIdEnum.Talon1, BuildAttributes(TalonIdEnum.Talon1)
                    },
                    {
                        TalonIdEnum.Talon2, BuildAttributes(TalonIdEnum.Talon2)
                    },
                };

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonId">
        /// </param>
        /// <returns>
        /// </returns>
        public static ITalonAttributes GetAttributes(TalonIdEnum talonId)
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
        public static HashSet<TalonIdEnum> GetSupportedTalonIds()
        {
            return new HashSet<TalonIdEnum>(TALON_ID_ATTRIBUTES_DICTIONARY.Keys);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonId">
        /// </param>
        /// <returns>
        /// </returns>
        private static ITalonAttributes BuildAttributes(TalonIdEnum talonId)
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
            private static readonly Dictionary<TalonIdEnum, IDestructibleAttributes> TALON_ID_DESTRUCTIBLE_ATTRIBUTES_DICTIONARY =
                    new Dictionary<TalonIdEnum, IDestructibleAttributes>()
                    {
                        {
                            TalonIdEnum.Talon0,
                            AttributesBuilder.Talon.Destructible.GetBuilder()
                                .SetArmourPoints(2)
                                .SetHealthPoints(16)
                                .Build()
                        },
                        {
                            TalonIdEnum.Talon1,
                            AttributesBuilder.Talon.Destructible.GetBuilder()
                                .SetArmourPoints(1)
                                .SetHealthPoints(12)
                                .Build()
                        },
                        {
                            TalonIdEnum.Talon2,
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
            public static IDestructibleAttributes GetAttributes(TalonIdEnum talonId)
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
            private static readonly Dictionary<TalonIdEnum, IFireableAttributes> TALON_ID_FIREABLE_ATTRIBUTES_DICTIONARY =
                    new Dictionary<TalonIdEnum, IFireableAttributes>()
                    {
                        {
                            TalonIdEnum.Talon0,
                            AttributesBuilder.Talon.Fireable.GetBuilder()
                                .SetWeaponPoints(2)
                                .Build()
                        },
                        {
                            TalonIdEnum.Talon1,
                            AttributesBuilder.Talon.Fireable.GetBuilder()
                                .SetWeaponPoints(1)
                                .Build()
                        },
                        {
                            TalonIdEnum.Talon2,
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
            public static IFireableAttributes GetAttributes(TalonIdEnum talonId)
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
            private static readonly Dictionary<TalonIdEnum, IMovableAttributes> TALON_ID_MOVABLE_ATTRIBUTES_DICTIONARY =
                    new Dictionary<TalonIdEnum, IMovableAttributes>()
                    {
                        {
                            TalonIdEnum.Talon0,
                            AttributesBuilder.Talon.Movable.GetBuilder()
                                .SetMovePoints(12)
                                .SetTurnPoints(3)
                                .Build()
                        },
                        {
                            TalonIdEnum.Talon1,
                            AttributesBuilder.Talon.Movable.GetBuilder()
                                .SetMovePoints(16)
                                .SetTurnPoints(4)
                                .Build()
                        },
                        {
                            TalonIdEnum.Talon2,
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
            public static IMovableAttributes GetAttributes(TalonIdEnum talonId)
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
            private static readonly Dictionary<TalonIdEnum, IUtilityAttributes> TALON_ID_UTILITY_ATTRIBUTES_DICTIONARY =
                    new Dictionary<TalonIdEnum, IUtilityAttributes>()
                    {
                        {
                            TalonIdEnum.Talon0,
                            AttributesBuilder.Talon.Utility.GetBuilder()
                                .SetUtilityPoints(1)
                                .Build()
                        },
                        {
                            TalonIdEnum.Talon1,
                            AttributesBuilder.Talon.Utility.GetBuilder()
                                .SetUtilityPoints(2)
                                .Build()
                        },
                        {
                            TalonIdEnum.Talon2,
                            AttributesBuilder.Talon.Utility.GetBuilder()
                                .SetUtilityPoints(1)
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
            public static IUtilityAttributes GetAttributes(TalonIdEnum talonId)
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