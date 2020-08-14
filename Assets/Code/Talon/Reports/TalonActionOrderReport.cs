using System;
using System.Collections.Generic;

/// <summary>
/// Todo
/// </summary>
public class TalonActionOrderReport
{
    #region Private Fields

    private readonly TalonIdentificationReport actingTalonIdentificationReport = null;
    private readonly TalonActionTypeEnum actionType = TalonActionTypeEnum.NULL;
    private readonly PathObject pathObject = null;
    private readonly TalonIdentificationReport targetTalonIdentificationReport = null;

    #endregion Private Fields

    #region Public Constructors

    public TalonActionOrderReport(TalonIdentificationReport actingTalonIdentificationReport,
        TalonIdentificationReport targetTalonIdentificationReport, PathObject pathObject)
    {
        this.actingTalonIdentificationReport = actingTalonIdentificationReport;
        this.pathObject = pathObject;
        if (this.pathObject is PathObjectMove)
        {
            this.actionType = TalonActionTypeEnum.Move;
        }
        else if (this.pathObject is PathObjectFire)
        {
            this.actionType = TalonActionTypeEnum.Fire;
            this.targetTalonIdentificationReport = targetTalonIdentificationReport;
        }
        else if (this.pathObject is PathObjectWait)
        {
            this.actionType = TalonActionTypeEnum.Wait;
        }
    }

    #endregion Public Constructors

    #region Public Methods

    public TalonIdentificationReport GetActingTalonIdentificationReport()
    {
        return this.actingTalonIdentificationReport;
    }

    public PathObject GetPathObject()
    {
        return this.pathObject;
    }

    public TalonActionTypeEnum GetTalonActionType()
    {
        return this.actionType;
    }

    public TalonIdentificationReport GetTargetTalonIdentificationReport()
    {
        return this.targetTalonIdentificationReport;
    }

    public override string ToString()
    {
        return this.GetType() + ": " +
            "\n\t>Acting " + this.GetActingTalonIdentificationReport() +
            "\n\t>Target " + this.GetTargetTalonIdentificationReport() +
            "\n\t>" + typeof(TalonActionTypeEnum) + "= " + this.GetTalonActionType() +
            "\n\t>" + typeof(PathObject) + "= [" + this.GetPathObject() + "]";
    }

    #endregion Public Methods

    #region Public Classes

    public class Builder
    {
        #region Private Fields

        private TalonIdentificationReport actingTalonIdentificationReport = null;
        private PathObject pathObject = null;
        private TalonIdentificationReport targetTalonIdentificationReport = null;

        #endregion Private Fields

        #region Public Methods

        public TalonActionOrderReport Build()
        {
            HashSet<string> invalidReasons = this.IsValid();
            // Check that the set parameters are valid
            if (invalidReasons.Count == 0)
            {
                // Instantiate a new Report
                return new TalonActionOrderReport(this.actingTalonIdentificationReport, this.targetTalonIdentificationReport, this.pathObject);
            }
            else
            {
                throw new ArgumentException("Unable to construct " + this.GetType() + ". Invalid Parameters." +
                    string.Join("\n\t>", invalidReasons));
            }
        }

        public Builder SetActingTalonIdentificationReport(TalonIdentificationReport actingTalonIdentificationReport)
        {
            this.actingTalonIdentificationReport = actingTalonIdentificationReport;
            return this;
        }

        public Builder SetPathObject(PathObject pathObject)
        {
            this.pathObject = pathObject;
            return this;
        }

        public Builder SetTargetTalonIdentificationReport(TalonIdentificationReport targetTalonIdentificationReport)
        {
            this.targetTalonIdentificationReport = targetTalonIdentificationReport;
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
            // Check that pathObject has been set
            if (this.pathObject == null)
            {
                argumentExceptionSet.Add(typeof(PathObject) + " has not been set");
            }
            // Check that actingTalonIdentificationReport has been set
            if (this.actingTalonIdentificationReport == null)
            {
                argumentExceptionSet.Add("Acting " + typeof(TalonIdentificationReport) + " has not been set");
            }
            // Check that actingTalonIdentificationReport has been set if this is a PathObjectFire
            if (this.pathObject is PathObjectFire &&
                this.targetTalonIdentificationReport == null)
            {
                argumentExceptionSet.Add("Target " + typeof(TalonIdentificationReport) + " has not been set");
            }
            return argumentExceptionSet;
        }

        #endregion Private Methods
    }

    #endregion Public Classes
}