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
        logger.Debug("Attempting to Get Implemented ?: ?=?", typeof(MechAttributes), typeof(MechIdEnum), mechId);
        if (MECH_ID_MECH_ATTRIBUTES_DICTIONARY.ContainsKey(mechId))
        {
            return MECH_ID_MECH_ATTRIBUTES_DICTIONARY[mechId];
        }
        else
        {
            logger.Warn("Unable to get ?. ?=? is not supported.", typeof(MechAttributes), typeof(MechIdEnum), mechId);
        }
        return null;
    }

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public static MechIdEnum GetRandomMechId()
    {
        Array enumValues = Enum.GetValues(typeof(MechIdEnum));
        return (MechIdEnum)enumValues.GetValue(random.Next(enumValues.Length));
    }

    #endregion Public Methods
}