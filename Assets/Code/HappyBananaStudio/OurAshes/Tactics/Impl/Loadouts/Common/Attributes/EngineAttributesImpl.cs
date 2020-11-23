namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Impl.Loadouts.Common.Attributes
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Api.Loadouts.Common.Attributes;

    /// <summary>
    /// Todo
    /// </summary>
    public struct EngineAttributesImpl
        : IEngineAttributes
    {
        // Todo
        private readonly int movementPoints;

        // Todo
        private readonly int actionPoints;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="movementPoints"></param>
        /// <param name="actionPoints"></param>
        private EngineAttributesImpl(int movementPoints, int actionPoints)
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

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private int movementPoints = 0;

            // Todo
            private int actionPoints = 0;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IEngineAttributes Build()
            {
                // Instantiate a new Report
                return new EngineAttributesImpl(this.movementPoints, this.actionPoints);
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="movementPoints"></param>
            public Builder SetMovementPoints(int movementPoints)
            {
                this.movementPoints = movementPoints;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="actionPoints"></param>
            public Builder SetActionPoints(int actionPoints)
            {
                this.actionPoints = actionPoints;
                return this;
            }
        }
    }
}