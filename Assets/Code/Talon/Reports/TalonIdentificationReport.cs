using System;
using System.Collections.Generic;

/// <summary>
/// Report to display the identification information for a specific Talon
/// </summary>
public class TalonIdentificationReport
{
    #region Private Fields

    private readonly TalonFactionIdEnum factionId = TalonFactionIdEnum.NULL;
    private readonly TalonIdEnum talonId = TalonIdEnum.NULL;
    private readonly TalonPhalanxIdEnum talonPhalanxId = TalonPhalanxIdEnum.NULL;
    private readonly int talonPhalanxIndex = int.MinValue;

    #endregion Private Fields

    #region Private Constructors

    /// <summary>
    /// Todo
    /// </summary>
    /// <param name="talonId">          </param>
    /// <param name="factionId">        </param>
    /// <param name="talonPhalanxId">   </param>
    /// <param name="talonPhalanxIndex"></param>
    private TalonIdentificationReport(TalonIdEnum talonId, TalonFactionIdEnum factionId, TalonPhalanxIdEnum talonPhalanxId, int talonPhalanxIndex)
    {
        this.talonId = talonId;
        this.factionId = factionId;
        this.talonPhalanxId = talonPhalanxId;
        this.talonPhalanxIndex = talonPhalanxIndex;
    }

    #endregion Private Constructors

    #region Public Methods

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public TalonFactionIdEnum GetTalonFactionId()
    {
        return this.factionId;
    }

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public TalonIdEnum GetTalonId()
    {
        return this.talonId;
    }

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public string GetTalonName()
    {
        return TalonConstants.Script.GetPhalanxIndexGameObjectPrefix() + this.GetTalonPhalanxIndex() + ", " +
            TalonConstants.Script.GetTalonIdGameObjectPrefix() + this.GetTalonId();
    }

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public TalonPhalanxIdEnum GetTalonPhalanxId()
    {
        return this.talonPhalanxId;
    }

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public int GetTalonPhalanxIndex()
    {
        return this.talonPhalanxIndex;
    }

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return this.GetType() + ": " +
            typeof(TalonFactionIdEnum) + ": " + this.GetTalonFactionId() +
            ", " + typeof(TalonPhalanxIdEnum) + ": " + this.GetTalonPhalanxId() +
            ", talonPhalanxIndex: " + this.GetTalonPhalanxIndex() +
            ", " + typeof(TalonIdEnum) + ": " + this.GetTalonId();
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
        private TalonFactionIdEnum factionId = TalonFactionIdEnum.NULL;

        // Todo
        private TalonIdEnum talonId = TalonIdEnum.NULL;

        // Todo
        private TalonPhalanxIdEnum talonPhalanxId = TalonPhalanxIdEnum.NULL;

        // Todo
        private int talonPhalanxIndex = int.MinValue;

        #endregion Private Fields

        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public TalonIdentificationReport Build()
        {
            HashSet<string> invalidReasons = this.IsValid();
            // Check that the set parameters are valid
            if (invalidReasons.Count == 0)
            {
                // Instantiate a new Report
                return new TalonIdentificationReport(this.talonId, this.factionId, this.talonPhalanxId, this.talonPhalanxIndex);
            }
            else
            {
                throw new ArgumentException("Unable to construct " + this.GetType() + ". Invalid Parameters." +
                    string.Join("\n", invalidReasons));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="factionId"></param>
        /// <returns></returns>
        public Builder SetTalonFactionId(TalonFactionIdEnum factionId)
        {
            this.factionId = factionId;
            return this;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonId"></param>
        /// <returns></returns>
        public Builder SetTalonId(TalonIdEnum talonId)
        {
            this.talonId = talonId;
            return this;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="factionTalonId"></param>
        /// <returns></returns>
        public Builder SetTalonPhalanxId(TalonPhalanxIdEnum talonPhalanxId)
        {
            this.talonPhalanxId = talonPhalanxId;
            return this;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonPhalanxIndex"></param>
        /// <returns></returns>
        public Builder SetTalonPhalanxIndex(int talonPhalanxIndex)
        {
            this.talonPhalanxIndex = talonPhalanxIndex;
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
            // Check that factionId has been set
            if (this.factionId == TalonFactionIdEnum.NULL)
            {
                argumentExceptionSet.Add(typeof(TalonFactionIdEnum) + " has not been set");
            }
            // Check that talonPhalanxId has been set
            if (this.talonPhalanxId == TalonPhalanxIdEnum.NULL)
            {
                argumentExceptionSet.Add(typeof(TalonPhalanxIdEnum) + " has not been set");
            }
            // Check that talonPhalanxIndex has been set
            if (this.talonPhalanxIndex == int.MinValue)
            {
                argumentExceptionSet.Add("talonPhalanxIndex has not been set");
            }
            else
            {
                // Check that talonPhalanxIndex is valid
                if (this.talonPhalanxIndex < 0)
                {
                    argumentExceptionSet.Add("talonPhalanxIndex=" + this.talonPhalanxIndex + ", is invalid");
                }
            }
            // Check that talonId has been set
            if (this.talonId == TalonIdEnum.NULL)
            {
                argumentExceptionSet.Add(typeof(TalonIdEnum) + " has not been set");
            }
            return argumentExceptionSet;
        }

        #endregion Private Methods
    }

    #endregion Public Classes
}