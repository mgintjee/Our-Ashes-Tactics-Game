﻿using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Classes.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.CallSigns;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Constants.Combatants;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Constants.Phalanxes;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Sizes;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
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
            IDictionary<CallSign, ISet<ICombatantDetails>> phalanxCombatantDetailsMap = BuildPhalanxCombatantDetails(random, phalanxCount, combatantCount);
            foreach (KeyValuePair<CallSign, ISet<ICombatantDetails>> phalanxCombatantDetails in phalanxCombatantDetailsMap)
            {
                CallSign phalanxCallSign = phalanxCombatantDetails.Key;
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

        private static IDictionary<CallSign, ISet<ICombatantDetails>> BuildPhalanxCombatantDetails(Random random, int phalanxCount, int combatantCount)
        {
            IDictionary<CallSign, ISet<ICombatantDetails>> phalanxCombatantDetails = new Dictionary<CallSign, ISet<ICombatantDetails>>();

            ISet<CallSign> phalanxCallSigns = BuildCallSigns(phalanxCount);
            foreach (CallSign phalanxCallSign in phalanxCallSigns)
            {
                phalanxCombatantDetails.Add(phalanxCallSign, new HashSet<ICombatantDetails>());
            }

            for (int i = 0; i < combatantCount; ++i)
            {
                CallSign phalanxCallSign = (CallSign)(i % phalanxCount);
                CallSign combatantCallSign = (CallSign)i;
                ICombatantDetails combatantDetails = CombatantDetailsRandomizerUtil.Randomize(random, combatantCallSign);
                phalanxCombatantDetails[phalanxCallSign].Add(combatantDetails);
            }

            return phalanxCombatantDetails;
        }

        private static ISet<CallSign> BuildCallSigns(int count)
        {
            ISet<CallSign> callSigns = new HashSet<CallSign>();

            for (int i = 0; i < count; ++i)
            {
                callSigns.Add((CallSign)i);
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