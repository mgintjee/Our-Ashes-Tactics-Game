using System;
using System.Collections.Generic;

/// <summary>
/// Report to display all of the information for a specific Talon
/// </summary>
public class TalonInformationReport
{
    #region Private Fields

    // Todo
    private readonly HashSet<TalonActionOrderReport> possibleTalonActionOrderReportSet;

    // Todo
    private readonly TalonAttributesReport talonAttributesReport;

    // Todo
    private readonly TalonIdentificationReport talonIdentificationReport;

    #endregion Private Fields

    #region Private Constructors

    /// <summary>
    /// Private constructor to force using the Builder
    /// </summary>
    /// <param name="talonAttributesReport">            The TalonAttributesReport to set</param>
    /// <param name="talonIdentificationReport">        The TalonIdentificationReport to set</param>
    /// <param name="possibleTalonActionOrderReportSet">The Set: TalonActionOrderReport to set</param>
    private TalonInformationReport(TalonAttributesReport talonAttributesReport,
        TalonIdentificationReport talonIdentificationReport,
        HashSet<TalonActionOrderReport> possibleTalonActionOrderReportSet)
    {
        this.talonAttributesReport = talonAttributesReport;
        this.talonIdentificationReport = talonIdentificationReport;
        this.possibleTalonActionOrderReportSet = possibleTalonActionOrderReportSet;
    }

    #endregion Private Constructors

    #region Public Methods

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public HashSet<TalonActionOrderReport> GetPossibleTalonActionOrderReportSet()
    {
        return this.possibleTalonActionOrderReportSet;
    }

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public TalonAttributesReport GetTalonAttributesReport()
    {
        return this.talonAttributesReport;
    }

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public TalonIdentificationReport GetTalonIdentificationReport()
    {
        return this.talonIdentificationReport;
    }

    public override string ToString()
    {
        int fireActionCount = 0;
        int moveActionCount = 0;
        int waitActionCount = 0;
        foreach (TalonActionOrderReport talonActionOrderReport in this.GetPossibleTalonActionOrderReportSet())
        {
            switch (talonActionOrderReport.GetTalonActionType())
            {
                case TalonActionTypeEnum.Fire:
                    fireActionCount++;
                    break;

                case TalonActionTypeEnum.Move:
                    moveActionCount++;
                    break;

                case TalonActionTypeEnum.Wait:
                    waitActionCount++;
                    break;
            }
        }
        return this.GetType() + ":" +
            "\n\t>" + this.GetTalonAttributesReport() +
            "\n\t>" + this.GetTalonIdentificationReport() +
            "\n\t>possibleTalonActionOrderReportSet=[" +
            "\n\t\t> Fire Actions= " + fireActionCount +
            "\n\t\t> Move Actions= " + moveActionCount +
            "\n\t\t> Wait Actions= " + waitActionCount +
            "\n]";
    }

    #endregion Public Methods

    #region Public Classes

    /// <summary>
    /// Builder class for this report
    /// </summary>
    public class Builder
    {
        #region Private Fields

        // Todo
        private HashSet<TalonActionOrderReport> possibleTalonActionOrderReportSet = null;

        // Todo
        private TalonAttributesReport talonAttributesReport = null;

        // Todo
        private TalonIdentificationReport talonIdentificationReport = null;

        #endregion Private Fields

        #region Public Methods

        /// <summary>
        /// Build the TalonInformationReport with the set parameters
        /// </summary>
        /// <returns>The TalonInformationReport</returns>
        public TalonInformationReport Build()
        {
            HashSet<string> invalidReasons = this.IsValid();
            // Check that the set parameters are valid
            if (invalidReasons.Count == 0)
            {
                // Instantiate a new Report
                return new TalonInformationReport(this.talonAttributesReport, this.talonIdentificationReport,
                    this.possibleTalonActionOrderReportSet);
            }
            else
            {
                throw new ArgumentException("Unable to construct " + this.GetType() + ". Invalid Parameters." +
                    string.Join("\n", invalidReasons));
            }
        }

        /// <summary>
        /// Set the value of the Set: TalonActionOrderReport
        /// </summary>
        /// <param name="possibleTalonActionOrderReportSet">
        /// The Set: TalonActionOrderReport to set
        /// </param>
        /// <returns>The Builder to continue building with</returns>
        public Builder SetPossibleTalonActionOrderReportSet(HashSet<TalonActionOrderReport> possibleTalonActionOrderReportSet)
        {
            this.possibleTalonActionOrderReportSet = possibleTalonActionOrderReportSet;
            return this;
        }

        /// <summary>
        /// Set the value of the TalonAttributesReport
        /// </summary>
        /// <param name="talonAttributesReport">The TalonAttributesReport to set</param>
        /// <returns>The Builder to continue building with</returns>
        public Builder SetTalonAttributesReport(TalonAttributesReport talonAttributesReport)
        {
            this.talonAttributesReport = talonAttributesReport;
            return this;
        }

        /// <summary>
        /// Set the value of the TalonIdentificationReport
        /// </summary>
        /// <param name="talonIdentificationReport">The TalonIdentificationReport to set</param>
        /// <returns>The Builder to continue building with</returns>
        public Builder SetTalonIdentifcationReport(TalonIdentificationReport talonIdentificationReport)
        {
            this.talonIdentificationReport = talonIdentificationReport;
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
            // Check that talonAttributesReport has been set
            if (this.talonAttributesReport == null)
            {
                argumentExceptionSet.Add(typeof(TalonAttributesReport) + " has not been set");
            }
            // Check that talonIdentificationReport has been set
            if (this.talonIdentificationReport == null)
            {
                argumentExceptionSet.Add(typeof(TalonIdentificationReport) + " has not been set");
            }
            // Check that possibleTalonActionOrderReportSet has been set
            if (this.possibleTalonActionOrderReportSet == null)
            {
                argumentExceptionSet.Add("possibleTalonActionOrderReportSet has not been set");
            }
            // Check that possibleTalonActionOrderReportSet is valid
            if (this.possibleTalonActionOrderReportSet != null &&
                this.possibleTalonActionOrderReportSet.Count == 0)
            {
                argumentExceptionSet.Add("possibleTalonActionOrderReportSet has is invalid");
            }
            return argumentExceptionSet;
        }

        #endregion Private Methods
    }

    #endregion Public Classes
}