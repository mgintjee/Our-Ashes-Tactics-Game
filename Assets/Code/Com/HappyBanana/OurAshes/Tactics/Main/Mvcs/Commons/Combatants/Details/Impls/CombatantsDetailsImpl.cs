using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Utils.Strings;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Factions.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Factions.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Phalanxes.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Phalanxes.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.IDs;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Details.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public class CombatantsDetailsImpl
        : ICombatantsDetails
    {
        private readonly IList<IFactionDetails> factionDetails;
        private readonly IList<IPhalanxDetails> phalanxDetails;
        private readonly IList<IUnitDetails> unitDetails;

        private CombatantsDetailsImpl(IList<IFactionDetails> factionDetails, IList<IPhalanxDetails> phalanxDetails, IList<IUnitDetails> unitDetails)
        {
            this.factionDetails = new List<IFactionDetails>(factionDetails);
            this.phalanxDetails = new List<IPhalanxDetails>(phalanxDetails);
            this.unitDetails = new List<IUnitDetails>(unitDetails);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("FactionDetails:{0}" +
                "\nPhalanxDetails:{1}" +
                "\nUnitDetails:{2}",
                StringUtils.Format(this.factionDetails),
                StringUtils.Format(this.phalanxDetails),
                StringUtils.Format(this.unitDetails));
        }

        IList<IFactionDetails> ICombatantsDetails.GetFactionDetails()
        {
            return new List<IFactionDetails>(this.factionDetails);
        }

        IList<IPhalanxDetails> ICombatantsDetails.GetPhalanxDetails()
        {
            return new List<IPhalanxDetails>(this.phalanxDetails);
        }

        IList<IUnitDetails> ICombatantsDetails.GetUnitDetails()
        {
            return new List<IUnitDetails>(this.unitDetails);
        }

        Optional<IPhalanxDetails> ICombatantsDetails.GetDetails(PhalanxID id)
        {
            foreach (IPhalanxDetails details in this.phalanxDetails)
            {
                if (details.GetPhalanxID() == id)
                {
                    return Optional<IPhalanxDetails>.Of(details);
                }
            }
            return Optional<IPhalanxDetails>.Empty();
        }

        Optional<IUnitDetails> ICombatantsDetails.GetDetails(UnitID id)
        {
            foreach (IUnitDetails details in this.phalanxDetails)
            {
                if (details.GetUnitID() == id)
                {
                    return Optional<IUnitDetails>.Of(details);
                }
            }
            return Optional<IUnitDetails>.Empty();
        }

        Optional<IFactionDetails> ICombatantsDetails.GetDetails(FactionID id)
        {
            foreach (IFactionDetails details in this.phalanxDetails)
            {
                if (details.GetFactionID() == id)
                {
                    return Optional<IFactionDetails>.Of(details);
                }
            }
            return Optional<IFactionDetails>.Empty();
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
                IInternalBuilder SetUnitDetails(IList<IUnitDetails> details);

                IInternalBuilder SetPhalanxDetails(IList<IPhalanxDetails> details);

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

                IInternalBuilder IInternalBuilder.SetUnitDetails(IList<IUnitDetails> details)
                {
                    this.unitDetails = new List<IUnitDetails>(details);
                    return this;
                }

                IInternalBuilder IInternalBuilder.SetPhalanxDetails(IList<IPhalanxDetails> details)
                {
                    this.phalanxDetails = new List<IPhalanxDetails>(details);
                    return this;
                }

                IInternalBuilder IInternalBuilder.SetFactionDetails(IList<IFactionDetails> details)
                {
                    this.factionDetails = new List<IFactionDetails>(details);
                    return this;
                }

                protected override ICombatantsDetails BuildObj()
                {
                    return new CombatantsDetailsImpl(factionDetails, phalanxDetails, unitDetails);
                }
            }
        }
    }
}