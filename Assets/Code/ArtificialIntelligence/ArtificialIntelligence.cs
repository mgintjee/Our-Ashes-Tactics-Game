using System;
using System.Collections.Generic;

/// <summary>
/// Workaround until I implement an actual AI
/// </summary>
public static class ArtificialIntelligence
{
    #region Public Methods

    public static TalonActionOrderReport DetermineBestAction(HashSet<TalonActionOrderReport> talonActionOrderReportSet)
    {
        if (talonActionOrderReportSet != null &&
            talonActionOrderReportSet.Count > 0)
        {
            int randomIndex = new Random().Next() % talonActionOrderReportSet.Count;
            return new List<TalonActionOrderReport>(talonActionOrderReportSet)[randomIndex];
        }
        else
        {
            throw new ArgumentException("Unable to DetermineBestAction. Invalid Parameters." +
                "\n\t>talonActionOrderReportSet is null/invalid: " +
                (talonActionOrderReportSet == null || talonActionOrderReportSet.Count < 1));
        }
    }

    #endregion Public Methods
}