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

    private readonly List<WeaponBehavior> weaponBehaviorList;

    // Todo
    private Dictionary<CubeCoordinates, PathObject> cubeCoordinatesPathObjectDictionary = new Dictionary<CubeCoordinates, PathObject>();

    // Todo
    private CubeCoordinates currentCubeCoordinates;

    #endregion Private Fields

    #region Public Constructors

    public TalonBehaviorFireableImpl(TalonAttributes talonAttributes)
    {
        if (talonAttributes != null)
        {
            this.talonAttributes = talonAttributes;
            this.weaponBehaviorList = new List<WeaponBehavior>();
        }
        else
        {
            throw new ArgumentException("Unable to construct " + this.GetType() + ". Invalid Parameters." +
                "\n\t>" + typeof(TalonAttributes) + " is null");
        }
    }

    #endregion Public Constructors

    #region Public Methods

    public override void AddWeapon(WeaponBehavior weaponBehavior)
    {
        if (weaponBehavior != null)
        {
            if (this.weaponBehaviorList.Count < this.talonAttributes.GetWeaponPoints())
            {
                this.weaponBehaviorList.Add(weaponBehavior);
            }
        }
        else
        {
            throw new ArgumentException("Unable to add " + typeof(WeaponBehavior) + ". Invalid Parameters." +
                "\n\t>" + typeof(WeaponBehavior) + " is null");
        }
    }

    public override void BeginPathFinding()
    {
        this.cubeCoordinatesPathObjectDictionary = (this.weaponBehaviorList.Count > 0)
            ? PathFinderFireUtil.BeginPathfindingFor(this.currentCubeCoordinates)
            : new Dictionary<CubeCoordinates, PathObject>();
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
            foreach (WeaponBehavior weaponBehavior in this.weaponBehaviorList)
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

        foreach (WeaponBehavior weaponBehavior in this.weaponBehaviorList)
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