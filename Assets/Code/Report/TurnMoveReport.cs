using System.Collections.Generic;

/// <summary>
/// Todo
/// </summary>
public class TurnMoveReport
    : TurnReport
{
    private readonly MechInfoReport actingMechInfoReport;
    private readonly PathObject pathObject;
    private readonly ActionTypeEnum actionType;
}