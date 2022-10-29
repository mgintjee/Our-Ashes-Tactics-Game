using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Apis.Optionals;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Apis.Optionals;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Factions.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Factions.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Phalanxes.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Phalanxes.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.IDs;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Details.Inters
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface ICombatantsDetails
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IList<IFactionDetails> GetFactionDetails();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IList<IPhalanxDetails> GetPhalanxDetails();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IList<IUnitDetails> GetUnitDetails();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IOptional<IPhalanxDetails> GetPhalanxDetails(PhalanxID id);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IOptional<IUnitDetails> GetUnitDetails(UnitID id);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IOptional<IFactionDetails> GetFactionDetails(FactionID id);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IOptional<IPhalanxDetails> GetPhalanxDetails(UnitID id);
    }
}