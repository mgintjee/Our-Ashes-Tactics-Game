using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Loggers.Classes.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Utils.Enums;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Details.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Factions.Constants;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Factions.Details.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Factions.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Factions.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Phalanxes.Constants;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Phalanxes.Details.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Phalanxes.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Phalanxes.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Constants;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Sizes;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Models.Utils.Randomizations
{
    public class CombatantsDetailsRandomizerUtil
    {
        private static readonly IClassLogger logger = LoggerManager.GetLogger(MvcType.Common)
                .GetClassLogger(new StackFrame().GetMethod().DeclaringType);

        public static ICombatantsDetails Randomize(Random random, FieldSize size)
        {
            int factionCount = GetFactionCount(random, size);
            int phalanxCount = GetPhalanxCount(random, size);
            int unitCount = GetUnitCount(random, size, phalanxCount);
            IList<IUnitDetails> unitDetails = RandomizeUnitDetails(random, unitCount);
            IList<IPhalanxDetails> phalanxDetails = RandomizePhlanaxDetails(random, phalanxCount, unitDetails);
            IList<IFactionDetails> factionDetails = RandomizeFactionDetails(random, factionCount, phalanxDetails);
            return CombatantsDetailsImpl.Builder.Get()
                .SetFactionDetails(factionDetails)
                .SetPhalanxDetails(phalanxDetails)
                .SetUnitDetails(unitDetails)
                .Build();
        }

        private static IList<IFactionDetails> RandomizeFactionDetails(Random random, int factionCount, IList<IPhalanxDetails> phalanxDetails)
        {
            // Todo: Use the random object
            IList<IFactionDetails> factionDetails = new List<IFactionDetails>();
            IList<FactionID> factionIDs = EnumUtils.GetEnumListWithoutFirst<FactionID>();
            IDictionary<FactionID, IList<PhalanxID>> factionPhalanxIDs = new Dictionary<FactionID, IList<PhalanxID>>();
            foreach (FactionID id in factionIDs)
            {
                factionPhalanxIDs.Add(id, new List<PhalanxID>());
            }
            if (factionCount == 1)
            {
                FactionID factionID = FactionID.Freelance;
                foreach (IPhalanxDetails details in phalanxDetails)
                {
                    factionPhalanxIDs[factionID].Add(details.GetPhalanxID());
                }
            }
            else
            {
                foreach (IPhalanxDetails details in phalanxDetails)
                {
                    PhalanxID phalanxID = details.GetPhalanxID();
                    FactionID factionID = (FactionID)(((int)phalanxID) % factionCount + 1);
                    factionPhalanxIDs[factionID].Add(details.GetPhalanxID());
                }
            }
            foreach (KeyValuePair<FactionID, IList<PhalanxID>> pairs in factionPhalanxIDs)
            {
                factionDetails.Add(FactionDetailsImpl.Builder.Get()
                    .SetFactionID(pairs.Key)
                    .SetPhalanxIDs(pairs.Value)
                    .Build());
            }
            return factionDetails;
        }

        private static IList<IPhalanxDetails> RandomizePhlanaxDetails(Random random, int phalanxCount, IList<IUnitDetails> unitDetails)
        {
            // Todo: Use the random object
            IList<IPhalanxDetails> phalanxDetails = new List<IPhalanxDetails>();
            IDictionary<PhalanxID, IList<UnitID>> phalanxUnitIDs = new Dictionary<PhalanxID, IList<UnitID>>();
            for (int i = 0; i < phalanxCount; ++i)
            {
                PhalanxID phalanxID = (PhalanxID)(i + 1);
                phalanxUnitIDs.Add(phalanxID, new List<UnitID>());
            }
            foreach (IUnitDetails details in unitDetails)
            {
                UnitID unitID = details.GetUnitID();
                PhalanxID phalanxID = (PhalanxID)(((int)unitID) % phalanxCount + 1);
                phalanxUnitIDs[phalanxID].Add(unitID);
            }
            foreach (KeyValuePair<PhalanxID, IList<UnitID>> pair in phalanxUnitIDs)
            {
                phalanxDetails.Add(PhalanxDetailsImpl.Builder.Get()
                    .SetPhalanxID(pair.Key)
                    .SetUnitIDs(pair.Value)
                    .Build());
            }
            return phalanxDetails;
        }

        private static IList<IUnitDetails> RandomizeUnitDetails(Random random, int unitCount)
        {
            IList<IUnitDetails> details = new List<IUnitDetails>();
            for (int i = 0; i < unitCount; ++i)
            {
                UnitID unitID = (UnitID)(i + 1);
                details.Add(UnitDetailsRandomizerUtil.Randomize(random, unitID));
            }
            return details;
        }

        private static int GetFactionCount(Random random, FieldSize fieldSize)
        {
            int maxFactionCount = FactionCountConstants.GetMaxCount(fieldSize);
            return random.Next(FactionCountConstants.MIN_COUNT, maxFactionCount);
        }

        private static int GetPhalanxCount(Random random, FieldSize fieldSize)
        {
            int maxPhalanxCount = PhalanxCountConstants.GetMaxCount(fieldSize);
            return random.Next(PhalanxCountConstants.MIN_COUNT, maxPhalanxCount);
        }

        private static int GetUnitCount(Random random, FieldSize fieldSize, int phalanxCount)
        {
            int maxUnitCount = UnitCountConstants.GetMaxCount(fieldSize, phalanxCount);
            return random.Next(phalanxCount, maxUnitCount);
        }
    }
}