using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Gears.Skins.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Stats.Gears.Views.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Materials.Indices.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Stats.Gears.Views.Implementations
{
    /// <summary>
    /// Gear View Stats Implementation
    /// </summary>
    public struct GearViewStats
        : IGearViewStats
    {
        // Todo
        private readonly IMaterialIndices _materialIndices;

        // Todo
        private readonly ISet<GearSkin> _gearSkins;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="materialIndices"></param>
        /// <param name="gearSkins">      </param>
        private GearViewStats(IMaterialIndices materialIndices, ISet<GearSkin> gearSkins)
        {
            _materialIndices = materialIndices;
            _gearSkins = gearSkins;
        }

        IMaterialIndices IGearViewStats.GetMaterialIndices()
        {
            return _materialIndices;
        }

        ISet<GearSkin> IGearViewStats.GetSkins()
        {
            return new HashSet<GearSkin>(_gearSkins);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private IMaterialIndices _materialIndices;

            // Todo
            private ISet<GearSkin> _gearSkins;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IGearViewStats Build()
            {
                return new GearViewStats(_materialIndices, _gearSkins);
            }

            /// <summary>
            ///Todo
            /// </summary>
            /// <param name="gearSkins"></param>
            /// <returns></returns>
            public Builder SetGearSkins(ISet<GearSkin> gearSkins)
            {
                if (gearSkins != null)
                {
                    _gearSkins = new HashSet<GearSkin>(gearSkins);
                }
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="materialIndices"></param>
            /// <returns></returns>
            public Builder SetMaterialIndices(IMaterialIndices materialIndices)
            {
                _materialIndices = materialIndices;
                return this;
            }
        }
    }
}