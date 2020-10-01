/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Enums;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Constants.Talons
{
    /// <summary>
    /// Todo
    /// </summary>
    public static class TalonPaintConstants
    {
        // Todo
        private static readonly string MECH_MODEL_NAME_COCKPIT = "MechCockpitModel";

        // Todo
        private static readonly string MECH_MODEL_NAME_LEGS = "MechLegsModel";

        // Todo
        private static readonly int MECH_MODEL_PAINT_INDEX_COCKPIT = 1;

        // Todo
        private static readonly int MECH_MODEL_PAINT_INDEX_LEGS = 2;

        // Todo
        private static readonly int MECH_MODEL_TILE_TOP_PAINT_INDEX_LEGS = 0;

        // Todo
        private static readonly Dictionary<string, int> MECH_NAME_PAINT_INDEX_DICTIONARY = new Dictionary<string, int>()
        {
            { TalonModelIdEnum.Talon0.ToString(), 1 },
            { TalonModelIdEnum.Talon1.ToString(), 1 },
            { TalonModelIdEnum.Talon2.ToString(), 1 },
        };

        // Todo
        private static readonly Dictionary<string, int> MECH_NAME_TILE_TOP_PAINT_INDEX_DICTIONARY = new Dictionary<string, int>()
        {
            { TalonModelIdEnum.Talon0.ToString(), 0 },
            { TalonModelIdEnum.Talon1.ToString(), 0 },
            { TalonModelIdEnum.Talon2.ToString(), 0 },
        };

        /// <summary>
        /// </summary>
        /// <param name="mechPartName">
        /// </param>
        /// <returns>
        /// </returns>
        public static int GetPaintIndexForTalonName(string mechPartName)
        {
            return (MECH_NAME_PAINT_INDEX_DICTIONARY.ContainsKey(mechPartName))
                ? MECH_NAME_PAINT_INDEX_DICTIONARY[mechPartName]
                : -1;
        }

        /// <summary>
        /// </summary>
        /// <param name="mechPartName">
        /// </param>
        /// <returns>
        /// </returns>
        public static int GetTilePaintIndexForName(string mechPartName)
        {
            return (MECH_NAME_TILE_TOP_PAINT_INDEX_DICTIONARY.ContainsKey(mechPartName))
                ? MECH_NAME_TILE_TOP_PAINT_INDEX_DICTIONARY[mechPartName]
                : -1;
        }
    }
}