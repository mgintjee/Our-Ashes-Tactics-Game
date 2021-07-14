﻿using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.CallSigns;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Phalanxes.CallSigns;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Engagements.Interfaces
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IEngagementModel
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IEngagementReport GetReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="rosterReport"></param>
        void Process(IRosterReport rosterReport);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="callSignA"></param>
        /// <param name="callSignB"></param>
        /// <returns></returns>
        bool AreFriendly(PhalanxCallSign callSignA, PhalanxCallSign callSignB);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="callSignA"></param>
        /// <param name="callSignB"></param>
        /// <returns></returns>
        bool AreFriendly(CombatantCallSign callSignA, CombatantCallSign callSignB);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="combatantCallSign"></param>
        /// <param name="phalanxCallSign">  </param>
        /// <returns></returns>
        bool AreFriendly(CombatantCallSign combatantCallSign, PhalanxCallSign phalanxCallSign);
    }
}