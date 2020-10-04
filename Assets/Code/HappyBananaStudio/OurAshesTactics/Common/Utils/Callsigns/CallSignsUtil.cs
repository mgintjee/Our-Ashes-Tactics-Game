/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Enums;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Utils.Callsigns
{
    /// <summary>
    /// Todo
    /// </summary>
    public static class CallSignsUtil
    {
        // Todo
        private static Dictionary<CallSignEnum, string> callSignCharacterDictionary = new Dictionary<CallSignEnum, string>()
        {
            {CallSignEnum.Alpha, "\u0391" },
            {CallSignEnum.Beta, "\u0392" },
            {CallSignEnum.Gamma, "\u0393" },
            {CallSignEnum.Delta, "\u0394" },
            {CallSignEnum.Epsilon, "\u0395" },
            {CallSignEnum.Zeta, "\u0396" },
            {CallSignEnum.Eta, "\u0397" },
            {CallSignEnum.Theta, "\u0398" },
            {CallSignEnum.Iota, "\u0399" },
            {CallSignEnum.Kappa, "\u039A" },
            {CallSignEnum.Lambda, "\u039B" },
            {CallSignEnum.Mu, "\u039C" },
            {CallSignEnum.Nu, "\u039D" },
            {CallSignEnum.Xi, "\u039E" },
            {CallSignEnum.Omicron, "\u039F" },
            {CallSignEnum.Pi, "\u03A0" },
            {CallSignEnum.Rho, "\u03A1" },
            {CallSignEnum.Sigma, "\u03A3" },
            {CallSignEnum.Tau, "\u03A4" },
            {CallSignEnum.Upsilon, "\u03A5" },
            {CallSignEnum.Phi, "\u03A6" },
            {CallSignEnum.Chi, "\u03A7" },
            {CallSignEnum.Psi, "\u03A8" },
            {CallSignEnum.Omega, "\u03A9" },
        };

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="callSign">
        /// </param>
        /// <returns>
        /// </returns>
        public static string GetCharacter(CallSignEnum callSign)
        {
            string character = "-";
            if (callSignCharacterDictionary.ContainsKey(callSign))
            {
                character = callSignCharacterDictionary[callSign];
            }
            return character;
        }
    }
}