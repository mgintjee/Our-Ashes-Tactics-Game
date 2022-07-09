using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Utils.Strings;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Models;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Details.Impls
{
    public struct UnitDetailsImpl
        : IUnitDetails
    {
        // Todo
        private readonly UnitID unitID;

        // Todo
        private readonly ModelID modelID;

        // Todo
        private readonly ILoadoutDetails loadoutDetails;

        private UnitDetailsImpl(UnitID unitID, ModelID modelID, ILoadoutDetails loadoutDetails)
        {
            this.unitID = unitID;
            this.modelID = modelID;
            this.loadoutDetails = loadoutDetails;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}" +
                "\n{1}" +
                "\n{2}",
                StringUtils.Format(this.unitID),
                StringUtils.Format(this.modelID),
                StringUtils.Format(this.loadoutDetails));
        }

        /// <inheritdoc/>
        UnitID IUnitDetails.GetUnitID()
        {
            return this.unitID;
        }

        /// <inheritdoc/>
        ModelID IUnitDetails.GetModelID()
        {
            return this.modelID;
        }

        /// <inheritdoc/>
        ILoadoutDetails IUnitDetails.GetLoadoutDetails()
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
                : IBuilder<IUnitDetails>
            {
                IInternalBuilder SetUnitID(UnitID id);

                IInternalBuilder SetModelID(ModelID id);

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
                : AbstractBuilder<IUnitDetails>, IInternalBuilder
            {
                private UnitID unitID;
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
                IInternalBuilder IInternalBuilder.SetUnitID(UnitID id)
                {
                    this.unitID = id;
                    return this;
                }

                /// <inheritdoc/>
                protected override IUnitDetails BuildObj()
                {
                    return new UnitDetailsImpl(this.unitID,
                        this.modelID, this.loadoutDetails);
                }

                /// <inheritdoc/>
                protected override void Validate(IList<string> invalidReasons)
                {
                    this.Validate(invalidReasons, this.unitID);
                    this.Validate(invalidReasons, this.modelID);
                    this.Validate(invalidReasons, this.loadoutDetails);
                }
            }
        }
    }
}