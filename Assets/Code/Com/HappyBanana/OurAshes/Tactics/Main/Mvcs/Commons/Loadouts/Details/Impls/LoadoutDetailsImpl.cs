using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Utils.Strings;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Armors.Gears.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Cabins.Gears.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Engines.Gears.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Weapons.Gears.Details.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Details.Impls
{
    public struct LoadoutDetailsImpl
        : ILoadoutDetails
    {
        private readonly IArmorGearDetails armorGearDetails;
        private readonly ICabinGearDetails cabinGearDetails;
        private readonly IEngineGearDetails engineGearDetails;
        private readonly ISet<IWeaponGearDetails> weaponGearDetails;

        private LoadoutDetailsImpl(IArmorGearDetails armorGearDetails, ICabinGearDetails cabinGearDetails,
            IEngineGearDetails engineGearDetails, ISet<IWeaponGearDetails> weaponGearDetails)
        {
            this.armorGearDetails = armorGearDetails;
            this.cabinGearDetails = cabinGearDetails;
            this.engineGearDetails = engineGearDetails;
            this.weaponGearDetails = weaponGearDetails;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("\n{0}" +
                "\n{1}" +
                "\n{2}" +
                "\n{3}",
                StringUtils.Format(this.armorGearDetails),
                StringUtils.Format(this.cabinGearDetails),
                StringUtils.Format(this.engineGearDetails),
                StringUtils.Format(this.weaponGearDetails));
        }

        /// <inheritdoc/>
        IArmorGearDetails ILoadoutDetails.GetArmorGearDetails()
        {
            return this.armorGearDetails;
        }

        /// <inheritdoc/>
        ICabinGearDetails ILoadoutDetails.GetCabinGearDetails()
        {
            return this.cabinGearDetails;
        }

        /// <inheritdoc/>
        IEngineGearDetails ILoadoutDetails.GetEngineGearDetails()
        {
            return this.engineGearDetails;
        }

        /// <inheritdoc/>
        ISet<IWeaponGearDetails> ILoadoutDetails.GetWeaponGearDetails()
        {
            return new HashSet<IWeaponGearDetails>(this.weaponGearDetails);
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
                : IBuilder<ILoadoutDetails>
            {
                IInternalBuilder SetArmorGearDetails(IArmorGearDetails details);

                IInternalBuilder SetCabinGearDetails(ICabinGearDetails details);

                IInternalBuilder SetEngineGearDetails(IEngineGearDetails details);

                IInternalBuilder SetWeaponGearDetails(ISet<IWeaponGearDetails> details);

                IInternalBuilder AddWeaponGearDetails(IWeaponGearDetails details);
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
                : AbstractBuilder<ILoadoutDetails>, IInternalBuilder
            {
                private IArmorGearDetails armorGearDetails;
                private ICabinGearDetails cabinGearDetails;
                private IEngineGearDetails engineGearDetails;
                private ISet<IWeaponGearDetails> weaponGearDetails = new HashSet<IWeaponGearDetails>();

                /// <inheritdoc/>
                IInternalBuilder IInternalBuilder.AddWeaponGearDetails(IWeaponGearDetails details)
                {
                    this.weaponGearDetails.Add(details);
                    return this;
                }

                /// <inheritdoc/>
                IInternalBuilder IInternalBuilder.SetArmorGearDetails(IArmorGearDetails details)
                {
                    this.armorGearDetails = details;
                    return this;
                }

                /// <inheritdoc/>
                IInternalBuilder IInternalBuilder.SetCabinGearDetails(ICabinGearDetails details)
                {
                    this.cabinGearDetails = details;
                    return this;
                }

                /// <inheritdoc/>
                IInternalBuilder IInternalBuilder.SetEngineGearDetails(IEngineGearDetails details)
                {
                    this.engineGearDetails = details;
                    return this;
                }

                /// <inheritdoc/>
                IInternalBuilder IInternalBuilder.SetWeaponGearDetails(ISet<IWeaponGearDetails> details)
                {
                    this.weaponGearDetails = new HashSet<IWeaponGearDetails>(details);
                    return this;
                }

                /// <inheritdoc/>
                protected override ILoadoutDetails BuildObj()
                {
                    return new LoadoutDetailsImpl(this.armorGearDetails,
                        this.cabinGearDetails, this.engineGearDetails, this.weaponGearDetails);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, armorGearDetails);
                    this.Validate(invalidReasons, cabinGearDetails);
                    this.Validate(invalidReasons, engineGearDetails);
                }
            }
        }
    }
}