using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Factions.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Phalanxes.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Icons.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Patterns.Details.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Factions.Details.Inters
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IFactionDetails
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        FactionID GetFactionID();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IList<PhalanxID> GetPhalanxIDs();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IPatternDetails GetPatternDetails();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IIconDetails GetIconDetails();
    }
}