using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Utils.Strings;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Units.Attrs.Mountables.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Sizes;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Units.Attrs.Mountables.Impls
{
    /// <summary>
    /// Mountable Attributes Impl
    /// </summary>
    public struct MountableAttributesImpl
        : IMountableAttributes
    {
        // Todo
        private readonly GearSize _armorGearSize;

        // Todo
        private readonly GearSize _cabinGearSize;

        // Todo
        private readonly GearSize _engineGearSize;

        // Todo
        private readonly IList<GearSize> _weaponGearSizes;

        /// <summary>
        /// Tododw
        /// </summary>
        /// <param name="armorGearSize">  </param>
        /// <param name="cabinGearSize">  </param>
        /// <param name="engineGearSize"> </param>
        /// <param name="weaponGearSizes"></param>
        private MountableAttributesImpl(GearSize armorGearSize, GearSize cabinGearSize,
            GearSize engineGearSize, IList<GearSize> weaponGearSizes)
        {
            _armorGearSize = armorGearSize;
            _cabinGearSize = cabinGearSize;
            _engineGearSize = engineGearSize;
            _weaponGearSizes = weaponGearSizes;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: Armor: {1}, Cabin: {2}, Engine: {3}, Weapons: {4}",
                this.GetType().Name,
                StringUtils.Format(_armorGearSize),
                StringUtils.Format(_cabinGearSize),
                StringUtils.Format(_engineGearSize),
                StringUtils.Format(_weaponGearSizes));
        }

        /// <inheritdoc/>
        GearSize IMountableAttributes.GetArmorGearSize()
        {
            return _armorGearSize;
        }

        /// <inheritdoc/>
        GearSize IMountableAttributes.GetCabinGearSize()
        {
            return _cabinGearSize;
        }

        /// <inheritdoc/>
        GearSize IMountableAttributes.GetEngineGearSize()
        {
            return _engineGearSize;
        }

        /// <inheritdoc/>
        IList<GearSize> IMountableAttributes.GetWeaponGearSizes()
        {
            return new List<GearSize>(_weaponGearSizes);
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
                private GearSize _armorGearSize = GearSize.None;

                // Todo
                private GearSize _cabinGearSize = GearSize.None;

                // Todo
                private GearSize _engineGearSize = GearSize.None;

                // Todo
                private IList<GearSize> _weaponsGearSizes = new List<GearSize>();

                /// <inheritdoc/>
                public IInternalBuilder SetArmorGearSize(GearSize gearSize)
                {
                    _armorGearSize = gearSize;
                    return this;
                }

                /// <inheritdoc/>
                public IInternalBuilder SetCabinGearSize(GearSize gearSize)
                {
                    _cabinGearSize = gearSize;
                    return this;
                }

                /// <inheritdoc/>
                public IInternalBuilder SetEngineGearSize(GearSize gearSize)
                {
                    _engineGearSize = gearSize;
                    return this;
                }

                /// <inheritdoc/>
                public IInternalBuilder SetWeaponGearSizes(IList<GearSize> gearSizes)
                {
                    _weaponsGearSizes = new List<GearSize>(gearSizes);
                    return this;
                }

                /// <inheritdoc/>
                protected override IMountableAttributes BuildObj()
                {
                    // Instantiate a new attributes
                    return new MountableAttributesImpl(_armorGearSize, _cabinGearSize, _engineGearSize, _weaponsGearSizes);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, _armorGearSize);
                    this.Validate(invalidReasons, _cabinGearSize);
                    this.Validate(invalidReasons, _engineGearSize);
                    this.Validate(invalidReasons, _weaponsGearSizes);
                }
            }
        }
    }
}