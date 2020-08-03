using System.Collections.Generic;

/// <summary>
/// Todo
/// </summary>
public class TalonBehaviorFireableImpl
    : TalonBehaviorFireable
{
    #region Private Fields

    private readonly TalonAttributes talonAttributes = null;

    #endregion Private Fields

    #region Public Constructors

    public TalonBehaviorFireableImpl(TalonAttributes talonAttributes)
    {
        if (talonAttributes != null)
        {
            this.talonAttributes = talonAttributes;
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
        //throw new System.NotImplementedException();
    }

    public override HashSet<WeaponCombatReport> GenerateWeaponReportSet(PathObjectFire pathObjectFire)
    {
        //throw new System.NotImplementedException();
        return null;
    }

    public override HashSet<PathObject> GetPathObjectFireSet()
    {
        //throw new System.NotImplementedException();
        return null;
    }

    public override List<WeaponIdEnum> GetWeaponIdList()
    {
        //throw new System.NotImplementedException();
        return null;
    }

    public override void SetCubeCoodinates(CubeCoordinates cubeCoordinates)
    {
        //throw new System.NotImplementedException();
    }

    #endregion Public Methods
}