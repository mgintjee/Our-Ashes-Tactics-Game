using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Utils.Strings;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Phalanxes.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Phalanxes.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Icons.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Patterns.Details.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Phalanxes.Details.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct PhalanxDetailsImpl
        : IPhalanxDetails
    {
        private readonly PhalanxID phalanxID;
        private readonly IList<UnitID> unitIDs;
        private readonly IIconDetails iconDetails;
        private readonly IPatternDetails patternDetails;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="phalanxID">     </param>
        /// <param name="unitIDs">       </param>
        /// <param name="iconDetails">   </param>
        /// <param name="patternDetails"></param>
        private PhalanxDetailsImpl(PhalanxID phalanxID, IList<UnitID> unitIDs, IIconDetails iconDetails, IPatternDetails patternDetails)
        {
            this.phalanxID = phalanxID;
            this.unitIDs = unitIDs;
            this.iconDetails = iconDetails;
            this.patternDetails = patternDetails;
        }

        /// <inheritdoc/>
        public IIconDetails GetIconDetails()
        {
            return iconDetails;
        }

        /// <inheritdoc/>
        public IPatternDetails GetPatternDetails()
        {
            return patternDetails;
        }

        /// <inheritdoc/>
        public PhalanxID GetPhalanxID()
        {
            return phalanxID;
        }

        /// <inheritdoc/>
        public IList<UnitID> GetUnitIDs()
        {
            return new List<UnitID>(unitIDs);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}" +
                "\nUnitDetails:{3}",
                StringUtils.Format(phalanxID),
                StringUtils.Format(iconDetails),
                StringUtils.Format(patternDetails),
                StringUtils.Format(unitIDs));
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
                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="id"></param>
                /// <returns></returns>
                IInternalBuilder SetPhalanxID(PhalanxID id);

                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="details"></param>
                /// <returns></returns>
                IInternalBuilder SetIconDetails(IIconDetails details);

                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="details"></param>
                /// <returns></returns>
                IInternalBuilder SetPatternDetails(IPatternDetails details);

                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="ids"></param>
                /// <returns></returns>
                IInternalBuilder SetUnitIDs(IList<UnitID> ids);
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
                private PhalanxID phalanxID;
                private IIconDetails iconDetails;
                private IPatternDetails patternDetails;
                private IList<UnitID> unitIDs = new List<UnitID>();

                /// <inheritdoc/>
                public IInternalBuilder SetPhalanxID(PhalanxID id)
                {
                    this.phalanxID = id;
                    return this;
                }

                /// <inheritdoc/>
                public IInternalBuilder SetIconDetails(IIconDetails details)
                {
                    iconDetails = details;
                    return this;
                }

                /// <inheritdoc/>
                public IInternalBuilder SetPatternDetails(IPatternDetails details)
                {
                    patternDetails = details;
                    return this;
                }

                /// <inheritdoc/>
                public IInternalBuilder SetUnitIDs(IList<UnitID> ids)
                {
                    this.unitIDs = new List<UnitID>(ids);
                    return this;
                }

                /// <inheritdoc/>
                protected override IPhalanxDetails BuildObj()
                {
                    return new PhalanxDetailsImpl(phalanxID, unitIDs, iconDetails, patternDetails);
                }

                /// <inheritdoc/>
                protected override void Validate(IList<string> invalidReasons)
                {
                    this.Validate(invalidReasons, phalanxID);
                    this.Validate(invalidReasons, iconDetails);
                    this.Validate(invalidReasons, patternDetails);
                }
            }
        }
    }
}