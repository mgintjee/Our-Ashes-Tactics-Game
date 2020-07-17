using System.Collections.Generic;

/// <summary>
/// Todo
/// </summary>
public class MechConstructionReport
{
    #region Private Fields

    private readonly MechIdEnum mechId;
    private readonly string mechName;
    private readonly int mechTeam;
    private readonly int mechTeamIndex;
    private readonly PaintSchemeReport paintSchemeReport;
    private readonly List<WeaponIdEnum> weaponIdList;

    #endregion Private Fields

    // Todo: Set the pilot in here if I ever get around to that

    #region Private Constructors

    /// <summary>
    /// Todo
    /// </summary>
    /// <param name="mechId">             </param>
    /// <param name="mechTeam">           </param>
    /// <param name="mechTeamIndex">      </param>
    /// <param name="primaryPaintColor">  </param>
    /// <param name="secondaryPaintColor"></param>
    /// <param name="weaponIdList">       </param>
    private MechConstructionReport(MechIdEnum mechId, int mechTeam,
        int mechTeamIndex, PaintSchemeReport paintSchemeReport, List<WeaponIdEnum> weaponIdList)
    {
        this.mechId = mechId;
        this.mechTeam = mechTeam;
        this.mechTeamIndex = mechTeamIndex;
        this.paintSchemeReport = paintSchemeReport;
        this.weaponIdList = new List<WeaponIdEnum>(weaponIdList);
        this.mechName = string.Join(":", new object[] { this.GetMechTeam(),
            this.GetMechTeamIndex(), this.GetMechId() });
    }

    #endregion Private Constructors

    #region Public Methods

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public MechIdEnum GetMechId()
    {
        return this.mechId;
    }

    public string GetMechName()
    {
        return this.mechName;
    }

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public int GetMechTeam()
    {
        return this.mechTeam;
    }

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public int GetMechTeamIndex()
    {
        return this.mechTeamIndex;
    }

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public PaintSchemeReport GetPaintSchemeReport()
    {
        return this.paintSchemeReport;
    }

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public List<WeaponIdEnum> GetWeaponIdList()
    {
        return new List<WeaponIdEnum>(this.weaponIdList);
    }

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return this.GetType().ToString() + ":" +
            "\n MechName=" + this.GetMechName() +
            ",\n WeaponIdSet=[" + string.Join(", ", this.GetWeaponIdList()) + "]" +
            ",\n PaintSchemeReport=" + this.GetPaintSchemeReport().ToString();
    }

    #endregion Public Methods

    #region Public Classes

    /// <summary>
    /// Todo
    /// </summary>
    public class Builder
    {
        #region Private Fields

        private MechIdEnum mechId;
        private int mechTeam;
        private int mechTeamIndex;
        private PaintSchemeReport paintSchemeReport;
        private List<WeaponIdEnum> weaponIdList;

        #endregion Private Fields

        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public MechConstructionReport Build()
        {
            return new MechConstructionReport(this.mechId, this.mechTeam, this.mechTeamIndex, this.paintSchemeReport, this.weaponIdList);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mechId"></param>
        /// <returns></returns>
        public Builder SetMechId(MechIdEnum mechId)
        {
            this.mechId = mechId;
            return this;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mechTeam"></param>
        /// <returns></returns>
        public Builder SetMechTeam(int mechTeam)
        {
            this.mechTeam = mechTeam;
            return this;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mechTeamIndex"></param>
        /// <returns></returns>
        public Builder SetMechTeamIndex(int mechTeamIndex)
        {
            this.mechTeamIndex = mechTeamIndex;
            return this;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="paintSchemeReport"></param>
        /// <returns></returns>
        public Builder SetPaintSchemeReport(PaintSchemeReport paintSchemeReport)
        {
            this.paintSchemeReport = paintSchemeReport;
            return this;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="weaponIdList"></param>
        /// <returns></returns>
        public Builder SetWeaponIdList(List<WeaponIdEnum> weaponIdList)
        {
            this.weaponIdList = new List<WeaponIdEnum>(weaponIdList);
            return this;
        }

        #endregion Public Methods
    }

    #endregion Public Classes
}