using System;
using System.Collections.Generic;

/// <summary>
/// Todo
/// </summary>
public class TalonBehaviorFireableImpl
    : TalonBehaviorFireable
{
    #region Private Fields

    // Todo
    private readonly TalonAttributes talonAttributes = null;

    // Todo
    private Dictionary<CubeCoordinates, PathObject> cubeCoordinatesPathObjectDictionary = new Dictionary<CubeCoordinates, PathObject>();

    // Todo
    private CubeCoordinates currentCubeCoordinates;

    private List<WeaponBehavior> weaponBehaviorSet = new List<WeaponBehavior>();

    #endregion Private Fields

    #region Public Constructors

    public TalonBehaviorFireableImpl(TalonAttributes talonAttributes)
    {
        if (talonAttributes != null)
        {
            this.talonAttributes = talonAttributes;
        }
        else
        {
            throw new ArgumentException("Unable to construct " + this.GetType() + ". Invalid Parameters." +
                "\n>" + typeof(TalonAttributes) + " is null");
        }
    }

    #endregion Public Constructors

    #region Public Methods

    public override void AddWeapon(WeaponBehavior weaponBehavior)
    {
        // throw new System.NotImplementedException();
    }

    public override void BeginPathFinding()
    {
        this.cubeCoordinatesPathObjectDictionary = PathFinderFireUtil.BeginPathfindingFor(this.currentCubeCoordinates);
    }

    public override HashSet<PathObject> GetPathObjectFireSet()
    {
        return new HashSet<PathObject>(this.cubeCoordinatesPathObjectDictionary.Values);
    }

    public override TalonCombatOrderReport GetTalonCombatOrderReport(PathObjectFire pathObjectFire)
    {
        List<WeaponCombatOrderReport> weaponCombatOrderList = new List<WeaponCombatOrderReport>();
        if (pathObjectFire != null)
        {
            foreach (WeaponBehavior weaponBehavior in this.weaponBehaviorSet)
            {
                // Collect the weaponCombatOrder from the weaponBehavior
                WeaponCombatOrderReport weaponCombatOrder = weaponBehavior.GenerateWeaponReport(pathObjectFire.GetPathObjectCost(),
                    pathObjectFire.GetPathObjectLength());
                // Add the generated weaponCombatOrder to the list
                weaponCombatOrderList.Add(weaponCombatOrder);
            }
        }
        return new TalonCombatOrderReport.Builder()
            .SetWeaponCombatOrderReportList(weaponCombatOrderList)
            .Build();
    }

    public override List<WeaponIdEnum> GetWeaponIdList()
    {
        List<WeaponIdEnum> weaponIdList = new List<WeaponIdEnum>();

        foreach (WeaponBehavior weaponBehavior in this.weaponBehaviorSet)
        {
            weaponIdList.Add(weaponBehavior.GetWeaponId());
        }
        return weaponIdList;
    }

    public override void SetCubeCoodinates(CubeCoordinates cubeCoordinates)
    {
        if (cubeCoordinates != null)
        {
            this.currentCubeCoordinates = cubeCoordinates;
        }
    }

    #endregion Public Methods
}