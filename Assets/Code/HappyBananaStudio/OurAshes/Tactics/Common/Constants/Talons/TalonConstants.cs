/// <summary>
/// Company: HappyBananaStudio
/// Author: Matthew Gintjee
/// </summary>

namespace HappyBananaStudio.OurAshes.Tactics.Common.Constants.Talons
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Loggers;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Loggers;
    using System.Diagnostics;

    /// <summary>
    /// File to store all of the constants for the Talon
    /// </summary>
    public static class TalonConstants
    {
        // Provide logging capability
        private static readonly ICodeLogger logger = new CodeLoggerImpl(new StackFrame().GetMethod().DeclaringType);

        /// <summary>
        /// Store all of the constants related to the Roster Object
        /// </summary>
        public static class Object
        {
        }

        /// <summary>
        /// Store all of the constants related to the Roster Script
        /// </summary>
        public static class Script
        {
            // Todo
            private static readonly string PHALANX_INDEX__GAME_OBJECT_PREFIX = "PhanlanxIndex: ";

            // Todo
            private static readonly string TALON_ID_GAME_OBJECT_PREFIX = "TalonId: ";

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns>
            /// </returns>
            public static string GetPhalanxIndexGameObjectPrefix()
            {
                return PHALANX_INDEX__GAME_OBJECT_PREFIX;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns>
            /// </returns>
            public static string GetTalonIdGameObjectPrefix()
            {
                return TALON_ID_GAME_OBJECT_PREFIX;
            }
        }
    }
}
