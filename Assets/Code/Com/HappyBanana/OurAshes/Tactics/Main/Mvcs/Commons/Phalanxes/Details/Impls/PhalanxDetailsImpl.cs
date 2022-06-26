using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Utils.Strings;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Units.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Phalanxes.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Phalanxes.IDs;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Phalanxes.Details.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public class PhalanxDetailsImpl
        : IPhalanxDetails
    {
        private readonly PhalanxID id;
        private readonly IList<IUnitDetails> unitDetails;

        private PhalanxDetailsImpl(PhalanxID id, IList<IUnitDetails> unitDetails)
        {
            this.id = id;
            this.unitDetails = unitDetails;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("\n{0}" +
                "\n{1}",
                StringUtils.Format(this.id),
                StringUtils.Format(this.unitDetails));
        }

        PhalanxID IPhalanxDetails.GetID()
        {
            return id;
        }

        IList<IUnitDetails> IPhalanxDetails.GetUnitDetails()
        {
            return new List<IUnitDetails>(unitDetails);
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
                : IBuilder<IPhalanxDetails>
            {
                IInternalBuilder SetID(PhalanxID id);

                IInternalBuilder SetUnitDetails(IList<IUnitDetails> unitDetails);
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
                : AbstractBuilder<IPhalanxDetails>, IInternalBuilder
            {
                private PhalanxID id;
                private IList<IUnitDetails> unitDetails;

                IInternalBuilder IInternalBuilder.SetID(PhalanxID id)
                {
                    this.id = id;
                    return this;
                }

                IInternalBuilder IInternalBuilder.SetUnitDetails(IList<IUnitDetails> unitDetails)
                {
                    this.unitDetails = new List<IUnitDetails>(unitDetails);
                    return this;
                }

                protected override IPhalanxDetails BuildObj()
                {
                    return new PhalanxDetailsImpl(id, unitDetails);
                }
            }
        }
    }
}