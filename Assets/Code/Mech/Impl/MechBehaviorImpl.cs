using System.Collections.Generic;
using System.Diagnostics;

/// <summary>
/// Todo
/// </summary>
public class MechBehaviorImpl
    : MechBehavior
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    private readonly MechAttributes mechAttributes;

    // MechDestructable that tracks the MechDestructable aspects for this Mech
    private readonly MechBehaviorDestructable mechBehaviorDestructable;

    // MechFireable that tracks the MechFireable aspects for this Mech
    private readonly MechBehaviorFireable mechBehaviorFireable;

    // MechMoveable that tracks the MechMoveable aspects for this Mech
    private readonly MechBehaviorMoveable mechBehaviorMoveable;

    // Todo
    private readonly MechIdEnum mechId;

    // Todo
    private readonly string mechName;

    // Todo
    private readonly TeamIdEnum teamId;

    //Todo
    private readonly int mechTeamIndex;

    // Todo
    private CubeCoordinates cubeCoordinates;

    #endregion Private Fields

    #region Public Constructors

    /// <summary>
    /// Todo
    /// </summary>
    /// <param name="mechConstructionReport"></param>
    public MechBehaviorImpl(MechConstructionReport mechConstructionReport)
    {
        this.mechId = mechConstructionReport.GetMechId();
        this.teamId = mechConstructionReport.GetTeamId();
        this.mechTeamIndex = mechConstructionReport.GetMechTeamIndex();
        this.mechName = mechConstructionReport.GetMechName();
        this.mechAttributes = MechAttributeConstants.GetImplementedMechAttributes(this.GetMechId());
        this.mechBehaviorDestructable = new MechBehaviorDestructable(this.mechAttributes.GetArmourPoints(), this.mechAttributes.GetHealthPoints());
        this.mechBehaviorFireable = new MechBehaviorFireable(this.mechAttributes.GetWeaponPoints(), this.teamId);
        this.mechBehaviorMoveable = new MechBehaviorMoveable(this.mechAttributes.GetMovePoints(), this.mechAttributes.GetTurnPoints());
    }

    #endregion Public Constructors

    #region Public Methods

    /// <summary>
    /// Todo
    /// </summary>
    /// <param name="weaponBehavior"></param>
    public override void AddWeapon(WeaponBehavior weaponBehavior)
    {
        if (weaponBehavior != null)
        {
            logger.Debug("Adding WeaponBehavior: WeaponId=?, to MechBehavior: MechName=?.", weaponBehavior.GetWeaponId(), this.GetMechName());
            this.mechBehaviorFireable.AddWeapon(weaponBehavior);
        }
        else
        {
            logger.Warn("Unable to add WeaponBehavior. WeaponBehavior is null.");
        }
    }

    /// <summary>
    /// Todo
    /// </summary>
    public override void BeginPathFinding()
    {
        logger.Debug("Beginning PathFinding for Mech=?", this.GetMechName());
        this.mechBehaviorMoveable.BeginPathFinding();
        this.mechBehaviorFireable.BeginPathFinding();
    }

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public override CubeCoordinates GetCubeCoordinates()
    {
        return this.cubeCoordinates;
    }

    public override int GetCurrentArmourPoints()
    {
        return this.mechBehaviorDestructable.GetArmourCurrentPoints();
    }

    public override int GetCurrentHealthPoints()
    {
        return this.mechBehaviorDestructable.GetHealthCurrentPoints();
    }

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public override int GetCurrentOrderPoints()
    {
        return this.mechBehaviorMoveable.GetCurrentOrderPoints();
    }

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public override MechIdEnum GetMechId()
    {
        return this.mechId;
    }

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public override MechInfoReport GetMechInfoReport()
    {
        return new MechInfoReport.Builder()
            .SetMechId(this.GetMechId())
            .SetMechTeam(this.GetTeamId())
            .SetMechTeamIndex(this.GetMechTeamIndex())
            .SetWeaponIdList(this.mechBehaviorFireable.GetWeaponIdList())
            .Build();
    }

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public override string GetMechName()
    {
        return this.mechName;
    }

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public override TeamIdEnum GetTeamId()
    {
        return this.teamId;
    }

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public override int GetMechTeamIndex()
    {
        return this.mechTeamIndex;
    }

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public override HashSet<PathObject> GetPathObjectFireSet()
    {
        return this.mechBehaviorFireable.GetPathObjectFireSet();
    }

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public override HashSet<PathObject> GetPathObjectMoveSet()
    {
        return this.mechBehaviorMoveable.GetPathObjectMoveSet();
    }

    /// <summary>
    /// Todo
    /// </summary>
    /// <param name="pathObjectFire"></param>
    /// <returns></returns>
    public override HashSet<WeaponCombatReport> GetWeaponCombatReportSet(PathObjectFire pathObjectFire)
    {
        return this.mechBehaviorFireable.GenerateWeaponReportSet(pathObjectFire);
    }

    /// <summary>
    /// Todo
    /// </summary>
    /// <param name="mechActionReport"></param>
    /// <returns></returns>
    public override bool InputMechActionReport(ActionReport mechActionReport)
    {
        return this.mechBehaviorMoveable.InputMechActionReport(mechActionReport);
    }

    /// <summary>
    /// Todo
    /// </summary>
    /// <param name="weaponCombatReportSet"></param>
    /// <returns></returns>
    public override bool InputWeaponCombatReportSet(HashSet<WeaponCombatReport> weaponCombatReportSet)
    {
        return this.mechBehaviorDestructable.ConsumeWeaponReportSet(weaponCombatReportSet);
    }

    /// <summary>
    /// Todo
    /// </summary>
    public override void ResetValuesForNewTurn()
    {
        this.mechBehaviorMoveable.ResetValuesForNewTurn();
    }

    /// <summary>
    /// Todo
    /// </summary>
    /// <param name="cubeCoordinates"></param>
    public override void SetCubeCoordinates(CubeCoordinates cubeCoordinates)
    {
        this.cubeCoordinates = cubeCoordinates;
        this.mechBehaviorMoveable.SetTileCoodinates(cubeCoordinates);
        this.mechBehaviorFireable.SetTileCoodinates(cubeCoordinates);
    }

    #endregion Public Methods
}