using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Utils.Strings;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Phalanxes.CallSigns;
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
        private readonly PhalanxCallSign callSign;
        private readonly IList<ICombatantDetails> combatantDetails;

        private PhalanxDetailsImpl(PhalanxCallSign callSign, IList<ICombatantDetails> combatantDetails)
        {
            this.callSign = callSign;
            this.combatantDetails = combatantDetails;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("\n{0}" +
                "\n{1}",
                StringUtils.Format(this.callSign),
                StringUtils.Format(this.combatantDetails));
        }

        PhalanxCallSign IPhalanxDetails.GetCallSign()
        {
            return callSign;
        }

        IList<ICombatantDetails> IPhalanxDetails.GetCombatantDetails()
        {
            return new List<ICombatantDetails>(combatantDetails);
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
                IInternalBuilder SetCallSign(PhalanxCallSign callSign);

                IInternalBuilder SetCombatantDetails(IList<ICombatantDetails> combatantDetails);
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
                private PhalanxCallSign callSign;
                private IList<ICombatantDetails> combatantDetails;

                IInternalBuilder IInternalBuilder.SetCallSign(PhalanxCallSign callSign)
                {
                    this.callSign = callSign;
                    return this;
                }

                IInternalBuilder IInternalBuilder.SetCombatantDetails(IList<ICombatantDetails> combatantDetails)
                {
                    this.combatantDetails = new List<ICombatantDetails>(combatantDetails);
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