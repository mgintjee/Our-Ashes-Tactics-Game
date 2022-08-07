﻿using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Loggers.Classes.Inters;
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
    public class FactionDetailsQueryUtil
    {
        // Provides logging capability
        private static readonly IClassLogger logger = LoggerManager.GetLogger(MvcType.Common)
                .GetClassLogger(new StackFrame().GetMethod().DeclaringType);
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="factionDetails"></param>
        /// <param name="factionID"></param>
        /// <returns></returns>
        public static Optional<IFactionDetails> GetDetails(IList<IFactionDetails> factionDetails, FactionID factionID)
        {
            IFactionDetails details = null;

            foreach (IFactionDetails fd in factionDetails)
            {
                if (fd.GetFactionID() == factionID)
                {
                    details = fd;
                }
            }
            logger.Debug("Found {} for {}", details, factionID);
            return Optional<IFactionDetails>.Of(details);
        }
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="factionDetails"></param>
        /// <param name="phalanxID"></param>
        /// <returns></returns>
        public static Optional<IFactionDetails> GetDetails(IList<IFactionDetails> factionDetails, PhalanxID phalanxID)
        {
            IFactionDetails details = null;

            foreach (IFactionDetails fd in factionDetails)
            {
                if (fd.GetPhalanxIDs().Contains(phalanxID))
                {
                    details = fd;
                }
            }
            logger.Debug("Found {} for {}", details, phalanxID);

            return Optional<IFactionDetails>.Of(details);
        }
    }
}