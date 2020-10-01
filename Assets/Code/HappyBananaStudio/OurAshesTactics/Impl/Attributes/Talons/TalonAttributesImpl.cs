/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Attributes.Talons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Exceptions;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Attributes.Talons
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct TalonAttributesImpl
        : ITalonAttributes
    {
        // Todo
        private readonly IDestructibleAttributes destructableAttributes;

        // Todo
        private readonly IFireableAttributes fireableAttributes;

        // Todo
        private readonly IMovableAttributes moveableAttributes;

        // Todo
        private readonly IUtilityAttributes utilityAttributes;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="destructableAttributes">
        /// </param>
        /// <param name="fireableAttributes">
        /// </param>
        /// <param name="moveableAttributes">
        /// </param>
        /// <param name="utilityAttributes">
        /// </param>
        private TalonAttributesImpl(IDestructibleAttributes destructableAttributes,
            IFireableAttributes fireableAttributes, IMovableAttributes moveableAttributes,
            IUtilityAttributes utilityAttributes)
        {
            this.destructableAttributes = destructableAttributes;
            this.fireableAttributes = fireableAttributes;
            this.moveableAttributes = moveableAttributes;
            this.utilityAttributes = utilityAttributes;
        }

        public IDestructibleAttributes DestructableAttributes => destructableAttributes;

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public IDestructibleAttributes GetDestructibleAttributes()
        {
            return this.DestructableAttributes;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public IFireableAttributes GetFireableAttributes()
        {
            return this.fireableAttributes;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public IMovableAttributes GetMovableAttributes()
        {
            return this.moveableAttributes;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public IUtilityAttributes GetUtilityAttributes()
        {
            return this.utilityAttributes;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private IDestructibleAttributes destructibleAttributes;

            // Todo
            private IFireableAttributes fireableAttributes;

            // Todo
            private IMovableAttributes movableAttributes;

            // Todo
            private IUtilityAttributes utilityAttributes;

            /// <summary>
            /// Build the FireableAttributes with the set parameters
            /// </summary>
            /// <returns>
            /// The IMovableAttributes
            /// </returns>
            public ITalonAttributes Build()
            {
                HashSet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new TalonAttributesImpl(this.destructibleAttributes, this.fireableAttributes,
                        this.movableAttributes, this.utilityAttributes);
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
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
            /// Set the value of the IFireableAttributes
            /// </summary>
            /// <param name="fireableAttributes">
            /// The IFireableAttributes to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetFireableAttributes(IFireableAttributes fireableAttributes)
            {
                this.fireableAttributes = fireableAttributes;
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
            /// Set the value of the IUtilityAttributes
            /// </summary>
            /// <param name="utilityAttributes">
            /// The IUtilityAttributes to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetUtilityAttributes(IUtilityAttributes utilityAttributes)
            {
                this.utilityAttributes = utilityAttributes;
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
                // Check that destructibleAttributes has been set
                if (this.destructibleAttributes == null)
                {
                    argumentExceptionSet.Add(typeof(IDestructibleAttributes) + " has not been set");
                }
                // Check that fireableAttributes has been set
                if (this.fireableAttributes == null)
                {
                    argumentExceptionSet.Add(typeof(IFireableAttributes) + " has not been set");
                }
                // Check that movableAttributes has been set
                if (this.movableAttributes == null)
                {
                    argumentExceptionSet.Add(typeof(IMovableAttributes) + " has not been set");
                }
                // Check that utilityAttributes has been set
                if (this.utilityAttributes == null)
                {
                    argumentExceptionSet.Add(typeof(IUtilityAttributes) + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}