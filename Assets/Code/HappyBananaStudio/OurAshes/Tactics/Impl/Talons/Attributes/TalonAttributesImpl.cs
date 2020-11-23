namespace HappyBananaStudio.OurAshes.Tactics.Impl.Talons.Attributes
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Attributes;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Exceptions;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public struct TalonAttributesImpl
        : ITalonAttributes
    {
        // Todo
        private readonly IDestructibleAttributes destructableAttributes;

        // Todo
        private readonly IMountableAttributes mountableAttributes;

        // Todo
        private readonly IMovableAttributes movableAttributes;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="destructableAttributes">
        /// </param>
        /// <param name="mountableAttributes">
        /// </param>
        /// <param name="moveableAttributes">
        /// </param>
        private TalonAttributesImpl(IDestructibleAttributes destructableAttributes,
            IMountableAttributes mountableAttributes, IMovableAttributes moveableAttributes)
        {
            this.destructableAttributes = destructableAttributes;
            this.movableAttributes = moveableAttributes;
            this.mountableAttributes = mountableAttributes;
        }

        public override string ToString()
        {
            return this.GetType().Name + ":" +
                "\n\t>" + this.destructableAttributes +
                "\n\t>" + this.mountableAttributes +
                "\n\t>" + this.movableAttributes;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IDestructibleAttributes ITalonAttributes.GetDestructibleAttributes()
        {
            return this.destructableAttributes;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IMountableAttributes ITalonAttributes.GetMountableAttributes()
        {
            return this.mountableAttributes;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IMovableAttributes ITalonAttributes.GetMovableAttributes()
        {
            return this.movableAttributes;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private IDestructibleAttributes destructibleAttributes;

            // Todo
            private IMountableAttributes mountableAttributes;

            // Todo
            private IMovableAttributes movableAttributes;

            /// <summary>
            /// Build the FireableAttributes with the set parameters
            /// </summary>
            /// <returns>
            /// The IMovableAttributes
            /// </returns>
            public ITalonAttributes Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new TalonAttributesImpl(this.destructibleAttributes,
                        this.mountableAttributes, this.movableAttributes);
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
            /// Set the value of the IMountableAttributes
            /// </summary>
            /// <param name="mountableAttributes">
            /// The IMountableAttributes to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetMountableAttributes(IMountableAttributes mountableAttributes)
            {
                this.mountableAttributes = mountableAttributes;
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
            /// Todo
            /// </summary>
            /// <returns>
            /// </returns>
            private ISet<string> IsInvalid()
            {
                // Default an empty Set: String
                ISet<string> argumentExceptionSet = new HashSet<string>();
                // Check that destructibleAttributes has been set
                if (this.destructibleAttributes == null)
                {
                    argumentExceptionSet.Add(typeof(IDestructibleAttributes) + " has not been set");
                }
                // Check that mountableAttributes has been set
                if (this.mountableAttributes == null)
                {
                    argumentExceptionSet.Add(typeof(IMountableAttributes) + " has not been set");
                }
                // Check that movableAttributes has been set
                if (this.movableAttributes == null)
                {
                    argumentExceptionSet.Add(typeof(IMovableAttributes) + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}