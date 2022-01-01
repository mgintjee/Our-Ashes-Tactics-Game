using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.CallSigns;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Phalanxes.CallSigns;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Reports.Models.Engagements.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Reports.Models.Rosters.Inters;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Models.Engagements.Inters
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
        void Process(IRosterModelReport rosterReport);

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