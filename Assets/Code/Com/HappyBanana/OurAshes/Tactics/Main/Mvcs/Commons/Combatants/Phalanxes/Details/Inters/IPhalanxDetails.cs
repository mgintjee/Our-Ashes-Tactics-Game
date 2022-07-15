using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Phalanxes.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Icons.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Patterns.Details.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Phalanxes.Details.Inters
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IPhalanxDetails
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        PhalanxID GetPhalanxID();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IList<UnitID> GetUnitIDs();

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