using System.Collections.Generic;

/// <summary>
/// Todo
/// </summary>
public class MechInfoReport
{
    #region Private Fields

    private readonly MechIdEnum mechId;
    private readonly int mechTeam;
    private readonly List<WeaponIdEnum> weaponIdList;

    #endregion Private Fields

    // Todo: Set the pilot in here if I ever get around to that

    #region Private Constructors

    /// <summary>
    /// Todo
    /// </summary>
    /// <param name="mechId">      </param>
    /// <param name="mechTeam">    </param>
    /// <param name="weaponIdList"></param>
    private MechInfoReport(MechIdEnum mechId, int mechTeam, List<WeaponIdEnum> weaponIdList)
    {
        this.mechId = mechId;
        this.mechTeam = mechTeam;
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
    public int GetMechTeam()
    {
        return this.mechTeam;
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
            ",\n MechTeam=" + this.GetMechTeam() +
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
        private int mechTeam;
        private List<WeaponIdEnum> weaponIdList;

        #endregion Private Fields

        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public MechInfoReport Build()
        {
            return new MechInfoReport(this.mechId, this.mechTeam, this.weaponIdList);
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