using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Implementations.Abstracts;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Destructibles.Implementations;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Destructibles.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Fireables.Implementations;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Fireables.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Loadouts.Implementations;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Loadouts.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Movables.Implementations;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Movables.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Implementations
{
    /// <summary>
    /// Combatant Attributes Implementations
    /// </summary>
    public struct CombatantAttributes : ICombatantAttributes
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
            _destructibleAttributes = destructibleAttributes;
            _fireableAttributes = fireableAttributes;
            _loadoutAttributes = loadoutAttributes;
            _movableAttributes = movableAttributes;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: {1}, {2}, {3}, {4}",
                this.GetType().Name,
                _destructibleAttributes, _movableAttributes, _fireableAttributes, _loadoutAttributes);
        }

        /// <inheritdoc/>
        IDestructibleAttributes ICombatantAttributes.GetDestructibleAttributes()
        {
            return _destructibleAttributes;
        }

        /// <inheritdoc/>
        IFireableAttributes ICombatantAttributes.GetFireableAttributes()
        {
            return _fireableAttributes;
        }

        /// <inheritdoc/>
        ILoadoutAttributes ICombatantAttributes.GetLoadoutAttributes()
        {
            return _loadoutAttributes;
        }

        /// <inheritdoc/>
        IMovableAttributes ICombatantAttributes.GetMovableAttributes()
        {
            return _movableAttributes;
        }

        /// <summary>
        /// Builder class for this object
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Builder Interface for this object
            /// </summary>
            public interface IBuilder : IBuilder<ICombatantAttributes>
            {
                IBuilder SetDestructibleAttributes(IDestructibleAttributes destructibleAttributes);

                IBuilder SetFireableAttributes(IFireableAttributes fireableAttributes);

                IBuilder SetLoadoutAttributes(ILoadoutAttributes loadoutAttributes);

                IBuilder SetMovableAttributes(IMovableAttributes movableAttributes);
            }

            /// <summary>
            /// Get the Builder for this object
            /// </summary>
            /// <returns></returns>
            public static IBuilder Get()
            {
                return new InternalBuilder();
            }

            /// <summary>
            /// Builder Implementation for this object
            /// </summary>
            private class InternalBuilder : AbstractBuilder<ICombatantAttributes>, IBuilder
            {
                // Todo
                private IDestructibleAttributes _destructibleAttributes = DestructibleAttributes.Builder.Get().Build();

                // Todo
                private IFireableAttributes _fireableAttributes = FireableAttributes.Builder.Get().Build();

                // Todo
                private ILoadoutAttributes _loadoutAttributes = LoadoutAttributes.Builder.Get().Build();

                // Todo
                private IMovableAttributes _movableAttributes = MovableAttributes.Builder.Get().Build();

                /// <inheritdoc/>
                IBuilder IBuilder.SetDestructibleAttributes(IDestructibleAttributes destructibleAttributes)
                {
                    _destructibleAttributes = destructibleAttributes;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetFireableAttributes(IFireableAttributes fireableAttributes)
                {
                    _fireableAttributes = fireableAttributes;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetLoadoutAttributes(ILoadoutAttributes loadoutAttributes)
                {
                    _loadoutAttributes = loadoutAttributes;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetMovableAttributes(IMovableAttributes movableAttributes)
                {
                    _movableAttributes = movableAttributes;
                    return this;
                }

                /// <inheritdoc/>
                protected override ICombatantAttributes BuildObj()
                {
                    return new CombatantAttributes(_destructibleAttributes, _fireableAttributes, _loadoutAttributes, _movableAttributes);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, _destructibleAttributes);
                    this.Validate(invalidReasons, _fireableAttributes);
                    this.Validate(invalidReasons, _loadoutAttributes);
                    this.Validate(invalidReasons, _movableAttributes);
                }
            }
        }
    }
}