using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Utils.Strings;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Units.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Units.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Units.Models;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Details.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Units.Details.Impls
{
    public struct UnitDetailsImpl
        : IUnitDetails
    {
        // Todo
        private readonly UnitID id;

        // Todo
        private readonly ModelID modelID;

        // Todo
        private readonly ILoadoutDetails loadoutDetails;

        private UnitDetailsImpl(UnitID id, ModelID modelID, ILoadoutDetails loadoutDetails)
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
        UnitID IUnitDetails.GetID()
        {
            return this.id;
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
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, this.unitID);
                    this.Validate(invalidReasons, this.modelID);
                    this.Validate(invalidReasons, this.loadoutDetails);
                }
            }
        }
    }
}