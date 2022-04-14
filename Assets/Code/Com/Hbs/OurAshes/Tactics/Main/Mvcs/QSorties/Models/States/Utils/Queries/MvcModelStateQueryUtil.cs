using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Utils.Enums;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.CallSigns;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Details.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Factions.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Factions.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Constants.Combatants;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Constants.Phalanxes;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Sizes;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Phalanxes.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Models.States.Impls;
using System;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Models.States.Utils.Finders
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

        public static Optional<IPhalanxDetails> GetPhalanxDetails(Inters.IMvcModelState mvcModelState, CallSign phalanxCallSign)
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

        public static Optional<IPhalanxDetails> GetPhalanxDetails(CallSign phalanxCallSign, ISet<IPhalanxDetails> phalanxDetailsSet)
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

        public static Optional<ICombatantDetails> GetCombatantDetails(Inters.IMvcModelState mvcModelState, CallSign combatantCallSign)
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

        private static Optional<ICombatantDetails> GetCombatantDetails(CallSign combatantCallSign, ISet<IPhalanxDetails> phalanxDetailsSet)
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

        private static Optional<ICombatantDetails> GetCombatantDetails(CallSign combatantCallSign, ISet<ICombatantDetails> combatantDetailsSet)
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

        public static FactionID GetFactionIDFromCombatant(Inters.IMvcModelState mvcModelState, CallSign combatantCallSign)
        {
            CallSign phalanxCallSign = GetPhalanxCallSignFromCombatant(mvcModelState, combatantCallSign);
            FactionID factionID = GetFactionIDFromPhalanx(mvcModelState, phalanxCallSign);
            return factionID;
        }

        public static FactionID GetFactionIDFromPhalanx(Inters.IMvcModelState mvcModelState, CallSign phalanxCallSign)
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

        public static CallSign GetPhalanxCallSignFromCombatant(Inters.IMvcModelState mvcModelState, CallSign combatantCallSign)
        {
            CallSign phalanxCallSign = CallSign.None;

            foreach(IFactionDetails factionDetails in mvcModelState.GetFactionDetails())
            {
                phalanxCallSign = GetPhalanxCallSignFromCombatant(combatantCallSign, factionDetails.GetPhalanxDetails());
                if(phalanxCallSign != CallSign.None)
                {
                    break;
                }
            }

            return phalanxCallSign;
        }


        private static CallSign GetPhalanxCallSignFromCombatant(CallSign combatantCallSign, ISet<IPhalanxDetails> phalanxDetailsSet)
        {
            CallSign phalanxCallSign = CallSign.None;

            foreach(IPhalanxDetails phalanxDetails in phalanxDetailsSet)
            {
                Optional<ICombatantDetails> combatantDetails = GetCombatantDetails(combatantCallSign, phalanxDetails.GetCombatantDetails());
                if(combatantDetails.IsPresent())
                {
                    phalanxCallSign = phalanxDetails.GetCallSign();
                    break;
                }
            }

            return phalanxCallSign;
        }
    }
}