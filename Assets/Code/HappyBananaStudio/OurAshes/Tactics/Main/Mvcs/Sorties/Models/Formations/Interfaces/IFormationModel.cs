using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.CallSigns.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Phalanxes.CallSigns.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Formations.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Models.Rosters.Reports.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Formations.Interfaces
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IFormationModel
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IFormationReport GetReport();

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