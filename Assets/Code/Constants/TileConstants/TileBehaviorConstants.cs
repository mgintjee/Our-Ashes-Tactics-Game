using System.Collections.Generic;
using System.Diagnostics;

/// <summary>
/// TileObjectType Enum
/// </summary>
public class TileBehaviorConstants
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    // Todo
    private static readonly Dictionary<TileTypeEnum, int> TILE_OBJECT_TYPE_FIRE_COST_DICTIONARY = new Dictionary<TileTypeEnum, int>()
    {
        {TileTypeEnum.Road, 0 },
        {TileTypeEnum.Plains, 5 },
        {TileTypeEnum.Forest, 20 },
        {TileTypeEnum.Mountain, 35 },
        {TileTypeEnum.Water, 5 },
    };

    // Todo
    private static readonly Dictionary<TileTypeEnum, int> TILE_OBJECT_TYPE_MOVE_COST_DICTIONARY = new Dictionary<TileTypeEnum, int>()
    {
        {TileTypeEnum.Road, 1 },
        {TileTypeEnum.Plains, 2 },
        {TileTypeEnum.Forest, 3 },
        {TileTypeEnum.Mountain, 4 },
        {TileTypeEnum.Water, 3 },
    };

    #endregion Private Fields

    #region Public Methods

    /// <summary>
    /// </summary>
    /// <param name="tileObjectType"></param>
    /// <returns></returns>
    public static int GetTileObjectTypeFireCost(TileTypeEnum tileObjectType)
    {
        if (TILE_OBJECT_TYPE_FIRE_COST_DICTIONARY.ContainsKey(tileObjectType))
        {
            return TILE_OBJECT_TYPE_FIRE_COST_DICTIONARY[tileObjectType];
        }
        else
        {
            logger.Warn("Unable to get FireCost. TILE_OBJECT_TYPE_FIRE_COST_DICTIONARY does not contain TileObjectType: ?", tileObjectType);
        }
        return int.MaxValue;
    }

    /// <summary>
    /// </summary>
    /// <param name="tileObjectType"></param>
    /// <returns></returns>
    public static int GetTileObjectTypeMoveCost(TileTypeEnum tileObjectType)
    {
        if (TILE_OBJECT_TYPE_MOVE_COST_DICTIONARY.ContainsKey(tileObjectType))
        {
            return TILE_OBJECT_TYPE_MOVE_COST_DICTIONARY[tileObjectType];
        }
        else
        {
            logger.Warn("Unable to get MoveCost. TILE_OBJECT_TYPE_MOVE_COST_DICTIONARY does not contain TileObjectType: ?", tileObjectType);
        }
        return int.MaxValue;
    }

    #endregion Public Methods
}