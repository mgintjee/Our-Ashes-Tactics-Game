using System;
using System.Collections.Generic;

/// <summary>
/// Todo
/// </summary>
public class TalonCombatOrderReport
{
    #region Private Fields

    private readonly List<WeaponCombatOrderReport> weaponCombatOrderReportList = new List<WeaponCombatOrderReport>();

    #endregion Private Fields

    #region Private Constructors

    private TalonCombatOrderReport(List<WeaponCombatOrderReport> weaponCombatOrderReportList)
    {
        this.weaponCombatOrderReportList = new List<WeaponCombatOrderReport>(weaponCombatOrderReportList);
    }

    #endregion Private Constructors

    #region Public Methods

    public List<WeaponCombatOrderReport> GetWeaponCombatOrderReportList()
    {
        return new List<WeaponCombatOrderReport>(this.weaponCombatOrderReportList);
    }

    public override string ToString()
    {
        return this.GetType() + ": " +
            "\n\t>weaponCombatOrderReportList= [\n\t>" + string.Join("\n\t>", this.GetWeaponCombatOrderReportList()) + "\n]";
    }

    #endregion Public Methods

    #region Public Classes

    public class Builder
    {
        #region Private Fields

        private List<WeaponCombatOrderReport> weaponCombatOrderReportList = new List<WeaponCombatOrderReport>();

        #endregion Private Fields

        #region Public Methods

        public TalonCombatOrderReport Build()
        {
            HashSet<string> invalidReasons = this.IsValid();
            // Check that the set parameters are valid
            if (invalidReasons.Count == 0)
            {
                // Instantiate a new Report
                return new TalonCombatOrderReport(this.weaponCombatOrderReportList);
            }
            else
            {
                throw new ArgumentException("Unable to construct " + this.GetType() + ". Invalid Parameters." +
                    string.Join("\n\t>", invalidReasons));
            }
        }

        public Builder SetWeaponCombatOrderReportList(List<WeaponCombatOrderReport> weaponCombatOrderReportList)
        {
            this.weaponCombatOrderReportList = new List<WeaponCombatOrderReport>(weaponCombatOrderReportList);
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
            // Check that weaponCombatOrderReportList has been set
            if (this.weaponCombatOrderReportList == null)
            {
                argumentExceptionSet.Add("weaponCombatOrderReportList has not been set");
            }
            // Check that weaponCombatOrderReportList is valid
            if (this.weaponCombatOrderReportList != null &&
                this.weaponCombatOrderReportList.Count < 1 &&
                this.weaponCombatOrderReportList.Contains(null))
            {
                argumentExceptionSet.Add("weaponCombatOrderReportList is not valid");
            }
            return argumentExceptionSet;
        }

        #endregion Private Methods
    }

    #endregion Public Classes
}