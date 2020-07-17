using System.Collections.Generic;

/// <summary>
/// Todo
/// </summary>
public class TileObjectTypeConstants
{
    #region Private Fields

    // Todo
    private static readonly Dictionary<TileObjectTypeEnum, int> TileTypeCounts =
        new Dictionary<TileObjectTypeEnum, int>
        {
            { TileObjectTypeEnum.Road, 2},
            { TileObjectTypeEnum.Plains, 3},
            { TileObjectTypeEnum.Forest, 2},
            { TileObjectTypeEnum.Mountain, 1},
            { TileObjectTypeEnum.Water, 1}
        };

    // Todo
    private static readonly Dictionary<TileObjectTypeEnum, float> TileTypeProbabilities =
        new Dictionary<TileObjectTypeEnum, float>
        {
            { TileObjectTypeEnum.Road, 1f},
            { TileObjectTypeEnum.Plains, 1f},
            { TileObjectTypeEnum.Forest, 1f},
            { TileObjectTypeEnum.Mountain, 1f},
            { TileObjectTypeEnum.Water, 1f}
        };

    #endregion Private Fields

    #region Public Methods

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public static Dictionary<TileObjectTypeEnum, int> GetTileObjectTypeDefaultCounts()
    {
        return new Dictionary<TileObjectTypeEnum, int>(TileTypeCounts);
    }

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public static Dictionary<TileObjectTypeEnum, float> GetTileObjectTypeProbabilities()
    {
        return new Dictionary<TileObjectTypeEnum, float>(TileTypeProbabilities);
    }

    #endregion Public Methods
}