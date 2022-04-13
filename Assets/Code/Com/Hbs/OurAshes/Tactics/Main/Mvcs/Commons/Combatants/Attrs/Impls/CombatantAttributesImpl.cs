using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Combatants.Attrs.Destructibles.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Combatants.Attrs.Destructibles.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Combatants.Attrs.Fireables.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Combatants.Attrs.Fireables.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Combatants.Attrs.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Combatants.Attrs.Mountables.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Combatants.Attrs.Mountables.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Combatants.Attrs.Movables.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Combatants.Attrs.Movables.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Combatants.Attrs.Impls
{
    /// <summary>
    /// Combatant Attributes Implementation
    /// </summary>
    public class CombatantAttributesImpl
        : ICombatantAttributes
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
        IDestructibleAttributes ICombatantAttributes.GetDestructibleAttributes()
        {
            return this.destructibleAttributes;
        }

        /// <inheritdoc/>
        IFireableAttributes ICombatantAttributes.GetFireableAttributes()
        {
            return this.fireableAttributes;
        }

        /// <inheritdoc/>
        IMountableAttributes ICombatantAttributes.GetMountableAttributes()
        {
            return this.mountableAttributes;
        }

        /// <inheritdoc/>
        IMovableAttributes ICombatantAttributes.GetMovableAttributes()
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
                : IBuilder<ICombatantAttributes>
            {
                IInternalBuilder SetDestructibleAttributes(IDestructibleAttributes destructibleAttributes);

                IInternalBuilder SetFireableAttributes(IFireableAttributes fireableAttributes);

                IInternalBuilder SetMountableAttributes(IMountableAttributes loadoutAttributes);

                IInternalBuilder SetMovableAttributes(IMovableAttributes movableAttributes);

                ICombatantAttributes Build(ISet<ICombatantAttributes> attributes);
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
                : AbstractBuilder<ICombatantAttributes>, IInternalBuilder
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
                ICombatantAttributes IInternalBuilder.Build(ISet<ICombatantAttributes> attributes)
                {
                    ISet<IMovableAttributes> movableAttributes = new HashSet<IMovableAttributes>();
                    ISet<IDestructibleAttributes> destructibleAttributes = new HashSet<IDestructibleAttributes>();
                    ISet<IFireableAttributes> fireableAttributes = new HashSet<IFireableAttributes>();
                    foreach (ICombatantAttributes attrs in attributes)
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
                protected override ICombatantAttributes BuildObj()
                {
                    CombatantAttributesImpl combatantAttributesImpl = new CombatantAttributesImpl();
                    combatantAttributesImpl.destructibleAttributes = destructibleAttributes;
                    combatantAttributesImpl.fireableAttributes = fireableAttributes;
                    combatantAttributesImpl.mountableAttributes = mountableAttributes;
                    combatantAttributesImpl.movableAttributes = movableAttributes;
                    return combatantAttributesImpl;
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