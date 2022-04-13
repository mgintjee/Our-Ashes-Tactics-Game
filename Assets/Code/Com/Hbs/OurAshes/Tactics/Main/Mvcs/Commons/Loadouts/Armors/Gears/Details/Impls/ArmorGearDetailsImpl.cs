using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Utils.Strings;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Armors.Gears.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Armors.Gears.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Armors.Traits.IDs;

using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Armors.Gears.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Armors.Gears.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Armors.Traits.IDs;

using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Armors.Gears.Details.Impls
{
    /// <summary>
    /// Armor Gear Details Implementation
    /// </summary>
    public struct ArmorGearDetailsImpl
        : IArmorGearDetails
    {
        // Todo
        private readonly ArmorGearID armorGearID;

        // Todo
        private readonly ISet<ArmorTraitID> armorTraitIDs;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="armor"> </param>
        /// <param name="health"></param>
        private ArmorGearDetailsImpl(ArmorGearID armorGearID, ISet<ArmorTraitID> armorTraitIDs)
        {
            this.armorGearID = armorGearID;
            this.armorTraitIDs = armorTraitIDs;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}, {1}",
                StringUtils.Format(this.armorGearID),
                StringUtils.FormatCollection(this.armorTraitIDs));
        }

        /// <inheritdoc/>
        ArmorGearID IArmorGearDetails.GetArmorGearID()
        {
            return this.armorGearID;
        }

        /// <inheritdoc/>
        ISet<ArmorTraitID> IArmorGearDetails.GetArmorTraitIDs()
        {
            return new HashSet<ArmorTraitID>(this.armorTraitIDs);
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
                : IBuilder<IArmorGearDetails>
            {
                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="armorGearID"></param>
                /// <returns></returns>
                IInternalBuilder SetArmorGearID(ArmorGearID armorGearID);

                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="armorTraitIDs"></param>
                /// <returns></returns>
                IInternalBuilder SetArmorTraitIDs(ISet<ArmorTraitID> armorTraitIDs);

                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="armorTraitID"></param>
                /// <returns></returns>
                IInternalBuilder AddArmorTraitID(ArmorTraitID armorTraitID);
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
                : AbstractBuilder<IArmorGearDetails>, IInternalBuilder
            {
                // Todo
                private ArmorGearID armorGearID = ArmorGearID.None;

                // Todo
                private ISet<ArmorTraitID> armorTraitIDs = new HashSet<ArmorTraitID>();

                /// <inheritdoc/>
                IInternalBuilder IInternalBuilder.AddArmorTraitID(ArmorTraitID armorTraitID)
                {
                    this.armorTraitIDs.Add(armorTraitID);
                    return this;
                }

                /// <inheritdoc/>
                IInternalBuilder IInternalBuilder.SetArmorGearID(ArmorGearID armorGearID)
                {
                    this.armorGearID = armorGearID;
                    return this;
                }

                /// <inheritdoc/>
                IInternalBuilder IInternalBuilder.SetArmorTraitIDs(ISet<ArmorTraitID> armorTraitIDs)
                {
                    this.armorTraitIDs = new HashSet<ArmorTraitID>(armorTraitIDs);
                    return this;
                }

                /// <inheritdoc/>
                protected override IArmorGearDetails BuildObj()
                {
                    return new ArmorGearDetailsImpl(armorGearID, armorTraitIDs);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, armorGearID);
                }
            }
        }
    }
}