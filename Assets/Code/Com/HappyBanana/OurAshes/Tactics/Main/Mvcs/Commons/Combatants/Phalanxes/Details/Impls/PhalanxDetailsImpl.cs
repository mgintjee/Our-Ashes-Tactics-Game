using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Utils.Strings;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Phalanxes.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Phalanxes.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.IDs;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Phalanxes.Details.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public class PhalanxDetailsImpl
        : IPhalanxDetails
    {
        private readonly PhalanxID phalanxID;
        private readonly IList<UnitID> unitIDs;

        private PhalanxDetailsImpl(PhalanxID phalanxID, IList<UnitID> unitIDs)
        {
            this.phalanxID = phalanxID;
            this.unitIDs = unitIDs;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}, " +
                "\nUnitDetails:{1}",
                StringUtils.Format(this.phalanxID),
                StringUtils.Format(this.unitIDs));
        }

        PhalanxID IPhalanxDetails.GetPhalanxID()
        {
            return phalanxID;
        }

        IList<UnitID> IPhalanxDetails.GetUnitIDs()
        {
            return new List<UnitID>(unitIDs);
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
                IInternalBuilder SetPhalanxID(PhalanxID id);

                IInternalBuilder SetUnitIDs(IList<UnitID> ids);
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
                private PhalanxID phalanxID;
                private IList<UnitID> unitIDs = new List<UnitID>();

                IInternalBuilder IInternalBuilder.SetPhalanxID(PhalanxID id)
                {
                    this.phalanxID = id;
                    return this;
                }

                IInternalBuilder IInternalBuilder.SetUnitIDs(IList<UnitID> ids)
                {
                    this.unitIDs = new List<UnitID>(ids);
                    return this;
                }

                protected override IPhalanxDetails BuildObj()
                {
                    return new PhalanxDetailsImpl(phalanxID, unitIDs);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, this.phalanxID);
                }
            }
        }
    }
}