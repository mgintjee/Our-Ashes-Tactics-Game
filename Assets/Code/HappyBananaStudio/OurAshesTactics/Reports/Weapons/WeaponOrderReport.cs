/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Weapons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Exceptions;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Reports.Weapons
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct WeaponOrderReport
        : IWeaponOrderReport
    {
        // Todo
        private readonly int shotsThatHit;

        // Todo
        private readonly IWeaponInformationReport weaponInformationReport;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="shotsThatHit">
        /// </param>
        /// <param name="weaponInformationReport">
        /// </param>
        private WeaponOrderReport(int shotsThatHit, IWeaponInformationReport weaponInformationReport)
        {
            this.shotsThatHit = shotsThatHit;
            this.weaponInformationReport = weaponInformationReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public int GetShotsThatHit()
        {
            return this.shotsThatHit;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public IWeaponInformationReport GetWeaponInformationReport()
        {
            return this.weaponInformationReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public override string ToString()
        {
            return this.GetType().Name + ":" +
                "\n\t>Shots that Hit= " + this.GetShotsThatHit() +
                "\n\t>" + typeof(IWeaponInformationReport).Name + "= " + this.GetWeaponInformationReport();
        }

        /// <summary>
        /// Builder class for this report
        /// </summary>
        public class Builder
        {
            // Todo
            private bool setShotsThatHit = false;

            // Todo
            private int shotsThatHit;

            // Todo
            private IWeaponInformationReport weaponInformationReport = null;

            /// <summary>
            /// Build the report with the set parameters
            /// </summary>
            /// <returns>
            /// The report interface
            /// </returns>
            public IWeaponOrderReport Build()
            {
                HashSet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new WeaponOrderReport(this.shotsThatHit, this.weaponInformationReport);
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Set the value of the int shotsThatHit
            /// </summary>
            /// <param name="shotsThatHit">
            /// The int shotsThatHit to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetShotsThatHit(int shotsThatHit)
            {
                this.shotsThatHit = shotsThatHit;
                this.setShotsThatHit = true;
                return this;
            }

            /// <summary>
            /// Set the value of the WeaponInformationReport
            /// </summary>
            /// <param name="weaponInformationReport">
            /// The WeaponInformationReport to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetWeaponInformationReport(IWeaponInformationReport weaponInformationReport)
            {
                this.weaponInformationReport = weaponInformationReport;
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
                // Check that shotsThatHit has been set
                if (!this.setShotsThatHit)
                {
                    argumentExceptionSet.Add("shotsThatHit has not been set");
                }
                // Check that weaponInformationReport has been set
                if (this.weaponInformationReport == null)
                {
                    argumentExceptionSet.Add(typeof(IWeaponInformationReport).Name + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}