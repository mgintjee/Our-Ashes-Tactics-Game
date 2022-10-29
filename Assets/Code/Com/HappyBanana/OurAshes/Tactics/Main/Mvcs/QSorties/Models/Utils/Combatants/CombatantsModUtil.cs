using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Apis.Loggers.Classes.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Managers.Loggers;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Managers.Randoms;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Utils.Enums;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Details.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Factions.Details.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Factions.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Armors.Gears.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Cabins.Gears.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Details.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Engines.Gears.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Weapons.Gears.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Phalanxes.Details.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Phalanxes.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Phalanxes.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Details.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Models;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Icons.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Icons.Details.Managers;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Icons.IDs;
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

        public static void HandlePhalanxIDMod(IMvcModelState modelState, IFactionPhalanxIDModRequest mvcRequest)
        {
            ICombatantsDetails currentCombatantsDetails = modelState.GetCombatantsDetails();
            IPhalanxDetails phalanxDetails = currentCombatantsDetails.GetPhalanxDetails(mvcRequest.GetPhalanxID()).GetValue();
            IList<IUnitDetails> unitDetailsList = UpdateUnitDetailsList(mvcRequest, phalanxDetails, currentCombatantsDetails.GetUnitDetails());
            IList<IPhalanxDetails> phalanxDetailsList = UpdatePhalanxDetailsList(mvcRequest, currentCombatantsDetails.GetPhalanxDetails());
            IList<IFactionDetails> factionDetailsList = UpdateFactionDetailsList(mvcRequest, currentCombatantsDetails.GetFactionDetails());
            UpdateModelState(modelState, factionDetailsList, phalanxDetailsList, unitDetailsList);
        }

        public static void HandleUnitIDMod(IMvcModelState modelState, IPhalanxUnitIDModRequest mvcRequest)
        {
            ICombatantsDetails currentCombatantsDetails = modelState.GetCombatantsDetails();
            IPhalanxDetails phalanxDetails = currentCombatantsDetails.GetPhalanxDetails(mvcRequest.GetPhalanxID()).GetValue();
            IList<IUnitDetails> unitDetailsList = UpdateUnitDetailsList(mvcRequest, currentCombatantsDetails.GetUnitDetails());
            IList<IPhalanxDetails> phalanxDetailsList = UpdatePhalanxDetailsList(mvcRequest, currentCombatantsDetails.GetPhalanxDetails(), phalanxDetails);
            UpdateModelState(modelState, modelState.GetCombatantsDetails().GetFactionDetails(),
                phalanxDetailsList, unitDetailsList);
        }

        public static void HandleUnitModelIDSelect(IMvcModelState mvcModelState, IEnumSelectRequest<ModelID> mvcRequest)
        {
            UnitID unitID = mvcModelState.GetSelectedUnitID();
            ModelID modelID = mvcRequest.GetEnum();
            ICombatantsDetails combatantsDetails = mvcModelState.GetCombatantsDetails();
            IUnitDetails unitDetails = combatantsDetails.GetUnitDetails(unitID).GetValue();
            IIconDetails iconDetails = IconIDDetailsManager.GetDetails(modelID.GetIconID()).GetValue();
            IUnitDetails newUnitDetails = UnitDetailsImpl.Builder.Get()
                .SetLoadoutDetails(LoadoutRandomizerUtil.Randomize(RandomManager.GetRandom(MvcType.QSortieMenu), modelID))
                .SetModelID(modelID)
                .SetUnitID(unitDetails.GetUnitID())
                .SetIconDetails(iconDetails)
                .Build();
            UpdateUnitDetails(unitDetails, newUnitDetails, mvcModelState);
        }

        public static void HandleUnitArmorGearIDSelect(IMvcModelState mvcModelState, IEnumSelectRequest<ArmorGearID> mvcRequest)
        {
            UnitID unitID = mvcModelState.GetSelectedUnitID();
            ArmorGearID gearID = mvcRequest.GetEnum();
            ICombatantsDetails combatantsDetails = mvcModelState.GetCombatantsDetails();
            IUnitDetails unitDetails = combatantsDetails.GetUnitDetails(unitID).GetValue();
            IUnitDetails newUnitDetails = UnitDetailsImpl.Builder.Get()
                .SetLoadoutDetails(UpdateLoadoutDetails(unitDetails.GetLoadoutDetails(), gearID))
                .SetModelID(unitDetails.GetModelID())
                .SetUnitID(unitDetails.GetUnitID())
                .Build();
            UpdateUnitDetails(unitDetails, newUnitDetails, mvcModelState);
        }

        public static void HandleUnitCabinGearIDSelect(IMvcModelState mvcModelState, IEnumSelectRequest<CabinGearID> mvcRequest)
        {
            UnitID unitID = mvcModelState.GetSelectedUnitID();
            CabinGearID gearID = mvcRequest.GetEnum();
            ICombatantsDetails combatantsDetails = mvcModelState.GetCombatantsDetails();
            IUnitDetails unitDetails = combatantsDetails.GetUnitDetails(unitID).GetValue();
            IUnitDetails newUnitDetails = UnitDetailsImpl.Builder.Get()
                .SetLoadoutDetails(UpdateLoadoutDetails(unitDetails.GetLoadoutDetails(), gearID))
                .SetModelID(unitDetails.GetModelID())
                .SetUnitID(unitDetails.GetUnitID())
                .Build();
            UpdateUnitDetails(unitDetails, newUnitDetails, mvcModelState);
        }

        public static void HandleUnitEngineGearIDSelect(IMvcModelState mvcModelState, IEnumSelectRequest<EngineGearID> mvcRequest)
        {
            UnitID unitID = mvcModelState.GetSelectedUnitID();
            EngineGearID gearID = mvcRequest.GetEnum();
            ICombatantsDetails combatantsDetails = mvcModelState.GetCombatantsDetails();
            IUnitDetails unitDetails = combatantsDetails.GetUnitDetails(unitID).GetValue();
            IUnitDetails newUnitDetails = UnitDetailsImpl.Builder.Get()
                .SetLoadoutDetails(UpdateLoadoutDetails(unitDetails.GetLoadoutDetails(), gearID))
                .SetModelID(unitDetails.GetModelID())
                .SetUnitID(unitDetails.GetUnitID())
                .Build();
            UpdateUnitDetails(unitDetails, newUnitDetails, mvcModelState);
        }

        public static void HandleUnitWeaponGearIDMod(IMvcModelState mvcModelState, IUnitWeaponGearIDModRequest mvcRequest)
        {
            UnitID unitID = mvcModelState.GetSelectedUnitID();
            ICombatantsDetails combatantsDetails = mvcModelState.GetCombatantsDetails();
            IUnitDetails unitDetails = combatantsDetails.GetUnitDetails(unitID).GetValue();
            IUnitDetails newUnitDetails = UnitDetailsImpl.Builder.Get()
                .SetLoadoutDetails(UpdateLoadoutDetails(unitDetails.GetLoadoutDetails(), mvcRequest.GetWeaponGearID(), mvcRequest.GetWeaponIndex()))
                .SetModelID(unitDetails.GetModelID())
                .SetUnitID(unitDetails.GetUnitID())
                .Build();
            UpdateUnitDetails(unitDetails, newUnitDetails, mvcModelState);
        }

        private static ILoadoutDetails UpdateLoadoutDetails(ILoadoutDetails loadoutDetails, WeaponGearID gearID, int index)
        {
            IList<WeaponGearID> weaponGearIDs = loadoutDetails.GetWeaponGearIDs();
            weaponGearIDs[index] = gearID;
            return LoadoutDetailsImpl.Builder.Get()
                .SetArmorGearID(loadoutDetails.GetArmorGearID())
                .SetCabinGearID(loadoutDetails.GetCabinGearID())
                .SetEngineGearID(loadoutDetails.GetEngineGearID())
                .SetWeaponGearID(weaponGearIDs)
                .Build();
        }

        private static ILoadoutDetails UpdateLoadoutDetails(ILoadoutDetails loadoutDetails, ArmorGearID gearID)
        {
            return LoadoutDetailsImpl.Builder.Get()
                .SetArmorGearID(gearID)
                .SetCabinGearID(loadoutDetails.GetCabinGearID())
                .SetEngineGearID(loadoutDetails.GetEngineGearID())
                .SetWeaponGearID(loadoutDetails.GetWeaponGearIDs())
                .Build();
        }

        private static ILoadoutDetails UpdateLoadoutDetails(ILoadoutDetails loadoutDetails, CabinGearID gearID)
        {
            return LoadoutDetailsImpl.Builder.Get()
                .SetArmorGearID(loadoutDetails.GetArmorGearID())
                .SetCabinGearID(gearID)
                .SetEngineGearID(loadoutDetails.GetEngineGearID())
                .SetWeaponGearID(loadoutDetails.GetWeaponGearIDs())
                .Build();
        }

        private static ILoadoutDetails UpdateLoadoutDetails(ILoadoutDetails loadoutDetails, EngineGearID gearID)
        {
            return LoadoutDetailsImpl.Builder.Get()
                .SetArmorGearID(loadoutDetails.GetArmorGearID())
                .SetCabinGearID(loadoutDetails.GetCabinGearID())
                .SetEngineGearID(gearID)
                .SetWeaponGearID(loadoutDetails.GetWeaponGearIDs())
                .Build();
        }

        private static void UpdateUnitDetails(IUnitDetails oldUnitDetails, IUnitDetails newUnitDetails, IMvcModelState mvcModelState)
        {
            ICombatantsDetails combatantsDetails = mvcModelState.GetCombatantsDetails();
            IList<IUnitDetails> newUnitDetailsList = combatantsDetails.GetUnitDetails();
            int oldIndex = newUnitDetailsList.IndexOf(oldUnitDetails);
            newUnitDetailsList[oldIndex] = newUnitDetails;
            UpdateModelState(mvcModelState, combatantsDetails.GetFactionDetails(), combatantsDetails.GetPhalanxDetails(), newUnitDetailsList);
        }

        private static void UpdateModelState(IMvcModelState mvcModelState, IList<IFactionDetails> factionDetailsList,
            IList<IPhalanxDetails> phalanxDetailsList, IList<IUnitDetails> unitDetailsList)
        {
            ICombatantsDetails newCombatantsDetails = CombatantsDetailsImpl.Builder.Get()
                .SetFactionDetails(factionDetailsList)
                .SetPhalanxDetails(phalanxDetailsList)
                .SetUnitDetails(unitDetailsList)
                .Build();
            logger.Debug("Old: {}" +
                "\n\nNew: {}", mvcModelState.GetCombatantsDetails(), newCombatantsDetails);
            ((MvcModelStateImpl)mvcModelState)
                .SetCombatantsDetails(newCombatantsDetails);
        }

        private static IList<IFactionDetails> UpdateFactionDetailsList(IFactionPhalanxIDModRequest mvcRequest, IList<IFactionDetails> factionDetailsList)
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

        private static IList<IPhalanxDetails> UpdatePhalanxDetailsList(IFactionPhalanxIDModRequest mvcRequest, IList<IPhalanxDetails> phalanxDetailsList)
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

        private static IList<IUnitDetails> UpdateUnitDetailsList(IFactionPhalanxIDModRequest mvcRequest, IPhalanxDetails phalanxDetails, IList<IUnitDetails> unitDetailsList)
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

        private static IList<IUnitDetails> UpdateUnitDetailsList(IPhalanxUnitIDModRequest mvcRequest, IList<IUnitDetails> unitDetailsList)
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
                IconID iconID = modelID.GetIconID();
                newDetailsList.Add(UnitDetailsImpl.Builder.Get()
                    .SetUnitID(mvcRequest.GetUnitID())
                    .SetModelID(modelID)
                    .SetLoadoutDetails(LoadoutRandomizerUtil.Randomize(RandomManager.GetRandom(MvcType.QSortieMenu), modelID))
                    .SetIconDetails(IconIDDetailsManager.GetDetails(iconID).GetValue())
                    .Build()) ;
            }
            return newDetailsList;
        }

        private static IList<IPhalanxDetails> UpdatePhalanxDetailsList(IPhalanxUnitIDModRequest mvcRequest, IList<IPhalanxDetails> phalanxDetailsList, IPhalanxDetails phalanxDetails)
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