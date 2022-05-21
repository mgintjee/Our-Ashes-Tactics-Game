using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Utils.Strings;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Weapons.Gears.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Weapons.Gears.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Weapons.Traits.IDs;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Weapons.Gears.Details.Impls
{
    /// <summary>
    /// Weapon Gear Details Implementation
    /// </summary>
    public struct WeaponGearDetailsImpl
        : IWeaponGearDetails
    {
        // Todo
        private readonly WeaponGearID weaponGearID;

        // Todo
        private readonly ISet<WeaponTraitID> weaponTraitIDs;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="Weapon"></param>
        /// <param name="health"></param>
        private WeaponGearDetailsImpl(WeaponGearID WeaponGearID, ISet<WeaponTraitID> WeaponTraitIDs)
        {
            this.weaponGearID = WeaponGearID;
            this.weaponTraitIDs = WeaponTraitIDs;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}, {1}",
                StringUtils.Format(this.weaponGearID),
                StringUtils.Format(this.weaponTraitIDs));
        }

        /// <inheritdoc/>
        WeaponGearID IWeaponGearDetails.GetWeaponGearID()
        {
            return this.weaponGearID;
        }

        /// <inheritdoc/>
        ISet<WeaponTraitID> IWeaponGearDetails.GetWeaponTraitIDs()
        {
            return new HashSet<WeaponTraitID>(this.weaponTraitIDs);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Todo
            /// </summary>
            public interface IInternalBuilder
                : IBuilder<IWeaponGearDetails>
            {
                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="weaponGearID"></param>
                /// <returns></returns>
                IInternalBuilder SetWeaponGearID(WeaponGearID weaponGearID);

                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="weaponTraitIDs"></param>
                /// <returns></returns>
                IInternalBuilder SetWeaponTraitIDs(ISet<WeaponTraitID> weaponTraitIDs);

                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="weaponTraitID"></param>
                /// <returns></returns>
                IInternalBuilder AddWeaponTraitID(WeaponTraitID weaponTraitID);
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public static IInternalBuilder Get()
            {
                return new InternalBuilder();
            }

            /// <summary>
            /// Todo
            /// </summary>
            private class InternalBuilder
                : AbstractBuilder<IWeaponGearDetails>, IInternalBuilder
            {
                // Todo
                private WeaponGearID weaponGearID = WeaponGearID.None;

                // Todo
                private ISet<WeaponTraitID> weaponTraitIDs = new HashSet<WeaponTraitID>();

                /// <inheritdoc/>
                IInternalBuilder IInternalBuilder.AddWeaponTraitID(WeaponTraitID weaponTraitID)
                {
                    this.weaponTraitIDs.Add(weaponTraitID);
                    return this;
                }

                /// <inheritdoc/>
                IInternalBuilder IInternalBuilder.SetWeaponGearID(WeaponGearID weaponGearID)
                {
                    this.weaponGearID = weaponGearID;
                    return this;
                }

                /// <inheritdoc/>
                IInternalBuilder IInternalBuilder.SetWeaponTraitIDs(ISet<WeaponTraitID> weaponTraitIDs)
                {
                    this.weaponTraitIDs = new HashSet<WeaponTraitID>(weaponTraitIDs);
                    return this;
                }

                /// <inheritdoc/>
                protected override IWeaponGearDetails BuildObj()
                {
                    return new WeaponGearDetailsImpl(weaponGearID, weaponTraitIDs);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, weaponGearID);
                }
            }
        }
    }
}