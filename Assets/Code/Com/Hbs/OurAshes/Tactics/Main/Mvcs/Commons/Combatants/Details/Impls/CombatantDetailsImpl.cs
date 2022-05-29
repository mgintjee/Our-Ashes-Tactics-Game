using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Utils.Strings;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Models;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Details.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Details.Impls
{
    public struct CombatantDetailsImpl
        : ICombatantDetails
    {
        // Todo
        private readonly CombatantID id;

        // Todo
        private readonly ModelID modelID;

        // Todo
        private readonly ILoadoutDetails loadoutDetails;

        private CombatantDetailsImpl(CombatantID id, ModelID modelID, ILoadoutDetails loadoutDetails)
        {
            this.id = id;
            this.modelID = modelID;
            this.loadoutDetails = loadoutDetails;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("\n{0}" +
                "\n{1}" +
                "\n{2}",
                StringUtils.Format(this.id),
                StringUtils.Format(this.modelID),
                StringUtils.Format(this.loadoutDetails));
        }

        /// <inheritdoc/>
        CombatantID ICombatantDetails.GetID()
        {
            return this.id;
        }

        /// <inheritdoc/>
        ModelID ICombatantDetails.GetModelID()
        {
            return this.modelID;
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

                IInternalBuilder SetModelID(ModelID modelID);

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
                private ModelID modelID;
                private ILoadoutDetails loadoutDetails;

                /// <inheritdoc/>
                IInternalBuilder IInternalBuilder.SetModelID(ModelID id)
                {
                    this.modelID = id;
                    return this;
                }

                /// <inheritdoc/>
                IInternalBuilder IInternalBuilder.SetLoadoutDetails(ILoadoutDetails details)
                {
                    this.loadoutDetails = details;
                    return this;
                }

                /// <inheritdoc/>
                IInternalBuilder IInternalBuilder.SetCombatantID(CombatantID id)
                {
                    this.combatantID = id;
                    return this;
                }

                /// <inheritdoc/>
                protected override ICombatantDetails BuildObj()
                {
                    return new CombatantDetailsImpl(this.combatantID,
                        this.modelID, this.loadoutDetails);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, this.combatantID);
                    this.Validate(invalidReasons, this.modelID);
                    this.Validate(invalidReasons, this.loadoutDetails);
                }
            }
        }
    }
}