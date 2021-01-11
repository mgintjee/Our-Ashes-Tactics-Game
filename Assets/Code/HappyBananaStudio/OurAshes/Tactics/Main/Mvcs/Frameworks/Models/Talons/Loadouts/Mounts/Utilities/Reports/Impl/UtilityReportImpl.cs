namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Mounts.Utilities.Reports.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Common.Attributes.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Common.Attributes.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Common.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Common.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Mounts.Common.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Mounts.Common.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Mounts.Utilities.Constants;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Mounts.Utilities.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Mounts.Utilities.Reports.Api;
    using HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public struct UtilityReportImpl
        : IUtilityReport
    {
        // Todo
        private readonly UtilityId utilityId;

        // Todo
        private readonly UtilityType utilityType;

        // Todo
        private readonly LoadoutRarity loadoutRarity;

        // Todo
        private readonly MountSize mountSize;

        // Todo
        private readonly ILoadoutAttributes loadoutAttributes;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="utilityId"></param>
        private UtilityReportImpl(UtilityId utilityId)
        {
            this.utilityId = utilityId;
            this.loadoutRarity = UtilityRarityConstants.GetLoadoutRarity(this.utilityId);
            this.utilityType = UtilityTypeConstants.GetUtilityType(this.utilityId);
            this.mountSize = UtilityMountSizeConstants.GetMountSize(this.utilityId);
            ISet<ILoadoutAttributes> loadoutAttributesSet = new HashSet<ILoadoutAttributes>()
            {
                UtilityIdConstants.GetLoadoutAttributes(this.utilityId)
            };
            this.loadoutAttributes = new LoadoutAttributesImpl.Builder().Build(loadoutAttributesSet);
        }

        /// <inheritdoc/>
        ILoadoutAttributes ILoadoutReport.GetLoadoutAttributes()
        {
            return this.loadoutAttributes;
        }

        /// <inheritdoc/>
        LoadoutRarity ILoadoutReport.GetLoadoutRarity()
        {
            return this.loadoutRarity;
        }

        /// <inheritdoc/>
        MountSize IMountReport.GetMountSize()
        {
            return this.mountSize;
        }

        /// <inheritdoc/>
        UtilityId IUtilityReport.GetUtilityId()
        {
            return this.utilityId;
        }

        /// <inheritdoc/>
        UtilityType IUtilityReport.GetUtilityType()
        {
            return this.utilityType;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private UtilityId utilityId = UtilityId.None;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IUtilityReport Build()
            {
                // Collect the invalid reasons to be built
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new UtilityReportImpl(this.utilityId);
                }
                else
                {
                    throw ExceptionUtil.Argument.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="utilityId"></param>
            public Builder SetUtilityId(UtilityId utilityId)
            {
                this.utilityId = utilityId;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns>
            /// </returns>
            private ISet<string> IsInvalid()
            {
                // Default an empty Set: String
                ISet<string> argumentExceptionSet = new HashSet<string>();
                // Check that utilityId has been set
                if (this.utilityId == UtilityId.None)
                {
                    argumentExceptionSet.Add(typeof(UtilityId).Name + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}