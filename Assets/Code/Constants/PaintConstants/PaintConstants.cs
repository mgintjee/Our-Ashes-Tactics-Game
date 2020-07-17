using System;

/// <summary>
/// Todo
/// </summary>
public static class PaintConstants
{
    #region Public Methods

    public static PaintColorEnum LoadRandomPaintColor()
    {
        return (PaintColorEnum)UnityEngine.Random.Range(0, Enum.GetValues(typeof(PaintColorEnum)).Length);
    }

    public static PaintSchemeReport LoadRandomPaintSchemeReport()
    {
        return new PaintSchemeReport.Builder()
            .SetPrimaryPaintColor(LoadRandomPaintColor())
            .SetSecondaryPaintColor(LoadRandomPaintColor())
            .Build();
    }

    #endregion Public Methods
}