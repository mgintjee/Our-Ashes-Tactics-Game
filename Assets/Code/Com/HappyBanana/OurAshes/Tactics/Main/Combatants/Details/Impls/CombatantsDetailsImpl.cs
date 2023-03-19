using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Apis.Builders.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Apis.Builders.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Utils.Strings;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Factions.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Factions.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Phalanxes.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Phalanxes.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.IDs;
using System.Collections.Generic;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Internals.Optionals;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Apis.Optionals;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Details.Impls
{
    /// <summary>
    /// Combatants Details Implementation
    /// </summary>
    public class CombatantsDetailsImpl
        : ICombatantsDetails
    {
        private readonly IList<IFactionDetails> factionDetails;
        private readonly IList<IPhalanxDetails> phalanxDetails;
        private readonly IList<IUnitDetails> unitDetails;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="factionDetails"></param>
        /// <param name="phalanxDetails"></param>
        /// <param name="unitDetails">   </param>
        private CombatantsDetailsImpl(IList<IFactionDetails> factionDetails, IList<IPhalanxDetails> phalanxDetails, IList<IUnitDetails> unitDetails)
        {
            this.factionDetails = new List<IFactionDetails>(factionDetails);
            this.phalanxDetails = new List<IPhalanxDetails>(phalanxDetails);
            this.unitDetails = new List<IUnitDetails>(unitDetails);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}" +
                "\n{1}" +
                "\n{2}",
                StringUtils.Format(factionDetails),
                StringUtils.Format(phalanxDetails),
                StringUtils.Format(unitDetails));
        }

        /// <inheritdoc/>
        public IList<IFactionDetails> GetFactionDetails()
        {
            return new List<IFactionDetails>(factionDetails);
        }

        /// <inheritdoc/>
        public IList<IPhalanxDetails> GetPhalanxDetails()
        {
            return new List<IPhalanxDetails>(phalanxDetails);
        }

        /// <inheritdoc/>
        public IList<IUnitDetails> GetUnitDetails()
        {
            return new List<IUnitDetails>(unitDetails);
        }

        /// <inheritdoc/>
        public IOptional<IPhalanxDetails> GetPhalanxDetails(PhalanxID id)
        {
            return PhalanxDetailsQueryUtil.GetDetails(phalanxDetails, id);
        }

        /// <inheritdoc/>
        public IOptional<IUnitDetails> GetUnitDetails(UnitID id)
        {
            return UnitDetailsQueryUtil.GetDetails(unitDetails, id);
        }

        /// <inheritdoc/>
        public IOptional<IFactionDetails> GetFactionDetails(FactionID id)
        {
            return FactionDetailsQueryUtil.GetDetails(factionDetails, id);
        }

        /// <inheritdoc/>
        public IOptional<IPhalanxDetails> GetPhalanxDetails(UnitID id)
        {
            return PhalanxDetailsQueryUtil.GetDetails(phalanxDetails, id);
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
                : IBuilder<ICombatantsDetails>
            {
                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="details"></param>
                /// <returns></returns>
                IInternalBuilder SetUnitDetails(IList<IUnitDetails> details);

                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="details"></param>
                /// <returns></returns>
                IInternalBuilder SetPhalanxDetails(IList<IPhalanxDetails> details);

                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="details"></param>
                /// <returns></returns>
                IInternalBuilder SetFactionDetails(IList<IFactionDetails> details);
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
                : AbstractBuilder<ICombatantsDetails>, IInternalBuilder
            {
                private IList<IFactionDetails> factionDetails;
                private IList<IPhalanxDetails> phalanxDetails;
                private IList<IUnitDetails> unitDetails;

                /// <inheritdoc/>
                public IInternalBuilder SetUnitDetails(IList<IUnitDetails> details)
                {
                    unitDetails = new List<IUnitDetails>(details);
                    return this;
                }

                /// <inheritdoc/>
                public IInternalBuilder SetPhalanxDetails(IList<IPhalanxDetails> details)
                {
                    phalanxDetails = new List<IPhalanxDetails>(details);
                    return this;
                }

                /// <inheritdoc/>
                public IInternalBuilder SetFactionDetails(IList<IFactionDetails> details)
                {
                    factionDetails = new List<IFactionDetails>(details);
                    return this;
                }

                /// <inheritdoc/>
                protected override ICombatantsDetails BuildObj()
                {
                    return new CombatantsDetailsImpl(factionDetails, phalanxDetails, unitDetails);
                }
            }
        }
    }
}