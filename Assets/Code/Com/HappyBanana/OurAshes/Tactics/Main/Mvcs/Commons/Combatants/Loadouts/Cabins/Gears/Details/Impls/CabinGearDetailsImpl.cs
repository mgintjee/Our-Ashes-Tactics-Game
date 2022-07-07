using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Utils.Strings;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Cabins.Gears.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Cabins.Gears.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Cabins.Traits.IDs;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Cabins.Gears.Details.Impls
{
    /// <summary>
    /// Cabin Gear Details Implementation
    /// </summary>
    public struct CabinGearDetailsImpl
        : ICabinGearDetails
    {
        // Todo
        private readonly CabinGearID cabinGearID;

        // Todo
        private readonly ISet<CabinTraitID> cabinTraitIDs;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="Cabin"> </param>
        /// <param name="health"></param>
        private CabinGearDetailsImpl(CabinGearID CabinGearID, ISet<CabinTraitID> CabinTraitIDs)
        {
            this.cabinGearID = CabinGearID;
            this.cabinTraitIDs = CabinTraitIDs;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}, {1}",
                StringUtils.Format(this.cabinGearID),
                StringUtils.Format(this.cabinTraitIDs));
        }

        /// <inheritdoc/>
        CabinGearID ICabinGearDetails.GetCabinGearID()
        {
            return this.cabinGearID;
        }

        /// <inheritdoc/>
        ISet<CabinTraitID> ICabinGearDetails.GetCabinTraitIDs()
        {
            return new HashSet<CabinTraitID>(this.cabinTraitIDs);
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
                : IBuilder<ICabinGearDetails>
            {
                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="cabinGearID"></param>
                /// <returns></returns>
                IInternalBuilder SetCabinGearID(CabinGearID cabinGearIDr);

                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="cabinTraitIDs"></param>
                /// <returns></returns>
                IInternalBuilder SetCabinTraitIDs(ISet<CabinTraitID> cabinTraitIDs);

                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="cabinTraitID"></param>
                /// <returns></returns>
                IInternalBuilder AddCabinTraitID(CabinTraitID cabinTraitID);
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
                : AbstractBuilder<ICabinGearDetails>, IInternalBuilder
            {
                // Todo
                private CabinGearID cabinGearID = CabinGearID.None;

                // Todo
                private ISet<CabinTraitID> cabinTraitIDs = new HashSet<CabinTraitID>();

                /// <inheritdoc/>
                IInternalBuilder IInternalBuilder.AddCabinTraitID(CabinTraitID cabinTraitID)
                {
                    this.cabinTraitIDs.Add(cabinTraitID);
                    return this;
                }

                /// <inheritdoc/>
                IInternalBuilder IInternalBuilder.SetCabinGearID(CabinGearID cabinGearID)
                {
                    this.cabinGearID = cabinGearID;
                    return this;
                }

                /// <inheritdoc/>
                IInternalBuilder IInternalBuilder.SetCabinTraitIDs(ISet<CabinTraitID> cabinTraitIDs)
                {
                    this.cabinTraitIDs = new HashSet<CabinTraitID>(cabinTraitIDs);
                    return this;
                }

                /// <inheritdoc/>
                protected override ICabinGearDetails BuildObj()
                {
                    return new CabinGearDetailsImpl(cabinGearID, cabinTraitIDs);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, cabinGearID);
                }
            }
        }
    }
}