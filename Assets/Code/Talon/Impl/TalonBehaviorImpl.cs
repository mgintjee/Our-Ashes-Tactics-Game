using System;
using System.Collections.Generic;

/// <summary>
/// Talon Behavior Impl
/// </summary>
public class TalonBehaviorImpl
    : TalonBehavior
{
    #region Private Fields

    private readonly TalonBehaviorDestructable talonBehaviorDestructable = null;
    private readonly TalonBehaviorFireable talonBehaviorFireable = null;
    private readonly TalonBehaviorMoveable talonBehaviorMoveable = null;
    private readonly TalonIdentificationReport talonIdentificationReport;
    private CubeCoordinates cubeCoordinates = null;

    #endregion Private Fields

    #region Public Constructors

    public TalonBehaviorImpl(TalonIdentificationReport talonIdentificationReport)
    {
        if (talonIdentificationReport != null)
        {
            this.talonIdentificationReport = talonIdentificationReport;
            TalonAttributes talonAttributes = TalonAttributesConstants.GetAttributes(this.talonIdentificationReport.GetTalonId());
            if (talonAttributes != null)
            {
                this.talonBehaviorMoveable = new TalonBehaviorMoveableImpl(talonAttributes);
                this.talonBehaviorFireable = new TalonBehaviorFireableImpl(talonAttributes);
                this.talonBehaviorDestructable = new TalonBehaviorDestructableImpl(talonAttributes);
            }
            else
            {
                throw new ArgumentException("Unable to construct " + this.GetType() + ". Invalid Parameters." +
                    "\n\t>" + typeof(TalonAttributes) + " is null");
            }
        }
        else
        {
            throw new ArgumentException("Unable to construct " + this.GetType() + ". Invalid Parameters." +
                "\n\t>" + typeof(TalonIdentificationReport) + " is null");
        }
    }

    #endregion Public Constructors

    #region Public Methods

    public override void AddWeaponBehavior(WeaponBehavior weaponBehavior)
    {
        this.talonBehaviorFireable.AddWeapon(weaponBehavior);
    }

    public override CubeCoordinates GetCubeCoordinates()
    {
        return this.cubeCoordinates;
    }

    public override TalonAttributesReport GetCurrentTalonAttributesReport()
    {
        return new TalonAttributesReport.Builder()
            .SetArmourPoints(this.talonBehaviorDestructable.GetCurrentArmourPoints())
            .SetHealthPoints(this.talonBehaviorDestructable.GetCurrentHealthPoints())
            .SetMovePoints(this.talonBehaviorMoveable.GetCurrentMovePoints())
            .SetTurnPoints(this.talonBehaviorMoveable.GetCurrentTurnPoints())
            .SetOrderPoints(this.talonBehaviorMoveable.GetCurrentOrderPoints())
            .Build();
    }

    public override TalonAttributesReport GetMaximumTalonAttributesReport()
    {
        return new TalonAttributesReport.Builder()
            .SetArmourPoints(this.talonBehaviorDestructable.GetMaximumArmourPoints())
            .SetHealthPoints(this.talonBehaviorDestructable.GetMaximumHealthPoints())
            .SetMovePoints(this.talonBehaviorMoveable.GetMaximumMovePoints())
            .SetTurnPoints(this.talonBehaviorMoveable.GetMaximumTurnPoints())
            .SetOrderPoints(this.talonBehaviorMoveable.GetMaximumOrderPoints())
            .Build();
    }

    public override HashSet<TalonActionOrderReport> GetPossibleTalonActionOrderReportSet()
    {
        // Begin pathFinding for the Moveable
        this.talonBehaviorMoveable.BeginPathFinding();
        // Begin pathFinding for the Fireable
        this.talonBehaviorFireable.BeginPathFinding();
        // Default an empty Set
        HashSet<TalonActionOrderReport> talonActionOrderReportSet = new HashSet<TalonActionOrderReport>();

        // Iterate over all possible pathObjects for moving
        foreach (PathObject pathObject in this.talonBehaviorMoveable.GetPathObjectMoveSet())
        {
            // Add the actionReport to fire
            talonActionOrderReportSet.Add(new TalonActionOrderReport.Builder()
                .SetActingTalonIdentificationReport(this.talonIdentificationReport)
                .SetPathObject(pathObject)
                .SetTargetTalonIdentificationReport(null)
                .Build());
        }
        // Iterate over all possible pathObjects for firing
        foreach (PathObject pathObject in this.talonBehaviorFireable.GetPathObjectFireSet())
        {
            int pathObjectCost = pathObject.GetPathObjectCost();
            int maxFireAccuracyPenalty = this.talonBehaviorFireable.GetMaxAccuracyPenalty(pathObject.GetPathObjectLength());
            if (pathObjectCost < maxFireAccuracyPenalty)
            {
                // Collect the ending cubeCoordinates for the pathObject
                CubeCoordinates cubeCoordinates = pathObject.GetCubeCoordinatesEnd();
                // Collect the HexTileObject from the cubeCoordinates
                HexTileObject hexTileObject = HexTileObjectFinderUtil.FindHexTileObjectFrom(cubeCoordinates);
                // Check that the HexTileObject is non-null
                if (hexTileObject != null)
                {
                    // Colect the talonIdentificationReport from the hexTileObject
                    TalonIdentificationReport talonIdentificationReport = hexTileObject.GetHexTileInformationReport().GetTalonIdentificationReport();
                    // Check that the FactionIds are not the same
                    if (!this.talonIdentificationReport.GetTalonFactionId().Equals(talonIdentificationReport.GetTalonFactionId()))
                    {
                        // Add the actionReport to fire
                        talonActionOrderReportSet.Add(new TalonActionOrderReport.Builder()
                            .SetActingTalonIdentificationReport(this.talonIdentificationReport)
                            .SetPathObject(pathObject)
                            .SetTargetTalonIdentificationReport(talonIdentificationReport)
                            .Build());
                    }
                }
            }
        }
        // Add the TalonActionOrderReport for Waiting
        talonActionOrderReportSet.Add(new TalonActionOrderReport.Builder()
            .SetActingTalonIdentificationReport(this.talonIdentificationReport)
            .SetPathObject(new PathObjectWait(new List<CubeCoordinates>() { this.GetCubeCoordinates() }))
            .Build()
            );

        return talonActionOrderReportSet;
    }

    public override TalonCombatOrderReport GetTalonCombatOrderReport(PathObjectFire pathObjectFire)
    {
        return this.talonBehaviorFireable.GetTalonCombatOrderReport(pathObjectFire);
    }

    public override TalonActionResultReport InputTalonActionOrderReport(TalonActionOrderReport talonActionOrder)
    {
        TalonActionResultReport talonActionReport = null;
        if (talonActionOrder != null)
        {
            this.talonBehaviorMoveable.InputTalonActionOrder(talonActionOrder);
            talonActionReport = new TalonActionResultReport.Builder()
                .SetTalonActionOrder(talonActionOrder)
                .SetTalonAttributesReport(this.GetCurrentTalonAttributesReport())
                .Build();
        }
        return talonActionReport;
    }

    public override TalonCombatResultReport InputTalonCombatOrderReport(TalonCombatOrderReport talonCombatOrderReport)
    {
        return this.talonBehaviorDestructable.InputTalonCombatOrderReport(talonCombatOrderReport);
    }

    public override void ResetTalonAttributeValues()
    {
        this.talonBehaviorMoveable.ResetTalonAttributeValues();
    }

    public override void SetCubeCoordinates(CubeCoordinates cubeCoordinates)
    {
        if (cubeCoordinates != null)
        {
            this.cubeCoordinates = cubeCoordinates;
            this.talonBehaviorFireable.SetCubeCoodinates(cubeCoordinates);
            this.talonBehaviorMoveable.SetCubeCoodinates(cubeCoordinates);
        }
        else
        {
            throw new ArgumentException("Unable to SetCubeCoordinates" +
                "\n\t>" + typeof(CubeCoordinates) + " is null");
        }
    }

    #endregion Public Methods
}