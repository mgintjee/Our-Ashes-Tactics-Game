using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Factions.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Factions.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Phalanxes.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Phalanxes.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.IDs;
using System.Collections.Generic;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Loggers.Classes.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Factions.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Factions.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Phalanxes.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using System.Collections.Generic;
using System.Diagnostics;
namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Models.Utils.Mods
{
    /// <summary>
    /// Todo
    /// </summary>
    public class PhalanxDetailsQueryUtil
    {
        // Provides logging capability
        private static readonly IClassLogger logger = LoggerManager.GetLogger(MvcType.Common)
                .GetClassLogger(new StackFrame().GetMethod().DeclaringType);
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="phalanxDetails"></param>
        /// <param name="phalanxID"></param>
        /// <returns></returns>
        public static Optional<IPhalanxDetails> GetDetails(IList<IPhalanxDetails> phalanxDetails, PhalanxID phalanxID)
        {
            IPhalanxDetails details = null;

            foreach (IPhalanxDetails pd in phalanxDetails)
            {
                if (pd.GetPhalanxID() == phalanxID)
                {
                    details = pd;
                }
            }
            logger.Debug("Found {} for {}", details, phalanxID);

            return Optional<IPhalanxDetails>.Of(details);
        }
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="phalanxDetails"></param>
        /// <param name="unitID"></param>
        /// <returns></returns>
        public static Optional<IPhalanxDetails> GetDetails(IList<IPhalanxDetails> phalanxDetails, UnitID unitID)
        {
            IPhalanxDetails details = null;

            foreach (IPhalanxDetails pd in phalanxDetails)
            {
                if (pd.GetUnitIDs().Contains(unitID))
                {
                    details = pd;
                }
            }
            logger.Debug("Found {} for {}", details, unitID);

            return Optional<IPhalanxDetails>.Of(details);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="phalanxDetails"></param>
        /// <param name="factionDetails"></param>
        /// <param name="factionID"></param>
        /// <returns></returns>
        public static IList<IPhalanxDetails> GetDetails(IList<IPhalanxDetails> phalanxDetails, IList<IFactionDetails> factionDetails, FactionID factionID)
        {
            IList<IPhalanxDetails> details = new List<IPhalanxDetails>();

            FactionDetailsQueryUtil.GetDetails(factionDetails, factionID).IfPresent(fd =>
            {
                foreach (PhalanxID id in fd.GetPhalanxIDs())
                {
                    GetDetails(phalanxDetails, id).IfPresent(ud => details.Add(ud));
                }
            });
            logger.Debug("Found {} details for {}", details.Count, factionID);
            return details;
        }
    }
}