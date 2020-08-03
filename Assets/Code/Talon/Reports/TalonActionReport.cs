using System;
using System.Collections.Generic;

/// <summary>
/// Todo
/// </summary>
public class TalonActionReport
{
    #region Private Fields

    private readonly TalonActionTypeEnum actionType = TalonActionTypeEnum.NULL;
    private readonly PathObject pathObject = null;
    private readonly TalonIdentificationReport talonIdentificationReport = null;

    #endregion Private Fields

    #region Public Constructors

    public TalonActionReport(TalonIdentificationReport talonIdentificationReport, PathObject pathObject)
    {
        this.talonIdentificationReport = talonIdentificationReport;
        this.pathObject = pathObject;
        if (this.pathObject is PathObjectMove)
        {
            this.actionType = TalonActionTypeEnum.Move;
        }
        else if (this.pathObject is PathObjectFire)
        {
            this.actionType = TalonActionTypeEnum.Fire;
        }
        else if (this.pathObject is PathObjectWait)
        {
            this.actionType = TalonActionTypeEnum.Wait;
        }
    }

    #endregion Public Constructors

    #region Public Methods

    public TalonActionTypeEnum GetActionType()
    {
        return this.actionType;
    }

    public PathObject GetPathObject()
    {
        return this.pathObject;
    }

    public TalonIdentificationReport GetTalonIdentificationReport()
    {
        return this.talonIdentificationReport;
    }

    public override string ToString()
    {
        return this.GetType() + ": " +
            "\n>" + this.GetTalonIdentificationReport() +
            ",\n>" + typeof(TalonActionTypeEnum) + "= " + this.GetActionType() +
            ",\n>" + typeof(PathObject) + "= [" + this.GetPathObject() + "]";
    }

    #endregion Public Methods

    #region Public Classes

    public class Builder
    {
        #region Private Fields

        private PathObject pathObject = null;
        private TalonIdentificationReport talonIdentificationReport = null;

        #endregion Private Fields

        #region Public Methods

        public TalonActionReport Build()
        {
            HashSet<string> invalidReasons = this.IsValid();
            // Check that the set parameters are valid
            if (invalidReasons.Count == 0)
            {
                // Instantiate a new Report
                return new TalonActionReport(this.talonIdentificationReport, pathObject);
            }
            else
            {
                throw new ArgumentException("Unable to construct " + this.GetType() + ". Invalid Parameters." +
                    string.Join("\n>", invalidReasons));
            }
        }

        public Builder SetActionType(PathObject pathObject)
        {
            this.pathObject = pathObject;
            return this;
        }

        public Builder SetTalonIdentificationReport(TalonIdentificationReport talonIdentificationReport)
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
            // Check that pathObject has been set
            if (this.pathObject == null)
            {
                argumentExceptionSet.Add(typeof(PathObject) + " has not been set");
            }
            // Check that talonIdentificationReport has been set
            if (this.talonIdentificationReport == null)
            {
                argumentExceptionSet.Add(typeof(TalonIdentificationReport) + " has not been set");
            }
            return argumentExceptionSet;
        }

        #endregion Private Methods
    }

    #endregion Public Classes
}