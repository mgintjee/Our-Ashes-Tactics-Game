using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Factions.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Factions.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Phalanxes.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Phalanxes.Details.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Models.States.Utils.Queries
{
    public static class MvcModelStateQueryUtil
    {
        public static Optional<IFactionDetails> GetFactionDetails(Inters.IMvcModelState mvcModelState, FactionID factionID)
        {
            IFactionDetails returnedFactionDetails = null;

            IList<IFactionDetails> factionDetailsSet = mvcModelState.GetFactionDetails();
            foreach (IFactionDetails factionDetails in factionDetailsSet)
            {
                if (factionDetails.GetFactionID() == factionID)
                {
                    returnedFactionDetails = factionDetails;
                    break;
                }
            }

            return Optional<IFactionDetails>.Of(returnedFactionDetails);
        }

        public static Optional<IPhalanxDetails> GetPhalanxDetails(Inters.IMvcModelState mvcModelState, PhalanxID phalanxID)
        {
            IPhalanxDetails returnedPhalanxDetails = null;

            IList<IFactionDetails> factionDetailsSet = mvcModelState.GetFactionDetails();
            foreach (IFactionDetails factionDetails in factionDetailsSet)
            {
                Optional<IPhalanxDetails> possiblePhalanxDetails = GetPhalanxDetails(phalanxID, factionDetails.GetPhalanxDetails());
                if (possiblePhalanxDetails.IsPresent())
                {
                    returnedPhalanxDetails = possiblePhalanxDetails.GetValue();
                    break;
                }
            }

            return Optional<IPhalanxDetails>.Of(returnedPhalanxDetails);
        }

        public static Optional<IPhalanxDetails> GetPhalanxDetails(PhalanxID phalanxID, IList<IPhalanxDetails> phalanxDetailsSet)
        {
            IPhalanxDetails returnedPhalanxDetails = null;
            foreach (IPhalanxDetails phalanxDetails in phalanxDetailsSet)
            {
                if (phalanxDetails.GetID() == phalanxID)
                {
                    returnedPhalanxDetails = phalanxDetails;
                    break;
                }
            }
            return Optional<IPhalanxDetails>.Of(returnedPhalanxDetails);
        }

        public static Optional<ICombatantDetails> GetCombatantDetails(Inters.IMvcModelState mvcModelState, CombatantID combatantID)
        {
            ICombatantDetails returnedCombatantDetails = null;

            IList<IFactionDetails> factionDetailsSet = mvcModelState.GetFactionDetails();
            foreach (IFactionDetails factionDetails in factionDetailsSet)
            {
                Optional<ICombatantDetails> possibleCombatantDetails = GetCombatantDetails(combatantID, factionDetails.GetPhalanxDetails());
                if (possibleCombatantDetails.IsPresent())
                {
                    returnedCombatantDetails = possibleCombatantDetails.GetValue();
                    break;
                }
            }

            return Optional<ICombatantDetails>.Of(returnedCombatantDetails);
        }

        public static FactionID GetFactionIDFromCombatant(Inters.IMvcModelState mvcModelState, CombatantID combatantID)
        {
            PhalanxID phalanxID = GetPhalanxIDFromCombatant(mvcModelState, combatantID);
            FactionID factionID = GetFactionIDFromPhalanx(mvcModelState, phalanxID);
            return factionID;
        }

        public static FactionID GetFactionIDFromPhalanx(Inters.IMvcModelState mvcModelState, PhalanxID phalanxID)
        {
            FactionID factionID = FactionID.None;

            foreach (IFactionDetails factionDetails in mvcModelState.GetFactionDetails())
            {
                Optional<IPhalanxDetails> phalanxDetails = GetPhalanxDetails(phalanxID, factionDetails.GetPhalanxDetails());
                if (phalanxDetails.IsPresent())
                {
                    factionID = factionDetails.GetFactionID();
                    break;
                }
            }

            return factionID;
        }

        public static PhalanxID GetPhalanxIDFromCombatant(Inters.IMvcModelState mvcModelState, CombatantID combatantID)
        {
            PhalanxID phalanxID = PhalanxID.None;

            foreach (IFactionDetails factionDetails in mvcModelState.GetFactionDetails())
            {
                phalanxID = GetPhalanxIDFromCombatant(combatantID, factionDetails.GetPhalanxDetails());
                if (phalanxID != PhalanxID.None)
                {
                    break;
                }
            }

            return phalanxID;
        }

        private static Optional<ICombatantDetails> GetCombatantDetails(CombatantID combatantID, IList<IPhalanxDetails> phalanxDetailsSet)
        {
            ICombatantDetails returnedCombatantDetails = null;
            foreach (IPhalanxDetails phalanxDetails in phalanxDetailsSet)
            {
                Optional<ICombatantDetails> possibleCombatantDetails = GetCombatantDetails(combatantID, phalanxDetails.GetCombatantDetails());
                if (possibleCombatantDetails.IsPresent())
                {
                    returnedCombatantDetails = possibleCombatantDetails.GetValue();
                    break;
                }
            }
            return Optional<ICombatantDetails>.Of(returnedCombatantDetails);
        }

        private static Optional<ICombatantDetails> GetCombatantDetails(CombatantID combatantID, IList<ICombatantDetails> combatantDetailsSet)
        {
            ICombatantDetails returnedCombatantDetails = null;
            foreach (ICombatantDetails combatantDetails in combatantDetailsSet)
            {
                if (combatantDetails.GetID() == combatantID)
                {
                    returnedCombatantDetails = combatantDetails;
                    break;
                }
            }
            return Optional<ICombatantDetails>.Of(returnedCombatantDetails);
        }

        private static PhalanxID GetPhalanxIDFromCombatant(CombatantID combatantID, IList<IPhalanxDetails> phalanxDetails)
        {
            PhalanxID phalanxID = PhalanxID.None;

            foreach (IPhalanxDetails details in phalanxDetails)
            {
                Optional<ICombatantDetails> combatantDetails = GetCombatantDetails(combatantID, details.GetCombatantDetails());
                if (combatantDetails.IsPresent())
                {
                    phalanxID = details.GetID();
                    break;
                }
            }

            return phalanxID;
        }
    }
}