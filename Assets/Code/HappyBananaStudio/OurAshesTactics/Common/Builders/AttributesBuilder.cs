/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Attributes.Bonus;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Attributes.HexTiles;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Attributes.Hoplites;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Attributes.Talons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Attributes.Weapons;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Builders
{
    /// <summary>
    /// Todo
    /// </summary>
    public static class AttributesBuilder
    {
        /// <summary>
        /// Todo
        /// </summary>
        public static class HexTile
        {
            /// <summary>
            /// Todo
            /// </summary>
            /// <returns>
            /// </returns>
            public static HexTileAttributesImpl.Builder GetBuilder()
            {
                return new HexTileAttributesImpl.Builder();
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        public static class Hoplite
        {
            /// <summary>
            /// Todo
            /// </summary>
            /// <returns>
            /// </returns>
            public static HopliteAttributesImpl.Builder GetBuilder()
            {
                return new HopliteAttributesImpl.Builder();
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        public static class Talon
        {
            /// <summary>
            /// Todo
            /// </summary>
            /// <returns>
            /// </returns>
            public static TalonAttributesImpl.Builder GetBuilder()
            {
                return new TalonAttributesImpl.Builder();
            }

            /// <summary>
            /// Todo
            /// </summary>
            public static class Bonus
            {
                /// <summary>
                /// Todo
                /// </summary>
                /// <returns>
                /// </returns>
                public static BonusAttributes.Builder GetBuilder()
                {
                    return new BonusAttributes.Builder();
                }
            }

            /// <summary>
            /// Todo
            /// </summary>
            public static class Destructible
            {
                /// <summary>
                /// Todo
                /// </summary>
                /// <returns>
                /// </returns>
                public static DestructibleAttributesImpl.Builder GetBuilder()
                {
                    return new DestructibleAttributesImpl.Builder();
                }
            }

            /// <summary>
            /// Todo
            /// </summary>
            public static class Fireable
            {
                /// <summary>
                /// Todo
                /// </summary>
                /// <returns>
                /// </returns>
                public static FireableAttributesImpl.Builder GetBuilder()
                {
                    return new FireableAttributesImpl.Builder();
                }
            }

            /// <summary>
            /// Todo
            /// </summary>
            public static class Movable
            {
                /// <summary>
                /// Todo
                /// </summary>
                /// <returns>
                /// </returns>
                public static MovableAttributesImpl.Builder GetBuilder()
                {
                    return new MovableAttributesImpl.Builder();
                }
            }

            /// <summary>
            /// Todo
            /// </summary>
            public static class Utility
            {
                /// <summary>
                /// Todo
                /// </summary>
                /// <returns>
                /// </returns>
                public static UtilityAttributesImpl.Builder GetBuilder()
                {
                    return new UtilityAttributesImpl.Builder();
                }
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        public static class Weapon
        {
            /// <summary>
            /// Todo
            /// </summary>
            /// <returns>
            /// </returns>
            public static WeaponAttributes.Builder GetBuilder()
            {
                return new WeaponAttributes.Builder();
            }
        }
    }
}