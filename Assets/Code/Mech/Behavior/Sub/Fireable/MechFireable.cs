using System.Collections.Generic;
using System.Diagnostics;

/// <summary>
/// Todo
/// </summary>
public class MechBehaviorFireable
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    // Todo
    private readonly TeamIdEnum teamId;

    // The PathFinderMove that will generate the possible move paths for this Mech
    private readonly PathFinderFire pathFinderFire;

    // The Set: Weapons for this MechFireable
    private readonly HashSet<WeaponBehavior> weaponBehaviorSet = new HashSet<WeaponBehavior>();

    // The int maximum amount of weapons for this MechFireable
    private readonly int weaponPoints = 0;

    // Todo
    private CubeCoordinates currentTileCoordinates;

    // Todo
    private Dictionary<CubeCoordinates, PathObject> pathObjectDictionary = new Dictionary<CubeCoordinates, PathObject>();

    #endregion Private Fields

    #region Public Constructors

    /// <summary>
    /// Construtor Method, To Construct the MechFireable with the parameterized values
    /// </summary>
    /// <param name="weaponPoints">The Integer maximum amount of weapons for this MechFireable</param>
    public MechBehaviorFireable(int weaponPoints, TeamIdEnum mechTeam)
    {
        logger.Debug("Constructing Object=? with WeaponPoints=?", this.GetType().ToString(), weaponPoints);
        this.weaponPoints = weaponPoints;
        this.teamId = mechTeam;
    }

    #endregion Public Constructors

    #region Public Methods

    /// <summary>
    /// MechFireable Method, to add to the weapon set
    /// </summary>
    /// <param name="weaponBehavior">The DefaultWeapon to add to the Set: Weapon</param>
    public void AddWeapon(WeaponBehavior weaponBehavior)
    {
        if (this.weaponBehaviorSet.Count + 1 <= this.weaponPoints)
        {
            this.weaponBehaviorSet.Add(weaponBehavior);
            logger.Debug("Added WeaponBehavior to MechFireable. Current Weapon Count=?", this.weaponBehaviorSet.Count);
        }
        else
        {
            logger.Warn("Unable to add WeaponBehavior. Current Weapon Count=?, is max allowed.", this.weaponBehaviorSet.Count);
        }
    }

    public void BeginPathFinding()
    {
        this.pathObjectDictionary = PathFinderFireUtil.BeginPathfindingFor(this.currentTileCoordinates, this.teamId);
    }

    /// <summary>
    /// MechFireable Metehod, to generate the Set: WeaponReport from the PathObjectFire
    /// </summary>
    /// <param name="pathObjectFire">The MechFireable's PathObjectFire that was generated</param>
    /// <returns>The Set: WeaponReport</returns>
    public HashSet<WeaponCombatReport> GenerateWeaponReportSet(PathObjectFire pathObjectFire)
    {
        // Default an empty set
        HashSet<WeaponCombatReport> weaponReportSet = new HashSet<WeaponCombatReport>();
        // Collect the Cost of the Path
        int pathCost = pathObjectFire.GetPathObjectCost();
        // Iterate over the MechFireable's Set: Weapon
        foreach (WeaponBehavior weapon in this.weaponBehaviorSet)
        {
            // Collect the weaponReport from the Weapon
            WeaponCombatReport weaponReport = weapon.GenerateWeaponReport(pathCost, pathObjectFire.GetPathObjectLength());
            // Add the generated WeaponReport to the set
            weaponReportSet.Add(weaponReport);
        }
        return weaponReportSet;
    }

    public HashSet<PathObject> GetPathObjectFireSet()
    {
        HashSet<PathObject> pathObjectSet = new HashSet<PathObject>();
        foreach (CubeCoordinates cubeCoordinates in this.pathObjectDictionary.Keys)
        {
            pathObjectSet.Add(this.pathObjectDictionary[cubeCoordinates]);
        }
        return pathObjectSet;
    }

    public List<WeaponIdEnum> GetWeaponIdList()
    {
        List<WeaponIdEnum> weaponIdList = new List<WeaponIdEnum>();
        foreach (WeaponBehavior weapon in this.weaponBehaviorSet)
        {
            if (weapon != null)
            {
                weaponIdList.Add(weapon.GetWeaponId());
            }
        }
        return weaponIdList;
    }

    public void SetTileCoodinates(CubeCoordinates tileCoordinates)
    {
        this.currentTileCoordinates = tileCoordinates;
    }

    #endregion Public Methods
}