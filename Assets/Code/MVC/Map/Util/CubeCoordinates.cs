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

    public CubeCoordinates(CubeCoordinates coordinates)
    {
        xValue = coordinates.GetX();
        yValue = coordinates.GetY();
        zValue = coordinates.GetZ();
    }

    #endregion Public Constructors

    #region Public Methods

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

    public override int GetHashCode()
    {
        // Auto-generated HashCode
        var hashCode = 230791427;
        hashCode = hashCode * -1521134295 + xValue.GetHashCode();
        hashCode = hashCode * -1521134295 + yValue.GetHashCode();
        hashCode = hashCode * -1521134295 + zValue.GetHashCode();
        return hashCode;
    }

    public CubeCoordinates GetNegatedCubeCoordinates()
    {
        return new CubeCoordinates(-this.xValue, -this.yValue, -this.zValue);
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

    public override string ToString()
    {
        return string.Format("({0},{1},{2})",
            this.GetX(), this.GetY(), this.GetZ());
    }

    #endregion Public Methods
}