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
    private static readonly Dictionary<TileObjectTypeEnum, int> TILE_OBJECT_TYPE_FIRE_COST_DICTIONARY = new Dictionary<TileObjectTypeEnum, int>()
    {
        {TileObjectTypeEnum.Road, 0 },
        {TileObjectTypeEnum.Plains, 5 },
        {TileObjectTypeEnum.Forest, 20 },
        {TileObjectTypeEnum.Mountain, 35 },
        {TileObjectTypeEnum.Water, 5 },
    };

    // Todo
    private static readonly Dictionary<TileObjectTypeEnum, int> TILE_OBJECT_TYPE_MOVE_COST_DICTIONARY = new Dictionary<TileObjectTypeEnum, int>()
    {
        {TileObjectTypeEnum.Road, 1 },
        {TileObjectTypeEnum.Plains, 2 },
        {TileObjectTypeEnum.Forest, 3 },
        {TileObjectTypeEnum.Mountain, 4 },
        {TileObjectTypeEnum.Water, 3 },
    };

    #endregion Private Fields

    #region Public Methods

    /// <summary>
    /// </summary>
    /// <param name="tileObjectType"></param>
    /// <returns></returns>
    public static int GetTileObjectTypeFireCost(TileObjectTypeEnum tileObjectType)
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
    public static int GetTileObjectTypeMoveCost(TileObjectTypeEnum tileObjectType)
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