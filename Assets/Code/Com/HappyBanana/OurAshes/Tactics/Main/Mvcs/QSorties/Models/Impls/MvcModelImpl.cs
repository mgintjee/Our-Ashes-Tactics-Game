﻿using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Randoms.Managers;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Units.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Units.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Factions.Details.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Factions.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Factions.IDs;
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
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Phalanxes.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Phalanxes.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Types;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Models.States.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Models.States.Utils.Randomizations;
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

                case RequestType.FieldIDMod:
                    this.HandleFieldIDMod((IFieldIDModRequest)mvcRequest);
                    break;

                case RequestType.FactionIDMod:
                    this.HandleFactionIDMod((IFactionIDModRequest)mvcRequest);
                    break;

                case RequestType.FieldBiomeMod:
                    this.HandleFieldBiomeMod((IFieldBiomeModRequest)mvcRequest);
                    break;

                case RequestType.FieldSizeMod:
                    this.HandleFieldSizeMod((IFieldSizeModRequest)mvcRequest);
                    break;

                case RequestType.FieldShapeMod:
                    this.HandleFieldShapeMod((IFieldShapeModRequest)mvcRequest);
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
            panelMvcRequests.Add(new DefaultRequestImpl().SetRequestType(RequestType.SortieRandomize));
            return panelMvcRequests;
        }

        private ISet<IMvcRequest> BuildPanelMvcModelRequests()
        {
            return new HashSet<IMvcRequest>
                    {
                        new DefaultRequestImpl().SetRequestType(RequestType.FieldDetails),
                        new DefaultRequestImpl().SetRequestType(RequestType.PhalanxDetails),
                        new DefaultRequestImpl().SetRequestType(RequestType.UnitDetails),
                        new DefaultRequestImpl().SetRequestType(RequestType.SortieDetails),
                        new DefaultRequestImpl().SetRequestType(RequestType.SortieStart),
                    };
        }


        private void HandleFactionIDMod(IFactionIDModRequest mvcRequest)
        {
            FactionID id = mvcRequest.GetFactionID();

            IList<IFactionDetails> currentFactionDetails = this.CastMvcModelState().GetFactionDetails();
            IList<IFactionDetails> factionDetails = new List<IFactionDetails>();
            int idIndex = this.GetFactionIDIndex(id, currentFactionDetails);

            for (int i = 0; i < currentFactionDetails.Count; ++i)
            {
                int indexToGet = (idIndex + i) % currentFactionDetails.Count;
                factionDetails.Add(currentFactionDetails[indexToGet]);
            }

            logger.Debug("OG:{}" +
                "\nNew:{}", currentFactionDetails, factionDetails);

            this.UpdateFactionDetails(factionDetails);
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

        private void HandleFieldIDMod(IFieldIDModRequest mvcRequest)
        {
            FieldID id = mvcRequest.GetFieldID();
            IFieldDetails fieldDetails = this.GetFieldDetails();
            this.UpdateFieldDetails(id, fieldDetails.GetFieldBiome(), fieldDetails.GetFieldShape(), fieldDetails.GetFieldSize());
        }

        private void HandleFieldBiomeMod(IFieldBiomeModRequest mvcRequest)
        {
            FieldBiome biome = mvcRequest.GetFieldBiome();
            IFieldDetails fieldDetails = this.GetFieldDetails();
            this.UpdateFieldDetails(fieldDetails.GetFieldID(), biome, fieldDetails.GetFieldShape(), fieldDetails.GetFieldSize());
        }

        private void HandleFieldSizeMod(IFieldSizeModRequest mvcRequest)
        {
            FieldSize size = mvcRequest.GetFieldSize();
            IFieldDetails fieldDetails = this.GetFieldDetails();
            this.UpdateFieldDetails(fieldDetails.GetFieldID(), fieldDetails.GetFieldBiome(), fieldDetails.GetFieldShape(), size);
        }

        private void HandleFieldShapeMod(IFieldShapeModRequest mvcRequest)
        {
            FieldShape shape = mvcRequest.GetFieldShape();
            IFieldDetails fieldDetails = this.GetFieldDetails();
            this.UpdateFieldDetails(fieldDetails.GetFieldID(), fieldDetails.GetFieldBiome(), shape, fieldDetails.GetFieldSize());
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
            IList<IFactionDetails> factionDetails = FactionDetailsRandomizerUtil
                .Randomize(RandomManager.GetRandom(MvcType.QSortieMenu),
                this.CastMvcModelState().GetFieldDetails());
            this.UpdateFactionDetails(factionDetails);
        }

        private void UpdateFieldDetails(IFieldDetails fieldDetails)
        {
            ((MvcModelStateImpl)this.mvcModelState)
                .SetFieldDetails(fieldDetails);
        }

        private void UpdateFactionDetails(IList<IFactionDetails> factionDetails)
        {
            ((MvcModelStateImpl)this.mvcModelState)
                .SetFactionDetails(factionDetails);
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