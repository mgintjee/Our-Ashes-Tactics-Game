using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Common.Attributes.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Common.Attributes.Impl;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Common.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Common.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Mounts.Common.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Mounts.Common.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Mounts.Utilities.Constants;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Mounts.Utilities.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Mounts.Utilities.Reports.Api;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Mounts.Utilities.Reports.Impl
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct UtilityReport
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
        private UtilityReport(UtilityId utilityId)
        {
            this.utilityId = utilityId;
            this.loadoutRarity = UtilityRarityConstants.GetLoadoutRarity(this.utilityId);
            this.utilityType = UtilityTypeConstants.GetUtilityType(this.utilityId);
            this.mountSize = UtilityMountSizeConstants.GetMountSize(this.utilityId);
            ISet<ILoadoutAttributes> loadoutAttributesSet = new HashSet<ILoadoutAttributes>()
            {
                UtilityIdConstants.GetLoadoutAttributes(this.utilityId)
            };
            this.loadoutAttributes = new LoadoutAttributes.Builder().Build(loadoutAttributesSet);
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

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: {1}={2}, {3}={4}, {5}={6}, " +
                "\n\t>{7}",
                this.GetType().Name, typeof(UtilityId).Name, this.utilityId,
                typeof(LoadoutRarity).Name, this.loadoutRarity,
                typeof(MountSize).Name, this.mountSize, this.loadoutAttributes);
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
                    return new UtilityReport(this.utilityId);
                }
                else
                {
                    throw ExceptionUtil.Arguments.Build("Unable to construct ?. Invalid Parameters. ?",
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