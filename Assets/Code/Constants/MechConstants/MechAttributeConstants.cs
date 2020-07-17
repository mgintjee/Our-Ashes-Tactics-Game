using System;
using System.Collections.Generic;
using System.Diagnostics;

/// <summary>
/// Todo
/// </summary>
public static class MechAttributeConstants
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    // Todo
    private static readonly Dictionary<MechIdEnum, MechAttributes> MECH_ID_MECH_ATTRIBUTES_DICTIONARY = new Dictionary<MechIdEnum, MechAttributes>()
    {
        {MechIdEnum.Light, new MechAttributes.LightImpl()},
    };

    // Todo
    private static readonly Random random = new Random();

    #endregion Private Fields

    #region Public Methods

    /// <summary>
    /// Todo
    /// </summary>
    /// <param name="mechId"></param>
    /// <returns></returns>
    public static MechAttributes GetImplementedMechAttributes(MechIdEnum mechId)
    {
        logger.Debug("Attempting to Get Implemented MechAttributes: MechIdEnum=?", mechId);
        if (MECH_ID_MECH_ATTRIBUTES_DICTIONARY.ContainsKey(mechId))
        {
            return MECH_ID_MECH_ATTRIBUTES_DICTIONARY[mechId];
        }
        else
        {
            logger.Warn("Unable to get MechAttributes. MechIdEnum=? is not supported.", mechId);
        }
        return null;
    }

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public static MechIdEnum GetRandomMechId()
    {
        int randomIndex = random.Next() % MECH_ID_MECH_ATTRIBUTES_DICTIONARY.Keys.Count;
        return new List<MechIdEnum>(MECH_ID_MECH_ATTRIBUTES_DICTIONARY.Keys)[randomIndex];
    }

    #endregion Public Methods
}