using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Destructibles.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Destructibles.Implementations
{
    /// <summary>
    /// Destructible Attributes Implementation
    /// </summary>
    public struct DestructibleAttributes
        : IDestructibleAttributes
    {
        // Todo
        private readonly float APs;

        // Todo
        private readonly float HPs;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="APs"></param>
        /// <param name="HPs"></param>
        private DestructibleAttributes(float APs, float HPs)
        {
            this.APs = APs;
            this.HPs = HPs;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: APs={1}, HPs={2}",
                this.GetType().Name, APs, HPs);
        }

        /// <inheritdoc/>
        float IDestructibleAttributes.GetArmor()
        {
            return APs;
        }

        /// <inheritdoc/>
        float IDestructibleAttributes.GetHealth()
        {
            return HPs;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private float APs = 0.0f;

            // Todo
            private float HPs = 0.0f;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IDestructibleAttributes Build()
            {
                // Instantiate a new Attributes
                return new DestructibleAttributes(APs, HPs);
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IDestructibleAttributes Build(ICollection<IDestructibleAttributes> destructibleAttributes)
            {
                this.APs = 0;
                this.HPs = 0;

                foreach (IDestructibleAttributes attributes in destructibleAttributes)
                {
                    this.APs += attributes.GetArmor();
                    this.HPs += attributes.GetHealth();
                }

                // Instantiate a new Attributes
                return new DestructibleAttributes(this.APs, this.HPs);
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="APs"></param>
            public Builder SetAPs(float APs)
            {
                this.APs = APs;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="HPs"></param>
            public Builder SetHPs(float HPs)
            {
                this.HPs = HPs;
                return this;
            }
        }
    }
}