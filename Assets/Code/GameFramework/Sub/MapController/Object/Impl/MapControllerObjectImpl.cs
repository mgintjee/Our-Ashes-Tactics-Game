using System.Collections.Generic;
using System.Diagnostics;

/// <summary>
/// MapController Impl
/// </summary>
public class MapControllerObjectImpl
    : MapControllerObject
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    // Todo
    private GameFrameworkObject gameFrameworkObject;

    private TeamControllerTypeEnum team1Controller;
    private TeamControllerTypeEnum team2Controller;

    #endregion Private Fields

    #region Public Constructors

    /// <summary>
    /// Constructor Method, to construct the MapControllerObject
    /// </summary>
    public MapControllerObjectImpl(GameFrameworkObject gameFrameworkObject)
    {
        logger.Debug("Constructing Object=?", this.GetType().ToString());
        this.gameFrameworkObject = gameFrameworkObject;
        this.gameFrameworkObject.SetMapControllerObject(this);
        logger.Debug("Constructed Object=?", this.GetType().ToString());
    }

    #endregion Public Constructors

    #region Public Methods

    public override MechActionReport CollectMechActionReport(GameFrameworkObject gameFrameworkObject)
    {
        MechObject mechObject = this.gameFrameworkObject.GetNextMechObject();
        HashSet<MechActionReport> mechActionReportSet = mechObject.GetMechActionReportSet();
        logger.Debug("Possible Mech Action Reports: ?", string.Join("\n", mechActionReportSet));
        MechActionReport mechActionReport = ArtificialIntelligence.DetermineBestAction(mechActionReportSet);
        logger.Debug("Selected Mech Action Reports: ?", mechActionReport);
        return mechActionReport;
    }

    #endregion Public Methods
}