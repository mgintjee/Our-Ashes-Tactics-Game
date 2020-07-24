using System.Collections.Generic;
using System.Diagnostics;

/// <summary>
/// Controller Object Impl
/// </summary>
public class ControllerObjectImpl
    : ControllerObject
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    // Todo
    private GameFrameworkObject gameFrameworkObject;

    #endregion Private Fields

    #region Public Constructors

    /// <summary>
    /// </summary>
    /// <param name="gameFrameworkObject"></param>
    public ControllerObjectImpl(GameFrameworkObject gameFrameworkObject)
    {
        logger.Debug("Constructing Object=?", this.GetType().ToString());
        this.gameFrameworkObject = gameFrameworkObject;
        this.gameFrameworkObject.SetMapControllerObject(this);
        logger.Debug("Constructed Object=?", this.GetType().ToString());
    }

    #endregion Public Constructors

    #region Public Methods

    /// <summary>
    /// </summary>
    /// <param name="mechObject"></param>
    /// <returns></returns>
    public override ActionReport CollectMechActionReport(MechObject mechObject)
    {
        HashSet<ActionReport> mechActionReportSet = mechObject.GetMechActionReportSet();
        logger.Debug("Possible Mech Action Reports: ?", string.Join("\n", mechActionReportSet));
        // Todo: Determine which robot should do this
        ActionReport mechActionReport = ArtificialIntelligence.DetermineBestAction(mechActionReportSet);
        logger.Debug("Selected Mech Action Reports: ?", mechActionReport);
        return mechActionReport;
    }

    #endregion Public Methods
}