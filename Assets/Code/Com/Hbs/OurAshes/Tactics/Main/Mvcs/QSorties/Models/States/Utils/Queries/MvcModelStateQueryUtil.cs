using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.CallSigns;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Factions.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Factions.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Phalanxes.CallSigns;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Phalanxes.Details.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Models.States.Utils.Queries
{
    public static class MvcModelStateQueryUtil
    {
        public static Optional<IFactionDetails> GetFactionDetails(Inters.IMvcModelState mvcModelState, FactionID factionID)
        {
            IFactionDetails returnedFactionDetails = null;

            ISet<IFactionDetails> factionDetailsSet = mvcModelState.GetFactionDetails();
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

        public static Optional<IPhalanxDetails> GetPhalanxDetails(Inters.IMvcModelState mvcModelState, PhalanxCallSign phalanxCallSign)
        {
            IPhalanxDetails returnedPhalanxDetails = null;

            ISet<IFactionDetails> factionDetailsSet = mvcModelState.GetFactionDetails();
            foreach (IFactionDetails factionDetails in factionDetailsSet)
            {
                Optional<IPhalanxDetails> possiblePhalanxDetails = GetPhalanxDetails(phalanxCallSign, factionDetails.GetPhalanxDetails());
                if (possiblePhalanxDetails.IsPresent())
                {
                    returnedPhalanxDetails = possiblePhalanxDetails.GetValue();
                    break;
                }
            }

            return Optional<IPhalanxDetails>.Of(returnedPhalanxDetails);
        }

        public static Optional<IPhalanxDetails> GetPhalanxDetails(PhalanxCallSign phalanxCallSign, ISet<IPhalanxDetails> phalanxDetailsSet)
        {
            IPhalanxDetails returnedPhalanxDetails = null;
            foreach (IPhalanxDetails phalanxDetails in phalanxDetailsSet)
            {
                if (phalanxDetails.GetCallSign() == phalanxCallSign)
                {
                    returnedPhalanxDetails = phalanxDetails;
                    break;
                }
            }
            return Optional<IPhalanxDetails>.Of(returnedPhalanxDetails);
        }

        public static Optional<ICombatantDetails> GetCombatantDetails(Inters.IMvcModelState mvcModelState, CombatantCallSign combatantCallSign)
        {
            ICombatantDetails returnedCombatantDetails = null;

            ISet<IFactionDetails> factionDetailsSet = mvcModelState.GetFactionDetails();
            foreach (IFactionDetails factionDetails in factionDetailsSet)
            {
                Optional<ICombatantDetails> possibleCombatantDetails = GetCombatantDetails(combatantCallSign, factionDetails.GetPhalanxDetails());
                if (possibleCombatantDetails.IsPresent())
                {
                    returnedCombatantDetails = possibleCombatantDetails.GetValue();
                    break;
                }
            }

            return Optional<ICombatantDetails>.Of(returnedCombatantDetails);
        }

        public static FactionID GetFactionIDFromCombatant(Inters.IMvcModelState mvcModelState, CombatantCallSign combatantCallSign)
        {
            PhalanxCallSign phalanxCallSign = GetPhalanxCallSignFromCombatant(mvcModelState, combatantCallSign);
            FactionID factionID = GetFactionIDFromPhalanx(mvcModelState, phalanxCallSign);
            return factionID;
        }

        public static FactionID GetFactionIDFromPhalanx(Inters.IMvcModelState mvcModelState, PhalanxCallSign phalanxCallSign)
        {
            FactionID factionID = FactionID.None;

            foreach (IFactionDetails factionDetails in mvcModelState.GetFactionDetails())
            {
                Optional<IPhalanxDetails> phalanxDetails = GetPhalanxDetails(phalanxCallSign, factionDetails.GetPhalanxDetails());
                if (phalanxDetails.IsPresent())
                {
                    factionID = factionDetails.GetFactionID();
                    break;
                }
            }

            return factionID;
        }

        public static PhalanxCallSign GetPhalanxCallSignFromCombatant(Inters.IMvcModelState mvcModelState, CombatantCallSign combatantCallSign)
        {
            PhalanxCallSign phalanxCallSign = PhalanxCallSign.None;

            foreach (IFactionDetails factionDetails in mvcModelState.GetFactionDetails())
            {
                phalanxCallSign = GetPhalanxCallSignFromCombatant(combatantCallSign, factionDetails.GetPhalanxDetails());
                if (phalanxCallSign != PhalanxCallSign.None)
                {
                    break;
                }
            }

            return phalanxCallSign;
        }

        private static Optional<ICombatantDetails> GetCombatantDetails(CombatantCallSign combatantCallSign, ISet<IPhalanxDetails> phalanxDetailsSet)
        {
            ICombatantDetails returnedCombatantDetails = null;
            foreach (IPhalanxDetails phalanxDetails in phalanxDetailsSet)
            {
                Optional<ICombatantDetails> possibleCombatantDetails = GetCombatantDetails(combatantCallSign, phalanxDetails.GetCombatantDetails());
                if (possibleCombatantDetails.IsPresent())
                {
                    returnedCombatantDetails = possibleCombatantDetails.GetValue();
                    break;
                }
            }
            return Optional<ICombatantDetails>.Of(returnedCombatantDetails);
        }

        private static Optional<ICombatantDetails> GetCombatantDetails(CombatantCallSign combatantCallSign, ISet<ICombatantDetails> combatantDetailsSet)
        {
            ICombatantDetails returnedCombatantDetails = null;
            foreach (ICombatantDetails combatantDetails in combatantDetailsSet)
            {
                if (combatantDetails.GetCallSign() == combatantCallSign)
                {
                    returnedCombatantDetails = combatantDetails;
                    break;
                }
            }
            return Optional<ICombatantDetails>.Of(returnedCombatantDetails);
        }

        private static PhalanxCallSign GetPhalanxCallSignFromCombatant(CombatantCallSign combatantCallSign, ISet<IPhalanxDetails> phalanxDetailsSet)
        {
            PhalanxCallSign phalanxCallSign = PhalanxCallSign.None;

            foreach (IPhalanxDetails phalanxDetails in phalanxDetailsSet)
            {
                Optional<ICombatantDetails> combatantDetails = GetCombatantDetails(combatantCallSign, phalanxDetails.GetCombatantDetails());
                if (combatantDetails.IsPresent())
                {
                    phalanxCallSign = phalanxDetails.GetCallSign();
                    break;
                }
            }

            return phalanxCallSign;
        }
    }
}