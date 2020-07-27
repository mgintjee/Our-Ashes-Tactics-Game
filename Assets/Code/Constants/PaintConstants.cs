using System;

/// <summary>
/// Todo
/// </summary>
public static class PaintConstants
{
    #region Private Fields

    // Todo
    private static readonly Random random = new Random();

    #endregion Private Fields

    #region Public Methods

    public static ColorIdEnum LoadRandomPaintColor()
    {
        Array enumValues = Enum.GetValues(typeof(ColorIdEnum));
        return (ColorIdEnum)enumValues.GetValue(random.Next(enumValues.Length));
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