using System;
using System.Collections.Generic;

/// <summary>
/// Todo
/// </summary>
public class TalonTurnReport
{
    #region Private Fields

    private readonly int actionCounter = int.MinValue;
    private readonly MapInformationReport mapInformationReport = null;
    private readonly int phaseCounter = int.MinValue;
    private readonly TalonActionResultReport talonActionResultReport = null;
    private readonly TalonCombatResultReport talonCombatResultReport = null;

    #endregion Private Fields

    #region Private Constructors

    private TalonTurnReport(int phaseCounter, int actionCounter, TalonActionResultReport talonActionResultReport,
        TalonCombatResultReport talonCombatResultReport, MapInformationReport mapInformationReport)
    {
        this.phaseCounter = phaseCounter;
        this.actionCounter = actionCounter;
        this.talonActionResultReport = talonActionResultReport;
        this.talonCombatResultReport = talonCombatResultReport;
        this.mapInformationReport = mapInformationReport;
    }

    #endregion Private Constructors

    #region Public Methods

    public int GetActionCounter()
    {
        return this.actionCounter;
    }

    public MapInformationReport GetMapInformationReport()
    {
        return this.mapInformationReport;
    }

    public int GetPhaseCounter()
    {
        return this.phaseCounter;
    }

    public TalonActionResultReport GetTalonActionResultReport()
    {
        return this.talonActionResultReport;
    }

    public TalonCombatResultReport GetTalonCombatResultReport()
    {
        return this.talonCombatResultReport;
    }

    public override string ToString()
    {
        string talonCombatResultReportString = (this.GetTalonCombatResultReport() != null)
            ? "\n\t>" + this.GetTalonCombatResultReport()
            : "";
        return this.GetType() + ": " +
            "\n\t>phaseCounter=" + this.GetPhaseCounter() +
            "\n\t>actionCounter=" + this.GetActionCounter() +
            "\n\t>" + this.GetTalonActionResultReport() +
            talonCombatResultReportString +
            "\n\t>" + this.GetMapInformationReport();
    }

    #endregion Public Methods

    #region Public Classes

    public class Builder
    {
        #region Private Fields

        private int actionCounter = int.MinValue;
        private MapInformationReport mapInformationReport = null;
        private int phaseCounter = int.MinValue;
        private TalonActionResultReport talonActionResultReport = null;
        private TalonCombatResultReport talonCombatResultReport = null;

        #endregion Private Fields

        #region Public Methods

        public TalonTurnReport Build()
        {
            HashSet<string> invalidReasons = this.IsValid();
            // Check that the set parameters are valid
            if (invalidReasons.Count == 0)
            {
                // Instantiate a new Report
                return new TalonTurnReport(this.phaseCounter, this.actionCounter, this.talonActionResultReport,
                    this.talonCombatResultReport, this.mapInformationReport);
            }
            else
            {
                throw new ArgumentException("Unable to construct " + this.GetType() + ". Invalid Parameters." +
                    string.Join("\n\t>", invalidReasons));
            }
        }

        public Builder SetActionCounter(int actionCounter)
        {
            this.actionCounter = actionCounter;
            return this;
        }

        public Builder SetMapInformationReport(MapInformationReport mapInformationReport)
        {
            this.mapInformationReport = mapInformationReport;
            return this;
        }

        public Builder SetPhaseCounter(int phaseCounter)
        {
            this.phaseCounter = phaseCounter;
            return this;
        }

        public Builder SetTalonActionResultReport(TalonActionResultReport talonActionResultReport)
        {
            this.talonActionResultReport = talonActionResultReport;
            return this;
        }

        public Builder SetTalonCombatResultReport(TalonCombatResultReport talonCombatResultReport)
        {
            this.talonCombatResultReport = talonCombatResultReport;
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
            // Check that phaseCounter has been set
            if (this.phaseCounter < 0)
            {
                argumentExceptionSet.Add("phaseCounter=" + this.phaseCounter + " is not valid");
            }
            // Check that actionCounter has been set
            if (this.actionCounter < 0)
            {
                argumentExceptionSet.Add("actionCounter=" + this.actionCounter + " is not valid");
            }
            // Check that talonActionResultReport has been set
            if (this.talonActionResultReport == null)
            {
                argumentExceptionSet.Add(typeof(TalonActionResultReport) + " has not been set");
            }
            // Check that talonCombatResultReport has been set
            if (this.talonActionResultReport != null &&
                this.talonActionResultReport.GetTalonActionOrder() != null &&
                this.talonActionResultReport.GetTalonActionOrder().GetTalonActionType().Equals(TalonActionTypeEnum.Fire) &&
                this.talonCombatResultReport == null)
            {
                argumentExceptionSet.Add(typeof(TalonCombatResultReport) + " has not been set");
            }
            // Check that mapInformationReport has been set
            if (this.mapInformationReport == null)
            {
                argumentExceptionSet.Add(typeof(MapInformationReport) + " has not been set");
            }
            return argumentExceptionSet;
        }

        #endregion Private Methods
    }

    #endregion Public Classes
}