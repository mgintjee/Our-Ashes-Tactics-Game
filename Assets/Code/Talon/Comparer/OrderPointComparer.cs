using System.Collections.Generic;

/// <summary>
/// Order Point Comparer for MechObjects
/// </summary>

public class OrderPointComparer
    : Comparer<TalonObject>
{
    #region Public Methods

    /// <summary>
    /// Compare 2 TalonObjects based off of their Order Points
    /// </summary>
    /// <param name="TalonObject">A TalonObject to compare with</param>
    /// <param name="TalonObject">A TalonObject to compare with</param>
    /// <returns>
    /// 1 if TalonObject B has more Order Points
    /// -1 if TalonObject A has more Order Points 0 if TalonObject are tied
    /// </returns>
    public override int Compare(TalonObject talonObjectLeft, TalonObject talonObjectRight)
    {
        // Check if Left is null or is unable to provide its order points
        if (talonObjectLeft == null ||
            talonObjectLeft.GetTalonAttributesReport() == null)
        {
            return 1;
        }
        // Check if Right is null or is unable to provide its order points
        else if (talonObjectRight == null ||
            talonObjectRight.GetTalonAttributesReport() == null)
        {
            return -1;
        }
        // Continue since they're both able to provide their order points
        else
        {
            // Collect the Order Points from both Left and Right
            int orderPointsLeft = talonObjectLeft.GetTalonAttributesReport().GetOrderPoints();
            int orderPointsRight = talonObjectRight.GetTalonAttributesReport().GetOrderPoints();
            // Check if the orderPoints for Left is less than the orderPoints for Right
            if (orderPointsLeft < orderPointsRight)
            {
                return 1;
            }
            // Otherwise Check if the orderPoints for Right is less than the orderPoints for Left
            else if (orderPointsLeft > orderPointsRight)
            {
                return -1;
            }
            // Otherwise they are tied
            else
            {
                return 0;
            }
        }
    }

    #endregion Public Methods
}