using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Gears.Sizes;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Utils.Strings;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Loadouts.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Loadouts.Implementations
{
    /// <summary>
    /// Loadout Attributes Implementation
    /// </summary>
    public struct LoadoutAttributes
        : ILoadoutAttributes
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
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private GearSize _armorGearSize = GearSize.None;

            // Todo
            private GearSize _cabinGearSize = GearSize.None;

            // Todo
            private GearSize _engineGearSize = GearSize.None;

            // Todo
            private IList<GearSize> _weaponGearSizes = new List<GearSize>();

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public ILoadoutAttributes Build()
            {
                // Instantiate a new attributes
                return new LoadoutAttributes(_armorGearSize, _cabinGearSize, _engineGearSize, _weaponGearSizes);
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="gearSize"></param>
            public Builder SetArmorGearSize(GearSize gearSize)
            {
                _armorGearSize = gearSize;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="gearSize"></param>
            public Builder SetCabinGearSize(GearSize gearSize)
            {
                _cabinGearSize = gearSize;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="gearSize"></param>
            public Builder SetEngineGearSize(GearSize gearSize)
            {
                _engineGearSize = gearSize;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="gearSizes"></param>
            public Builder SetWeaponGearSizes(IList<GearSize> gearSizes)
            {
                _weaponGearSizes = new List<GearSize>(gearSizes);
                return this;
            }
        }
    }
}