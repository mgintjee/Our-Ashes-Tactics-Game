using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Apis.Builders.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Apis.Builders.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Utils.Strings;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Gears.Armors.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Gears.Cabins.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Gears.Engines.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Gears.Weapons.IDs;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Details.Impls
{
    public struct LoadoutDetailsImpl
        : ILoadoutDetails
    {
        private readonly EngineGearID engineGearID;

        private readonly ArmorGearID armorGearID;

        private readonly CabinGearID cabinGearID;

        private readonly IList<WeaponGearID> weaponGearIDs;

        private LoadoutDetailsImpl(ArmorGearID armorGearID, CabinGearID cabinGearID, EngineGearID engineGearID, IList<WeaponGearID> weaponGearIDs)
        {
            this.armorGearID = armorGearID;
            this.cabinGearID = cabinGearID;
            this.engineGearID = engineGearID;
            this.weaponGearIDs = weaponGearIDs;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("\n{0}" +
                "\n{1}" +
                "\n{2}" +
                "\n{3}",
                StringUtils.Format(this.armorGearID),
                StringUtils.Format(this.cabinGearID),
                StringUtils.Format(this.engineGearID),
                StringUtils.Format(this.weaponGearIDs));
        }

        /// <inheritdoc/>
        ArmorGearID ILoadoutDetails.GetArmorGearID()
        {
            return armorGearID;
        }

        /// <inheritdoc/>
        CabinGearID ILoadoutDetails.GetCabinGearID()
        {
            return cabinGearID;
        }

        /// <inheritdoc/>
        EngineGearID ILoadoutDetails.GetEngineGearID()
        {
            return engineGearID;
        }

        /// <inheritdoc/>
        IList<WeaponGearID> ILoadoutDetails.GetWeaponGearIDs()
        {
            return new List<WeaponGearID>(weaponGearIDs);
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
                IInternalBuilder SetArmorGearID(ArmorGearID id);

                IInternalBuilder SetCabinGearID(CabinGearID id);

                IInternalBuilder SetEngineGearID(EngineGearID id);

                IInternalBuilder SetWeaponGearID(IList<WeaponGearID> id);

                IInternalBuilder AddWeaponGearID(WeaponGearID id);
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
                private ArmorGearID armorGearID;
                private CabinGearID cabinGearID;
                private EngineGearID engineGearID;
                private IList<WeaponGearID> weaponGearID = new List<WeaponGearID>();

                /// <inheritdoc/>
                IInternalBuilder IInternalBuilder.AddWeaponGearID(WeaponGearID id)
                {
                    this.weaponGearID.Add(id);
                    return this;
                }

                /// <inheritdoc/>
                IInternalBuilder IInternalBuilder.SetArmorGearID(ArmorGearID id)
                {
                    this.armorGearID = id;
                    return this;
                }

                /// <inheritdoc/>
                IInternalBuilder IInternalBuilder.SetCabinGearID(CabinGearID id)
                {
                    this.cabinGearID = id;
                    return this;
                }

                /// <inheritdoc/>
                IInternalBuilder IInternalBuilder.SetEngineGearID(EngineGearID id)
                {
                    this.engineGearID = id;
                    return this;
                }

                /// <inheritdoc/>
                IInternalBuilder IInternalBuilder.SetWeaponGearID(IList<WeaponGearID> id)
                {
                    this.weaponGearID = new List<WeaponGearID>(id);
                    return this;
                }

                /// <inheritdoc/>
                protected override ILoadoutDetails BuildObj()
                {
                    return new LoadoutDetailsImpl(this.armorGearID,
                        this.cabinGearID, this.engineGearID, this.weaponGearID);
                }
            }
        }
    }
}