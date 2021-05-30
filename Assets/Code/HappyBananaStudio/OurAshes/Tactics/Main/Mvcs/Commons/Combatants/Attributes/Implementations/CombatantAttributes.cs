using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Destructibles.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Destructibles.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Fireables.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Fireables.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Loadouts.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Loadouts.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Movables.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Movables.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Implementations
{
    /// <summary>
    /// Combatant Attributes Implementations
    /// </summary>
    public struct CombatantAttributes
        : ICombatantAttributes
    {
        // Todo
        private readonly IDestructibleAttributes _destructibleAttributes;

        // Todo
        private readonly IFireableAttributes _fireableAttributes;

        // Todo
        private readonly ILoadoutAttributes _loadoutAttributes;

        // Todo
        private readonly IMovableAttributes _movableAttributes;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="destructibleAttributes"></param>
        /// <param name="fireableAttributes">    </param>
        /// <param name="loadoutAttributes">     </param>
        /// <param name="movableAttributes">     </param>
        private CombatantAttributes(IDestructibleAttributes destructibleAttributes, IFireableAttributes fireableAttributes,
            ILoadoutAttributes loadoutAttributes, IMovableAttributes movableAttributes)
        {
            this._destructibleAttributes = destructibleAttributes;
            this._fireableAttributes = fireableAttributes;
            this._loadoutAttributes = loadoutAttributes;
            this._movableAttributes = movableAttributes;
        }

        IDestructibleAttributes ICombatantAttributes.GetDestructibleAttributes()
        {
            return this._destructibleAttributes;
        }

        IFireableAttributes ICombatantAttributes.GetFireableAttributes()
        {
            return this._fireableAttributes;
        }

        ILoadoutAttributes ICombatantAttributes.GetLoadoutAttributes()
        {
            return this._loadoutAttributes;
        }

        IMovableAttributes ICombatantAttributes.GetMovableAttributes()
        {
            return this._movableAttributes;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private IDestructibleAttributes _destructibleAttributes = new DestructibleAttributes.Builder().Build();

            // Todo
            private IFireableAttributes _fireableAttributes = new FireableAttributes.Builder().Build();

            // Todo
            private ILoadoutAttributes _loadoutAttributes = new LoadoutAttributes.Builder().Build();

            // Todo
            private IMovableAttributes _movableAttributes = new MovableAttributes.Builder().Build();

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public ICombatantAttributes Build()
            {
                // Instantiate a new Attributes
                return new CombatantAttributes(this._destructibleAttributes,
                    this._fireableAttributes, this._loadoutAttributes, this._movableAttributes);
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public ICombatantAttributes Build(ICollection<ICombatantAttributes> combatantAttributes)
            {
                ISet<IDestructibleAttributes> destructibleAttributes = new HashSet<IDestructibleAttributes>();
                ISet<IFireableAttributes> fireableAttributes = new HashSet<IFireableAttributes>();
                ISet<IMovableAttributes> movableAttributes = new HashSet<IMovableAttributes>();

                foreach (ICombatantAttributes attributes in combatantAttributes)
                {
                    destructibleAttributes.Add(attributes.GetDestructibleAttributes());
                    fireableAttributes.Add(attributes.GetFireableAttributes());
                    movableAttributes.Add(attributes.GetMovableAttributes());
                }

                // Instantiate a new Attributes
                return new CombatantAttributes(
                    new DestructibleAttributes.Builder().Build(destructibleAttributes),
                    new FireableAttributes.Builder().Build(fireableAttributes),
                    this._loadoutAttributes,
                    new MovableAttributes.Builder().Build(movableAttributes));
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="destructibleAttributes"></param>
            public Builder SetDestructibleAttributes(IDestructibleAttributes destructibleAttributes)
            {
                this._destructibleAttributes = destructibleAttributes;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="fireableAttributes"></param>
            public Builder SetFireableAttributes(IFireableAttributes fireableAttributes)
            {
                this._fireableAttributes = fireableAttributes;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="loadoutAttributes"></param>
            public Builder SetLoadoutAttributes(ILoadoutAttributes loadoutAttributes)
            {
                this._loadoutAttributes = loadoutAttributes;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="movableAttributes"></param>
            public Builder SetMovableAttributes(IMovableAttributes movableAttributes)
            {
                this._movableAttributes = movableAttributes;
                return this;
            }
        }
    }
}