namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Objects.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Effects.Objects.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Armors.Attributes.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Objects.Api;
    using System.Collections.Generic;

    /// <summary>
    /// Destructible Object Impl
    /// </summary>
    public class DestructibleObject
        : IDestructibleObject
    {
        // Todo
        private readonly IArmorAttributes armorAttributes;

        // Todo
        private float currentHealthPoints;

        // Todo
        private float currentArmorPoints;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="armorAttributes"></param>
        private DestructibleObject(IArmorAttributes armorAttributes)
        {
            this.armorAttributes = armorAttributes;
            this.currentHealthPoints = this.armorAttributes.GetHealthPoints();
            this.currentArmorPoints = this.armorAttributes.GetArmorPoints();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="destructibleObject"></param>
        public DestructibleObject(IDestructibleObject destructibleObject)
        {
            this.armorAttributes = destructibleObject.GetArmorAttributes();
            this.currentArmorPoints = destructibleObject.GetCurrentArmorPoints();
            this.currentHealthPoints = destructibleObject.GetCurrentHealthPoints();
        }

        /// <inheritdoc/>
        IArmorAttributes IDestructibleObject.GetArmorAttributes()
        {
            return this.armorAttributes;
        }

        /// <inheritdoc/>
        float IDestructibleObject.GetCurrentArmorPoints()
        {
            return this.currentArmorPoints;
        }

        /// <inheritdoc/>
        float IDestructibleObject.GetCurrentHealthPoints()
        {
            return this.currentHealthPoints;
        }

        /// <inheritdoc/>
        void IDestructibleObject.InputTalonEffect(ITalonEffectObject talonEffectObject)
        {
            this.currentArmorPoints += talonEffectObject.GetArmorEffect();
            this.currentHealthPoints += talonEffectObject.GetHealthEffect();
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private IArmorAttributes armorAttributes = null;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IDestructibleObject Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Object
                    return new DestructibleObject(this.armorAttributes);
                }
                else
                {
                    throw ExceptionUtil.Arguments.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="destructibleObject"></param>
            /// <returns></returns>
            public IDestructibleObject Build(IDestructibleObject destructibleObject)
            {
                return new DestructibleObject(destructibleObject);
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="armorAttributes"></param>
            /// <returns></returns>
            public Builder SetArmorAttributes(IArmorAttributes armorAttributes)
            {
                this.armorAttributes = armorAttributes;
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
                // Check that armorAttributes has been set
                if (this.armorAttributes == null)
                {
                    argumentExceptionSet.Add(typeof(IArmorAttributes) + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}