using System.Collections.Generic;

/// <summary>
/// Todo
/// </summary>
public class TurnFireReport
    : TurnReport
{
    private readonly MechInfoReport actingMechInfoReport;
    private readonly MechInfoReport targetMechInfoReport;
    private readonly PathObject pathObject;
    private readonly ActionTypeEnum actionType;
}