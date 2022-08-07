using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Utils.Strings;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Factions.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Factions.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Phalanxes.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Icons.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Patterns.Details.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Factions.Details.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct FactionDetailsImpl
        : IFactionDetails
    {
        private readonly FactionID factionID;
        private readonly IList<PhalanxID> phalanxIDs;
        private readonly IIconDetails iconDetails;
        private readonly IPatternDetails patternDetails;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="factionID"></param>
        /// <param name="phalanxIDs"></param>
        /// <param name="iconDetails"></param>
        /// <param name="patternDetails"></param>
        private FactionDetailsImpl(FactionID factionID, IList<PhalanxID> phalanxIDs, IIconDetails iconDetails, IPatternDetails patternDetails)
        {
            this.factionID = factionID;
            this.phalanxIDs = phalanxIDs;
            this.iconDetails = iconDetails;
            this.patternDetails = patternDetails;
        }

        /// <inheritdoc/>
        public FactionID GetFactionID()
        {
            return factionID;
        }

        /// <inheritdoc/>
        public IIconDetails GetIconDetails()
        {
            return iconDetails;
        }

        /// <inheritdoc/>
        public IPatternDetails GetPatternDetails()
        {
            return patternDetails;
        }

        /// <inheritdoc/>
        public IList<PhalanxID> GetPhalanxIDs()
        {
            return new List<PhalanxID>(phalanxIDs);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}" +
                "\nPhalanxIDs:{3}",
                StringUtils.Format(this.factionID),
                StringUtils.Format(this.iconDetails),
                StringUtils.Format(this.patternDetails),
                StringUtils.Format(this.phalanxIDs));
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
                : IBuilder<IFactionDetails>
            {
                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="id"></param>
                /// <returns></returns>
                IInternalBuilder SetFactionID(FactionID id);
                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="details"></param>
                /// <returns></returns>
                IInternalBuilder SetIconDetails(IIconDetails details);
                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="details"></param>
                /// <returns></returns>
                IInternalBuilder SetPatternDetails(IPatternDetails details);
                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="ids"></param>
                /// <returns></returns>
                IInternalBuilder SetPhalanxIDs(IList<PhalanxID> ids);
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
                : AbstractBuilder<IFactionDetails>, IInternalBuilder
            {
                private FactionID factionID;
                private IList<PhalanxID> phalanxIDs;
                private IIconDetails iconDetails;
                private IPatternDetails patternDetails;

                /// <inheritdoc/>
                public IInternalBuilder SetIconDetails(IIconDetails details)
                {
                    iconDetails = details;
                    return this;
                }

                /// <inheritdoc/>
                public IInternalBuilder SetPatternDetails(IPatternDetails details)
                {
                    patternDetails = details;
                    return this;
                }

                /// <inheritdoc/>
                public IInternalBuilder SetFactionID(FactionID id)
                {
                    factionID = id;
                    return this;
                }

                /// <inheritdoc/>
                public IInternalBuilder SetPhalanxIDs(IList<PhalanxID> ids)
                {
                    phalanxIDs = ids;
                    return this;
                }

                /// <inheritdoc/>
                protected override IFactionDetails BuildObj()
                {
                    return new FactionDetailsImpl(factionID, phalanxIDs, iconDetails, patternDetails);
                }

                /// <inheritdoc/>
                protected override void Validate(IList<string> invalidReasons)
                {
                    this.Validate(invalidReasons, this.factionID);
                    this.Validate(invalidReasons, this.iconDetails);
                    this.Validate(invalidReasons, this.patternDetails);
                }
            }
        }
    }
}