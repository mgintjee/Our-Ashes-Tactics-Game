using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Loadouts.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Loadouts.Gears.Sizes;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Utils.Strings;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Loadouts.Impls
{
    /// <summary>
    /// Loadout Attributes Implementation
    /// </summary>
    public struct LoadoutAttributes : ILoadoutAttributes
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
        private LoadoutAttributes(GearSize armorGearSize, GearSize cabinGearSize,
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
                StringUtils.FormatCollection(_weaponGearSizes));
        }

        /// <inheritdoc/>
        GearSize ILoadoutAttributes.GetArmorGearSize()
        {
            return _armorGearSize;
        }

        /// <inheritdoc/>
        GearSize ILoadoutAttributes.GetCabinGearSize()
        {
            return _cabinGearSize;
        }

        /// <inheritdoc/>
        GearSize ILoadoutAttributes.GetEngineGearSize()
        {
            return _engineGearSize;
        }

        /// <inheritdoc/>
        IList<GearSize> ILoadoutAttributes.GetWeaponGearSizes()
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
            public interface IBuilder : IBuilder<ILoadoutAttributes>
            {
                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="gearSize"></param>
                /// <returns></returns>
                IBuilder SetArmorGearSize(GearSize gearSize);

                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="gearSize"></param>
                /// <returns></returns>
                IBuilder SetCabinGearSize(GearSize gearSize);

                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="gearSize"></param>
                /// <returns></returns>
                IBuilder SetEngineGearSize(GearSize gearSize);

                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="gearSizes"></param>
                /// <returns></returns>
                IBuilder SetWeaponGearSizes(IList<GearSize> gearSizes);
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
            private class InternalBuilder : AbstractBuilder<ILoadoutAttributes>, IBuilder
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
                public IBuilder SetArmorGearSize(GearSize gearSize)
                {
                    _armorGearSize = gearSize;
                    return this;
                }

                /// <inheritdoc/>
                public IBuilder SetCabinGearSize(GearSize gearSize)
                {
                    _cabinGearSize = gearSize;
                    return this;
                }

                /// <inheritdoc/>
                public IBuilder SetEngineGearSize(GearSize gearSize)
                {
                    _engineGearSize = gearSize;
                    return this;
                }

                /// <inheritdoc/>
                public IBuilder SetWeaponGearSizes(IList<GearSize> gearSizes)
                {
                    _weaponsGearSizes = new List<GearSize>(gearSizes);
                    return this;
                }

                /// <inheritdoc/>
                protected override ILoadoutAttributes BuildObj()
                {
                    // Instantiate a new attributes
                    return new LoadoutAttributes(_armorGearSize, _cabinGearSize, _engineGearSize, _weaponsGearSizes);
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