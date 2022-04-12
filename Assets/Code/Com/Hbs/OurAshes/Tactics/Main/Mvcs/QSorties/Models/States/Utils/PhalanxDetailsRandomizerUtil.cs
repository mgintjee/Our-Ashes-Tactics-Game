using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Constants.Combatants;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Constants.Phalanxes;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Sizes;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Phalanxes.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Models.States.Impls;
using System;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Models.States.Utils
{
    public class PhalanxDetailsRandomizerUtil
    {
        private static readonly int MIN_PHALANX_COUNT = 2;
        public static ISet<IPhalanxDetails> Randomize(Random random, IFieldDetails fieldDetails)
        {
            ISet<IPhalanxDetails> phalanxDetails = new HashSet<IPhalanxDetails>();

            FieldSize fieldSize = fieldDetails.GetFieldSize();
            int phalanxCount = GetPhalanxCount(random, fieldSize);
            int combatantCount = GetCombatantCount(random, fieldSize, phalanxCount);


            return phalanxDetails;
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