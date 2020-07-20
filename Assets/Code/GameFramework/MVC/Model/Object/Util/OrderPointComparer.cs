using System.Collections.Generic;

/// <summary>
/// Order Point Comparer for MechObjects
/// </summary>

public class OrderPointComparer
    : Comparer<MechObject>
{
    #region Public Methods

    /// <summary>
    /// Compare 2 MechObjects based off of their Order Points
    /// </summary>
    /// <param name="mechObjectA">A MechObject to compare with</param>
    /// <param name="mechObjectB">A MechObject to compare with</param>
    /// <returns>
    /// 1 if MechObject B has more Order Points 2 if MechObject A has more Order Points 0 if
    /// MechObjects are tied
    /// </returns>
    public override int Compare(MechObject mechObjectA, MechObject mechObjectB)
    {
        // Collect the Order Points from the MechObjects
        int orderPointsA = mechObjectA.GetMechBehavior().GetCurrentOrderPoints();
        int orderPointsB = mechObjectB.GetMechBehavior().GetCurrentOrderPoints();
        // Check if the orderPoints for MechObject A is less than the orderPoints for MechObject B
        if (orderPointsA < orderPointsB)
        {
            return 1;
        }
        // Otherwise Check if the orderPoints for MechObject B is less than the orderPoints for
        // MechObject A
        else if (orderPointsA > orderPointsB)
        {
            return -1;
        }
        // Otherwise they are tied
        else
        {
            return 0;
        }
    }

    #endregion Public Methods
}