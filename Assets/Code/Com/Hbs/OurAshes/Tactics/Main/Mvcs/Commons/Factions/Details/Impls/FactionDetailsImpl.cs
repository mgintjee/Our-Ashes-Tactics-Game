using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Utils.Strings;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Factions.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Factions.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Phalanxes.Details.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Factions.Details.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public class FactionDetailsImpl
        : IFactionDetails
    {
        private readonly FactionID factionID;
        private readonly ISet<IPhalanxDetails> phalanxDetails;

        private FactionDetailsImpl(FactionID factionID, ISet<IPhalanxDetails> PhalanxDetails)
        {
            this.factionID = factionID;
            this.phalanxDetails = PhalanxDetails;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("\n{0}" +
                "\n{1}",
                StringUtils.Format(this.factionID),
                StringUtils.Format(this.phalanxDetails));
        }

        ISet<IPhalanxDetails> IFactionDetails.GetPhalanxDetails()
        {
            return new HashSet<IPhalanxDetails>(phalanxDetails);
        }

        FactionID IFactionDetails.GetFactionID()
        {
            return factionID;
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
                IInternalBuilder SetFactionID(FactionID factionID);

                IInternalBuilder SetPhalanxDetails(ISet<IPhalanxDetails> phalanxDetails);
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
                private ISet<IPhalanxDetails> phalanxDetails;

                IInternalBuilder IInternalBuilder.SetPhalanxDetails(ISet<IPhalanxDetails> phalanxDetails)
                {
                    this.phalanxDetails = new HashSet<IPhalanxDetails>(phalanxDetails);
                    return this;
                }

                IInternalBuilder IInternalBuilder.SetFactionID(FactionID factionID)
                {
                    this.factionID = factionID;
                    return this;
                }

                protected override IFactionDetails BuildObj()
                {
                    return new FactionDetailsImpl(factionID, phalanxDetails);
                }
            }
        }
    }
}