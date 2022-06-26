using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Units.Attrs.Destructibles.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Units.Attrs.Destructibles.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Units.Attrs.Fireables.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Units.Attrs.Fireables.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Units.Attrs.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Units.Attrs.Mountables.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Units.Attrs.Mountables.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Units.Attrs.Movables.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Units.Attrs.Movables.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Units.Attrs.Impls
{
    /// <summary>
    /// Unit Attributes Implementation
    /// </summary>
    public class UnitAttributesImpl
        : IUnitAttributes
    {
        // Todo
        protected IDestructibleAttributes destructibleAttributes;

        // Todo
        protected IFireableAttributes fireableAttributes;

        // Todo
        protected IMountableAttributes mountableAttributes;

        // Todo
        protected IMovableAttributes movableAttributes;

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: {1}, {2}, {3}, {4}",
                this.GetType().Name,
                this.destructibleAttributes, this.movableAttributes,
                this.fireableAttributes, this.mountableAttributes);
        }

        /// <inheritdoc/>
        IDestructibleAttributes IUnitAttributes.GetDestructibleAttributes()
        {
            return this.destructibleAttributes;
        }

        /// <inheritdoc/>
        IFireableAttributes IUnitAttributes.GetFireableAttributes()
        {
            return this.fireableAttributes;
        }

        /// <inheritdoc/>
        IMountableAttributes IUnitAttributes.GetMountableAttributes()
        {
            return this.mountableAttributes;
        }

        /// <inheritdoc/>
        IMovableAttributes IUnitAttributes.GetMovableAttributes()
        {
            return this.movableAttributes;
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
                : IBuilder<IUnitAttributes>
            {
                IInternalBuilder SetDestructibleAttributes(IDestructibleAttributes destructibleAttributes);

                IInternalBuilder SetFireableAttributes(IFireableAttributes fireableAttributes);

                IInternalBuilder SetMountableAttributes(IMountableAttributes loadoutAttributes);

                IInternalBuilder SetMovableAttributes(IMovableAttributes movableAttributes);

                IUnitAttributes Build(ISet<IUnitAttributes> attributes);
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
                : AbstractBuilder<IUnitAttributes>, IInternalBuilder
            {
                // Todo
                private IDestructibleAttributes destructibleAttributes = DestructibleAttributesImpl.Builder.Get().Build();

                // Todo
                private IFireableAttributes fireableAttributes = FireableAttributesImpl.Builder.Get().Build();

                // Todo
                private IMountableAttributes mountableAttributes = MountableAttributesImpl.Builder.Get().Build();

                // Todo
                private IMovableAttributes movableAttributes = MovableAttributesImpl.Builder.Get().Build();

                /// <inheritdoc/>
                IInternalBuilder IInternalBuilder.SetDestructibleAttributes(IDestructibleAttributes destructibleAttributes)
                {
                    this.destructibleAttributes = destructibleAttributes;
                    return this;
                }

                /// <inheritdoc/>
                IInternalBuilder IInternalBuilder.SetFireableAttributes(IFireableAttributes fireableAttributes)
                {
                    this.fireableAttributes = fireableAttributes;
                    return this;
                }

                /// <inheritdoc/>
                IInternalBuilder IInternalBuilder.SetMountableAttributes(IMountableAttributes loadoutAttributes)
                {
                    mountableAttributes = loadoutAttributes;
                    return this;
                }

                /// <inheritdoc/>
                IInternalBuilder IInternalBuilder.SetMovableAttributes(IMovableAttributes movableAttributes)
                {
                    this.movableAttributes = movableAttributes;
                    return this;
                }

                /// <inheritdoc/>
                IUnitAttributes IInternalBuilder.Build(ISet<IUnitAttributes> attributes)
                {
                    ISet<IMovableAttributes> movableAttributes = new HashSet<IMovableAttributes>();
                    ISet<IDestructibleAttributes> destructibleAttributes = new HashSet<IDestructibleAttributes>();
                    ISet<IFireableAttributes> fireableAttributes = new HashSet<IFireableAttributes>();
                    foreach (IUnitAttributes attrs in attributes)
                    {
                        movableAttributes.Add(attrs.GetMovableAttributes());
                        destructibleAttributes.Add(attrs.GetDestructibleAttributes());
                        fireableAttributes.Add(attrs.GetFireableAttributes());
                        if (attrs.GetMountableAttributes() != null)
                        {
                            this.mountableAttributes = attrs.GetMountableAttributes();
                        }
                    }

                    this.destructibleAttributes = DestructibleAttributesImpl.Builder.Get().Build(destructibleAttributes);
                    this.movableAttributes = MovableAttributesImpl.Builder.Get().Build(movableAttributes);
                    this.fireableAttributes = FireableAttributesImpl.Builder.Get().Build(fireableAttributes);

                    return this.BuildObj();
                }

                /// <inheritdoc/>
                protected override IUnitAttributes BuildObj()
                {
                    UnitAttributesImpl unitAttributesImpl = new UnitAttributesImpl();
                    unitAttributesImpl.destructibleAttributes = destructibleAttributes;
                    unitAttributesImpl.fireableAttributes = fireableAttributes;
                    unitAttributesImpl.mountableAttributes = mountableAttributes;
                    unitAttributesImpl.movableAttributes = movableAttributes;
                    return unitAttributesImpl;
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, destructibleAttributes);
                    this.Validate(invalidReasons, fireableAttributes);
                    this.Validate(invalidReasons, movableAttributes);
                }
            }
        }
    }
}