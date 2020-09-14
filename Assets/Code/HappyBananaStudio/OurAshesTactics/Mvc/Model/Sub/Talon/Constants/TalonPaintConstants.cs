/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using System.Collections.Generic;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Constants
{
    /// <summary>
    /// Todo
    /// </summary>
    public static class TalonPaintConstants
    {
        #region Private Fields

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
            { MECH_MODEL_NAME_COCKPIT, MECH_MODEL_PAINT_INDEX_COCKPIT },
            { MECH_MODEL_NAME_LEGS, MECH_MODEL_PAINT_INDEX_LEGS },
        };

        // Todo
        private static readonly Dictionary<string, int> MECH_NAME_TILE_TOP_PAINT_INDEX_DICTIONARY = new Dictionary<string, int>()
        {
            { MECH_MODEL_NAME_LEGS, MECH_MODEL_TILE_TOP_PAINT_INDEX_LEGS },
        };

        #endregion Private Fields

        #region Public Methods

        /// <summary>
        /// </summary>
        /// <param name="mechPartName"></param>
        /// <returns></returns>
        public static int GetPaintIndexForName(string mechPartName)
        {
            return (MECH_NAME_PAINT_INDEX_DICTIONARY.ContainsKey(mechPartName))
                ? MECH_NAME_PAINT_INDEX_DICTIONARY[mechPartName]
                : -1;
        }

        /// <summary>
        /// </summary>
        /// <param name="mechPartName"></param>
        /// <returns></returns>
        public static int GetTilePaintIndexForName(string mechPartName)
        {
            return (MECH_NAME_TILE_TOP_PAINT_INDEX_DICTIONARY.ContainsKey(mechPartName))
                ? MECH_NAME_TILE_TOP_PAINT_INDEX_DICTIONARY[mechPartName]
                : -1;
        }

        #endregion Public Methods
    }
}