using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Apis.Loggers.Classes.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Apis.Optionals;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Internals.Optionals;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Managers.Loggers;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Phalanxes.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Phalanxes.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Sorties.Menus.Models.Utils.Queries
{
    /// <summary>
    /// Todo
    /// </summary>
    public class UnitDetailsQueryUtil
    {
        // Provides logging capability
        private static readonly IClassLogger logger = LoggerManager.GetLogger(MvcType.Common)
                .GetClassLogger(new StackFrame().GetMethod().DeclaringType);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="unitDetails"></param>
        /// <param name="unitID">     </param>
        /// <returns></returns>
        public static IOptional<IUnitDetails> GetDetails(IList<IUnitDetails> unitDetails, UnitID unitID)
        {
            IUnitDetails details = null;

            foreach (IUnitDetails ud in unitDetails)
            {
                if (ud.GetUnitID() == unitID)
                {
                    details = ud;
                }
            }
            logger.Debug("Found {} details for {}", details, unitID);

            return Optional<IUnitDetails>.Of(details);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="unitDetails">   </param>
        /// <param name="phalanxDetails"></param>
        /// <param name="phalanxID">     </param>
        /// <returns></returns>
        public static IList<IUnitDetails> GetDetails(IList<IUnitDetails> unitDetails, IList<IPhalanxDetails> phalanxDetails, PhalanxID phalanxID)
        {
            IList<IUnitDetails> details = new List<IUnitDetails>();

            PhalanxDetailsQueryUtil.GetDetails(phalanxDetails, phalanxID).IfPresent(pd =>
            {
                foreach (UnitID unitID in pd.GetUnitIDs())
                {
                    GetDetails(unitDetails, unitID).IfPresent(ud => details.Add(ud));
                }
            });
            logger.Debug("Found {} details for {}", details.Count, phalanxID);
            return details;
        }
    }
}