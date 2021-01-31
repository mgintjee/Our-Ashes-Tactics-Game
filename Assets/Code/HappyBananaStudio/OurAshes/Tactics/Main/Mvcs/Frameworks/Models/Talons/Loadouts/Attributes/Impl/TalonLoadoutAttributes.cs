namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Attributes.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Armors.Attributes.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Attributes.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Engines.Attributes.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Mounts.Common.Enums;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public struct TalonLoadoutAttributes
        : ITalonLoadoutAttributes
    {
        // Todo
        private readonly IArmorAttributes armorAttributes;

        // Todo
        private readonly IEngineAttributes engineAttributes;

        // Todo
        private readonly IList<MountSize> mountSizeList;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="armorAttributes"></param>
        /// <param name="engineAttributes"></param>
        /// <param name="mountSizeList"></param>
        private TalonLoadoutAttributes(IArmorAttributes armorAttributes,
            IEngineAttributes engineAttributes, IList<MountSize> mountSizeList)
        {
            this.armorAttributes = armorAttributes;
            this.engineAttributes = engineAttributes;
            this.mountSizeList = new List<MountSize>(mountSizeList);
        }

        /// <inheritdoc/>
        IArmorAttributes ITalonLoadoutAttributes.GetArmorAttributes()
        {
            return this.armorAttributes;
        }

        /// <inheritdoc/>
        IEngineAttributes ITalonLoadoutAttributes.GetEngineAttributes()
        {
            return this.engineAttributes;
        }

        /// <inheritdoc/>
        IList<MountSize> ITalonLoadoutAttributes.GetMountSizeList()
        {
            return new List<MountSize>(this.mountSizeList);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private IArmorAttributes armorAttributes = null;

            // Todo
            private IEngineAttributes engineAttributes = null;

            // Todo
            private IList<MountSize> mountSizeList = null;

            /// <summary>
            /// Build the report implementation with the set parameters
            /// </summary>
            /// <returns>
            /// The report interface
            /// </returns>
            public ITalonLoadoutAttributes Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new TalonLoadoutAttributes(this.armorAttributes,
                        this.engineAttributes, this.mountSizeList);
                }
                else
                {
                    throw ExceptionUtil.Arguments.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="armorAttributes"></param>
            /// <returns></returns>
            public Builder SetArmorAttributes(IArmorAttributes armorAttributes)
            {
                this.armorAttributes = armorAttributes;
                return this;
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="engineAttributes"></param>
            /// <returns></returns>
            public Builder SetEngineAttributes(IEngineAttributes engineAttributes)
            {
                this.engineAttributes = engineAttributes;
                return this;
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="mountSizeList"></param>
            /// <returns></returns>
            public Builder SetMountSizeList(IList<MountSize> mountSizeList)
            {
                this.mountSizeList = new List<MountSize>(mountSizeList);
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
                // Check that armorAttributes has been set
                if (this.armorAttributes == null)
                {
                    argumentExceptionSet.Add(typeof(IArmorAttributes) + " has not been set");
                }
                // Check that engineAttributes has been set
                if (this.engineAttributes == null)
                {
                    argumentExceptionSet.Add(typeof(IEngineAttributes) + " has not been set");
                }
                // Check that mountSizeList has been set
                if (this.mountSizeList == null)
                {
                    argumentExceptionSet.Add("List:" + typeof(MountSize) + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}