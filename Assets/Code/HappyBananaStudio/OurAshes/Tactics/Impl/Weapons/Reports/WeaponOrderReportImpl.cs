

namespace HappyBananaStudio.OurAshes.Tactics.Impl.Weapons.Reports
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Weapons.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Exceptions;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public struct WeaponOrderReportImpl
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
        private WeaponOrderReportImpl(int shotsThatHit, IWeaponInformationReport weaponInformationReport)
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
            return this.GetType().Name + ": Shots that Hit= " + this.GetShotsThatHit() +
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
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new WeaponOrderReportImpl(this.shotsThatHit, this.weaponInformationReport);
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
            private ISet<string> IsInvalid()
            {
                // Default an empty Set: String
                ISet<string> argumentExceptionSet = new HashSet<string>();
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
