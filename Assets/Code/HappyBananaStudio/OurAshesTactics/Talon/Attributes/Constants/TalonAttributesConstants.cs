/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Common.Exceptions;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Enums;
using HappyBananaStudio.OurAshesTactics.Talon.Attributes.Api;
using HappyBananaStudio.OurAshesTactics.Talon.Attributes.Impl;
using System.Collections.Generic;
using System.Diagnostics;

namespace HappyBananaStudio.OurAshesTactics.Talon.Attributes.Constants
{
    /// <summary>
    /// Object to store the constant numerical attributes of supported Talons
    /// </summary>
    public class TalonAttributesConstants
    {
        #region Private Fields

        // Todo
        private static readonly Dictionary<TalonIdEnum, ITalonAttributes> TALON_ID_ATTRIBUTES_DICTIONARY =
            new Dictionary<TalonIdEnum, ITalonAttributes>()
        {
            {
                TalonIdEnum.Talon0,
                new TalonAttributesImpl(
                    new DestructableAttributesImpl(2, 16),
                    new FireableAttributesImpl(2),
                    new MoveableAttributesImpl(12, 3)
                    )
            },
            {
                TalonIdEnum.Talon1,
                new TalonAttributesImpl(
                    new DestructableAttributesImpl(1, 12),
                    new FireableAttributesImpl(1),
                    new MoveableAttributesImpl(16, 4)
                    )
            },
            {
                TalonIdEnum.Talon2,
                new TalonAttributesImpl(
                    new DestructableAttributesImpl(3, 20),
                    new FireableAttributesImpl(3),
                    new MoveableAttributesImpl(8, 2)
                    )
            },
        };

        #endregion Private Fields

        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonId"></param>
        /// <returns></returns>
        public static ITalonAttributes GetAttributes(TalonIdEnum talonId)
        {
            if (TALON_ID_ATTRIBUTES_DICTIONARY.ContainsKey(talonId))
            {
                return TALON_ID_ATTRIBUTES_DICTIONARY[talonId];
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                    new StackFrame().GetMethod().Name, talonId);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static HashSet<TalonIdEnum> GetSupportedTalonIds()
        {
            return new HashSet<TalonIdEnum>(TALON_ID_ATTRIBUTES_DICTIONARY.Keys);
        }

        #endregion Public Methods
    }
}