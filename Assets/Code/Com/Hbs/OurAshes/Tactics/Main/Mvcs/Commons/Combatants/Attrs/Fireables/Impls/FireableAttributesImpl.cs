using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attrs.Fireables.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attrs.Fireables.Impls
{
    /// <summary>
    /// Fireable Attributes Impl
    /// </summary>
    public struct FireableAttributesImpl
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
        private FireableAttributesImpl(float accuracy, float range)
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
            public interface IInternalBuilder
                : IBuilder<IFireableAttributes>
            {
                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="accuracy"></param>
                /// <returns></returns>
                IInternalBuilder SetAccuracy(float accuracy);

                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="range"></param>
                /// <returns></returns>
                IInternalBuilder SetRange(float range);

                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="attributes"></param>
                /// <returns></returns>
                IFireableAttributes Build(ISet<IFireableAttributes> attributes);
            }

            /// <summary>
            /// Get the Builder for this object
            /// </summary>
            /// <returns></returns>
            public static IInternalBuilder Get()
            {
                return new InternalBuilder();
            }

            /// <summary>
            /// Builder Impl for this object
            /// </summary>
            private class InternalBuilder
                : AbstractBuilder<IFireableAttributes>, IInternalBuilder
            {
                // Todo
                private float _accuracy = 0.0f;

                // Todo
                private float _range = 0.0f;

                /// <inheritdoc/>
                IInternalBuilder IInternalBuilder.SetAccuracy(float accuracy)
                {
                    _accuracy = accuracy;
                    return this;
                }

                /// <inheritdoc/>
                IInternalBuilder IInternalBuilder.SetRange(float range)
                {
                    _range = range;
                    return this;
                }

                /// <inheritdoc/>
                IFireableAttributes IInternalBuilder.Build(ISet<IFireableAttributes> attributes)
                {
                    _accuracy = 0.0f;
                    _range = 0.0f;

                    foreach (IFireableAttributes attrs in attributes)
                    {
                        _accuracy += attrs.GetAccuracy();
                        _range += attrs.GetRange();
                    }

                    return this.BuildObj();
                }

                /// <inheritdoc/>
                protected override IFireableAttributes BuildObj()
                {
                    // Instantiate a new attributes
                    return new FireableAttributesImpl(_accuracy, _range);
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