using System;
using System.Diagnostics;

/// <summary>
/// Todo
/// </summary>
public class CubeCoordinates
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    private readonly int xValue;

    private readonly int yValue;

    private readonly int zValue;

    #endregion Private Fields

    #region Public Constructors

    public CubeCoordinates(int x, int y, int z)
    {
        if (x + y + z == 0)
        {
            xValue = x;
            yValue = y;
            zValue = z;
        }
        else
        {
            throw new ArgumentException("Invalid parameters for " + this.GetType() +
                ". Parameters must sum to 0." +
                "\n x=" + x +
                "\n y=" + y +
                "\n z=" + z);
        }
    }

    /// <summary>
    /// Constructor method, to construct a Coordinates using the provided Coordinates
    /// </summary>
    /// <param name="coordinates">The coordinates that will provide the xCoord and yCoord</param>
    public CubeCoordinates(CubeCoordinates coordinates)
    {
        xValue = coordinates.GetX();
        yValue = coordinates.GetY();
        zValue = coordinates.GetZ();
    }

    #endregion Public Constructors

    #region Public Methods

    /// <summary>
    /// Comparison mehtod, to check if another Coordinates object equals this one
    /// </summary>
    /// <param name="obj">
    /// THe other Coordinates object to test if it is equal to this Coordinates objecy
    /// </param>
    /// <returns>True if the obj is equal to this coordinates, False otherwise</returns>
    public override bool Equals(object obj)
    {
        // Check if same type
        if (obj != null &&
            obj.GetType() == this.GetType())
        {
            CubeCoordinates OtherCoord = (CubeCoordinates)obj;
            bool SameX = this.GetX() == OtherCoord.GetX();
            bool SameY = this.GetY() == OtherCoord.GetY();
            bool SameZ = this.GetZ() == OtherCoord.GetZ();
            return SameX && SameY && SameZ;
        }
        else
        {
            return false;
        }
    }

    ////////////////////////
    // Comparison Methods
    ////////////////////////
    /// <summary>
    /// Comparison method, to get the hash code of this object
    /// </summary>
    /// <returns>The hash code representation of this object</returns>
    public override int GetHashCode()
    {
        return this.ToString().GetHashCode();
    }

    public int GetX()
    {
        return this.xValue;
    }

    public int GetY()
    {
        return this.yValue;
    }

    public int GetZ()
    {
        return this.zValue;
    }

    /// <summary>
    /// Comparison method, to get the hash code of this object
    /// </summary>
    /// <returns>The hash code representation of this object</returns>
    public override string ToString()
    {
        return string.Format("({0},{1},{2})",
            this.GetX(), this.GetY(), this.GetZ());
    }

    #endregion Public Methods
}