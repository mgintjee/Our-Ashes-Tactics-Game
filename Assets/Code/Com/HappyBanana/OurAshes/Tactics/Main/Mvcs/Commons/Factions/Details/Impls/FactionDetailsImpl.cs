using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Utils.Strings;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Factions.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Factions.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Phalanxes.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Phalanxes.IDs;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Factions.Details.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public class FactionDetailsImpl
        : IFactionDetails
    {
        private readonly FactionID factionID;
        private readonly IList<PhalanxID> phalanxIDs;

        private FactionDetailsImpl(FactionID factionID, IList<PhalanxID> phalanxIDs)
        {
            this.factionID = factionID;
            this.phalanxIDs = phalanxIDs;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("\n{0}" +
                "\n{1}",
                StringUtils.Format(this.factionID),
                StringUtils.Format(this.phalanxIDs));
        }

        FactionID IFactionDetails.GetFactionID()
        {
            return factionID;
        }

        IList<PhalanxID> IFactionDetails.GetPhalanxIDs()
        {
            return new List<PhalanxID>(phalanxIDs);
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
                IInternalBuilder SetFactionID(FactionID id);

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

                IInternalBuilder IInternalBuilder.SetPhalanxIDs(IList<PhalanxID> ids)
                {
                    this.phalanxIDs = new List<PhalanxID>(ids);
                    return this;
                }

                IInternalBuilder IInternalBuilder.SetFactionID(FactionID id)
                {
                    this.factionID = id;
                    return this;
                }

                protected override IFactionDetails BuildObj()
                {
                    return new FactionDetailsImpl(factionID, phalanxIDs);
                }
            }
        }
    }
}