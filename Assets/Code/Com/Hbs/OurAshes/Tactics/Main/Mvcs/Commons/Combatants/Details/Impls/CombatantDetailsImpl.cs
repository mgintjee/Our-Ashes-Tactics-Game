using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Utils.Strings;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.CallSigns;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Details.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Details.Impls
{
    public struct CombatantDetailsImpl
        : ICombatantDetails
    {
        // Todo
        private readonly CombatantCallSign callSign;

        // Todo
        private readonly CombatantID combatantID;

        // Todo
        private readonly ILoadoutDetails loadoutDetails;

        private CombatantDetailsImpl(CombatantCallSign callSign, CombatantID combatantID, ILoadoutDetails loadoutDetails)
        {
            this.callSign = callSign;
            this.combatantID = combatantID;
            this.loadoutDetails = loadoutDetails;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("\n{0}" +
                "\n{1}" +
                "\n{2}",
                StringUtils.Format(this.callSign),
                StringUtils.Format(this.combatantID),
                StringUtils.Format(this.loadoutDetails));
        }

        /// <inheritdoc/>
        CombatantCallSign ICombatantDetails.GetCallSign()
        {
            return this.callSign;
        }

        /// <inheritdoc/>
        CombatantID ICombatantDetails.GetCombatantID()
        {
            return this.combatantID;
        }

        /// <inheritdoc/>
        ILoadoutDetails ICombatantDetails.GetLoadoutDetails()
        {
            return this.loadoutDetails;
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
                : IBuilder<ICombatantDetails>
            {
                IInternalBuilder SetCallSign(CombatantCallSign callSign);

                IInternalBuilder SetCombatantID(CombatantID id);

                IInternalBuilder SetLoadoutDetails(ILoadoutDetails details);
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
                : AbstractBuilder<ICombatantDetails>, IInternalBuilder
            {
                private CombatantCallSign callSign;
                private CombatantID combatantID;
                private ILoadoutDetails loadoutDetails;

                /// <inheritdoc/>
                IInternalBuilder IInternalBuilder.SetCombatantID(CombatantID id)
                {
                    this.combatantID = id;
                    return this;
                }

                /// <inheritdoc/>
                IInternalBuilder IInternalBuilder.SetLoadoutDetails(ILoadoutDetails details)
                {
                    this.loadoutDetails = details;
                    return this;
                }

                /// <inheritdoc/>
                IInternalBuilder IInternalBuilder.SetCallSign(CombatantCallSign callSign)
                {
                    this.callSign = callSign;
                    return this;
                }

                /// <inheritdoc/>
                protected override ICombatantDetails BuildObj()
                {
                    return new CombatantDetailsImpl(this.callSign,
                        this.combatantID, this.loadoutDetails);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, this.callSign);
                    this.Validate(invalidReasons, this.combatantID);
                    this.Validate(invalidReasons, this.loadoutDetails);
                }
            }
        }
    }
}