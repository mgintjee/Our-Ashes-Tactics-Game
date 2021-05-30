using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Movables.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Movables.Implementations
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct MovableAttributes
        : IMovableAttributes
    {
        // Todo
        private readonly float APs;

        // Todo
        private readonly float MPs;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="MPs"></param>
        /// <param name="APs"></param>
        private MovableAttributes(float MPs, float APs)
        {
            this.MPs = MPs;
            this.APs = APs;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: APs={1}, MPs={2}",
                this.GetType().Name, this.APs, this.MPs);
        }

        /// <inheritdoc/>
        float IMovableAttributes.GetActions()
        {
            return this.APs;
        }

        /// <inheritdoc/>
        float IMovableAttributes.GetMovement()
        {
            return this.MPs;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private float APs = 0;

            // Todo
            private float MPs = 0;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IMovableAttributes Build()
            {
                // Instantiate a new attributes
                return new MovableAttributes(this.MPs, this.APs);
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IMovableAttributes Build(ICollection<IMovableAttributes> movableAttributes)
            {
                this.APs = 0;
                this.MPs = 0;

                foreach (IMovableAttributes attributes in movableAttributes)
                {
                    this.APs += attributes.GetActions();
                    this.MPs += attributes.GetMovement();
                }

                // Instantiate a new Attributes
                return new MovableAttributes(this.APs, this.MPs);
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
            /// <param name="MPs"></param>
            public Builder SetMPs(float MPs)
            {
                this.MPs = MPs;
                return this;
            }
        }
    }
}