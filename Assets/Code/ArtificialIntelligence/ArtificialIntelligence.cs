using System;
using System.Collections.Generic;
using System.Diagnostics;

/// <summary>
/// </summary>
public static class ArtificialIntelligence
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    #endregion Private Fields

    #region Public Methods

    /// <summary>
    /// </summary>
    /// <param name="mechActionReportSet"></param>
    /// <returns></returns>
    public static ActionReport DetermineBestAction(HashSet<ActionReport> mechActionReportSet)
    {
        // Todo: Make this null-pointer safe
        int randomIndex = new Random().Next() % mechActionReportSet.Count;
        return new List<ActionReport>(mechActionReportSet)[randomIndex];
    }

    #endregion Public Methods
}