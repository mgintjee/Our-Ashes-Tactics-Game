using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Apis.Builders.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Apis.Builders.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Utils.Strings;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Gears.Sizes;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Attrs.Mountables.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Attrs.Mountables.Impls
{
    /// <summary>
    /// Mountable Attributes Impl
    /// </summary>
    public struct MountableAttributesImpl
        : IMountableAttributes
    {
        // Todo
        private readonly GearSize armorGearSize;

        // Todo
        private readonly GearSize cabinGearSize;

        // Todo
        private readonly GearSize engineGearSize;

        // Todo
        private readonly IList<GearSize> weaponGearSizes;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="armorGearSize">  </param>
        /// <param name="cabinGearSize">  </param>
        /// <param name="engineGearSize"> </param>
        /// <param name="weaponGearSizes"></param>
        private MountableAttributesImpl(GearSize armorGearSize, GearSize cabinGearSize,
            GearSize engineGearSize, IList<GearSize> weaponGearSizes)
        {
            this.armorGearSize = armorGearSize;
            this.cabinGearSize = cabinGearSize;
            this.engineGearSize = engineGearSize;
            this.weaponGearSizes = weaponGearSizes;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: Armor: {1}, Cabin: {2}, Engine: {3}, Weapons: {4}",
                this.GetType().Name,
                StringUtils.Format(armorGearSize),
                StringUtils.Format(cabinGearSize),
                StringUtils.Format(engineGearSize),
                StringUtils.Format(weaponGearSizes));
        }

        /// <inheritdoc/>
        GearSize IMountableAttributes.GetArmorGearSize()
        {
            return armorGearSize;
        }

        /// <inheritdoc/>
        GearSize IMountableAttributes.GetCabinGearSize()
        {
            return cabinGearSize;
        }

        /// <inheritdoc/>
        GearSize IMountableAttributes.GetEngineGearSize()
        {
            return engineGearSize;
        }

        /// <inheritdoc/>
        IList<GearSize> IMountableAttributes.GetWeaponGearSizes()
        {
            return new List<GearSize>(weaponGearSizes);
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
                : IBuilder<IMountableAttributes>
            {
                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="gearSize"></param>
                /// <returns></returns>
                IInternalBuilder SetArmorGearSize(GearSize gearSize);

                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="gearSize"></param>
                /// <returns></returns>
                IInternalBuilder SetCabinGearSize(GearSize gearSize);

                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="gearSize"></param>
                /// <returns></returns>
                IInternalBuilder SetEngineGearSize(GearSize gearSize);

                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="gearSizes"></param>
                /// <returns></returns>
                IInternalBuilder SetWeaponGearSizes(IList<GearSize> gearSizes);
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
                : AbstractBuilder<IMountableAttributes>, IInternalBuilder
            {
                // Todo
                private GearSize armorGearSize = GearSize.None;

                // Todo
                private GearSize cabinGearSize = GearSize.None;

                // Todo
                private GearSize engineGearSize = GearSize.None;

                // Todo
                private IList<GearSize> weaponsGearSizes = new List<GearSize>();

                /// <inheritdoc/>
                public IInternalBuilder SetArmorGearSize(GearSize gearSize)
                {
                    armorGearSize = gearSize;
                    return this;
                }

                /// <inheritdoc/>
                public IInternalBuilder SetCabinGearSize(GearSize gearSize)
                {
                    cabinGearSize = gearSize;
                    return this;
                }

                /// <inheritdoc/>
                public IInternalBuilder SetEngineGearSize(GearSize gearSize)
                {
                    engineGearSize = gearSize;
                    return this;
                }

                /// <inheritdoc/>
                public IInternalBuilder SetWeaponGearSizes(IList<GearSize> gearSizes)
                {
                    weaponsGearSizes = new List<GearSize>(gearSizes);
                    return this;
                }

                /// <inheritdoc/>
                protected override IMountableAttributes BuildObj()
                {
                    // Instantiate a new attributes
                    return new MountableAttributesImpl(armorGearSize, cabinGearSize, engineGearSize, weaponsGearSizes);
                }
            }
        }
    }
}