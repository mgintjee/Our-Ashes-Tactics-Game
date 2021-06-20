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
        private readonly float _actions;

        // Todo
        private readonly float _movements;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="movements"></param>
        /// <param name="actions"></param>
        private MovableAttributes(float movements, float actions)
        {
            this._movements = movements;
            this._actions = actions;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: _actions={1}, _movements={2}",
                this.GetType().Name, this._actions, this._movements);
        }

        /// <inheritdoc/>
        float IMovableAttributes.GetActions()
        {
            return this._actions;
        }

        /// <inheritdoc/>
        float IMovableAttributes.GetMovement()
        {
            return this._movements;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private float _actions = 0;

            // Todo
            private float _movements = 0;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IMovableAttributes Build()
            {
                // Instantiate a new attributes
                return new MovableAttributes(this._movements, this._actions);
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IMovableAttributes Build(ICollection<IMovableAttributes> movableAttributes)
            {
                this._actions = 0;
                this._movements = 0;

                foreach (IMovableAttributes attributes in movableAttributes)
                {
                    this._actions += attributes.GetActions();
                    this._movements += attributes.GetMovement();
                }

                // Instantiate a new Attributes
                return new MovableAttributes(this._movements, this._actions);
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="actions"></param>
            public Builder SetActions(float actions)
            {
                this._actions = actions;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="movements"></param>
            public Builder SetMovements(float movements)
            {
                this._movements = movements;
                return this;
            }
        }
    }
}