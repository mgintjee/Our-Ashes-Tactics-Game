/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Attributes.Bonus;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Attributes.Talons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Attributes.Weapons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Builders;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Utils.Exceptions;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Attributes.Bonus
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct BonusAttributes
        : IBonusAttributes
    {
        // Todo
        private readonly IDestructibleAttributes destructableAttributes;

        // Todo
        private readonly IMovableAttributes moveableAttributes;

        // Todo
        private readonly IWeaponAttributes weaponAttributes;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="destructableAttributes">
        /// </param>
        /// <param name="weaponAttributes">
        /// </param>
        /// <param name="moveableAttributes">
        /// </param>
        private BonusAttributes(IDestructibleAttributes destructableAttributes,
            IMovableAttributes moveableAttributes,
            IWeaponAttributes weaponAttributes)
        {
            this.destructableAttributes = destructableAttributes;
            this.moveableAttributes = moveableAttributes;
            this.weaponAttributes = weaponAttributes;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="bonusAttributesCollection">
        /// </param>
        private BonusAttributes(ICollection<IBonusAttributes> bonusAttributesCollection)
        {
            ICollection<IDestructibleAttributes> destructibleAttributesCollection = new HashSet<IDestructibleAttributes>();
            ICollection<IMovableAttributes> movableAttributesCollection = new HashSet<IMovableAttributes>();
            ICollection<IWeaponAttributes> weaponAttributesCollection = new HashSet<IWeaponAttributes>();

            foreach (IBonusAttributes bonusAttributes in bonusAttributesCollection)
            {
                if (bonusAttributes != null)
                {
                    destructibleAttributesCollection.Add(bonusAttributes.GetDestructibleAttributes());
                    movableAttributesCollection.Add(bonusAttributes.GetMoveableAttributes());
                    weaponAttributesCollection.Add(bonusAttributes.GetWeaponAttributes());
                }
            }

            this.destructableAttributes = AttributesBuilder.Talon.Destructible.GetBuilder()
                .SetDestrucibleAttributesCollection(destructibleAttributesCollection)
                .Build();
            this.weaponAttributes = AttributesBuilder.Weapon.GetBuilder()
                .SetWeaponAttributesCollection(weaponAttributesCollection)
                .Build();
            this.moveableAttributes = AttributesBuilder.Talon.Movable.GetBuilder()
                .SetMovableAttributesCollection(movableAttributesCollection)
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public IDestructibleAttributes GetDestructibleAttributes()
        {
            return this.destructableAttributes;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public IMovableAttributes GetMoveableAttributes()
        {
            return this.moveableAttributes;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public IWeaponAttributes GetWeaponAttributes()
        {
            return this.weaponAttributes;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private ICollection<IBonusAttributes> bonusAttributesCollection;

            // Todo
            private IDestructibleAttributes destructibleAttributes;

            // Todo
            private IMovableAttributes movableAttributes;

            // Todo
            private IWeaponAttributes weaponAttributes;

            /// <summary>
            /// Build the UtilityAttributes with the set parameters
            /// </summary>
            /// <returns>
            /// The IUtilityAttributes
            /// </returns>
            public IBonusAttributes Build()
            {
                HashSet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    if (this.bonusAttributesCollection != null)
                    {
                        // Instantiate a new Report
                        return new BonusAttributes(this.bonusAttributesCollection);
                    }
                    else
                    {
                        // Instantiate a new Report
                        return new BonusAttributes(this.destructibleAttributes,
                            this.movableAttributes, this.weaponAttributes);
                    }
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Set the value of the Collection: DestructibleAttributes
            /// </summary>
            /// <param name="bonusAttributesCollection">
            /// The Collection: DestructibleAttributes to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetBonusAttributesCollection(ICollection<IBonusAttributes> bonusAttributesCollection)
            {
                this.bonusAttributesCollection = bonusAttributesCollection;
                return this;
            }

            /// <summary>
            /// Set the value of the IDestructibleAttributes
            /// </summary>
            /// <param name="destructibleAttributes">
            /// The IDestructibleAttributes to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetDestructibleAttributes(IDestructibleAttributes destructibleAttributes)
            {
                this.destructibleAttributes = destructibleAttributes;
                return this;
            }

            /// <summary>
            /// Set the value of the IMovableAttributes
            /// </summary>
            /// <param name="movableAttributes">
            /// The IMovableAttributes to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetMovableAttributes(IMovableAttributes movableAttributes)
            {
                this.movableAttributes = movableAttributes;
                return this;
            }

            /// <summary>
            /// Set the value of the IWeaponAttributes
            /// </summary>
            /// <param name="weaponAttributes">
            /// The IWeaponAttributes to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetWeaponAttributes(IWeaponAttributes weaponAttributes)
            {
                this.weaponAttributes = weaponAttributes;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns>
            /// </returns>
            private HashSet<string> IsInvalid()
            {
                // Default an empty Set: String
                HashSet<string> argumentExceptionSet = new HashSet<string>();
                // Check if the bonusAttributesCollection has been set
                if (this.bonusAttributesCollection == null)
                {
                    // Check that destructibleAttributes has been set
                    if (this.destructibleAttributes == null)
                    {
                        argumentExceptionSet.Add(typeof(IDestructibleAttributes) + " has not been set");
                    }
                    // Check that movableAttributes has been set
                    if (this.movableAttributes == null)
                    {
                        argumentExceptionSet.Add(typeof(IMovableAttributes) + " has not been set");
                    }
                    // Check that weaponAttributes has been set
                    if (this.weaponAttributes == null)
                    {
                        argumentExceptionSet.Add(typeof(IWeaponAttributes) + " has not been set");
                    }
                }
                else
                {
                    // Check if the bonusAttributesCollection is valid
                    if (this.bonusAttributesCollection.Count == 0)
                    {
                        argumentExceptionSet.Add("Collection: " + typeof(IBonusAttributes) + " is empty.");
                    }
                }
                return argumentExceptionSet;
            }
        }
    }
}