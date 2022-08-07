using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Utils.Strings;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Models;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Icons.Details.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Details.Impls
{
    public struct UnitDetailsImpl
        : IUnitDetails
    {
        private readonly UnitID unitID;
        private readonly ModelID modelID;
        private readonly ILoadoutDetails loadoutDetails;
        private readonly IIconDetails iconDetails;

        private UnitDetailsImpl(UnitID unitID, ModelID modelID, ILoadoutDetails loadoutDetails, IIconDetails iconDetails)
        {
            this.unitID = unitID;
            this.modelID = modelID;
            this.loadoutDetails = loadoutDetails;
            this.iconDetails = iconDetails;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}" +
                "\n{3}",
                StringUtils.Format(unitID),
                StringUtils.Format(modelID),
                StringUtils.Format(iconDetails),
                StringUtils.Format(loadoutDetails));
        }

        /// <inheritdoc/>
        public UnitID GetUnitID()
        {
            return unitID;
        }

        /// <inheritdoc/>
        public ModelID GetModelID()
        {
            return modelID;
        }

        /// <inheritdoc/>
        public ILoadoutDetails GetLoadoutDetails()
        {
            return loadoutDetails;
        }

        /// <inheritdoc/>
        public IIconDetails GetIconDetails()
        {
            return iconDetails;
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

                IInternalBuilder SetIconDetails(IIconDetails details);

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
                private IIconDetails iconDetails;

                /// <inheritdoc/>
                public IInternalBuilder SetModelID(ModelID id)
                {
                    modelID = id;
                    return this;
                }

                /// <inheritdoc/>
                public IInternalBuilder SetLoadoutDetails(ILoadoutDetails details)
                {
                    loadoutDetails = details;
                    return this;
                }

                /// <inheritdoc/>
                public IInternalBuilder SetUnitID(UnitID id)
                {
                    unitID = id;
                    return this;
                }

                public IInternalBuilder SetIconDetails(IIconDetails details)
                {
                    iconDetails = details;
                    return this;
                }

                /// <inheritdoc/>
                protected override IUnitDetails BuildObj()
                {
                    return new UnitDetailsImpl(unitID, modelID, loadoutDetails, iconDetails);
                }

                /// <inheritdoc/>
                protected override void Validate(IList<string> invalidReasons)
                {
                    this.Validate(invalidReasons, unitID);
                    this.Validate(invalidReasons, modelID);
                    this.Validate(invalidReasons, iconDetails);
                    this.Validate(invalidReasons, loadoutDetails);
                }
            }
        }
    }
}