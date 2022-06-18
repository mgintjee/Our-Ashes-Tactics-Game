using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Utils.Strings;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Details.Inters;
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
        private readonly IList<ICombatantDetails> combatantDetails;

        private PhalanxDetailsImpl(PhalanxID id, IList<ICombatantDetails> combatantDetails)
        {
            this.id = id;
            this.combatantDetails = combatantDetails;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("\n{0}" +
                "\n{1}",
                StringUtils.Format(this.id),
                StringUtils.Format(this.combatantDetails));
        }

        PhalanxID IPhalanxDetails.GetID()
        {
            return id;
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
                IInternalBuilder SetID(PhalanxID id);

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
                private PhalanxID id;
                private IList<ICombatantDetails> combatantDetails;

                IInternalBuilder IInternalBuilder.SetID(PhalanxID id)
                {
                    this.id = id;
                    return this;
                }

                IInternalBuilder IInternalBuilder.SetCombatantDetails(IList<ICombatantDetails> combatantDetails)
                {
                    this.combatantDetails = new List<ICombatantDetails>(combatantDetails);
                    return this;
                }

                protected override IPhalanxDetails BuildObj()
                {
                    return new PhalanxDetailsImpl(id, combatantDetails);
                }
            }
        }
    }
}