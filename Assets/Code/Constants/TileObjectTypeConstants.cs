using System.Collections.Generic;

/// <summary>
/// Todo
/// </summary>
public class TileObjectTypeConstants
{
    #region Private Fields

    // Todo
    private static readonly Dictionary<TileTypeEnum, int> TileTypeCounts =
        new Dictionary<TileTypeEnum, int>
        {
            { TileTypeEnum.Road, 2},
            { TileTypeEnum.Plains, 3},
            { TileTypeEnum.Forest, 2},
            { TileTypeEnum.Mountain, 1},
            { TileTypeEnum.Water, 1}
        };

    // Todo
    private static readonly Dictionary<TileTypeEnum, float> TileTypeProbabilities =
        new Dictionary<TileTypeEnum, float>
        {
            { TileTypeEnum.Road, 1f},
            { TileTypeEnum.Plains, 1f},
            { TileTypeEnum.Forest, 1f},
            { TileTypeEnum.Mountain, 1f},
            { TileTypeEnum.Water, 1f}
        };

    #endregion Private Fields

    #region Public Methods

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public static Dictionary<TileTypeEnum, int> GetTileObjectTypeDefaultCounts()
    {
        return new Dictionary<TileTypeEnum, int>(TileTypeCounts);
    }

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public static Dictionary<TileTypeEnum, float> GetTileObjectTypeProbabilities()
    {
        return new Dictionary<TileTypeEnum, float>(TileTypeProbabilities);
    }

    #endregion Public Methods
}