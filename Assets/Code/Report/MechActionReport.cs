using System.Collections.Generic;

/// <summary>
/// Todo
/// </summary>
public class ActionReport
{
    #region Private Fields

    private readonly ActionTypeEnum mechActionTypeEnum;
    private readonly MechObject mechObject;
    private readonly PathObject pathObject;

    #endregion Private Fields

    #region Public Constructors

    public ActionReport(MechObject mechObject, PathObject pathObject)
    {
        this.mechObject = mechObject;
        this.pathObject = pathObject;
        if (this.pathObject is PathObjectMove)
        {
            this.mechActionTypeEnum = ActionTypeEnum.Move;
        }
        else if (this.pathObject is PathObjectFire)
        {
            this.mechActionTypeEnum = ActionTypeEnum.Fire;
        }
        else if (this.pathObject is PathObjectWait)
        {
            this.mechActionTypeEnum = ActionTypeEnum.Wait;
        }
    }

    public ActionReport(MechObject mechObject)
    {
        this.mechObject = mechObject;
        this.pathObject = new PathObjectWait(new List<CubeCoordinates>() { this.mechObject.GetMechBehavior().GetCubeCoordinates() });
        this.mechActionTypeEnum = ActionTypeEnum.Wait;
    }

    #endregion Public Constructors

    #region Public Methods

    public ActionTypeEnum GetMechActionType()
    {
        return this.mechActionTypeEnum;
    }

    public MechObject GetMechObject()
    {
        return this.mechObject;
    }

    public PathObject GetPathObject()
    {
        return this.pathObject;
    }

    public override string ToString()
    {
        return this.GetType().ToString() + ": " +
            "\n MechName=" + this.GetMechObject().GetMechName() +
            ",\n ActionType=" + this.GetMechActionType() +
            ",\n PathObject=[" + this.GetPathObject() + "]";
    }

    #endregion Public Methods
}