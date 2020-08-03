using System;

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

    #endregion Private Fields

    #region Public Constructors

    public TalonBehaviorImpl(TalonIdEnum talonId)
    {
        if (talonId != TalonIdEnum.NULL)
        {
            TalonAttributes talonAttributes = TalonAttributesConstants.GetAttributes(talonId);
            if (talonAttributes != null)
            {
                this.talonBehaviorMoveable = new TalonBehaviorMoveableImpl(talonAttributes);
                this.talonBehaviorFireable = new TalonBehaviorFireableImpl(talonAttributes);
                this.talonBehaviorDestructable = new TalonBehaviorDestructableImpl(talonAttributes);
            }
            else
            {
                throw new ArgumentException("Unable to construct " + this.GetType() + ". Invalid Parameters." +
                    "\n>" + typeof(TalonAttributes) + " is null");
            }
        }
        else
        {
            throw new ArgumentException("Unable to construct " + this.GetType() + ". Invalid Parameters." +
                "\n>" + typeof(TalonIdEnum) + " is invalid");
        }
    }

    #endregion Public Constructors

    #region Public Methods

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

    public override TalonBehaviorDestructable GetTalonBehaviorDestructable()
    {
        return this.talonBehaviorDestructable;
    }

    public override TalonBehaviorFireable GetTalonBehaviorFireable()
    {
        return this.talonBehaviorFireable;
    }

    public override TalonBehaviorMoveable GetTalonBehaviorMoveable()
    {
        return this.talonBehaviorMoveable;
    }

    public override void SetCubeCoordinates(CubeCoordinates cubeCoordinates)
    {
        if (cubeCoordinates != null)
        {
            this.talonBehaviorFireable.SetCubeCoodinates(cubeCoordinates);
            this.talonBehaviorMoveable.SetCubeCoodinates(cubeCoordinates);
        }
        else
        {
            throw new ArgumentException("Unable to SetCubeCoordinates" +
                "\n>" + typeof(CubeCoordinates) + " is null: " + (cubeCoordinates == null));

        }
    }

    #endregion Public Methods
}