using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Classes.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Constants.Combatants;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Constants.Phalanxes;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Sizes;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Phalanxes.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Phalanxes.Details.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Phalanxes.Details.Inters;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Models.States.Utils.Randomizations
{
    public class PhalanxDetailsRandomizerUtil
    {
        private static readonly int MIN_PHALANX_COUNT = 2;

        private static readonly IClassLogger logger = LoggerManager.GetLogger(MvcType.Common)
                .GetClassLogger(new StackFrame().GetMethod().DeclaringType);

        public static IList<IPhalanxDetails> Randomize(Random random, IFieldDetails fieldDetails)
        {
            IList<IPhalanxDetails> phalanxDetails = new List<IPhalanxDetails>();

            FieldSize fieldSize = fieldDetails.GetFieldSize();
            int phalanxCount = GetPhalanxCount(random, fieldSize);
            int combatantCount = GetCombatantCount(random, fieldSize, phalanxCount);
            IDictionary<PhalanxID, IList<ICombatantDetails>> phalanxCombatantDetailsMap = BuildPhalanxCombatantDetails(random, phalanxCount, combatantCount);
            foreach (KeyValuePair<PhalanxID, IList<ICombatantDetails>> phalanxCombatantDetails in phalanxCombatantDetailsMap)
            {
                PhalanxID phalanxID = phalanxCombatantDetails.Key;
                IList<ICombatantDetails> combatantDetails = phalanxCombatantDetails.Value;
                phalanxDetails.Add(
                    PhalanxDetailsImpl.Builder.Get()
                    .SetID(phalanxID)
                    .SetCombatantDetails(combatantDetails)
                    .Build());
            }
            logger.Debug("Randomized {}", phalanxDetails);
            return phalanxDetails;
        }

        private static IDictionary<PhalanxID, IList<ICombatantDetails>> BuildPhalanxCombatantDetails(Random random, int phalanxCount, int combatantCount)
        {
            IDictionary<PhalanxID, IList<ICombatantDetails>> phalanxCombatantDetails = new Dictionary<PhalanxID, IList<ICombatantDetails>>();

            IList<PhalanxID> phalanxIDs = BuildIDs(phalanxCount);
            foreach (PhalanxID phalanxID in phalanxIDs)
            {
                phalanxCombatantDetails.Add(phalanxID, new List<ICombatantDetails>());
            }

            for (int i = 0; i < combatantCount; ++i)
            {
                PhalanxID phalanxID = (PhalanxID)((i % phalanxCount)+1);
                CombatantID combatantID = (CombatantID)(i+1);
                ICombatantDetails combatantDetails = CombatantDetailsRandomizerUtil.Randomize(random, combatantID);
                phalanxCombatantDetails[phalanxID].Add(combatantDetails);
            }

            return phalanxCombatantDetails;
        }

        private static IList<PhalanxID> BuildIDs(int count)
        {
            IList<PhalanxID> ids = new List<PhalanxID>();

            for (int i = 0; i < count; ++i)
            {
                ids.Add((PhalanxID)(i+1));
            }

            return ids;
        }

        private static int GetPhalanxCount(Random random, FieldSize fieldSize)
        {
            int maxPhalanxCount = PhalanxCountConstants.GetMaxPhalanxCounts(fieldSize);
            return random.Next(MIN_PHALANX_COUNT, maxPhalanxCount);
        }

        private static int GetCombatantCount(Random random, FieldSize fieldSize, int phalanxCount)
        {
            int maxCombatantCount = CombatantCountConstants.GetMaxCombatantCounts(fieldSize, phalanxCount);
            return random.Next(phalanxCount, maxCombatantCount);
        }
    }
}