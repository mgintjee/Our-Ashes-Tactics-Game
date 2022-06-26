using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Loggers.Classes.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Units.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Units.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Constants.Units;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Constants.Phalanxes;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Sizes;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Phalanxes.Details.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Phalanxes.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Phalanxes.IDs;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Models.States.Utils.Randomizations
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
            int unitCount = GetUnitCount(random, fieldSize, phalanxCount);
            IDictionary<PhalanxID, IList<IUnitDetails>> phalanxUnitDetailsMap = BuildPhalanxUnitDetails(random, phalanxCount, unitCount);
            foreach (KeyValuePair<PhalanxID, IList<IUnitDetails>> phalanxUnitDetails in phalanxUnitDetailsMap)
            {
                PhalanxID phalanxID = phalanxUnitDetails.Key;
                IList<IUnitDetails> unitDetails = phalanxUnitDetails.Value;
                phalanxDetails.Add(
                    PhalanxDetailsImpl.Builder.Get()
                    .SetID(phalanxID)
                    .SetUnitDetails(unitDetails)
                    .Build());
            }
            logger.Debug("Randomized {}", phalanxDetails);
            return phalanxDetails;
        }

        private static IDictionary<PhalanxID, IList<IUnitDetails>> BuildPhalanxUnitDetails(Random random, int phalanxCount, int unitCount)
        {
            IDictionary<PhalanxID, IList<IUnitDetails>> phalanxUnitDetails = new Dictionary<PhalanxID, IList<IUnitDetails>>();

            IList<PhalanxID> phalanxIDs = BuildIDs(phalanxCount);
            foreach (PhalanxID phalanxID in phalanxIDs)
            {
                phalanxUnitDetails.Add(phalanxID, new List<IUnitDetails>());
            }

            for (int i = 0; i < unitCount; ++i)
            {
                PhalanxID phalanxID = (PhalanxID)((i % phalanxCount) + 1);
                UnitID unitID = (UnitID)(i + 1);
                IUnitDetails unitDetails = UnitDetailsRandomizerUtil.Randomize(random, unitID);
                phalanxUnitDetails[phalanxID].Add(unitDetails);
            }

            return phalanxUnitDetails;
        }

        private static IList<PhalanxID> BuildIDs(int count)
        {
            IList<PhalanxID> ids = new List<PhalanxID>();

            for (int i = 0; i < count; ++i)
            {
                ids.Add((PhalanxID)(i + 1));
            }

            return ids;
        }

        private static int GetPhalanxCount(Random random, FieldSize fieldSize)
        {
            int maxPhalanxCount = PhalanxCountConstants.GetMaxPhalanxCounts(fieldSize);
            return random.Next(MIN_PHALANX_COUNT, maxPhalanxCount);
        }

        private static int GetUnitCount(Random random, FieldSize fieldSize, int phalanxCount)
        {
            int maxUnitCount = UnitCountConstants.GetMaxUnitCounts(fieldSize, phalanxCount);
            return random.Next(phalanxCount, maxUnitCount);
        }
    }
}