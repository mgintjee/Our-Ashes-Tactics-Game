using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Loggers.Classes.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Randoms.Managers;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Utils.Enums;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Details.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Factions.Details.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Factions.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Phalanxes.Details.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Phalanxes.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Phalanxes.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Details.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Models;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Models.States.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Models.States.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Models.Utils.Randomizations;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Models.Utils.Mods
{
    public class CombatantsModUtil
    {
        private static readonly IClassLogger logger = LoggerManager.GetLogger(MvcType.Common)
                .GetClassLogger(new StackFrame().GetMethod().DeclaringType);

        public static void HandlePhalanxIDMod(IMvcModelState modelState, IPhalanxIDModRequest mvcRequest)
        {
            ICombatantsDetails currentCombatantsDetails = modelState.GetCombatantsDetails();
            IPhalanxDetails phalanxDetails = currentCombatantsDetails.GetDetails(mvcRequest.GetPhalanxID()).GetValue();
            IList<IUnitDetails> unitDetailsList = UpdateUnitDetailsList(mvcRequest, phalanxDetails, currentCombatantsDetails.GetUnitDetails());
            logger.Debug("Old: {}" +
                "\n\nNew: {}", currentCombatantsDetails.GetUnitDetails(), unitDetailsList);
            IList<IPhalanxDetails> phalanxDetailsList = UpdatePhalanxDetailsList(mvcRequest, currentCombatantsDetails.GetPhalanxDetails());
            logger.Debug("Old: {}" +
                "\n\nNew: {}", currentCombatantsDetails.GetPhalanxDetails(), phalanxDetailsList);
            IList<IFactionDetails> factionDetailsList = UpdateFactionDetailsList(mvcRequest, currentCombatantsDetails.GetFactionDetails());
            logger.Debug("Old: {}" +
                "\n\nNew: {}", currentCombatantsDetails.GetFactionDetails(), factionDetailsList);
            UpdateModelState(modelState, factionDetailsList, phalanxDetailsList, unitDetailsList);
        }

        public static void HandleUnitIDMod(IMvcModelState modelState, IUnitIDModRequest mvcRequest)
        {
            ICombatantsDetails currentCombatantsDetails = modelState.GetCombatantsDetails();
            IPhalanxDetails phalanxDetails = currentCombatantsDetails.GetDetails(mvcRequest.GetPhalanxID()).GetValue();
            IList<IUnitDetails> unitDetailsList = UpdateUnitDetailsList(mvcRequest, currentCombatantsDetails.GetUnitDetails());
            logger.Debug("Old: {}" +
                "\n\nNew: {}", currentCombatantsDetails.GetUnitDetails(), unitDetailsList);
            IList<IPhalanxDetails> phalanxDetailsList = UpdatePhalanxDetailsList(mvcRequest, currentCombatantsDetails.GetPhalanxDetails(), phalanxDetails);
            logger.Debug("Old: {}" +
                "\n\nNew: {}", currentCombatantsDetails.GetPhalanxDetails(), phalanxDetailsList);
            UpdateModelState(modelState, modelState.GetCombatantsDetails().GetFactionDetails(),
                phalanxDetailsList, unitDetailsList);
        }

        private static void UpdateModelState(IMvcModelState mvcModelState, IList<IFactionDetails> factionDetailsList,
            IList<IPhalanxDetails> phalanxDetailsList, IList<IUnitDetails> unitDetailsList)
        {
            ICombatantsDetails newCombatantsDetails = CombatantsDetailsImpl.Builder.Get()
                .SetFactionDetails(factionDetailsList)
                .SetPhalanxDetails(phalanxDetailsList)
                .SetUnitDetails(unitDetailsList)
                .Build();
            ((MvcModelStateImpl)mvcModelState)
                .SetCombatantsDetails(newCombatantsDetails);
        }

        private static IList<IFactionDetails> UpdateFactionDetailsList(IPhalanxIDModRequest mvcRequest, IList<IFactionDetails> factionDetailsList)
        {
            IList<IFactionDetails> newFactionDetailsList = new List<IFactionDetails>();
            IFactionDetails newFactionDetails = null;
            foreach (IFactionDetails details in factionDetailsList)
            {
                if (details.GetFactionID() == mvcRequest.GetFactionID())
                {
                    newFactionDetails = details;
                }
            }
            if (newFactionDetails != null)
            {
                IList<PhalanxID> phalanxIDs = newFactionDetails.GetPhalanxIDs();
                factionDetailsList.Remove(newFactionDetails);
                if (mvcRequest.IsAdd())
                {
                    phalanxIDs.Add(mvcRequest.GetPhalanxID());
                }
                else
                {
                    phalanxIDs.Remove(mvcRequest.GetPhalanxID());
                }

                newFactionDetails = FactionDetailsImpl.Builder.Get()
                    .SetFactionID(newFactionDetails.GetFactionID())
                    .SetPhalanxIDs(phalanxIDs)
                    .Build();
                newFactionDetailsList.Add(newFactionDetails);
                foreach (IFactionDetails details in factionDetailsList)
                {
                    newFactionDetailsList.Add(details);
                }
            }
            return newFactionDetailsList;
        }

        private static IList<IPhalanxDetails> UpdatePhalanxDetailsList(IPhalanxIDModRequest mvcRequest, IList<IPhalanxDetails> phalanxDetailsList)
        {
            IList<IPhalanxDetails> newPhalanxDetailsList = new List<IPhalanxDetails>(phalanxDetailsList);
            if (mvcRequest.IsAdd())
            {
                newPhalanxDetailsList.Add(PhalanxDetailsImpl.Builder.Get()
                    .SetPhalanxID(mvcRequest.GetPhalanxID())
                    .Build());
            }
            else
            {
                foreach (IPhalanxDetails details in phalanxDetailsList)
                {
                    if (details.GetPhalanxID() == mvcRequest.GetPhalanxID())
                    {
                        newPhalanxDetailsList.Remove(details);
                    }
                }
            }
            return newPhalanxDetailsList;
        }

        private static IList<IUnitDetails> UpdateUnitDetailsList(IPhalanxIDModRequest mvcRequest, IPhalanxDetails phalanxDetails, IList<IUnitDetails> unitDetailsList)
        {
            IList<IUnitDetails> newDetailsList = new List<IUnitDetails>(unitDetailsList);
            if (!mvcRequest.IsAdd())
            {
                foreach (IUnitDetails unitDetails in unitDetailsList)
                {
                    if (phalanxDetails.GetUnitIDs().Contains(unitDetails.GetUnitID()))
                    {
                        newDetailsList.Remove(unitDetails);
                    }
                }
            }
            return newDetailsList;
        }

        private static IList<IUnitDetails> UpdateUnitDetailsList(IUnitIDModRequest mvcRequest, IList<IUnitDetails> unitDetailsList)
        {
            IList<IUnitDetails> newDetailsList = new List<IUnitDetails>(unitDetailsList);
            if (!mvcRequest.IsAdd())
            {
                foreach (IUnitDetails unitDetails in unitDetailsList)
                {
                    if (unitDetails.GetUnitID() == mvcRequest.GetUnitID())
                    {
                        newDetailsList.Remove(unitDetails);
                    }
                }
            }
            else
            {
                ModelID modelID = EnumUtils.GenerateRandomEnum<ModelID>(RandomManager.GetRandom(MvcType.QSortieMenu));
                newDetailsList.Add(UnitDetailsImpl.Builder.Get()
                    .SetUnitID(mvcRequest.GetUnitID())
                    .SetModelID(modelID)
                    .SetLoadoutDetails(LoadoutDetailsRandomizerUtil.Randomize(RandomManager.GetRandom(MvcType.QSortieMenu), modelID))
                    .Build());
            }
            return newDetailsList;
        }

        private static IList<IPhalanxDetails> UpdatePhalanxDetailsList(IUnitIDModRequest mvcRequest, IList<IPhalanxDetails> phalanxDetailsList, IPhalanxDetails phalanxDetails)
        {
            IList<IPhalanxDetails> newPhalanxDetailsList = new List<IPhalanxDetails>();
            IPhalanxDetails newPhalanxDetails;
            IList<UnitID> unitIDs = new List<UnitID>(phalanxDetails.GetUnitIDs());
            if (mvcRequest.IsAdd())
            {
                unitIDs.Add(mvcRequest.GetUnitID());
            }
            else
            {
                unitIDs.Remove(mvcRequest.GetUnitID());
            }
            newPhalanxDetails = PhalanxDetailsImpl.Builder.Get()
                .SetPhalanxID(phalanxDetails.GetPhalanxID())
                .SetUnitIDs(unitIDs)
                .Build();
            newPhalanxDetailsList.Add(newPhalanxDetails);
            foreach (IPhalanxDetails details in phalanxDetailsList)
            {
                newPhalanxDetailsList.Add(details);
            }
            newPhalanxDetailsList.Remove(phalanxDetails);
            return newPhalanxDetailsList;
        }
    }
}