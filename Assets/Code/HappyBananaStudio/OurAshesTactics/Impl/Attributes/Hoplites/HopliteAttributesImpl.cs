/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Attributes.Bonus;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Attributes.Hoplites;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Attributes.Talons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Attributes.Weapons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Builders;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Constants.Attributes.Hoplites;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Enums;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Utils.Exceptions;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Attributes.Hoplites
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct HopliteAttributesImpl
        : IHopliteAttributes
    {
        // Todo
        private readonly IBonusAttributes bonusAttributes;

        // Todo
        private readonly ControllerIdEnum controllerId;

        // Todo
        private readonly HashSet<HopliteTraitEnum> hopliteTraitSet;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="defaultAttributes">
        /// </param>
        /// <param name="hopliteTraitSet">
        /// </param>
        private HopliteAttributesImpl(HashSet<HopliteTraitEnum> hopliteTraitSet, ControllerIdEnum controllerId)
        {
            this.controllerId = controllerId;
            this.hopliteTraitSet = hopliteTraitSet;
            HashSet<IBonusAttributes> bonusAttributesSet = new HashSet<IBonusAttributes>();
            foreach (HopliteTraitEnum hopliteTrait in this.hopliteTraitSet)
            {
                bonusAttributesSet.Add(HopliteAttributesConstants.GetAttributes(hopliteTrait));
            }
            this.bonusAttributes = AttributesBuilder.Talon.Bonus.GetBuilder()
                .SetBonusAttributesCollection(bonusAttributesSet)
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public ControllerIdEnum GetControllerId()
        {
            return this.controllerId;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public IDestructibleAttributes GetDestructibleAttributes()
        {
            return this.bonusAttributes.GetDestructibleAttributes();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public HashSet<HopliteTraitEnum> GetHopliteTraitSet()
        {
            return new HashSet<HopliteTraitEnum>(this.hopliteTraitSet);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public IMovableAttributes GetMoveableAttributes()
        {
            return this.bonusAttributes.GetMoveableAttributes();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public IWeaponAttributes GetWeaponAttributes()
        {
            return this.bonusAttributes.GetWeaponAttributes();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public override string ToString()
        {
            return this.GetType().Name + ": " + typeof(ControllerIdEnum).Name + ": " + this.GetControllerId() + ", Set: " + typeof(HopliteTraitEnum).Name + ": " + string.Join(", ", this.GetHopliteTraitSet()) +
            "\n\t>" + this.GetDestructibleAttributes() +
            "\n\t>" + this.GetMoveableAttributes() +
            "\n\t>" + this.GetWeaponAttributes();
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private ControllerIdEnum controllerId = ControllerIdEnum.None;

            // Todo
            private HashSet<HopliteTraitEnum> hopliteTraitSet = null;

            /// <summary>
            /// Build the HopliteAttributes with the set parameters
            /// </summary>
            /// <returns>
            /// The IHopliteAttributes
            /// </returns>
            public IHopliteAttributes Build()
            {
                HashSet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new HopliteAttributesImpl(this.hopliteTraitSet, this.controllerId);
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Set the value of the ControllerIdEnum
            /// </summary>
            /// <param name="controllerId">
            /// The ControllerIdEnum to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetControllerId(ControllerIdEnum controllerId)
            {
                this.controllerId = controllerId;
                return this;
            }

            /// <summary>
            /// Set the value of the Set: HopliteTraitEnum
            /// </summary>
            /// <param name="hopliteTraitSet">
            /// The Set: HopliteTraitEnum to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetHopliteTraitSet(HashSet<HopliteTraitEnum> hopliteTraitSet)
            {
                this.hopliteTraitSet = new HashSet<HopliteTraitEnum>(hopliteTraitSet);
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
                // Check if the hopliteTraitSet has been set
                if (this.hopliteTraitSet == null)
                {
                    argumentExceptionSet.Add("Set: " + typeof(HopliteTraitEnum).Name + " has not been set");
                }
                // Check if the hopliteTraitSet has been set
                if (this.controllerId == ControllerIdEnum.None)
                {
                    argumentExceptionSet.Add(typeof(ControllerIdEnum).Name + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}