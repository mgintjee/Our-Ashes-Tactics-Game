
namespace HappyBananaStudio.OurAshes.Tactics.Common.Utils.Emblems
{
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Talons;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public static class CallSignsUtil
    {
        // Todo
        private static readonly IDictionary<CallSign, string> CallSignCharacterDictionary = new Dictionary<CallSign, string>()
        {
            {CallSign.Alpha, "\u0391" },
            {CallSign.Beta, "\u0392" },
            {CallSign.Gamma, "\u0393" },
            {CallSign.Delta, "\u0394" },
            {CallSign.Epsilon, "\u0395" },
            {CallSign.Zeta, "\u0396" },
            {CallSign.Eta, "\u0397" },
            {CallSign.Theta, "\u0398" },
            {CallSign.Iota, "\u0399" },
            {CallSign.Kappa, "\u039A" },
            {CallSign.Lambda, "\u039B" },
            {CallSign.Mu, "\u039C" },
            {CallSign.Nu, "\u039D" },
            {CallSign.Xi, "\u039E" },
            {CallSign.Omicron, "\u039F" },
            {CallSign.Pi, "\u03A0" },
            {CallSign.Rho, "\u03A1" },
            {CallSign.Sigma, "\u03A3" },
            {CallSign.Tau, "\u03A4" },
            {CallSign.Upsilon, "\u03A5" },
            {CallSign.Phi, "\u03A6" },
            {CallSign.Chi, "\u03A7" },
            {CallSign.Psi, "\u03A8" },
            {CallSign.Omega, "\u03A9" },
        };

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="callSign">
        /// </param>
        /// <returns>
        /// </returns>
        public static string GetCharacter(CallSign callSign)
        {
            string character = "-";
            if (CallSignCharacterDictionary.ContainsKey(callSign))
            {
                character = CallSignCharacterDictionary[callSign];
            }
            return character;
        }
    }
}
