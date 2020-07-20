using System.Collections.Generic;

/// <summary>
/// Todo
/// </summary>
public class MechInfoReport
{
    #region Private Fields

    private readonly MechIdEnum mechId;
    private readonly TeamIdEnum teamId;
    private readonly int mechTeamIndex;
    private readonly List<WeaponIdEnum> weaponIdList;

    #endregion Private Fields

    // Todo: Set the pilot in here if I ever get around to that

    #region Private Constructors

    /// <summary>
    /// Todo
    /// </summary>
    /// <param name="mechId">      </param>
    /// <param name="teamId">    </param>
    /// <param name="weaponIdList"></param>
    private MechInfoReport(MechIdEnum mechId, TeamIdEnum teamId, int mechTeamIndex, List<WeaponIdEnum> weaponIdList)
    {
        this.mechId = mechId;
        this.teamId = teamId;
        this.mechTeamIndex = mechTeamIndex;
        this.weaponIdList = new List<WeaponIdEnum>(weaponIdList);
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

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public TeamIdEnum GetTeamId()
    {
        return this.teamId;
    }

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public int GetMechTeamId()
    {
        return this.mechTeamIndex;
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
        return this.GetType().ToString() + ": " +
            "\n MechId=" + this.GetMechId() +
            ",\n MechTeam=" + this.GetTeamId() +
            ",\n MechTeamId=" + this.GetMechTeamId() +
            ",\n WeaponIdSet=[" + string.Join(", ", this.GetWeaponIdList()) + "]";
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
        private TeamIdEnum teamId;
        private int mechTeamIndex;
        private List<WeaponIdEnum> weaponIdList;

        #endregion Private Fields

        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public MechInfoReport Build()
        {
            /*
            if (this.mechId.Equals(MechIdEnum.NULL) ||
                this.teamId.Equals(TeamIdEnum.NULL) ||
                this.mechTeamIndex < 0 ||
                this.paintSchemeReport == null ||
                this.weaponIdList.Count == 0)
            {
                throw new ArgumentException("Unable to construct ?" + this.GetType().ToString() + ". Invalid Parameters." +
                    "\nmechId=" + this.mechId +
                    "\nteamId=" + this.teamId +
                    "\nmechTeamIndex=" + this.mechTeamIndex +
                    "\npaintSchemeReport=" + this.paintSchemeReport +
                    "\nweaponIdList.Count=" + this.weaponIdList.Count);
            }
            */
            // Todo: Have a safety check that all parameters have been filled
            return new MechInfoReport(this.mechId, this.teamId, this.mechTeamIndex, this.weaponIdList);
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
        /// <param name="teamId"></param>
        /// <returns></returns>
        public Builder SetMechTeam(TeamIdEnum teamId)
        {
            this.teamId = teamId;
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