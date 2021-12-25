using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Loadouts.Gears.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Loadouts.Gears.Skins;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Constants.Loadouts.Views.Gears.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Constants.Loadouts.Views.Gears.Impls
{
    /// <summary>
    /// Gear View Constants Impl
    /// </summary>
    public struct GearViewConstants : IGearViewConstants
    {
        private readonly GearID _gearID;
        private readonly ICollection<GearSkin> _gearSkins;

        private GearViewConstants(GearID gearID, ICollection<GearSkin> gearSkins)
        {
            _gearID = gearID;
            _gearSkins = gearSkins;
        }

        /// <inheritdoc/>
        GearID IGearViewConstants.GetGearID()
        {
            return _gearID;
        }

        /// <inheritdoc/>
        ISet<GearSkin> IGearViewConstants.GetGearSkins()
        {
            return new HashSet<GearSkin>(_gearSkins);
        }

        /// <summary>
        /// Builder class for this object
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Builder Interface for this object
            /// </summary>
            public interface IBuilder : IBuilder<IGearViewConstants>
            {
                IBuilder SetGearSkins(ICollection<GearSkin> combatantSkins);

                IBuilder SetGearID(GearID gearID);
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
            /// Builder Impl for this object
            /// </summary>
            private class InternalBuilder : AbstractBuilder<IGearViewConstants>, IBuilder
            {
                private GearID _gearID;
                private ICollection<GearSkin> _gearSkins = new List<GearSkin>();

                /// <inheritdoc/>
                IBuilder IBuilder.SetGearSkins(ICollection<GearSkin> gearSkins)
                {
                    _gearSkins = new HashSet<GearSkin>(gearSkins);
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetGearID(GearID gearID)
                {
                    _gearID = gearID;
                    return this;
                }

                /// <inheritdoc/>
                protected override IGearViewConstants BuildObj()
                {
                    return new GearViewConstants(_gearID, _gearSkins);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, _gearSkins);
                }
            }
        }
    }
}