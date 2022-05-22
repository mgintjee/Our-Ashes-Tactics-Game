using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Classes.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.CallSigns;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Constants.Combatants;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Constants.Phalanxes;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Sizes;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Phalanxes.CallSigns;
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

        public static ISet<IPhalanxDetails> Randomize(Random random, IFieldDetails fieldDetails)
        {
            ISet<IPhalanxDetails> phalanxDetails = new HashSet<IPhalanxDetails>();

            FieldSize fieldSize = fieldDetails.GetFieldSize();
            int phalanxCount = GetPhalanxCount(random, fieldSize);
            int combatantCount = GetCombatantCount(random, fieldSize, phalanxCount);
            IDictionary<PhalanxCallSign, ISet<ICombatantDetails>> phalanxCombatantDetailsMap = BuildPhalanxCombatantDetails(random, phalanxCount, combatantCount);
            foreach (KeyValuePair<PhalanxCallSign, ISet<ICombatantDetails>> phalanxCombatantDetails in phalanxCombatantDetailsMap)
            {
                PhalanxCallSign phalanxCallSign = phalanxCombatantDetails.Key;
                ISet<ICombatantDetails> combatantDetails = phalanxCombatantDetails.Value;
                phalanxDetails.Add(
                    PhalanxDetailsImpl.Builder.Get()
                    .SetCallSign(phalanxCallSign)
                    .SetCombatantDetails(combatantDetails)
                    .Build());
            }
            logger.Debug("Randomized {}", phalanxDetails);
            return phalanxDetails;
        }

        private static IDictionary<PhalanxCallSign, ISet<ICombatantDetails>> BuildPhalanxCombatantDetails(Random random, int phalanxCount, int combatantCount)
        {
            IDictionary<PhalanxCallSign, ISet<ICombatantDetails>> phalanxCombatantDetails = new Dictionary<PhalanxCallSign, ISet<ICombatantDetails>>();

            ISet<PhalanxCallSign> phalanxCallSigns = BuildCallSigns(phalanxCount);
            foreach (PhalanxCallSign phalanxCallSign in phalanxCallSigns)
            {
                phalanxCombatantDetails.Add(phalanxCallSign, new HashSet<ICombatantDetails>());
            }

            for (int i = 0; i < combatantCount; ++i)
            {
                PhalanxCallSign phalanxCallSign = (PhalanxCallSign)(i % phalanxCount);
                CombatantCallSign combatantCallSign = (CombatantCallSign)i;
                ICombatantDetails combatantDetails = CombatantDetailsRandomizerUtil.Randomize(random, combatantCallSign);
                phalanxCombatantDetails[phalanxCallSign].Add(combatantDetails);
            }

            return phalanxCombatantDetails;
        }

        private static ISet<PhalanxCallSign> BuildCallSigns(int count)
        {
            ISet<PhalanxCallSign> callSigns = new HashSet<PhalanxCallSign>();

            for (int i = 0; i < count; ++i)
            {
                callSigns.Add((PhalanxCallSign)i);
            }

            return callSigns;
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