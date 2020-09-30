/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Attributes.Impl;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Attributes.Impl.HexTiles;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Attributes.Impl.Hoplites;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Attributes.Impl.Talons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Attributes.Impl.Weapons;

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
            public static HexTileAttributes.Builder GetBuilder()
            {
                return new HexTileAttributes.Builder();
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
            public static HopliteAttributes.Builder GetBuilder()
            {
                return new HopliteAttributes.Builder();
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
            public static TalonAttributes.Builder GetBuilder()
            {
                return new TalonAttributes.Builder();
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
                public static DestructibleAttributes.Builder GetBuilder()
                {
                    return new DestructibleAttributes.Builder();
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
                public static FireableAttributes.Builder GetBuilder()
                {
                    return new FireableAttributes.Builder();
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
                public static MovableAttributes.Builder GetBuilder()
                {
                    return new MovableAttributes.Builder();
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
                public static UtilityAttributes.Builder GetBuilder()
                {
                    return new UtilityAttributes.Builder();
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