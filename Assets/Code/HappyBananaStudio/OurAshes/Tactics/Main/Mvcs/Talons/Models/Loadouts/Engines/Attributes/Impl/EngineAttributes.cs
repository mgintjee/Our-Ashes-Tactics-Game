using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Engines.Attributes.Api;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Engines.Attributes.Impl
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct EngineAttributes
        : IEngineAttributes
    {
        // Todo
        private readonly float movementPoints;

        // Todo
        private readonly float actionPoints;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="movementPoints"></param>
        /// <param name="actionPoints"></param>
        private EngineAttributes(float movementPoints, float actionPoints)
        {
            this.movementPoints = movementPoints;
            this.actionPoints = actionPoints;
        }

        /// <inheritdoc/>
        float IEngineAttributes.GetMovementPoints()
        {
            return this.movementPoints;
        }

        /// <inheritdoc/>
        float IEngineAttributes.GetActionPoints()
        {
            return this.actionPoints;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: actionPoints={1}, movementPoints={2}",
                this.GetType().Name, this.actionPoints, this.movementPoints);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private float movementPoints = 0;

            // Todo
            private float actionPoints = 0;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IEngineAttributes Build()
            {
                // Instantiate a new Report
                return new EngineAttributes(this.movementPoints, this.actionPoints);
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IEngineAttributes Build(ISet<IEngineAttributes> engineAttributesSet)
            {
                // Reset the value to 0
                this.actionPoints = 0;
                // Reset the value to 0
                this.movementPoints = 0;
                // Iterate over the other attributes
                foreach (IEngineAttributes engineAttributes in engineAttributesSet)
                {
                    this.actionPoints += engineAttributes.GetActionPoints();
                    this.movementPoints += engineAttributes.GetMovementPoints();
                }
                // Instantiate a new Report
                return new EngineAttributes(this.movementPoints, this.actionPoints);
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="movementPoints"></param>
            public Builder SetMovementPoints(float movementPoints)
            {
                this.movementPoints = movementPoints;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="actionPoints"></param>
            public Builder SetActionPoints(float actionPoints)
            {
                this.actionPoints = actionPoints;
                return this;
            }
        }
    }
}