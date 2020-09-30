/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Attributes.Api.Hoplites;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Hoplites;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Enums;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Exceptions;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Reports.Hoplites
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct HopliteReport
        : IHopliteReport
    {
        // Todo
        private readonly ControllerIdEnum controllerId;

        // Todo
        private readonly IHopliteAttributes hopliteAttributes;

        private HopliteReport(ControllerIdEnum controllerId, IHopliteAttributes hopliteAttributes)
        {
            this.controllerId = controllerId;
            this.hopliteAttributes = hopliteAttributes;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public ControllerIdEnum GetControllerId()
        {
            return this.controllerId;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public IHopliteAttributes GetHopliteAttributes()
        {
            return this.hopliteAttributes;
        }

        public override string ToString()
        {
            return this.GetType() + ":" +
                "\n\t>" + typeof(ControllerIdEnum).Name + ":" + this.GetControllerId() +
                "\n\t>" + this.GetHopliteAttributes();
        }

        /// <summary>
        /// Builder class for this report
        /// </summary>
        public class Builder
        {
            // Todo
            private ControllerIdEnum controllerId;

            // Todo
            private IHopliteAttributes hopliteAttributes;

            /// <summary>
            /// Build the HopliteReport with the set parameters
            /// </summary>
            /// <returns>
            /// The IHopliteReport
            /// </returns>
            public IHopliteReport Build()
            {
                HashSet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new HopliteReport(this.controllerId, this.hopliteAttributes);
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Set the value of the ControllerIdEnum
            /// </summary>
            /// <param name="controllerId">
            /// The ControllerIdEnum to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetControllerId(ControllerIdEnum controllerId)
            {
                this.controllerId = controllerId;
                return this;
            }

            /// <summary>
            /// Set the value of the IHopliteAttributes
            /// </summary>
            /// <param name="hopliteAttributes">
            /// The IHopliteAttributes to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetHopliteAttributes(IHopliteAttributes hopliteAttributes)
            {
                this.hopliteAttributes = hopliteAttributes;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns>
            /// </returns>
            private HashSet<string> IsInvalid()
            {
                // Default an empty Set: String
                HashSet<string> argumentExceptionSet = new HashSet<string>();
                // Check that controllerId has been set
                if (this.controllerId == ControllerIdEnum.None)
                {
                    argumentExceptionSet.Add(typeof(ControllerIdEnum).Name + " has not been set");
                }
                // Check that hopliteAttributes has been set
                if (this.hopliteAttributes == null)
                {
                    argumentExceptionSet.Add(typeof(IHopliteAttributes).Name + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}