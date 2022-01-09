using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Details.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Details.Impls
{
    public struct CombatantDetailsImpl
        : ICombatantDetails
    {
        private readonly CombatantID combatantID;
        private readonly ILoadoutDetails loadoutDetails;

        private CombatantDetailsImpl(CombatantID combatantID, ILoadoutDetails loadoutDetails)
        {
            this.combatantID = combatantID;
            this.loadoutDetails = loadoutDetails;
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
                protected override ICombatantDetails BuildObj()
                {
                    return new CombatantDetailsImpl(this.combatantID, this.loadoutDetails);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, combatantID);
                    this.Validate(invalidReasons, loadoutDetails);
                }
            }
        }
    }
}