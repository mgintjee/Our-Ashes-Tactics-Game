using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Randoms.Managers;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Details.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Factions.Details.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Factions.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Factions.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Phalanxes.Details.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Phalanxes.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Phalanxes.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Biomes;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Details.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Details.Managers;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Shapes;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Sizes;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Tiles.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Models.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Models.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Types;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Models.States.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Models.Utils.Mods;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Models.Utils.Randomizations;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Models.Impls
{
    /// <summary>
    /// QSortie Model Impl
    /// </summary>
    public class MvcModelImpl
        : AbstractMvcModel, IMvcModel
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        public MvcModelImpl(IMvcFrameConstruction mvcFrameConstruction)
            : base(mvcFrameConstruction)
        {
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        protected override IMvcModelState ProcessInitialMvcModelRequest()
        {
            return this.mvcModelState;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcRequest"></param>
        /// <returns></returns>
        protected override IMvcModelState ProcessMvcModelRequest(IMvcRequest mvcRequest)
        {
            IQSortieMenuMvcRequest qSortieMenuMvcRequest = (IQSortieMenuMvcRequest)mvcRequest;
            logger.Info("Received {}", qSortieMenuMvcRequest);
            switch (qSortieMenuMvcRequest.GetRequestType())
            {
                case RequestType.SortieRandomize:
                    this.HandleSortieRandomize();
                    break;

                case RequestType.FieldRandomize:
                    this.HandleFieldRandomize();
                    break;

                case RequestType.FactionRandomize:
                    this.HandleFactionRandomize();
                    break;

                case RequestType.FieldIDSelect:
                    this.HandleFieldIDSelect((IEnumSelectRequest<FieldID>)mvcRequest);
                    break;

                case RequestType.FactionIDSelect:
                    this.HandleFactionIDSelect((IEnumSelectRequest<FactionID>)mvcRequest);
                    break;

                case RequestType.PhalanxIDSelect:
                    this.HandlePhalanxIDSelect((IEnumSelectRequest<PhalanxID>)mvcRequest);
                    break;

                case RequestType.UnitIDSelect:
                    this.HandleUnitIDSelect((IEnumSelectRequest<UnitID>)mvcRequest);
                    break;

                case RequestType.FieldBiomeSelect:
                    this.HandleFieldBiomeSelect((IEnumSelectRequest<FieldBiome>)mvcRequest);
                    break;

                case RequestType.FieldSizeSelect:
                    this.HandleFieldSizeSelect((IEnumSelectRequest<FieldSize>)mvcRequest);
                    break;

                case RequestType.FieldShapeSelect:
                    this.HandleFieldShapeSelect((IEnumSelectRequest<FieldShape>)mvcRequest);
                    break;

                case RequestType.FactionPhalanxIDAddMod:
                case RequestType.FactionPhalanxIDMinusMod:
                    CombatantsModUtil.HandlePhalanxIDMod((States.Inters.IMvcModelState)this.mvcModelState, (IPhalanxIDModRequest)mvcRequest);
                    break;

                case RequestType.PhalanxUnitIDAddMod:
                case RequestType.PhalanxUnitIDMinusMod:
                    CombatantsModUtil.HandleUnitIDMod((States.Inters.IMvcModelState)this.mvcModelState, (IUnitIDModRequest)mvcRequest);
                    break;
            }
            ((MvcModelStateImpl)this.mvcModelState)
                .SetPrevMvcRequest(mvcRequest);
            // Todo: This is where I would modify the existing MvcModelState
            return this.mvcModelState;
        }

        protected override IMvcModelState BuildInitialMvcModelState()
        {
            return MvcModelStateRandomizerUtil.Randomize(RandomManager.GetRandom(MvcType.QSortieMenu));
        }

        private ISet<IMvcRequest> BuildInitialMvcModelRequests()
        {
            ISet<IMvcRequest> panelMvcRequests = this.BuildPanelMvcModelRequests();
            panelMvcRequests.Add(new DefaultRequestImpl(RequestType.SortieRandomize));
            return panelMvcRequests;
        }

        private ISet<IMvcRequest> BuildPanelMvcModelRequests()
        {
            return new HashSet<IMvcRequest>
                    {
                        new DefaultRequestImpl(RequestType.DetailsField),
                        new DefaultRequestImpl(RequestType.DetailsPhalanx),
                        new DefaultRequestImpl(RequestType.DetailsUnit),
                        new DefaultRequestImpl(RequestType.DetailsSortie),
                        new DefaultRequestImpl(RequestType.SortieStart)
                    };
        }


        private void HandleFactionIDSelect(IEnumSelectRequest<FactionID> mvcRequest)
        {
            FactionID id = mvcRequest.GetEnum();

            ICombatantsDetails currentCombatantsDetails = this.CastMvcModelState().GetCombatantsDetails();
            IList<IFactionDetails> currentDetails = currentCombatantsDetails.GetFactionDetails();
            IList<IFactionDetails> newDetails = new List<IFactionDetails>();
            int idIndex = this.GetFactionIDIndex(id, currentDetails);

            for (int i = 0; i < currentDetails.Count; ++i)
            {
                int indexToGet = (idIndex + i) % currentDetails.Count;
                newDetails.Add(currentDetails[indexToGet]);
            }

            this.UpdateFactionDetails(CombatantsDetailsImpl.Builder.Get()
                .SetFactionDetails(newDetails)
                .SetPhalanxDetails(currentCombatantsDetails.GetPhalanxDetails())
                .SetUnitDetails(currentCombatantsDetails.GetUnitDetails())
                .Build());
        }

        private int GetFactionIDIndex(FactionID id, IList<IFactionDetails> factionDetails)
        {
            int counter = 0;
            foreach (IFactionDetails details in factionDetails)
            {
                if (details.GetFactionID() == id)
                {
                    return counter;
                }
                counter++;
            }
            return 0;
        }

        private void HandlePhalanxIDSelect(IEnumSelectRequest<PhalanxID> mvcRequest)
        {
            PhalanxID id = mvcRequest.GetEnum();

            ICombatantsDetails currentCombatantsDetails = this.CastMvcModelState().GetCombatantsDetails();
            IList<IPhalanxDetails> currentDetails = currentCombatantsDetails.GetPhalanxDetails();
            IList<IPhalanxDetails> newDetails = new List<IPhalanxDetails>();
            int idIndex = this.GetPhalanxIDIndex(id, currentDetails);

            for (int i = 0; i < currentDetails.Count; ++i)
            {
                int indexToGet = (idIndex + i) % currentDetails.Count;
                newDetails.Add(currentDetails[indexToGet]);
            }

            this.UpdateFactionDetails(CombatantsDetailsImpl.Builder.Get()
                .SetFactionDetails(currentCombatantsDetails.GetFactionDetails())
                .SetPhalanxDetails(newDetails)
                .SetUnitDetails(currentCombatantsDetails.GetUnitDetails())
                .Build());
        }

        private int GetPhalanxIDIndex(PhalanxID id, IList<IPhalanxDetails> phalanxDetails)
        {
            int counter = 0;
            foreach (IPhalanxDetails details in phalanxDetails)
            {
                if (details.GetPhalanxID() == id)
                {
                    return counter;
                }
                counter++;
            }
            return 0;
        }

        private void HandleUnitIDSelect(IEnumSelectRequest<UnitID> mvcRequest)
        {
            UnitID id = mvcRequest.GetEnum();

            ICombatantsDetails currentCombatantsDetails = this.CastMvcModelState().GetCombatantsDetails();
            IList<IUnitDetails> currentDetails = currentCombatantsDetails.GetUnitDetails();
            IList<IUnitDetails> newDetails = new List<IUnitDetails>();
            int idIndex = this.GetUnitIDIndex(id, currentDetails);

            for (int i = 0; i < currentDetails.Count; ++i)
            {
                int indexToGet = (idIndex + i) % currentDetails.Count;
                newDetails.Add(currentDetails[indexToGet]);
            }

            this.UpdateFactionDetails(CombatantsDetailsImpl.Builder.Get()
                .SetFactionDetails(currentCombatantsDetails.GetFactionDetails())
                .SetPhalanxDetails(currentCombatantsDetails.GetPhalanxDetails())
                .SetUnitDetails(newDetails)
                .Build());
        }

        private int GetUnitIDIndex(UnitID id, IList<IUnitDetails> unitDetails)
        {
            int counter = 0;
            foreach (IUnitDetails details in unitDetails)
            {
                if (details.GetUnitID() == id)
                {
                    return counter;
                }
                counter++;
            }
            return 0;
        }

        private void HandleFieldIDSelect(IEnumSelectRequest<FieldID> mvcRequest)
        {
            FieldID id = mvcRequest.GetEnum();
            IFieldDetails fieldDetails = this.GetFieldDetails();
            this.UpdateFieldDetails(id, fieldDetails.GetFieldBiome(), fieldDetails.GetFieldShape(), fieldDetails.GetFieldSize());
        }

        private void HandleFieldBiomeSelect(IEnumSelectRequest<FieldBiome> mvcRequest)
        {
            FieldBiome biome = mvcRequest.GetEnum();
            IFieldDetails fieldDetails = this.GetFieldDetails();
            this.UpdateFieldDetails(fieldDetails.GetFieldID(), biome, fieldDetails.GetFieldShape(), fieldDetails.GetFieldSize());
        }

        private void HandleFieldSizeSelect(IEnumSelectRequest<FieldSize> mvcRequest)
        {
            FieldSize size = mvcRequest.GetEnum();
            IFieldDetails fieldDetails = this.GetFieldDetails();
            this.UpdateFieldDetails(fieldDetails.GetFieldID(), fieldDetails.GetFieldBiome(), fieldDetails.GetFieldShape(), size);
        }

        private void HandleFieldShapeSelect(IEnumSelectRequest<FieldShape> mvcRequest)
        {
            FieldShape shape = mvcRequest.GetEnum();
            IFieldDetails fieldDetails = this.GetFieldDetails();
            this.UpdateFieldDetails(fieldDetails.GetFieldID(), fieldDetails.GetFieldBiome(), shape, fieldDetails.GetFieldSize());
        }

        private void HandlePhalanxIDMod(IPhalanxIDModRequest mvcRequest)
        {
            mvcRequest.GetFactionID();
            mvcRequest.GetPhalanxID();
            mvcRequest.IsAdd();
            ICombatantsDetails currentCombatantsDetails = this.CastMvcModelState().GetCombatantsDetails();
            IList<IFactionDetails> factionDetailsList = currentCombatantsDetails.GetFactionDetails();
            IList<IPhalanxDetails> phalanxDetailsList = currentCombatantsDetails.GetPhalanxDetails();
            IList<IUnitDetails> unitDetailsList = currentCombatantsDetails.GetUnitDetails();
            IFactionDetails factionDetails = factionDetailsList[0];
            IList<PhalanxID> phalanxIDs = factionDetails.GetPhalanxIDs();
            if (mvcRequest.IsAdd())
            {
                phalanxIDs.Add(mvcRequest.GetPhalanxID());
                phalanxDetailsList.Add(PhalanxDetailsImpl.Builder.Get()
                    .SetPhalanxID(mvcRequest.GetPhalanxID())
                    .Build());
            }
            else
            {
                phalanxIDs.Remove(mvcRequest.GetPhalanxID());
            }
            IFactionDetails newFactionDetails = FactionDetailsImpl.Builder.Get()
                .SetFactionID(factionDetails.GetFactionID())
                .SetPhalanxIDs(phalanxIDs)
                .Build();
            factionDetailsList[0] = newFactionDetails;
            this.UpdateFactionDetails(CombatantsDetailsImpl.Builder.Get()
                .SetFactionDetails(factionDetailsList)
                .SetPhalanxDetails(phalanxDetailsList)
                .SetUnitDetails(currentCombatantsDetails.GetUnitDetails())
                .Build());
        }

        private void UpdateFieldDetails(FieldID fieldID, FieldBiome fieldBiome, FieldShape fieldShape, FieldSize fieldSize)
        {
            IFieldDetails fieldDetails = FieldDetailsManager.GetFieldDetails(fieldID).GetValue();
            if (fieldDetails == null)
            {
                ISet<ITileDetails> tileDetails = this.GetFieldDetails().GetTileDetails();
                if (this.ShouldBuildNewTileDetails(fieldID, fieldShape, fieldSize))
                {
                    tileDetails = FieldDetailsRandomizerUtil.GetRandomTileDetails(
                       RandomManager.GetRandom(MvcType.QSortieMenu), fieldShape, fieldSize);
                }
                fieldDetails = FieldDetailsImpl.Builder.Get()
                    .SetFieldBiome(fieldBiome)
                    .SetFieldID(fieldID)
                    .SetFieldShape(fieldShape)
                    .SetFieldSize(fieldSize)
                    .SetTileDetails(tileDetails)
                    .Build();
            }
            this.UpdateFieldDetails(fieldDetails);
        }

        private bool ShouldBuildNewTileDetails(FieldID fieldID, FieldShape fieldShape, FieldSize fieldSize)
        {
            IFieldDetails currentFieldDetails = this.GetFieldDetails();
            return fieldID == FieldID.Random ||
                fieldShape != currentFieldDetails.GetFieldShape() ||
                fieldSize != currentFieldDetails.GetFieldSize();
        }

        private void HandleSortieRandomize()
        {
            this.HandleFieldRandomize();
            this.HandleFactionRandomize();
        }

        private void HandleFieldRandomize()
        {
            IFieldDetails fieldDetails = FieldDetailsRandomizerUtil
                .Randomize(RandomManager.GetRandom(MvcType.QSortieMenu));
            this.UpdateFieldDetails(fieldDetails);
        }

        private void HandleFactionRandomize()
        {
            /*
            IList<IFactionDetails> factionDetails = FactionDetailsRandomiRandom(MvcType.QSortieMenu),
                this.CastMvcModelState().GetzerUtil
                .Randomize(RandomManager.GetFieldDetails());
            this.UpdateFactionDetails(factionDetails);
            */
        }

        private void UpdateFieldDetails(IFieldDetails details)
        {
            ((MvcModelStateImpl)this.mvcModelState)
                .SetFieldDetails(details);
        }

        private void UpdateFactionDetails(ICombatantsDetails details)
        {
            ((MvcModelStateImpl)this.mvcModelState)
                .SetCombatantsDetails(details);
        }

        private States.Inters.IMvcModelState CastMvcModelState()
        {
            return ((States.Inters.IMvcModelState)this.mvcModelState);
        }

        private IFieldDetails GetFieldDetails()
        {
            return this.CastMvcModelState().GetFieldDetails();
        }
    }
}