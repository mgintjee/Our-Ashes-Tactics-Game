using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Implementations.Abstracts;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Fireables.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Fireables.Implementations
{
    /// <summary>
    /// Fireable Attributes Implementation
    /// </summary>
    public struct FireableAttributes
        : IFireableAttributes
    {
        // Accuracy Points
        private readonly float _accuracy;

        // Range Points
        private readonly float _range;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="accuracy"></param>
        /// <param name="range">   </param>
        private FireableAttributes(float accuracy, float range)
        {
            _accuracy = accuracy;
            _range = range;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: _accuracy={1}, _range={2}",
                this.GetType().Name, _accuracy, _range);
        }

        /// <inheritdoc/>
        float IFireableAttributes.GetAccuracy()
        {
            return _accuracy;
        }

        /// <inheritdoc/>
        float IFireableAttributes.GetRange()
        {
            return _range;
        }

        /// <summary>
        /// Builder class for this object
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Builder Interface for this object
            /// </summary>
            public interface IBuilder : IBuilder<IFireableAttributes>
            {
                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="accuracy"></param>
                /// <returns></returns>
                IBuilder SetAccuracy(float accuracy);

                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="range"></param>
                /// <returns></returns>
                IBuilder SetRange(float range);
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
            private class InternalBuilder : AbstractBuilder<IFireableAttributes>, IBuilder
            {
                // Todo
                private float _accuracy = 0.0f;

                // Todo
                private float _range = 0.0f;

                /// <inheritdoc/>
                IBuilder IBuilder.SetAccuracy(float accuracy)
                {
                    _accuracy = accuracy;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetRange(float range)
                {
                    _range = range;
                    return this;
                }

                /// <inheritdoc/>
                protected override IFireableAttributes BuildObj()
                {
                    // Instantiate a new attributes
                    return new FireableAttributes(_accuracy, _range);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, _accuracy);
                    this.Validate(invalidReasons, _range);
                }
            }
        }
    }
}