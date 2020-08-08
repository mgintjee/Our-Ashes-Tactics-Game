using System;
using System.Collections.Generic;

/// <summary>
/// Todo
/// </summary>
public class TalonCombatResultReport
{
    #region Private Fields

    private readonly bool isTargetDestroyed = false;
    private readonly TalonCombatOrderReport talonCombatOrderReport = null;
    private readonly List<WeaponCombatResultReport> weaponCombatResultReportList = new List<WeaponCombatResultReport>();

    #endregion Private Fields

    #region Private Constructors

    private TalonCombatResultReport(bool isTargetDestroyed, TalonCombatOrderReport talonCombatOrderReport, List<WeaponCombatResultReport> weaponCombatResultReportList)
    {
        this.isTargetDestroyed = isTargetDestroyed;
        this.talonCombatOrderReport = talonCombatOrderReport;
        this.weaponCombatResultReportList = new List<WeaponCombatResultReport>(weaponCombatResultReportList);
    }

    #endregion Private Constructors

    #region Public Methods

    public bool GetIsTargetDestroyed()
    {
        return this.isTargetDestroyed;
    }

    public TalonCombatOrderReport GetTalonCombatOrderReport()
    {
        return this.talonCombatOrderReport;
    }

    public List<WeaponCombatResultReport> GetWeaponCombatResultReportList()
    {
        return new List<WeaponCombatResultReport>(this.weaponCombatResultReportList);
    }

    #endregion Public Methods

    #region Public Classes

    public class Builder
    {
        #region Private Fields

        private bool isTargetDestroyed = false;
        private bool setIsTargetDestroyed = false;
        private TalonCombatOrderReport talonCombatOrderReport = null;
        private List<WeaponCombatResultReport> weaponCombatResultReportList = new List<WeaponCombatResultReport>();

        #endregion Private Fields

        #region Public Methods

        public TalonCombatResultReport Build()
        {
            HashSet<string> invalidReasons = this.IsValid();
            // Check that the set parameters are valid
            if (invalidReasons.Count == 0)
            {
                // Instantiate a new Report
                return new TalonCombatResultReport(this.isTargetDestroyed, this.talonCombatOrderReport, this.weaponCombatResultReportList);
            }
            else
            {
                throw new ArgumentException("Unable to construct " + this.GetType() + ". Invalid Parameters." +
                    string.Join("\n>", invalidReasons));
            }
        }

        public Builder SetIsTargetDestroyed(bool isTargetDestroyed)
        {
            this.setIsTargetDestroyed = true;
            this.isTargetDestroyed = isTargetDestroyed;
            return this;
        }

        public Builder SetTalonCombatOrderReport(TalonCombatOrderReport talonCombatOrderReport)
        {
            this.talonCombatOrderReport = talonCombatOrderReport;
            return this;
        }

        public Builder SetWeaponCombatResultReportList(List<WeaponCombatResultReport> weaponCombatResultReportList)
        {
            this.weaponCombatResultReportList = weaponCombatResultReportList;
            return this;
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        private HashSet<string> IsValid()
        {
            // Default an empty Set: String
            HashSet<string> argumentExceptionSet = new HashSet<string>();
            // Check that isTargetDestroyed has been set
            if (!this.setIsTargetDestroyed)
            {
                argumentExceptionSet.Add("isTargetDestroyed has not been set");
            }
            // Check that talonCombatOrderReport has been set
            if (this.talonCombatOrderReport == null)
            {
                argumentExceptionSet.Add(typeof(TalonCombatOrderReport) + " has not been set");
            }
            // Check that weaponCombatResultReportList has been set
            if (this.weaponCombatResultReportList == null)
            {
                argumentExceptionSet.Add("weaponCombatResultReportList has not been set");
            }
            // Check that weaponCombatResultReportList is valid
            if (this.weaponCombatResultReportList != null &&
                this.weaponCombatResultReportList.Count < 1)
            {
                argumentExceptionSet.Add("weaponCombatResultReportList is not valid");
            }
            return argumentExceptionSet;
        }

        #endregion Private Methods
    }

    #endregion Public Classes
}