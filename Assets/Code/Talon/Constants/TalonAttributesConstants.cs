using System.Collections.Generic;

/// <summary>
/// Object to store the constant numerical attributes of supported Talons
/// </summary>
public class TalonAttributesConstants
{
    #region Private Fields

    private static readonly Dictionary<TalonIdEnum, TalonAttributes> TALON_ID_ATTRIBUTES_DICTIONARY = new Dictionary<TalonIdEnum, TalonAttributes>()
    {
        {
            TalonIdEnum.CreativeName1,
            new TalonAttributes.Builder()
            .SetArmourPoints(1)
            .SetHealthPoints(16)
            .SetMovePoints(8)
            .SetTurnPoints(3)
            .SetWeaponPoints(2)
            .Build()
        },
    };

    #endregion Private Fields

    #region Public Methods

    /// <summary>
    /// Todo
    /// </summary>
    /// <param name="talonId"></param>
    /// <returns></returns>
    public static TalonAttributes GetAttributes(TalonIdEnum talonId)
    {
        if (TALON_ID_ATTRIBUTES_DICTIONARY.ContainsKey(talonId))
        {
            return TALON_ID_ATTRIBUTES_DICTIONARY[talonId];
        }
        return null;
    }

    #endregion Public Methods
}