namespace HappyBananaStudio.OurAshes.Tactics.Impl.Talons.Attributes
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Attributes;
    using HappyBananaStudio.OurAshes.Tactics.Api.Weapons.Attributes;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Exceptions;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Weapons.Attributes;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public struct BonusAttributesImpl
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
        private BonusAttributesImpl(IDestructibleAttributes destructableAttributes,
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
        private BonusAttributesImpl(ICollection<IBonusAttributes> bonusAttributesCollection)
        {
            ICollection<IDestructibleAttributes> destructibleAttributesCollection = new HashSet<IDestructibleAttributes>();
            ICollection<IMovableAttributes> movableAttributesCollection = new HashSet<IMovableAttributes>();
            ICollection<IWeaponAttributes> weaponAttributesCollection = new HashSet<IWeaponAttributes>();

            foreach (IBonusAttributes bonusAttributes in bonusAttributesCollection)
            {
                if (bonusAttributes != null)
                {
                    destructibleAttributesCollection.Add(bonusAttributes.GetDestructibleAttributes());
                    movableAttributesCollection.Add(bonusAttributes.GetMovableAttributes());
                    weaponAttributesCollection.Add(bonusAttributes.GetWeaponAttributes());
                }
            }

            this.destructableAttributes = new DestructibleAttributesImpl.Builder()
                .SetDestrucibleAttributesCollection(destructibleAttributesCollection)
                .Build();
            this.weaponAttributes = new WeaponAttributesImpl.Builder()
                .SetWeaponAttributesCollection(weaponAttributesCollection)
                .Build();
            this.moveableAttributes = new MovableAttributesImpl.Builder()
                .SetMovableAttributesCollection(movableAttributesCollection)
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public override string ToString()
        {
            return this.GetType().Name + ":" +
                "\n\t>" + this.destructableAttributes +
                "\n\t>" + this.moveableAttributes +
                "\n\t>" + this.weaponAttributes;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IDestructibleAttributes IBonusAttributes.GetDestructibleAttributes()
        {
            return this.destructableAttributes;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IMovableAttributes IBonusAttributes.GetMovableAttributes()
        {
            return this.moveableAttributes;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IWeaponAttributes IBonusAttributes.GetWeaponAttributes()
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
            /// Build the attributes with the set parameters
            /// </summary>
            /// <returns>
            /// The attributes interface
            /// </returns>
            public IBonusAttributes Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    if (this.bonusAttributesCollection != null)
                    {
                        // Instantiate a new Report
                        return new BonusAttributesImpl(this.bonusAttributesCollection);
                    }
                    else
                    {
                        // Instantiate a new Report
                        return new BonusAttributesImpl(this.destructibleAttributes,
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
            private ISet<string> IsInvalid()
            {
                // Default an empty Set: String
                ISet<string> argumentExceptionSet = new HashSet<string>();
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
