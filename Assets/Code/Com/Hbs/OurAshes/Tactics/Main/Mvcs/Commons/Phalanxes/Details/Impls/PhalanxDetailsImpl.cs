using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.CallSigns;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Factions.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Phalanxes.Details.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Phalanxes.Details.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public class PhalanxDetailsImpl
        : IPhalanxDetails
    {
        private readonly CallSign callSign;
        private readonly ISet<ICombatantDetails> combatantDetails;

        private PhalanxDetailsImpl(CallSign callSign, ISet<ICombatantDetails> combatantDetails)
        {
            this.callSign = callSign;
            this.combatantDetails = combatantDetails;
        }

        CallSign IPhalanxDetails.GetCallSign()
        {
            return callSign;
        }

        ISet<ICombatantDetails> IPhalanxDetails.GetCombatantDetails()
        {
            return new HashSet<ICombatantDetails>(combatantDetails);
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

                IInternalBuilder SetCallSign(CallSign callSign);

                IInternalBuilder SetCombatantDetails(ISet<ICombatantDetails> combatantDetails);
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
                private CallSign callSign;
                private ISet<ICombatantDetails> combatantDetails;

                IInternalBuilder IInternalBuilder.SetCallSign(CallSign callSign)
                {
                    this.callSign = callSign;
                    return this;
                }

                IInternalBuilder IInternalBuilder.SetCombatantDetails(ISet<ICombatantDetails> combatantDetails)
                {
                    this.combatantDetails = new HashSet<ICombatantDetails>(combatantDetails);
                    return this;
                }

                protected override IPhalanxDetails BuildObj()
                {
                    return new PhalanxDetailsImpl(callSign, combatantDetails);
                }
            }
        }
    }
}