using System;
using System.Collections.Generic;

/// <summary>
/// Report to display the construction information for a specific Talon
/// </summary>
public class TalonConstructionReport
{
    #region Private Fields

    private readonly TalonIdentificationReport talonIdentificationReport = null;
    private readonly TalonPaintSchemeReport talonPaintSchemeReport = null;
    private readonly List<WeaponIdEnum> weaponIdList = null;

    #endregion Private Fields

    #region Private Constructors

    private TalonConstructionReport(TalonIdentificationReport talonIdentificationReport,
        TalonPaintSchemeReport talonPaintSchemeReport, List<WeaponIdEnum> weaponIdList)
    {
        this.talonIdentificationReport = talonIdentificationReport;
        this.talonPaintSchemeReport = talonPaintSchemeReport;
        this.weaponIdList = weaponIdList;
    }

    #endregion Private Constructors

    #region Public Methods

    public TalonIdentificationReport GetTalonIdentificationReport()
    {
        return this.talonIdentificationReport;
    }

    public TalonPaintSchemeReport GetTalonPaintSchemeReport()
    {
        return this.talonPaintSchemeReport;
    }

    public List<WeaponIdEnum> GetWeaponIdList()
    {
        return new List<WeaponIdEnum>(this.weaponIdList);
    }

    #endregion Public Methods

    #region Public Classes

    public class Builder
    {
        #region Private Fields

        private TalonIdentificationReport talonIdentificationReport = null;
        private TalonPaintSchemeReport talonPaintSchemeReport = null;
        private List<WeaponIdEnum> weaponIdList = null;

        #endregion Private Fields

        #region Public Methods

        public TalonConstructionReport Build()
        {
            HashSet<string> invalidReasons = this.IsValid();
            // Check that the set parameters are valid
            if (invalidReasons.Count == 0)
            {
                // Instantiate a new Report
                return new TalonConstructionReport(this.talonIdentificationReport, this.talonPaintSchemeReport, this.weaponIdList);
            }
            else
            {
                throw new ArgumentException("Unable to construct " + this.GetType() + ". Invalid Parameters." +
                    string.Join("\n", invalidReasons));
            }
        }

        public Builder SetTalonIdentificationReport(TalonIdentificationReport talonIdentificationReport)
        {
            this.talonIdentificationReport = talonIdentificationReport;
            return this;
        }

        public Builder SetTalonPaintSchemeReport(TalonPaintSchemeReport talonPaintSchemeReport)
        {
            this.talonPaintSchemeReport = talonPaintSchemeReport;
            return this;
        }

        public Builder SetWeaponIdList(List<WeaponIdEnum> weaponIdList)
        {
            this.weaponIdList = new List<WeaponIdEnum>(weaponIdList);
            return this;
        }

        #endregion Public Methods

        #region Private Methods

        private HashSet<string> IsValid()
        {
            // Default an empty Set: String
            HashSet<string> argumentExceptionSet = new HashSet<string>();
            // Check that talonIdentificationReport has been set
            if (this.talonIdentificationReport == null)
            {
                argumentExceptionSet.Add(typeof(TalonIdentificationReport) + " has not been set");
            }
            // Check that talonPaintSchemeReport has been set
            if (this.talonPaintSchemeReport == null)
            {
                argumentExceptionSet.Add(typeof(TalonPaintSchemeReport) + " has not been set");
            }
            // Check that weaponIdList has been set
            if (this.weaponIdList == null)
            {
                argumentExceptionSet.Add("weaponIdList has not been set");
            }
            return argumentExceptionSet;
        }

        #endregion Private Methods
    }

    #endregion Public Classes
}