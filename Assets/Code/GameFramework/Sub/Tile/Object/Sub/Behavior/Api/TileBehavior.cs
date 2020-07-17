using System.Collections.Generic;

/// <summary>
/// API for TileBehavior
/// </summary>
public abstract class TileBehavior
{
    #region Protected Fields

    protected TileObject tileObject;

    #endregion Protected Fields

    #region Public Methods

    public static bool operator !=(TileBehavior left, TileBehavior right)
    {
        return !(left == right);
    }

    public static bool operator ==(TileBehavior left, TileBehavior right)
    {
        if (ReferenceEquals(left, right))
        {
            return true;
        }
        if (left is null)
        {
            return false;
        }
        if (right is null)
        {
            return false;
        }
        return left.Equals(right);
    }

    public override bool Equals(object obj)
    {
        // Check if parameter is non-null and the same type as this
        if (obj != null &&
            obj.GetType() == this.GetType())
        {
            TileBehavior otherTileBehavior = (TileBehavior)obj;
            return this.GetCubeCoordinates() == otherTileBehavior.GetCubeCoordinates();
        }
        else
        {
            return false;
        }
    }

    public abstract CubeCoordinates GetCubeCoordinates();

    public override int GetHashCode()
    {
        return this.GetCubeCoordinates().GetHashCode();
    }

    public abstract HashSet<CubeCoordinates> GetNeighborCubeCoordinatesSet();

    public abstract MechObject GetOccupyingMechObject();

    public abstract int GetTileFireCost();

    public abstract TileInfoReport GetTileInfoReport();

    public abstract int GetTileMoveCost();

    public abstract TileObjectTypeEnum GetTileObjectType();

    public abstract void SetOccupyingMechObject(MechObject mechObject);

    #endregion Public Methods
}