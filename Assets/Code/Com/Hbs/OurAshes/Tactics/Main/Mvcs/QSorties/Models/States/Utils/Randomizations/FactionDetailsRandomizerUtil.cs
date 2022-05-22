using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Factions.Details.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Factions.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Factions.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Phalanxes.Details.Inters;
using System;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Models.States.Utils.Randomizations
{
    public class FactionDetailsRandomizerUtil
    {
        public static ISet<IFactionDetails> Randomize(Random random, IFieldDetails fieldDetails)
        {
            ISet<IFactionDetails> factionDetails = new HashSet<IFactionDetails>();
            IDictionary<FactionID, ISet<IPhalanxDetails>> factionPhalanxDetailsMap = BuildFactionPhalanxDetails(random, fieldDetails);
            foreach (KeyValuePair<FactionID, ISet<IPhalanxDetails>> factionPhalanxDetails in factionPhalanxDetailsMap)
            {
                FactionID factionID = factionPhalanxDetails.Key;
                ISet<IPhalanxDetails> phalanxDetails = factionPhalanxDetails.Value;
                factionDetails.Add(
                    FactionDetailsImpl.Builder.Get()
                    .SetFactionID(factionID)
                    .SetPhalanxDetails(phalanxDetails)
                    .Build());
            }

            return factionDetails;
        }

        private static IDictionary<FactionID, ISet<IPhalanxDetails>> BuildFactionPhalanxDetails(Random random, IFieldDetails fieldDetails)
        {
            IDictionary<FactionID, ISet<IPhalanxDetails>> factionPhalanxDetails = new Dictionary<FactionID, ISet<IPhalanxDetails>>();
            ISet<IPhalanxDetails> phalanxDetails = PhalanxDetailsRandomizerUtil.Randomize(random, fieldDetails);
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