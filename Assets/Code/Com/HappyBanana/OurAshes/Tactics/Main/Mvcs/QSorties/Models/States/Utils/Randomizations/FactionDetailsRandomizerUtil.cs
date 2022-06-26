using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Utils.Enums;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Factions.Details.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Factions.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Factions.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Phalanxes.Details.Inters;
using System;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Models.States.Utils.Randomizations
{
    public class FactionDetailsRandomizerUtil
    {
        public static IList<IFactionDetails> Randomize(Random random, IFieldDetails fieldDetails)
        {
            IList<IFactionDetails> factionDetails = new List<IFactionDetails>();
            IDictionary<FactionID, IList<IPhalanxDetails>> factionPhalanxDetailsMap = BuildFactionPhalanxDetails(random, fieldDetails);

            foreach (FactionID id in EnumUtils.GetEnumListWithoutFirst<FactionID>())
            {
                if (!factionPhalanxDetailsMap.ContainsKey(id))
                {
                    factionPhalanxDetailsMap[id] = new List<IPhalanxDetails>();
                }
            }

            foreach (KeyValuePair<FactionID, IList<IPhalanxDetails>> factionPhalanxDetails in factionPhalanxDetailsMap)
            {
                FactionID factionID = factionPhalanxDetails.Key;
                IList<IPhalanxDetails> phalanxDetails = factionPhalanxDetails.Value;
                factionDetails.Add(
                    FactionDetailsImpl.Builder.Get()
                    .SetFactionID(factionID)
                    .SetPhalanxDetails(phalanxDetails)
                    .Build());
            }

            return factionDetails;
        }

        private static IDictionary<FactionID, IList<IPhalanxDetails>> BuildFactionPhalanxDetails(Random random, IFieldDetails fieldDetails)
        {
            IDictionary<FactionID, IList<IPhalanxDetails>> factionPhalanxDetails = new Dictionary<FactionID, IList<IPhalanxDetails>>();
            IList<IPhalanxDetails> phalanxDetails = PhalanxDetailsRandomizerUtil.Randomize(random, fieldDetails);
            // Check if this will be a free-for-all
            if (true)
            {
                factionPhalanxDetails.Add(FactionID.Delta, phalanxDetails);
            }
            else
            {
                /// Todo Add support for allied phalanxes
            }

            return factionPhalanxDetails;
        }
    }
}